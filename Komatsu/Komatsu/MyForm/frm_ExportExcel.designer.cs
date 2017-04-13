namespace KOMTSU.MyForm
{
    partial class frm_ExportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExportExcel));
            this.cbb_Batch = new System.Windows.Forms.ComboBox();
            this.btn_Export = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_SoDong = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btn_CheckAll = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CheckNone = new DevExpress.XtraEditors.SimpleButton();
            this.rb_Loai1 = new System.Windows.Forms.RadioButton();
            this.rb_Loai2 = new System.Windows.Forms.RadioButton();
            this.lbl_File = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_Batch
            // 
            this.cbb_Batch.FormattingEnabled = true;
            this.cbb_Batch.Location = new System.Drawing.Point(714, 42);
            this.cbb_Batch.Name = "cbb_Batch";
            this.cbb_Batch.Size = new System.Drawing.Size(167, 21);
            this.cbb_Batch.TabIndex = 0;
            this.cbb_Batch.Visible = false;
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(276, 47);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(99, 23);
            this.btn_Export.TabIndex = 3;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(276, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(605, 444);
            this.dataGridView1.TabIndex = 4;
            // 
            // lb_SoDong
            // 
            this.lb_SoDong.AutoSize = true;
            this.lb_SoDong.Location = new System.Drawing.Point(381, 57);
            this.lb_SoDong.Name = "lb_SoDong";
            this.lb_SoDong.Size = new System.Drawing.Size(16, 13);
            this.lb_SoDong.TabIndex = 5;
            this.lb_SoDong.Text = "...";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(12, 79);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(258, 444);
            this.checkedListBoxControl1.TabIndex = 6;
            // 
            // btn_CheckAll
            // 
            this.btn_CheckAll.Location = new System.Drawing.Point(12, 47);
            this.btn_CheckAll.Name = "btn_CheckAll";
            this.btn_CheckAll.Size = new System.Drawing.Size(75, 23);
            this.btn_CheckAll.TabIndex = 7;
            this.btn_CheckAll.Text = "Check All";
            this.btn_CheckAll.Click += new System.EventHandler(this.btn_CheckAll_Click);
            // 
            // btn_CheckNone
            // 
            this.btn_CheckNone.Location = new System.Drawing.Point(118, 47);
            this.btn_CheckNone.Name = "btn_CheckNone";
            this.btn_CheckNone.Size = new System.Drawing.Size(75, 23);
            this.btn_CheckNone.TabIndex = 7;
            this.btn_CheckNone.Text = "UnCheck All";
            this.btn_CheckNone.Click += new System.EventHandler(this.btn_CheckNone_Click);
            // 
            // rb_Loai1
            // 
            this.rb_Loai1.AutoSize = true;
            this.rb_Loai1.Location = new System.Drawing.Point(33, 19);
            this.rb_Loai1.Name = "rb_Loai1";
            this.rb_Loai1.Size = new System.Drawing.Size(58, 17);
            this.rb_Loai1.TabIndex = 8;
            this.rb_Loai1.TabStop = true;
            this.rb_Loai1.Text = "Type 1";
            this.rb_Loai1.UseVisualStyleBackColor = true;
            this.rb_Loai1.CheckedChanged += new System.EventHandler(this.rb_Loai1_CheckedChanged);
            // 
            // rb_Loai2
            // 
            this.rb_Loai2.AutoSize = true;
            this.rb_Loai2.Location = new System.Drawing.Point(118, 19);
            this.rb_Loai2.Name = "rb_Loai2";
            this.rb_Loai2.Size = new System.Drawing.Size(58, 17);
            this.rb_Loai2.TabIndex = 8;
            this.rb_Loai2.TabStop = true;
            this.rb_Loai2.Text = "Type 2";
            this.rb_Loai2.UseVisualStyleBackColor = true;
            this.rb_Loai2.CheckedChanged += new System.EventHandler(this.rb_Loai2_CheckedChanged);
            // 
            // lbl_File
            // 
            this.lbl_File.AutoSize = true;
            this.lbl_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_File.ForeColor = System.Drawing.Color.Red;
            this.lbl_File.Location = new System.Drawing.Point(381, 26);
            this.lbl_File.Name = "lbl_File";
            this.lbl_File.Size = new System.Drawing.Size(23, 17);
            this.lbl_File.TabIndex = 5;
            this.lbl_File.Text = "...";
            // 
            // frm_ExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 537);
            this.Controls.Add(this.rb_Loai2);
            this.Controls.Add(this.rb_Loai1);
            this.Controls.Add(this.btn_CheckNone);
            this.Controls.Add(this.btn_CheckAll);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.lbl_File);
            this.Controls.Add(this.lb_SoDong);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.cbb_Batch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ExportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Excel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_Batch;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_SoDong;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.SimpleButton btn_CheckAll;
        private DevExpress.XtraEditors.SimpleButton btn_CheckNone;
        private System.Windows.Forms.RadioButton rb_Loai1;
        private System.Windows.Forms.RadioButton rb_Loai2;
        private System.Windows.Forms.Label lbl_File;
    }
}

