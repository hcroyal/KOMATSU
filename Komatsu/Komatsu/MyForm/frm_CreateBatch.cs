using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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

        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            btn_BrowserPDF.Enabled = false;
            btn_BrowserFolder.Enabled = false;
            txt_UserCreate.Text = Global.StrUsername;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToShortTimeString();

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
        private void ExtractImage()
        {
            int h = 1;
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                _truongSo06 = new string[TongSoTrang + 1];
                _truongSo08 = new string[TongSoTrang + 1];
               
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

            var f = new PdfFocus {Serial = "1234567890"};
            string pdfFile = txt_ImagePath.Text;
            string imageDir = Path.GetDirectoryName(pdfFile);
            List<PdfFocus.PdfImage> pdfImages = null;
            f.OpenPdf(pdfFile);
            if (f.PageCount > 0)
            {
                pdfImages = f.ExtractImages(1, f.PageCount);

                // Show all extracted images.
                if (pdfImages != null && pdfImages.Count > 0)
                {

                    for (int i = 0; i < pdfImages.Count; i++)
                    {
                        string imageFile = Path.Combine(txt_FolderSaveImage.Text+"\\", "Page"+(i+1)+".jpg");
                        pdfImages[i].Picture.Save(imageFile);
                        
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
                string[] filePaths = Directory.GetFiles(txt_FolderSaveImage.Text, "*.jpg");
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
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                if (dataGridView1.RowCount == 1)
                {
                    MessageBox.Show(@"You haven't filled in the Field 06 or Field 08!");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txt_TruongSo06.Text)||string.IsNullOrEmpty(txt_TruongSo08.Text))
                {
                    MessageBox.Show(@"You haven't filled in the Field 06 or Field 08!");
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

                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = "Page"+i+".jpg",
                        ReadImageDESo = 0,
                        CheckedDESo = 0,
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDESO = "Hình chưa nhập",
                        TienDoDEJP = "Hình chưa nhập",
                        Page = i,
                        TruongSo06 = _truongSo06[i],
                        TruongSo08 = _truongSo08[i]
                    };
                    Global.db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.db.SubmitChanges();

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
                        TienDoDESO = "Hình chưa nhập",
                        TienDoDEJP = "Hình chưa nhập",
                        Page = i,
                        TruongSo06 = txt_TruongSo06.Text,
                        TruongSo08 = txt_TruongSo08.Text
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
            txt_TruongSo06.Text = "";
            txt_TruongSo08.Text = "";
;           lbl_Page.Text = "";
            dataGridView1.Rows.Clear();
        }
        
        private void rb_LoaiBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                txt_TruongSo06.Text = "";
                txt_TruongSo08.Text = "";
                txt_TruongSo06.Enabled = false;
                txt_TruongSo08.Enabled = false;

                dataGridView1.Enabled = true;

                //dataGridView1.Visible = true;

                //labelControl3.Visible = false;
                //labelControl4.Visible = false;
                //txt_TruongSo06.Visible = false;
                //txt_TruongSo08.Visible = false;
            }
            else
            {
                txt_TruongSo06.Enabled = true;
                txt_TruongSo08.Enabled = true;

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