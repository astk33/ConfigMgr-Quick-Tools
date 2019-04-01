﻿namespace ConfigMgr.QuickTools.DriverManager
{
    partial class DriverGrabberSelectPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelProcessingObject = new System.Windows.Forms.Label();
            this.panelProcessing = new System.Windows.Forms.Panel();
            this.progressBarObjects = new System.Windows.Forms.ProgressBar();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.labelPackage = new System.Windows.Forms.Label();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.panelComplete = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.dataGridViewDrivers = new System.Windows.Forms.DataGridView();
            this.columnCapture = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnProvider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOEMInf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelProcessing.SuspendLayout();
            this.panelComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProcessingObject
            // 
            this.labelProcessingObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProcessingObject.Location = new System.Drawing.Point(22, 95);
            this.labelProcessingObject.Name = "labelProcessingObject";
            this.labelProcessingObject.Size = new System.Drawing.Size(441, 170);
            this.labelProcessingObject.TabIndex = 1;
            this.labelProcessingObject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelProcessing
            // 
            this.panelProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelProcessing.Controls.Add(this.labelProcessingObject);
            this.panelProcessing.Controls.Add(this.progressBarObjects);
            this.panelProcessing.Location = new System.Drawing.Point(485, 0);
            this.panelProcessing.Name = "panelProcessing";
            this.panelProcessing.Size = new System.Drawing.Size(485, 360);
            this.panelProcessing.TabIndex = 11;
            this.panelProcessing.Visible = false;
            // 
            // progressBarObjects
            // 
            this.progressBarObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarObjects.Location = new System.Drawing.Point(25, 33);
            this.progressBarObjects.Name = "progressBarObjects";
            this.progressBarObjects.Size = new System.Drawing.Size(438, 23);
            this.progressBarObjects.TabIndex = 0;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(6, 337);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(455, 20);
            this.textBoxDestination.TabIndex = 11;
            // 
            // labelPackage
            // 
            this.labelPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPackage.AutoSize = true;
            this.labelPackage.Location = new System.Drawing.Point(3, 321);
            this.labelPackage.Name = "labelPackage";
            this.labelPackage.Size = new System.Drawing.Size(103, 13);
            this.labelPackage.TabIndex = 10;
            this.labelPackage.Text = "Capture Destination:";
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSelectAll.Location = new System.Drawing.Point(371, 291);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(91, 23);
            this.buttonSelectAll.TabIndex = 3;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeselectAll.Location = new System.Drawing.Point(274, 291);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(91, 23);
            this.buttonDeselectAll.TabIndex = 4;
            this.buttonDeselectAll.Text = "Deselect All";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // panelComplete
            // 
            this.panelComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelComplete.Controls.Add(this.labelDescription);
            this.panelComplete.Controls.Add(this.labelDestination);
            this.panelComplete.Controls.Add(this.textBoxDestination);
            this.panelComplete.Controls.Add(this.labelPackage);
            this.panelComplete.Controls.Add(this.buttonSelectAll);
            this.panelComplete.Controls.Add(this.buttonDeselectAll);
            this.panelComplete.Controls.Add(this.dataGridViewDrivers);
            this.panelComplete.Location = new System.Drawing.Point(0, 0);
            this.panelComplete.Name = "panelComplete";
            this.panelComplete.Size = new System.Drawing.Size(485, 360);
            this.panelComplete.TabIndex = 12;
            this.panelComplete.Visible = false;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 4);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(43, 13);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "Drivers:";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(101, 321);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(28, 13);
            this.labelDestination.TabIndex = 13;
            this.labelDestination.Text = "       ";
            // 
            // dataGridViewDrivers
            // 
            this.dataGridViewDrivers.AllowUserToAddRows = false;
            this.dataGridViewDrivers.AllowUserToDeleteRows = false;
            this.dataGridViewDrivers.AllowUserToOrderColumns = true;
            this.dataGridViewDrivers.AllowUserToResizeRows = false;
            this.dataGridViewDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCapture,
            this.columnProvider,
            this.columnDesc,
            this.columnVersion,
            this.columnOEMInf});
            this.dataGridViewDrivers.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewDrivers.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.dataGridViewDrivers.Name = "dataGridViewDrivers";
            this.dataGridViewDrivers.RowHeadersVisible = false;
            this.dataGridViewDrivers.Size = new System.Drawing.Size(455, 268);
            this.dataGridViewDrivers.StandardTab = true;
            this.dataGridViewDrivers.TabIndex = 7;
            this.dataGridViewDrivers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDrivers_CellValueChanged);
            this.dataGridViewDrivers.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewDrivers_CurrentCellDirtyStateChanged);
            // 
            // columnCapture
            // 
            this.columnCapture.HeaderText = "";
            this.columnCapture.MinimumWidth = 20;
            this.columnCapture.Name = "columnCapture";
            this.columnCapture.Width = 25;
            // 
            // columnProvider
            // 
            this.columnProvider.HeaderText = "Provider";
            this.columnProvider.MinimumWidth = 50;
            this.columnProvider.Name = "columnProvider";
            this.columnProvider.ReadOnly = true;
            this.columnProvider.Width = 140;
            // 
            // columnDesc
            // 
            this.columnDesc.HeaderText = "Description";
            this.columnDesc.Name = "columnDesc";
            this.columnDesc.ReadOnly = true;
            this.columnDesc.Width = 210;
            // 
            // columnVersion
            // 
            this.columnVersion.HeaderText = "Version";
            this.columnVersion.Name = "columnVersion";
            this.columnVersion.Width = 70;
            // 
            // columnOEMInf
            // 
            this.columnOEMInf.HeaderText = "OEMInf";
            this.columnOEMInf.Name = "columnOEMInf";
            this.columnOEMInf.Visible = false;
            // 
            // DriverGrabberSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelProcessing);
            this.Controls.Add(this.panelComplete);
            this.Name = "DriverGrabberSelectPage";
            this.Size = new System.Drawing.Size(970, 360);
            this.panelProcessing.ResumeLayout(false);
            this.panelComplete.ResumeLayout(false);
            this.panelComplete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelProcessingObject;
        private System.Windows.Forms.Panel panelProcessing;
        private System.Windows.Forms.ProgressBar progressBarObjects;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label labelPackage;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Panel panelComplete;
        private System.Windows.Forms.DataGridView dataGridViewDrivers;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnCapture;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOEMInf;
    }
}
