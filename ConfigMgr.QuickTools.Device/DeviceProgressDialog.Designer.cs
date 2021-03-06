﻿namespace ConfigMgr.QuickTools.Device
{
    partial class DeviceProgressDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceProgressDialog));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelOther = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCompleted = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewHosts = new Microsoft.ConfigurationManagement.AdminConsole.Common.SmsSearchableListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonOK = new System.Windows.Forms.Button();
            this.clientActionProgressBar = new ConfigMgr.QuickTools.Device.ClientActionProgressBar();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(247, 326);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(275, 304);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Total:";
            // 
            // labelOther
            // 
            this.labelOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOther.AutoSize = true;
            this.labelOther.Location = new System.Drawing.Point(155, 304);
            this.labelOther.Name = "labelOther";
            this.labelOther.Size = new System.Drawing.Size(0, 13);
            this.labelOther.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Other:";
            // 
            // labelCompleted
            // 
            this.labelCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCompleted.AutoSize = true;
            this.labelCompleted.Location = new System.Drawing.Point(72, 304);
            this.labelCompleted.Name = "labelCompleted";
            this.labelCompleted.Size = new System.Drawing.Size(0, 13);
            this.labelCompleted.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Completed:";
            // 
            // listViewHosts
            // 
            this.listViewHosts.Activation = System.Windows.Forms.ItemActivation.Standard;
            this.listViewHosts.Alignment = System.Windows.Forms.ListViewAlignment.Top;
            this.listViewHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewHosts.AutoSort = true;
            this.listViewHosts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listViewHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderStatus});
            this.listViewHosts.CustomNoResultsText = null;
            this.listViewHosts.FullRowSelect = true;
            this.listViewHosts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            this.listViewHosts.HideSelection = false;
            this.listViewHosts.IsLoading = false;
            this.listViewHosts.LargeImageList = null;
            this.listViewHosts.Location = new System.Drawing.Point(12, 12);
            this.listViewHosts.MultiSelect = true;
            this.listViewHosts.Name = "listViewHosts";
            this.listViewHosts.ShowSearchBar = true;
            this.listViewHosts.Size = new System.Drawing.Size(310, 256);
            this.listViewHosts.SmallImageList = null;
            this.listViewHosts.Sorting = System.Windows.Forms.SortOrder.None;
            this.listViewHosts.StateImageList = null;
            this.listViewHosts.TabIndex = 12;
            this.listViewHosts.TileSize = new System.Drawing.Size(0, 0);
            this.listViewHosts.UseCompatibleStateImageBehavior = false;
            this.listViewHosts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 90;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(166, 326);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // clientActionProgressBar1
            // 
            this.clientActionProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientActionProgressBar.Complete = 0;
            this.clientActionProgressBar.Failed = 0;
            this.clientActionProgressBar.Location = new System.Drawing.Point(12, 274);
            this.clientActionProgressBar.Name = "clientActionProgressBar1";
            this.clientActionProgressBar.Offline = 0;
            this.clientActionProgressBar.Size = new System.Drawing.Size(310, 23);
            this.clientActionProgressBar.TabIndex = 10;
            // 
            // DeviceProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelOther);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCompleted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewHosts);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.clientActionProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(310, 350);
            this.Name = "DeviceProgressDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceProgressDialog_FormClosing);
            this.Shown += new System.EventHandler(this.DeviceProgressDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelOther;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCompleted;
        private System.Windows.Forms.Label label1;
        private Microsoft.ConfigurationManagement.AdminConsole.Common.SmsSearchableListView listViewHosts;
        private System.Windows.Forms.Button buttonOK;
        private ClientActionProgressBar clientActionProgressBar;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
    }
}