﻿using Microsoft.ConfigurationManagement.AdminConsole;
using Microsoft.ConfigurationManagement.AdminConsole.DialogFramework;
using Microsoft.ConfigurationManagement.ManagementProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Text;

namespace ConfigMgr.QuickTools.Device.PropertiesDialog
{
    public partial class ResultSUComplianceControl : SmsPageControl
    {
        private BackgroundWorker backgroundWorker;

        public ResultSUComplianceControl(SmsPageData pageData)
          : base(pageData)
        {
            InitializeComponent();
            buttonSURefresh.Image = new Icon(Properties.Resources.reload, new Size(16, 16)).ToBitmap();
            Title = "Software Updates Compliance";
        }

        public override void InitializePageControl()
        {
            base.InitializePageControl();

            if (!PropertyManager["IsClient"].BooleanValue)
            {
                buttonSURefresh.Enabled = false;
            }

            Initialized = true;
        }

        private void buttonSURefresh_Click(object sender, EventArgs e)
        {
            listViewListSoftwareUpdates.IsLoading = true;
            listViewListSoftwareUpdates.UpdateColumnWidth(columnHeaderAssignment);
            listViewListSoftwareUpdates.Items.Clear();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(infoWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(infoWorker_RunWorkerCompleted);
            backgroundWorker.WorkerSupportsCancellation = false;
            backgroundWorker.WorkerReportsProgress = false;
            buttonSURefresh.Enabled = false;
            Cursor = Cursors.WaitCursor;
            backgroundWorker.RunWorkerAsync();
        }

        private void infoWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string host = PropertyManager["Name"].StringValue;

                ManagementScope scope = Utility.GetWMIScope(host, @"ccm\SoftwareUpdates\DeploymentAgent");
                ObjectQuery query = new ObjectQuery("SELECT * FROM CCM_AssignmentCompliance");
                List<ManagementObject> compliance = Utility.SearchWMI(scope, query).ToList();
                // it is faster to run two separate queries than one. SELECT SMS_AuthorizationList.LocalizedDisplayName FROM SMS_UpdateGroupAssignment JOIN SMS_AuthorizationList ON SMS_AuthorizationList.CI_ID = SMS_UpdateGroupAssignment.AssignedUpdateGroup WHERE SMS_UpdateGroupAssignment.AssignmentUniqueID =          
                List<IResultObject> assignments = Utility.SearchWMIToList(ConnectionManager, "SELECT * FROM SMS_UpdateGroupAssignment");
                List<IResultObject> updateGroups = Utility.SearchWMIToList(ConnectionManager, "SELECT * FROM SMS_AuthorizationList");

                foreach (ManagementObject item in compliance)
                {
                    var assignment = assignments.Where(x => x.Properties["AssignmentUniqueID"].StringValue.Equals(item.Properties["AssignmentId"].Value)).FirstOrDefault();
                    if (assignment != null)
                    {
                        var updateGroup = updateGroups.Where(x => x.Properties["CI_ID"].IntegerValue.Equals(assignment.Properties["AssignedUpdateGroup"].IntegerValue)).FirstOrDefault();
                        if (updateGroup != null)
                        {
                            listViewListSoftwareUpdates.Items.Add(new ListViewItem()
                            {
                                Text = updateGroup["LocalizedDisplayName"].StringValue,
                                SubItems = {
                                    ((bool)item.Properties["IsCompliant"].Value ? "Compliant" : "Non-Compliant")
                                }
                            });
                        }
                    }
                }

                ManagementObject lastscan = Utility.GetFirstWMIInstance(host, @"ccm\scanagent", "CCM_ScanUpdateSourceHistory");

                DateTime time = ManagementDateTimeConverter.ToDateTime(lastscan["LastCompletionTime"].ToString());
                labelLastScan.Text = time.ToString("dd'/'MM'/'yyyy HH:mm");

                ManagementObject scansource = Utility.GetFirstWMIInstance(host, @"ccm\SoftwareUpdates\WUAhandler", "CCM_UpdateSource");

                labelCABSource.Text = scansource["ContentLocation"].ToString();
                labelCABVersion.Text = scansource["ContentVersion"].ToString();
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("An error occured while querying for WMI data: " + ex.Message);
            }
            catch (UnauthorizedAccessException unauthorizedErr)
            {
                MessageBox.Show("Connection error " + "(user name or password might be incorrect): " + unauthorizedErr.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("{0}: {1}", ex.GetType().Name, ex.Message));
            }
        }

        private void infoWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    using (SccmExceptionDialog sccmExceptionDialog = new SccmExceptionDialog(e.Error))
                    {
                        int num = (int)sccmExceptionDialog.ShowDialog();
                    }
                }
            }
            finally
            {
                if (sender as BackgroundWorker == backgroundWorker)
                {
                    backgroundWorker.Dispose();
                    backgroundWorker = null;
                    Cursor = Cursors.Default;
                    listViewListSoftwareUpdates.IsLoading = false;
                    listViewListSoftwareUpdates.UpdateColumnWidth(columnHeaderAssignment);
                    buttonSURefresh.Enabled = true;
                }
            }
        }

        private void listViewListSoftwareUpdates_CopyKeyEvent(object sender, EventArgs e)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (ListViewItem item in listViewListSoftwareUpdates.SelectedItems)
            {
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    buffer.Append(subitem.Text);
                    buffer.Append("\t");
                }
                buffer.AppendLine();
            }
            buffer.Remove(buffer.Length - 1, 1);
            Clipboard.SetData(DataFormats.Text, buffer.ToString());
        }
    }
}