namespace KOMTSU.MyForm
{
    partial class frm_CreateBatch
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
            this.cbb_loaithoigian = new System.Windows.Forms.ComboBox();
            this.nud_sophutlam = new System.Windows.Forms.NumericUpDown();
            this.nud_sogiolam = new System.Windows.Forms.NumericUpDown();
            this.nud_thoigiandeadline = new System.Windows.Forms.NumericUpDown();
            this.nud_songaylam = new System.Windows.Forms.NumericUpDown();
            this.timeEdit_ngayketthuc = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit_ngaybatdau = new DevExpress.XtraEditors.TimeEdit();
            this.dateEdit_ngayketthuc = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_ngaybatdau = new DevExpress.XtraEditors.DateEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.btn_CreateBatch = new DevExpress.XtraEditors.SimpleButton();
            this.btn_BrowserPDF = new DevExpress.XtraEditors.SimpleButton();
            this.txt_ImagePath = new DevExpress.XtraEditors.TextEdit();
            this.txt_DateCreate = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserCreate = new DevExpress.XtraEditors.TextEdit();
            this.txt_BatchName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rb_LoaiBatch = new DevExpress.XtraEditors.RadioGroup();
            this.txt_TruongSo06 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TruongSo08 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TruongSo06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TruongSo08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Page = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txt_FolderSaveImage = new DevExpress.XtraEditors.TextEdit();
            this.btn_BrowserFolder = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_Page = new DevExpress.XtraEditors.LabelControl();
            this.ck_CoDeso = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lb_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sophutlam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sogiolam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_thoigiandeadline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_songaylam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_ngayketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_ngaybatdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngayketthuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngayketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaybatdau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaybatdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ImagePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BatchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_LoaiBatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo06.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo08.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FolderSaveImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_CoDeso.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_loaithoigian
            // 
            this.cbb_loaithoigian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_loaithoigian.FormattingEnabled = true;
            this.cbb_loaithoigian.Location = new System.Drawing.Point(238, 428);
            this.cbb_loaithoigian.Name = "cbb_loaithoigian";
            this.cbb_loaithoigian.Size = new System.Drawing.Size(101, 21);
            this.cbb_loaithoigian.TabIndex = 47;
            this.cbb_loaithoigian.SelectedIndexChanged += new System.EventHandler(this.cbb_loaithoigian_SelectedIndexChanged);
            // 
            // nud_sophutlam
            // 
            this.nud_sophutlam.Location = new System.Drawing.Point(273, 370);
            this.nud_sophutlam.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nud_sophutlam.Name = "nud_sophutlam";
            this.nud_sophutlam.Size = new System.Drawing.Size(40, 21);
            this.nud_sophutlam.TabIndex = 46;
            this.nud_sophutlam.ValueChanged += new System.EventHandler(this.nud_sophutlam_ValueChanged);
            this.nud_sophutlam.Click += new System.EventHandler(this.nud_sophutlam_Click);
            // 
            // nud_sogiolam
            // 
            this.nud_sogiolam.Location = new System.Drawing.Point(198, 370);
            this.nud_sogiolam.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nud_sogiolam.Name = "nud_sogiolam";
            this.nud_sogiolam.Size = new System.Drawing.Size(40, 21);
            this.nud_sogiolam.TabIndex = 45;
            this.nud_sogiolam.ValueChanged += new System.EventHandler(this.nud_sogiolam_ValueChanged);
            this.nud_sogiolam.Click += new System.EventHandler(this.nud_sogiolam_Click);
            // 
            // nud_thoigiandeadline
            // 
            this.nud_thoigiandeadline.DecimalPlaces = 2;
            this.nud_thoigiandeadline.Location = new System.Drawing.Point(115, 428);
            this.nud_thoigiandeadline.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_thoigiandeadline.Name = "nud_thoigiandeadline";
            this.nud_thoigiandeadline.Size = new System.Drawing.Size(117, 21);
            this.nud_thoigiandeadline.TabIndex = 44;
            this.nud_thoigiandeadline.ValueChanged += new System.EventHandler(this.nud_thoigiandeadline_ValueChanged);
            this.nud_thoigiandeadline.Click += new System.EventHandler(this.nud_thoigiandeadline_Click);
            // 
            // nud_songaylam
            // 
            this.nud_songaylam.Location = new System.Drawing.Point(115, 370);
            this.nud_songaylam.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_songaylam.Name = "nud_songaylam";
            this.nud_songaylam.Size = new System.Drawing.Size(40, 21);
            this.nud_songaylam.TabIndex = 43;
            this.nud_songaylam.ValueChanged += new System.EventHandler(this.nud_songaylam_ValueChanged);
            this.nud_songaylam.Click += new System.EventHandler(this.nud_songaylam_Click);
            // 
            // timeEdit_ngayketthuc
            // 
            this.timeEdit_ngayketthuc.EditValue = new System.DateTime(2017, 3, 16, 0, 0, 0, 0);
            this.timeEdit_ngayketthuc.Location = new System.Drawing.Point(238, 399);
            this.timeEdit_ngayketthuc.Name = "timeEdit_ngayketthuc";
            this.timeEdit_ngayketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_ngayketthuc.Properties.Mask.EditMask = "HH:mm:ss";
            this.timeEdit_ngayketthuc.Size = new System.Drawing.Size(101, 20);
            this.timeEdit_ngayketthuc.TabIndex = 42;
            this.timeEdit_ngayketthuc.EditValueChanged += new System.EventHandler(this.timeEdit_ngayketthuc_EditValueChanged);
            this.timeEdit_ngayketthuc.Click += new System.EventHandler(this.timeEdit_ngayketthuc_Click);
            // 
            // timeEdit_ngaybatdau
            // 
            this.timeEdit_ngaybatdau.EditValue = new System.DateTime(2017, 3, 16, 0, 0, 0, 0);
            this.timeEdit_ngaybatdau.Location = new System.Drawing.Point(238, 343);
            this.timeEdit_ngaybatdau.Name = "timeEdit_ngaybatdau";
            this.timeEdit_ngaybatdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_ngaybatdau.Properties.Mask.EditMask = "HH:mm:ss";
            this.timeEdit_ngaybatdau.Size = new System.Drawing.Size(101, 20);
            this.timeEdit_ngaybatdau.TabIndex = 41;
            this.timeEdit_ngaybatdau.EditValueChanged += new System.EventHandler(this.timeEdit_ngaybatdau_EditValueChanged);
            this.timeEdit_ngaybatdau.Click += new System.EventHandler(this.timeEdit_ngaybatdau_Click);
            // 
            // dateEdit_ngayketthuc
            // 
            this.dateEdit_ngayketthuc.EditValue = null;
            this.dateEdit_ngayketthuc.Location = new System.Drawing.Point(115, 400);
            this.dateEdit_ngayketthuc.Name = "dateEdit_ngayketthuc";
            this.dateEdit_ngayketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_ngayketthuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_ngayketthuc.Properties.CalendarTimeProperties.TouchUIMaxValue = new System.DateTime(3000, 12, 31, 23, 59, 0, 0);
            this.dateEdit_ngayketthuc.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit_ngayketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit_ngayketthuc.Properties.MaxValue = new System.DateTime(3000, 12, 31, 23, 59, 0, 0);
            this.dateEdit_ngayketthuc.Size = new System.Drawing.Size(117, 20);
            this.dateEdit_ngayketthuc.TabIndex = 40;
            this.dateEdit_ngayketthuc.EditValueChanged += new System.EventHandler(this.dateEdit_ngayketthuc_EditValueChanged);
            this.dateEdit_ngayketthuc.Click += new System.EventHandler(this.dateEdit_ngayketthuc_Click);
            // 
            // dateEdit_ngaybatdau
            // 
            this.dateEdit_ngaybatdau.EditValue = null;
            this.dateEdit_ngaybatdau.Location = new System.Drawing.Point(115, 344);
            this.dateEdit_ngaybatdau.Name = "dateEdit_ngaybatdau";
            this.dateEdit_ngaybatdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_ngaybatdau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_ngaybatdau.Properties.CalendarTimeProperties.TouchUIMaxValue = new System.DateTime(3000, 12, 31, 23, 59, 0, 0);
            this.dateEdit_ngaybatdau.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit_ngaybatdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit_ngaybatdau.Properties.MaxValue = new System.DateTime(3000, 12, 31, 23, 59, 0, 0);
            this.dateEdit_ngaybatdau.Size = new System.Drawing.Size(117, 20);
            this.dateEdit_ngaybatdau.TabIndex = 39;
            this.dateEdit_ngaybatdau.EditValueChanged += new System.EventHandler(this.dateEdit_ngaybatdau_EditValueChanged);
            this.dateEdit_ngaybatdau.Click += new System.EventHandler(this.dateEdit_ngaybatdau_Click);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(16, 403);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(92, 13);
            this.labelControl11.TabIndex = 25;
            this.labelControl11.Text = "Thời gian kết thúc :";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(242, 374);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(15, 13);
            this.labelControl13.TabIndex = 26;
            this.labelControl13.Text = "Giờ";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(158, 374);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(25, 13);
            this.labelControl12.TabIndex = 23;
            this.labelControl12.Text = "Ngày";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(39, 375);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(69, 13);
            this.labelControl10.TabIndex = 22;
            this.labelControl10.Text = "Thời gian làm :";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(18, 348);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(90, 13);
            this.labelControl9.TabIndex = 21;
            this.labelControl9.Text = "Thời gian bắt đầu :";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(48, 185);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(61, 13);
            this.labelControl8.TabIndex = 20;
            this.labelControl8.Text = "Type Batch :";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarControl1.Location = new System.Drawing.Point(0, 523);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(835, 40);
            this.progressBarControl1.TabIndex = 36;
            // 
            // btn_CreateBatch
            // 
            this.btn_CreateBatch.Location = new System.Drawing.Point(317, 464);
            this.btn_CreateBatch.Name = "btn_CreateBatch";
            this.btn_CreateBatch.Size = new System.Drawing.Size(164, 44);
            this.btn_CreateBatch.TabIndex = 35;
            this.btn_CreateBatch.Text = "Create Batch";
            this.btn_CreateBatch.Click += new System.EventHandler(this.btn_CreateBatch_Click);
            // 
            // btn_BrowserPDF
            // 
            this.btn_BrowserPDF.Location = new System.Drawing.Point(720, 87);
            this.btn_BrowserPDF.Name = "btn_BrowserPDF";
            this.btn_BrowserPDF.Size = new System.Drawing.Size(109, 23);
            this.btn_BrowserPDF.TabIndex = 33;
            this.btn_BrowserPDF.Text = "Browse PDF...";
            this.btn_BrowserPDF.Click += new System.EventHandler(this.btn_BrowserPDF_Click);
            // 
            // txt_ImagePath
            // 
            this.txt_ImagePath.Location = new System.Drawing.Point(113, 89);
            this.txt_ImagePath.Name = "txt_ImagePath";
            this.txt_ImagePath.Properties.ReadOnly = true;
            this.txt_ImagePath.Size = new System.Drawing.Size(601, 20);
            this.txt_ImagePath.TabIndex = 31;
            this.txt_ImagePath.EditValueChanged += new System.EventHandler(this.txt_ImagePath_EditValueChanged);
            // 
            // txt_DateCreate
            // 
            this.txt_DateCreate.Location = new System.Drawing.Point(114, 296);
            this.txt_DateCreate.Name = "txt_DateCreate";
            this.txt_DateCreate.Properties.ReadOnly = true;
            this.txt_DateCreate.Size = new System.Drawing.Size(225, 20);
            this.txt_DateCreate.TabIndex = 30;
            // 
            // txt_UserCreate
            // 
            this.txt_UserCreate.Location = new System.Drawing.Point(114, 268);
            this.txt_UserCreate.Name = "txt_UserCreate";
            this.txt_UserCreate.Properties.ReadOnly = true;
            this.txt_UserCreate.Size = new System.Drawing.Size(225, 20);
            this.txt_UserCreate.TabIndex = 32;
            // 
            // txt_BatchName
            // 
            this.txt_BatchName.Location = new System.Drawing.Point(113, 59);
            this.txt_BatchName.Name = "txt_BatchName";
            this.txt_BatchName.Size = new System.Drawing.Size(601, 20);
            this.txt_BatchName.TabIndex = 0;
            this.txt_BatchName.EditValueChanged += new System.EventHandler(this.txt_BatchName_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(41, 92);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 13);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "Path File PDF:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(18, 299);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(91, 13);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Date create Batch:";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(9, 431);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(99, 13);
            this.labelControl15.TabIndex = 17;
            this.labelControl15.Text = "Thông báo Deadline:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(19, 271);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(90, 13);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "User create Batch:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(48, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Batch name:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(311, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(188, 25);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Create Batch New";
            // 
            // rb_LoaiBatch
            // 
            this.rb_LoaiBatch.EditValue = "1";
            this.rb_LoaiBatch.Location = new System.Drawing.Point(113, 178);
            this.rb_LoaiBatch.Name = "rb_LoaiBatch";
            this.rb_LoaiBatch.Properties.Columns = 2;
            this.rb_LoaiBatch.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Loai1", "Type 1"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Loai2", "Type 2")});
            this.rb_LoaiBatch.Size = new System.Drawing.Size(226, 28);
            this.rb_LoaiBatch.TabIndex = 48;
            this.rb_LoaiBatch.SelectedIndexChanged += new System.EventHandler(this.rb_LoaiBatch_SelectedIndexChanged);
            // 
            // txt_TruongSo06
            // 
            this.txt_TruongSo06.Location = new System.Drawing.Point(113, 212);
            this.txt_TruongSo06.Name = "txt_TruongSo06";
            this.txt_TruongSo06.Size = new System.Drawing.Size(226, 20);
            this.txt_TruongSo06.TabIndex = 49;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(74, 215);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Field 6:";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // txt_TruongSo08
            // 
            this.txt_TruongSo08.Location = new System.Drawing.Point(113, 238);
            this.txt_TruongSo08.Name = "txt_TruongSo08";
            this.txt_TruongSo08.Size = new System.Drawing.Size(226, 20);
            this.txt_TruongSo08.TabIndex = 50;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(74, 241);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Field 8:";
            this.labelControl4.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TruongSo06,
            this.TruongSo08,
            this.Page});
            this.dataGridView1.Location = new System.Drawing.Point(345, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(487, 301);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // TruongSo06
            // 
            this.TruongSo06.DataPropertyName = "TruongSo06";
            this.TruongSo06.HeaderText = "Field 6";
            this.TruongSo06.Name = "TruongSo06";
            this.TruongSo06.Width = 170;
            // 
            // TruongSo08
            // 
            this.TruongSo08.DataPropertyName = "TruongSo08";
            this.TruongSo08.HeaderText = "Field 8";
            this.TruongSo08.Name = "TruongSo08";
            this.TruongSo08.Width = 170;
            // 
            // Page
            // 
            this.Page.DataPropertyName = "Page";
            this.Page.HeaderText = "Page";
            this.Page.Name = "Page";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(47, 121);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(61, 13);
            this.labelControl16.TabIndex = 19;
            this.labelControl16.Text = "Save Image:";
            // 
            // txt_FolderSaveImage
            // 
            this.txt_FolderSaveImage.Location = new System.Drawing.Point(113, 118);
            this.txt_FolderSaveImage.Name = "txt_FolderSaveImage";
            this.txt_FolderSaveImage.Properties.ReadOnly = true;
            this.txt_FolderSaveImage.Size = new System.Drawing.Size(601, 20);
            this.txt_FolderSaveImage.TabIndex = 31;
            // 
            // btn_BrowserFolder
            // 
            this.btn_BrowserFolder.Location = new System.Drawing.Point(720, 116);
            this.btn_BrowserFolder.Name = "btn_BrowserFolder";
            this.btn_BrowserFolder.Size = new System.Drawing.Size(109, 23);
            this.btn_BrowserFolder.TabIndex = 33;
            this.btn_BrowserFolder.Text = "Folder save...";
            this.btn_BrowserFolder.Click += new System.EventHandler(this.btn_BrowserFolder_Click);
            // 
            // lbl_Page
            // 
            this.lbl_Page.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Page.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Page.Appearance.Options.UseFont = true;
            this.lbl_Page.Appearance.Options.UseForeColor = true;
            this.lbl_Page.Location = new System.Drawing.Point(140, 148);
            this.lbl_Page.Name = "lbl_Page";
            this.lbl_Page.Size = new System.Drawing.Size(0, 19);
            this.lbl_Page.TabIndex = 19;
            // 
            // ck_CoDeso
            // 
            this.ck_CoDeso.Location = new System.Drawing.Point(748, 62);
            this.ck_CoDeso.Name = "ck_CoDeso";
            this.ck_CoDeso.Properties.Caption = "DESo";
            this.ck_CoDeso.Size = new System.Drawing.Size(75, 19);
            this.ck_CoDeso.TabIndex = 52;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(317, 375);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(22, 13);
            this.labelControl14.TabIndex = 26;
            this.labelControl14.Text = "Phút";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.ForeColor = System.Drawing.Color.Maroon;
            this.lb_status.Location = new System.Drawing.Point(13, 464);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(28, 13);
            this.lb_status.TabIndex = 53;
            this.lb_status.Text = "       ";
            // 
            // frm_CreateBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(835, 563);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.ck_CoDeso);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_TruongSo08);
            this.Controls.Add(this.txt_TruongSo06);
            this.Controls.Add(this.rb_LoaiBatch);
            this.Controls.Add(this.cbb_loaithoigian);
            this.Controls.Add(this.nud_sophutlam);
            this.Controls.Add(this.nud_sogiolam);
            this.Controls.Add(this.nud_thoigiandeadline);
            this.Controls.Add(this.nud_songaylam);
            this.Controls.Add(this.timeEdit_ngayketthuc);
            this.Controls.Add(this.timeEdit_ngaybatdau);
            this.Controls.Add(this.dateEdit_ngayketthuc);
            this.Controls.Add(this.dateEdit_ngaybatdau);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.btn_CreateBatch);
            this.Controls.Add(this.btn_BrowserFolder);
            this.Controls.Add(this.txt_FolderSaveImage);
            this.Controls.Add(this.btn_BrowserPDF);
            this.Controls.Add(this.txt_ImagePath);
            this.Controls.Add(this.txt_DateCreate);
            this.Controls.Add(this.txt_UserCreate);
            this.Controls.Add(this.lbl_Page);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.txt_BatchName);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.Name = "frm_CreateBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Batch";
            this.Load += new System.EventHandler(this.frm_CreateBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_sophutlam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sogiolam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_thoigiandeadline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_songaylam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_ngayketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_ngaybatdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngayketthuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngayketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaybatdau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaybatdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ImagePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BatchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_LoaiBatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo06.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo08.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FolderSaveImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_CoDeso.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_loaithoigian;
        private System.Windows.Forms.NumericUpDown nud_sophutlam;
        private System.Windows.Forms.NumericUpDown nud_sogiolam;
        private System.Windows.Forms.NumericUpDown nud_thoigiandeadline;
        private System.Windows.Forms.NumericUpDown nud_songaylam;
        private DevExpress.XtraEditors.TimeEdit timeEdit_ngayketthuc;
        private DevExpress.XtraEditors.TimeEdit timeEdit_ngaybatdau;
        private DevExpress.XtraEditors.DateEdit dateEdit_ngayketthuc;
        private DevExpress.XtraEditors.DateEdit dateEdit_ngaybatdau;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.SimpleButton btn_CreateBatch;
        private DevExpress.XtraEditors.SimpleButton btn_BrowserPDF;
        private DevExpress.XtraEditors.TextEdit txt_ImagePath;
        private DevExpress.XtraEditors.TextEdit txt_DateCreate;
        private DevExpress.XtraEditors.TextEdit txt_UserCreate;
        private DevExpress.XtraEditors.TextEdit txt_BatchName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.RadioGroup rb_LoaiBatch;
        private DevExpress.XtraEditors.TextEdit txt_TruongSo06;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_TruongSo08;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit txt_FolderSaveImage;
        private DevExpress.XtraEditors.SimpleButton btn_BrowserFolder;
        private DevExpress.XtraEditors.LabelControl lbl_Page;
        private DevExpress.XtraEditors.CheckEdit ck_CoDeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn TruongSo06;
        private System.Windows.Forms.DataGridViewTextBoxColumn TruongSo08;
        private System.Windows.Forms.DataGridViewTextBoxColumn Page;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private System.Windows.Forms.Label lb_status;
    }
}