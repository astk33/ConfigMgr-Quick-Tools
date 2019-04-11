﻿using Microsoft.ConfigurationManagement.AdminConsole;
using Microsoft.ConfigurationManagement.ManagementProvider;
using Microsoft.ConfigurationManagement.AdminConsole.Common;
using Microsoft.ConfigurationManagement.AdminConsole.DialogFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Management;
using System.Globalization;

namespace ConfigMgr.QuickTools.CollectionManagment
{
    public partial class IncrementalCollectionsPage : SmsPageControl
    {
        private SmsBackgroundWorker backgroundWorker;

        public IncrementalCollectionsPage(SmsPageData pageData)
            : base(pageData)
        {
            FormTitle = "Incremental Collections";
            Title = "Select Collections";
            Headline = "Disable incremental updates for selected collections";

            InitializeComponent();
        }

        public override void InitializePageControl()
        {
            base.InitializePageControl();

            dataGridViewCollections.Rows.Clear();
            UtilitiesClass.UpdateDataGridViewColumnsSize(dataGridViewCollections, columnCollection);

            ControlsInspector.AddControl(dataGridViewCollections, new ControlDataStateEvaluator(ValidateSelectedCollections), "Select collections to disable");

            string query = string.Format("SELECT * FROM SMS_Collection WHERE RefreshType IN (4,6) AND CollectionType = 2 AND CollectionID NOT LIKE 'SMS%'");

            backgroundWorker = new SmsBackgroundWorker();
            backgroundWorker.QueryProcessorCompleted += new EventHandler<RunWorkerCompletedEventArgs>(BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.QueryProcessorObjectsReady += new EventHandler<QueryProcessorObjectsEventArgs>(BackgroundWorker_QueryProcessorObjectsReady);
            ConnectionManagerBase.SmsTraceSource.TraceEvent(TraceEventType.Information, 1, "InitializePageControl");
            UseWaitCursor = true;
            QueryProcessor.ProcessQuery(backgroundWorker, query);
        }

        public override bool OnDeactivate()
        {
            dataGridViewCollections.EndEdit();
            return base.OnDeactivate();
        }

        private void BackgroundWorker_QueryProcessorObjectsReady(object sender, QueryProcessorObjectsEventArgs e)
        {
            if (e.ResultObjects == null)
                return;
            foreach (IResultObject resultObject in e.ResultObjects)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dataGridViewCollections);

                dataGridViewRow.Cells[0].Value = false;
                dataGridViewRow.Cells[1].Value = ResourceDisplayClass.GetAliasDisplayText(resultObject, "Name");
                dataGridViewRow.Cells[2].Value = ResourceDisplayClass.GetAliasDisplayText(resultObject, "CollectionID");

                dataGridViewRow.Tag = resultObject;
                dataGridViewCollections.Rows.Add(dataGridViewRow);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    using (SccmExceptionDialog sccmExceptionDialog = new SccmExceptionDialog(e.Error))
                    {
                        sccmExceptionDialog.ShowDialog();
                    }
                }
                else if (e.Cancelled)
                    ConnectionManagerBase.SmsTraceSource.TraceEvent(TraceEventType.Information, 1, "User canceled");
                else
                    Initialized = true;
            }
            finally
            {
                if (sender as SmsBackgroundWorker == backgroundWorker)
                {
                    backgroundWorker.Dispose();
                    backgroundWorker = null;
                    dataGridViewCollections.Sort(columnCollection, ListSortDirection.Ascending);
                    UseWaitCursor = false;
                }
            }
        }

        public override void PostApply(BackgroundWorker worker, DoWorkEventArgs e)
        {
            try
            {
                int num = 0;
                Dictionary<string, IResultObject> error = new Dictionary<string, IResultObject>();
                List<string> success = new List<string>();
                List<IResultObject> collections = (List<IResultObject>)UserData["CollectionItems"];
                foreach (IResultObject collection in collections)
                {
                    worker.ReportProgress(num * 100 / collections.Count, string.Format("Disabling incremental updates for collection: {0}", ResourceDisplayClass.GetAliasDisplayText(collection, "Name")));

                    collection["RefreshType"].IntegerValue = collection["RefreshType"].IntegerValue == 4 ? 1 : 2;
                    bool er = false;

                    try
                    {
                        collection.Put();
                        collection.Get();
                    }
                    catch (SmsQueryException ex)
                    {
                        ManagementException managementException = ex.InnerException as ManagementException;
                        error.Add("Could not disabled incremental updates: " + managementException.ErrorInformation["Description"].ToString(), collection);
                        er = true;
                    }

                    if (!er)
                    {
                        success.Add(ResourceDisplayClass.GetAliasDisplayText(collection, "Name"));
                    }

                    ++num;
                }

                PrepareCompletion(success, error);
                AddRefreshResultObject(null, PropertyDataUpdateAction.RefreshAll);
                base.PostApply(worker, e);
            }
            catch (Exception ex)
            {
                AddRefreshResultObject(null, PropertyDataUpdateAction.RefreshAll);
                PrepareError(ex.Message);
                throw;
            }
            finally
            {

            }
        }

        public override void OnAddSummary(SummaryRequestHandler handler)
        {
            base.OnAddSummary(handler);
            PrepareSummary();
        }

        private void RemoveAllSummary()
        {
            foreach (string id in Enumerable.ToList(Enumerable.Select(GetSummaryItems(), i => i.Id)))
            {
                RemoveItem(id);
            }
        }

        private void PrepareSummary()
        {
            RemoveAllSummary();

            List<IResultObject> list = new List<IResultObject>();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewCollections.Rows)
            {
                if (Convert.ToBoolean(dataGridViewRow.Cells[columnDisable.Name].Value) == true)
                {
                    IResultObject collection = dataGridViewRow.Tag as IResultObject;
                    if (collection != null)
                    {
                        list.Add(collection);
                    }
                }
            }
            UserData["CollectionItems"] = list;

            AddAction("GeneralDescription", string.Format("The following incremental collection(s) will be disabled ({0}):", list.Count));
            AddAction("CollectionInformation", string.Empty);

            foreach (IResultObject collection in (IEnumerable)list)
            {
                AddActionDetailMessage("CollectionInformation", ResourceDisplayClass.GetAliasDisplayText(collection, "Name"));
            }
        }

        private void PrepareCompletion(List<string> success, Dictionary<string, IResultObject> error)
        {
            RemoveAllSummary();

            if (success.Count > 0)
            {
                AddAction("CollectionInformation", string.Format("The following incremental collection(s) were disabled ({0}):", success.Count));
                UpdateActionStatus("CollectionInformation", SmsSummaryAction.ActionStatus.CompleteWithSuccess);

                foreach (string message in success)
                {
                    AddActionDetailMessage("CollectionInformation", message);
                }

                AddAction("EmptyLine", string.Empty);
            }

            if (error.Count > 0)
            {
                AddAction("CollectionError", string.Format("The following incremental collection(s) cannot be disabled ({0}):", error.Count));
                UpdateActionStatus("CollectionError", SmsSummaryAction.ActionStatus.CompleteWithErrors);
                foreach (KeyValuePair<string, IResultObject> item in error)
                {
                    AddActionDetailMessage("CollectionError", string.Format("{0}: {1}", ResourceDisplayClass.GetAliasDisplayText(item.Value, "Name"), item.Key));
                }
            }
        }

        private void PrepareError(string errorMessage)
        {
            RemoveAllSummary();
            AddAction("ErrorInfo", errorMessage);
            UpdateActionStatus("ErrorInfo", SmsSummaryAction.ActionStatus.CompleteWithErrors);
        }

        private ControlDataState ValidateSelectedCollections()
        {
            foreach (DataGridViewRow dataGridViewRow in dataGridViewCollections.Rows)
            {
                if (Convert.ToBoolean(dataGridViewRow.Cells[0].Value, CultureInfo.InvariantCulture))
                    return ControlDataState.Valid;
            }
            return ControlDataState.Invalid;
        }

        private void dataGridViewCollections_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!dataGridViewCollections.IsCurrentCellDirty)
                return;
            dataGridViewCollections.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridViewCollections_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Utility.UpdateDataGridViewColumnsSize(dataGridViewCollections, columnCollection);
        }

        private void DataGridViewCollections_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ControlsInspector.InspectAll();
            Dirty = !ReadOnly;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "http://go.microsoft.com/fwlink/?LinkId=626982";
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch (Win32Exception ex)
            {
                ExceptionUtilities.TraceException((Exception)ex);
            }
            finally
            {
                process?.Dispose();
            }
        }
    }
}