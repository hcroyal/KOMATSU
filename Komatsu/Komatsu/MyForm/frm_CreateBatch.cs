using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Komatsu;
using SautinSoft;

namespace KOMTSU.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string[] _lFileNames;
        private int TongSoTrang;
        public frm_CreateBatch()
        {
            InitializeComponent();
        }


        private bool flag_load = false;
        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            txt_TruongSo06_A.Enabled = false;
            txt_TruongSo08_A.Enabled = false;
            txt_TruongSo06_B.Enabled = false;
            txt_TruongSo08_B.Enabled = false;
            dataGridView1.Enabled = false;
            btn_BrowserPDF.Enabled = false;
            btn_BrowserFolder.Enabled = false;
            txt_UserCreate.Text = Global.StrUsername;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToShortTimeString();
            cbb_loaithoigian.DisplayMember = "Text";
            cbb_loaithoigian.ValueMember = "Value";

            cbb_loaithoigian.Items.Add(new { Text = "", Value = "" });
            cbb_loaithoigian.Items.Add(new { Text = "Ngày", Value = "Ngay" });
            cbb_loaithoigian.Items.Add(new { Text = "Giờ", Value = "Gio" });
            cbb_loaithoigian.Items.Add(new { Text = "Phút", Value = "Phut" });
            cbb_loaithoigian.SelectedIndex = 0;
            dateEdit_ngaybatdau.DateTime = DateTime.Now;
            timeEdit_ngaybatdau.Time = DateTime.Now;
            timeEdit_ngayketthuc.Time = DateTime.Now;
            dateEdit_ngayketthuc.DateTime = DateTime.Now;
            lb_status.Text = "";
            flag_load = true;
            rb_LoaiBatch.SelectedIndex = 0;
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[1].Value != null)//Nếu ô thứ i của cột thứ 1 (cột sau cột STT ấy) mà có dữ liệu thì gán giá trị cho cột STT, nếu không thì cột STT cũng không có dữ liệu lun
            //    {
            //        dataGridView1.Rows[i].Cells[0].Value = i + 1;
            //    }
            //}
        }

        private void txt_BatchName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BatchName.Text))
            {
                btn_BrowserPDF.Enabled = true;
            }
            else
            {
                btn_BrowserPDF.Enabled = false;
            }
        }

        private void btn_BrowserPDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BatchName.Text))
            {
                MessageBox.Show(@"Please enter a batch name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Types PDF|*.pdf";

            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _lFileNames = dlg.FileNames;
                txt_ImagePath.Text = Path.GetFullPath(dlg.FileName);
            }
            var f = new PdfFocus { Serial = "1234567890" };
            string pdfFile = txt_ImagePath.Text;
            f.OpenPdf(pdfFile);
            TongSoTrang = f.PageCount;
            lbl_Page.Text = TongSoTrang + " Pages";
        }

        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            UploadImage();
        }

        private string[] _truongSo06, _truongSo08;
        private string truongso6, truongso8;
        private void ExtractImage()
        {
            int h = 1;
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                _truongSo06 = new string[TongSoTrang + 1];
                _truongSo08 = new string[TongSoTrang + 1];
                if (dataGridView1.RowCount<3)
                {
                    truongso6 = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    truongso8 = dataGridView1.Rows[0].Cells[1].Value.ToString();

                }
                else
                {
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        string temp = "";
                        string[] temp1 = null;


                        if (h < dataGridView1.RowCount)
                        {
                            temp = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : "";
                            if (temp.IndexOf(";", StringComparison.Ordinal) > 0)
                            {
                                temp1 = temp.Split(';');
                                for (int i = 0; i < temp1.Length; i++)
                                {
                                    if (temp1[i].IndexOf("-", StringComparison.Ordinal) > 0)
                                    {
                                        string[] temp2 = temp1[i].Split('-');
                                        for (int j = int.Parse(temp2[0]); j <= int.Parse(temp2[1]); j++)
                                        {
                                            _truongSo06[j] = dr.Cells[0].Value.ToString();
                                            _truongSo08[j] = dr.Cells[1].Value.ToString();
                                        }
                                    }
                                    else
                                    {
                                        _truongSo06[int.Parse(temp1[i])] = dr.Cells[0].Value.ToString();
                                        _truongSo08[int.Parse(temp1[i])] = dr.Cells[1].Value.ToString();
                                    }

                                }
                            }
                            else
                            {
                                if (temp.IndexOf("-", StringComparison.Ordinal) > 0)
                                {
                                    string[] temp2 = temp.Split('-');
                                    for (int j = int.Parse(temp2[0]); j <= int.Parse(temp2[1]); j++)
                                    {
                                        _truongSo06[j] = dr.Cells[0].Value.ToString();
                                        _truongSo08[j] = dr.Cells[1].Value.ToString();
                                    }
                                }
                                else
                                {
                                    _truongSo06[int.Parse(temp)] = dr.Cells[0].Value.ToString();
                                    _truongSo08[int.Parse(temp)] = dr.Cells[1].Value.ToString();
                                }
                            }

                        }
                        h++;
                    }
                }
                
            }

            var f = new PdfFocus();
            f.Serial = "1234567890";

            string pdfFile = txt_ImagePath.Text;
            string imageDir = Path.GetDirectoryName(pdfFile);
            List<Image> pdfImages = new List<Image>();
            f.OpenPdf(pdfFile);
            if (f.PageCount > 0)
            {

                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                f.ImageOptions.Dpi = 200;

                // Set 95 as JPEG quality
                f.ImageOptions.JpegQuality = 95;
                //pdfImages = f.ExtractImages(1, f.PageCount);
                
                // Show all extracted images.
                
                for (int i = 1; i <= f.PageCount; i++)
                {
                    string imageFile = Path.Combine(txt_FolderSaveImage.Text+"\\", "Page"+i+".jpg");
                    int result = f.ToImage(imageFile, i);

                    // Show only 1st page
                    if (result == 0)
                    {
                        pdfImages.Add(f.ToDrawingImage(i));
                        //pdfImages[i].Save(imageFile);
                    }
                        
                }
                
            }
        }

        private void txt_ImagePath_EditValueChanged(object sender, EventArgs e)
        {
            btn_BrowserFolder.Enabled = !string.IsNullOrEmpty(txt_ImagePath.Text);
        }

        private void btn_BrowserFolder_Click(object sender, EventArgs e)
        {
            while (true)
            {
                string dummyFileName = "Save Here";

                SaveFileDialog sf = new SaveFileDialog();
                // Feed the dummy name to the save dialog
                sf.FileName = dummyFileName;
                
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    // Now here's our save folder
                    string savePath = Path.GetDirectoryName(sf.FileName);
                    txt_FolderSaveImage.Text = savePath;
                }
                string[] filePaths = null;
                if (!string.IsNullOrEmpty(txt_FolderSaveImage.Text))
                {
                    filePaths = Directory.GetFiles(txt_FolderSaveImage.Text, "*.jpg");
                }
                
                if (filePaths.Length > 0)
                {
                    MessageBox.Show(@"Folder has image file, choose another folder");
                    continue;
                }
                break;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            UploadImage();

        }
        private void UploadImage()
        {
            Global.db = new DataKomtsuDataContext();
            if (string.IsNullOrEmpty(txt_BatchName.Text))
            {
                MessageBox.Show("No batch name");
                return;
            }
            if (string.IsNullOrEmpty(txt_ImagePath.Text))
            {
                MessageBox.Show("No pdf file selected");
                return;
            }
            if (string.IsNullOrEmpty(txt_FolderSaveImage.Text))
            {
                MessageBox.Show("No path to save the file");
                return;
            }
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                if (dataGridView1.RowCount < 2)
                {
                    MessageBox.Show(@"You haven't filled in the Field 06 or Field 08!");
                    return;
                }
                else if (dataGridView1.RowCount == 2)
                {
                    if (string.IsNullOrEmpty(dataGridView1.Rows[0].Cells[0].Value?.ToString()) || string.IsNullOrEmpty(dataGridView1.Rows[0].Cells[1].Value?.ToString()))
                    {
                        MessageBox.Show(@"You haven't filled in the Field 06 or Field 08 or Field Page!");
                        return;
                    }
                }
                else
                {
                    for (int i = 0; i < dataGridView1.RowCount-1; i++)
                    {
                        if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value?.ToString()) || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value?.ToString()) || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value?.ToString()))
                        {
                            MessageBox.Show(@"You haven't filled in the Field 06 or Field 08 or Field Page!");
                            return;
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txt_TruongSo06_A.Text)||string.IsNullOrEmpty(txt_TruongSo08_A.Text))
                {
                    MessageBox.Show(@"You haven't filled in the Field 06_A or Field 08_A!");
                    return;
                }
            }
           
            ExtractImage();
            string[] filePaths = Directory.GetFiles(txt_FolderSaveImage.Text, "*.jpg");
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = TongSoTrang;
            progressBarControl1.Properties.Minimum = 0;
            var batch = (from w in Global.db.tbl_Batches.Where(w => w.fBatchName == txt_BatchName.Text) select w.fBatchName).FirstOrDefault();

            if (string.IsNullOrEmpty(batch))
            {
                var fBatch = new tbl_Batch
                {
                    fBatchName = txt_BatchName.Text,
                    fusercreate = txt_UserCreate.Text,
                    fdatecreated = DateTime.Now,
                    fPathPicture = txt_ImagePath.Text,
                    fSoLuongAnh = filePaths.Length.ToString(),
                    LoaiBatch = rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString(),
                    CoDeSo = ck_CoDeso.Checked

                };
                Global.db.tbl_Batches.InsertOnSubmit(fBatch);
                Global.db.SubmitChanges();


            }
            else
            {
                MessageBox.Show(@"Batch already exists, please enter another batch name!");
                return;
            }
            string temp = Global.StrPath + "\\" + txt_BatchName.Text;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            else
            {
                MessageBox.Show(@"Coincidence batch name");
                return;
            }
            int k = 1;
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                
                for (int i = 1; i <= TongSoTrang; i++)
                {
                    string filePath = txt_FolderSaveImage.Text + @"\" + "Page" + i+".jpg";
                    FileInfo fi = new FileInfo(filePath);
                    if (dataGridView1.RowCount<3)
                    {
                        tbl_Image tempImage = new tbl_Image
                        {
                            fbatchname = txt_BatchName.Text,
                            idimage = "Page" + i + ".jpg",
                            ReadImageDESo = 0,
                            CheckedDESo = 0,
                            ReadImageDEJP = 0,
                            CheckedDEJP = 0,
                            TienDoDESO = "Image remaining",
                            TienDoDEJP = "Image remaining",
                            Page = i,
                            TruongSo06_A = truongso6,
                            TruongSo08_A = truongso8
                        };
                        Global.db.tbl_Images.InsertOnSubmit(tempImage);
                        Global.db.SubmitChanges();
                    }
                    else
                    {
                        tbl_Image tempImage = new tbl_Image
                        {
                            fbatchname = txt_BatchName.Text,
                            idimage = "Page" + i + ".jpg",
                            ReadImageDESo = 0,
                            CheckedDESo = 0,
                            ReadImageDEJP = 0,
                            CheckedDEJP = 0,
                            TienDoDESO = "Image remaining",
                            TienDoDEJP = "Image remaining",
                            Page = i,
                            TruongSo06_A = _truongSo06[i],
                            TruongSo08_A = _truongSo08[i]
                        };
                        Global.db.tbl_Images.InsertOnSubmit(tempImage);
                        Global.db.SubmitChanges();
                    }
                   

                    k++;
                    string des = temp + @"\" + "Page" + i+".jpg";
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
            }
            else
            {
                for (int i = 1; i <= TongSoTrang; i++)
                {
                    string filePath = txt_FolderSaveImage.Text + @"\" + "Page" + i + ".jpg";
                    FileInfo fi = new FileInfo(filePath);

                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = "Page" + i + ".jpg",
                        ReadImageDESo = 0,
                        CheckedDESo = 0,
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDESO = "Image remaining",
                        TienDoDEJP = "Image remaining",
                        Page = i,
                        TruongSo06_A = txt_TruongSo06_A.Text,
                        TruongSo08_A = txt_TruongSo08_A.Text,
                        TruongSo06_B = txt_TruongSo06_B.Text,
                        TruongSo08_B = txt_TruongSo08_B.Text
                    };
                    Global.db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.db.SubmitChanges();

                    k++;
                    string des = temp + @"\" + "Page" + i + ".jpg";
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
            }
                
            MessageBox.Show(@"Create a new batch successfully!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            txt_FolderSaveImage.Text = "";
            txt_TruongSo06_A.Text = "";
            txt_TruongSo08_A.Text = "";
;           lbl_Page.Text = "";
            dataGridView1.Rows.Clear();
        }

        private bool _flag;
        public void HandlingTimeWork()
        {
            try
            {
                if (!_flag) return;
                TimeSpan timeAdd = new TimeSpan(Convert.ToInt32(nud_songaylam.Value), Convert.ToInt32(nud_sogiolam.Value), Convert.ToInt32(nud_sophutlam.Value), 0);
                DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Year,
                                                    dateEdit_ngaybatdau.DateTime.Month,
                                                    dateEdit_ngaybatdau.DateTime.Day,
                                                    timeEdit_ngaybatdau.Time.Hour,
                                                    timeEdit_ngaybatdau.Time.Minute,
                                                    timeEdit_ngaybatdau.Time.Second);
                DateTime timeEnd = timeStart.Add(timeAdd);
                dateEdit_ngayketthuc.EditValue = timeEnd;
                timeEdit_ngayketthuc.EditValue = timeEnd;
                lb_status.Text = "";
            }
            catch (Exception i)
            {
                lb_status.Text = " Ngày kết thúc không được nhỏ hơn ngày bắt đầu";
            }
        }

        public void HandlingTimeWork_1()
        {
            if(flag_load)
                try
                {
                    if (_flag) return;
                    DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Year,
                                                        dateEdit_ngaybatdau.DateTime.Month,
                                                        dateEdit_ngaybatdau.DateTime.Day,
                                                        timeEdit_ngaybatdau.Time.Hour,
                                                        timeEdit_ngaybatdau.Time.Minute,
                                                        timeEdit_ngaybatdau.Time.Second);
                    DateTime timeEnd = new DateTime(dateEdit_ngayketthuc.DateTime.Year,
                                                        dateEdit_ngayketthuc.DateTime.Month,
                                                        dateEdit_ngayketthuc.DateTime.Day,
                                                        timeEdit_ngayketthuc.Time.Hour,
                                                        timeEdit_ngayketthuc.Time.Minute,
                                                        timeEdit_ngayketthuc.Time.Second);
                    TimeSpan time = timeEnd.Subtract(timeStart);
                    nud_songaylam.Value = time.Days;
                    nud_sogiolam.Value = time.Hours;
                    nud_sophutlam.Value = time.Minutes;
                    lb_status.Text = "";
                }
                catch (Exception e)
                {
                    lb_status.Text = " Ngày kết thúc không được nhỏ hơn ngày bắt đầu";
                }
        }
        private void nud_sophutlam_ValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void dateEdit_ngaybatdau_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void timeEdit_ngaybatdau_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void nud_songaylam_ValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void nud_sogiolam_ValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork();
        }

        private void dateEdit_ngayketthuc_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork_1();
        }

        private void timeEdit_ngayketthuc_EditValueChanged(object sender, EventArgs e)
        {
            HandlingTimeWork_1();
        }

        private void nud_thoigiandeadline_ValueChanged(object sender, EventArgs e)
        {
            DateTime timeStart = new DateTime(dateEdit_ngaybatdau.DateTime.Year,
                                                dateEdit_ngaybatdau.DateTime.Month,
                                                dateEdit_ngaybatdau.DateTime.Day,
                                                timeEdit_ngaybatdau.Time.Hour,
                                                timeEdit_ngaybatdau.Time.Minute,
                                                timeEdit_ngaybatdau.Time.Second);
            DateTime timeEnd = new DateTime(dateEdit_ngayketthuc.DateTime.Year,
                                                dateEdit_ngayketthuc.DateTime.Month,
                                                dateEdit_ngayketthuc.DateTime.Day,
                                                timeEdit_ngayketthuc.Time.Hour,
                                                timeEdit_ngayketthuc.Time.Minute,
                                                timeEdit_ngayketthuc.Time.Second);
            TimeSpan time = timeEnd.Subtract(timeStart);
            if (timeStart > timeEnd)
            {
                lb_status.Text="Ngày kết thúc dự án không được trước ngày bắt đầu";
                return;
            }
            else
            {
                lb_status.Text = "";
            }
            if (cbb_loaithoigian.Text == "Ngày")
            {
                float ngay = (float)time.Days + (float)time.Hours / 24 + (float)time.Minutes / (60 * 24);
                if (Convert.ToSingle(nud_thoigiandeadline.Value) > ngay)
                {
                    lb_status.Text = "Thời gian thông báo deadline không được lớn hơn thời gian thực hiện dự án. Thời gian tối đa: " + time.Days + " ngày "+ time.Hours+" giờ "+ time.Minutes+" Phút";
                    return;
                }
                lb_status.Text = "";
            }
            else if (cbb_loaithoigian.Text == "Giờ")
            {
                float gio = (float)time.Days * 24 + (float)time.Hours + (float)time.Minutes / 60;
                if (Convert.ToSingle(nud_thoigiandeadline.Value) > gio)
                {
                    lb_status.Text = "Thời gian thông báo deadline không được lớn hơn thời gian thực hiện dự án. Thời gian tối đa: " + time.Hours + " giờ" + time.Minutes + " Phút";
                    return;
                }
                lb_status.Text = "";
            }
            else if (cbb_loaithoigian.Text == "Phút")
            {
                float phut = (float)time.Days * (24 * 60) + (float)time.Hours * 60 + (float)time.Minutes;
                if (Convert.ToSingle(nud_thoigiandeadline.Value) > phut)
                {
                    lb_status.Text = "Thời gian thông báo deadline không được lớn hơn thời gian thực hiện dự án. Thời gian tối đa: " + time.Minutes + " phút";
                    return;
                }
                lb_status.Text = "";
            }
        }

        private void cbb_loaithoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            nud_thoigiandeadline_ValueChanged(null, null);
        }

        private void nud_thoigiandeadline_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbb_loaithoigian.Text))
            {
                MessageBox.Show(string.Format("Bạn{0} hãy chọn kiểu thời gian", ""));
                nud_thoigiandeadline.Value = 0; return;
            }
        }

        private void dateEdit_ngaybatdau_Click(object sender, EventArgs e)
        {
            _flag = true;
        }

        private void timeEdit_ngaybatdau_Click(object sender, EventArgs e)
        {
            _flag = true;
        }

        private void nud_songaylam_Click(object sender, EventArgs e)
        {
            _flag = true;
        }

        private void nud_sogiolam_Click(object sender, EventArgs e)
        {
            _flag = true;
        }

        private void nud_sophutlam_Click(object sender, EventArgs e)
        {
            _flag = true;
        }

        private void dateEdit_ngayketthuc_Click(object sender, EventArgs e)
        {
            _flag = false;
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void timeEdit_ngayketthuc_Click(object sender, EventArgs e)
        {
            _flag = false;
        }

        private void rb_LoaiBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                txt_TruongSo06_A.Text = "";
                txt_TruongSo08_A.Text = "";
                txt_TruongSo06_A.Enabled = false;
                txt_TruongSo08_A.Enabled = false;

                txt_TruongSo06_B.Text = "";
                txt_TruongSo08_B.Text = "";
                txt_TruongSo06_B.Enabled = false;
                txt_TruongSo08_B.Enabled = false;

                dataGridView1.Enabled = true;

                //dataGridView1.Visible = true;

                //labelControl3.Visible = false;
                //labelControl4.Visible = false;
                //txt_TruongSo06.Visible = false;
                //txt_TruongSo08.Visible = false;
            }
            else
            {
                txt_TruongSo06_A.Enabled = true;
                txt_TruongSo08_A.Enabled = true;

                txt_TruongSo06_B.Enabled = true;
                txt_TruongSo08_B.Enabled = true;

                //labelControl3.Visible = true;
                //labelControl4.Visible = true;
                //txt_TruongSo06.Visible = true;
                //txt_TruongSo08.Visible = true;

                dataGridView1.Rows.Clear();
                dataGridView1.Enabled = false;

                //dataGridView1.Visible = false;

            }
        }
    }
}