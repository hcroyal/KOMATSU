namespace KOMTSU.MyForm
{
    partial class frm_NangSuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NangSuat));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtp_EndDay = new System.Windows.Forms.DateTimePicker();
            this.dtp_FirstDay = new System.Windows.Forms.DateTimePicker();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tp_DeSo = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_DeSo = new DevExpress.XtraGrid.GridControl();
            this.dgv_DeSo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tp_DeJP = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_DeJP = new DevExpress.XtraGrid.GridControl();
            this.dgv_DeJP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tp_DeSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DeSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeSo)).BeginInit();
            this.tp_DeJP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DeJP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeJP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dataGridView1);
            this.panelControl1.Controls.Add(this.dtp_EndDay);
            this.panelControl1.Controls.Add(this.dtp_FirstDay);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(929, 88);
            this.panelControl1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(600, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(56, 74);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // dtp_EndDay
            // 
            this.dtp_EndDay.CustomFormat = "dd/MM/yyyy";
            this.dtp_EndDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndDay.Location = new System.Drawing.Point(278, 50);
            this.dtp_EndDay.Name = "dtp_EndDay";
            this.dtp_EndDay.Size = new System.Drawing.Size(143, 21);
            this.dtp_EndDay.TabIndex = 4;
            this.dtp_EndDay.ValueChanged += new System.EventHandler(this.dtp_EndDay_ValueChanged);
            // 
            // dtp_FirstDay
            // 
            this.dtp_FirstDay.CustomFormat = "dd/MM/yyyy";
            this.dtp_FirstDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FirstDay.Location = new System.Drawing.Point(278, 18);
            this.dtp_FirstDay.Name = "dtp_FirstDay";
            this.dtp_FirstDay.Size = new System.Drawing.Size(143, 21);
            this.dtp_FirstDay.TabIndex = 4;
            this.dtp_FirstDay.ValueChanged += new System.EventHandler(this.dtp_FirstDay_ValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(439, 22);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(93, 45);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Export Excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(234, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "To date:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(223, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "From date:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 88);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tp_DeSo;
            this.xtraTabControl1.Size = new System.Drawing.Size(929, 559);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tp_DeSo,
            this.tp_DeJP});
            // 
            // tp_DeSo
            // 
            this.tp_DeSo.Controls.Add(this.gridControl_DeSo);
            this.tp_DeSo.Name = "tp_DeSo";
            this.tp_DeSo.Size = new System.Drawing.Size(923, 531);
            this.tp_DeSo.Text = "DeSo";
            // 
            // gridControl_DeSo
            // 
            this.gridControl_DeSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DeSo.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DeSo.MainView = this.dgv_DeSo;
            this.gridControl_DeSo.Name = "gridControl_DeSo";
            this.gridControl_DeSo.Size = new System.Drawing.Size(923, 531);
            this.gridControl_DeSo.TabIndex = 4;
            this.gridControl_DeSo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_DeSo});
            // 
            // dgv_DeSo
            // 
            this.dgv_DeSo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn33,
            this.gridColumn18});
            this.dgv_DeSo.GridControl = this.gridControl_DeSo;
            this.dgv_DeSo.Name = "dgv_DeSo";
            this.dgv_DeSo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgv_DeSo.OptionsBehavior.Editable = false;
            this.dgv_DeSo.OptionsFind.AlwaysVisible = true;
            this.dgv_DeSo.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "UserName";
            this.gridColumn13.FieldName = "UserName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            this.gridColumn13.Width = 116;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Name";
            this.gridColumn14.FieldName = "FullName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 184;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Total row do";
            this.gridColumn15.FieldName = "SoPhieuNhap";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 116;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Correct row";
            this.gridColumn16.FieldName = "PhieuDung";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 3;
            this.gridColumn16.Width = 102;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Wrong row";
            this.gridColumn17.FieldName = "PhieuSai";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            this.gridColumn17.Width = 94;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Time";
            this.gridColumn33.FieldName = "ThoiGian";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 5;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Performance (%)";
            this.gridColumn18.FieldName = "HieuSuat";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            this.gridColumn18.Width = 84;
            // 
            // tp_DeJP
            // 
            this.tp_DeJP.Controls.Add(this.gridControl_DeJP);
            this.tp_DeJP.Name = "tp_DeJP";
            this.tp_DeJP.Size = new System.Drawing.Size(923, 531);
            this.tp_DeJP.Text = "DeJP";
            // 
            // gridControl_DeJP
            // 
            this.gridControl_DeJP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DeJP.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DeJP.MainView = this.dgv_DeJP;
            this.gridControl_DeJP.Name = "gridControl_DeJP";
            this.gridControl_DeJP.Size = new System.Drawing.Size(923, 531);
            this.gridControl_DeJP.TabIndex = 5;
            this.gridControl_DeJP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_DeJP});
            // 
            // dgv_DeJP
            // 
            this.dgv_DeJP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn31,
            this.gridColumn12});
            this.dgv_DeJP.GridControl = this.gridControl_DeJP;
            this.dgv_DeJP.Name = "dgv_DeJP";
            this.dgv_DeJP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgv_DeJP.OptionsBehavior.Editable = false;
            this.dgv_DeJP.OptionsFind.AlwaysVisible = true;
            this.dgv_DeJP.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "UserName";
            this.gridColumn7.FieldName = "Username";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 116;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Personnel name";
            this.gridColumn8.FieldName = "FullName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 184;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total row do";
            this.gridColumn9.FieldName = "SoPhieuNhap";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 116;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Correct row";
            this.gridColumn10.FieldName = "PhieuDung";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 102;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Wrong row";
            this.gridColumn11.FieldName = "PhieuSai";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 94;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Time";
            this.gridColumn31.FieldName = "ThoiGian";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Performance (%)";
            this.gridColumn12.FieldName = "HieuSuat";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            this.gridColumn12.Width = 84;
            // 
            // frm_NangSuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 647);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_NangSuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productivity";
            this.Load += new System.EventHandler(this.frm_NangSuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tp_DeSo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DeSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeSo)).EndInit();
            this.tp_DeJP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DeJP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeJP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtp_EndDay;
        private System.Windows.Forms.DateTimePicker dtp_FirstDay;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tp_DeSo;
        private DevExpress.XtraTab.XtraTabPage tp_DeJP;
        private DevExpress.XtraGrid.GridControl gridControl_DeJP;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_DeJP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.GridControl gridControl_DeSo;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_DeSo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
    }
}