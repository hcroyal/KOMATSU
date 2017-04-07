using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)//Nếu ô thứ i của cột thứ 1 (cột sau cột STT ấy) mà có dữ liệu thì gán giá trị cho cột STT, nếu không thì cột STT cũng không có dữ liệu lun
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
            }
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
                MessageBox.Show("Vui lòng điền tên batch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        class dataPage
        {
            public string TruongSo06;
            public string TruongSo08;
            public int SoTrang;
        }

        private List<dataPage> dtPages;
        private void ExtractImage()
        {
            int h = 1;
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                string[] TruongSo06 = new string[TongSoTrang + 1];
                dtPages = new List<dataPage>();

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
                                        TruongSo06[j] = dr.Cells[0].Value.ToString();
                                        dtPages[j].TruongSo06 = dr.Cells[0].Value.ToString();
                                        dtPages[j].TruongSo08 = dr.Cells[1].Value.ToString();
                                        dtPages[j].SoTrang = j;
                                    }
                                }
                                else
                                {
                                    TruongSo06[int.Parse(temp1[i])] = dr.Cells[0].Value.ToString();
                                    dtPages[int.Parse(temp1[i])].TruongSo06 = dr.Cells[0].Value.ToString();
                                    dtPages[int.Parse(temp1[i])].TruongSo08 = dr.Cells[1].Value.ToString();
                                    dtPages[int.Parse(temp1[i])].SoTrang = int.Parse(temp1[i]);
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
                                    TruongSo06[j] = dr.Cells[0].Value.ToString();
                                    dtPages[j].TruongSo06 = dr.Cells[0].Value.ToString();
                                    dtPages[j].TruongSo08 = dr.Cells[1].Value.ToString();
                                    dtPages[j].SoTrang = j;
                                }
                            }
                            else
                            {
                                TruongSo06[int.Parse(temp)] = dr.Cells[0].Value.ToString();
                                dtPages[int.Parse(temp)].TruongSo06 = dr.Cells[0].Value.ToString();
                                dtPages[int.Parse(temp)].TruongSo08 = dr.Cells[1].Value.ToString();
                                dtPages[int.Parse(temp)].SoTrang = int.Parse(temp);
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
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            UploadImage();

        }
        private void UploadImage()
        {
            ExtractImage();
            string[] filePaths = Directory.GetFiles(txt_FolderSaveImage.Text, "*.jpg");
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = _lFileNames.Length;
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
                MessageBox.Show("Batch đã tồn tại vui lòng điền tên batch khác!");
                return;
            }
            string temp = Global.StrPath + "\\" + txt_BatchName.Text;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            else
            {
                MessageBox.Show("Bị trùng tên batch!");
                return;
            }
            int k = 1;
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                foreach (string i in filePaths)
                {
                    FileInfo fi = new FileInfo(i);

                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDESo = 0,
                        CheckedDESo = 0,
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDESO = "Hình chưa nhập",
                        TienDoDEJP = "Hình chưa nhập",
                        Page = k,
                        TruongSo06 = dtPages[k].TruongSo06,
                        TruongSo08 = dtPages[k].TruongSo08
                    };
                    Global.db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.db.SubmitChanges();

                    k++;
                    string des = temp + @"\" + Path.GetFileName(fi.ToString());
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
            }
            else
            {
                foreach (string i in filePaths)
                {
                    FileInfo fi = new FileInfo(i);

                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDESo = 0,
                        CheckedDESo = 0,
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDESO = "Hình chưa nhập",
                        TienDoDEJP = "Hình chưa nhập",
                        Page = k,
                        TruongSo06 = txt_TruongSo06.Text,
                        TruongSo08 = txt_TruongSo08.Text
                    };
                    Global.db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.db.SubmitChanges();

                    k++;
                    string des = temp + @"\" + Path.GetFileName(fi.ToString());
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
            }
                
            MessageBox.Show("Tạo batch mới thành công!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            txt_FolderSaveImage.Text = "";
            txt_TruongSo06.Text = "";
            txt_TruongSo08.Text = "";
;           lbl_Page.Text = "";

        }

        private void rb_LoaiBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rb_LoaiBatch.Properties.Items[rb_LoaiBatch.SelectedIndex].Value.ToString() == "Loai1")
            {
                txt_TruongSo06.Enabled = false;
                txt_TruongSo08.Enabled = false;
                dataGridView1.Enabled = true;
            }
            else
            {
                txt_TruongSo06.Enabled = true;
                txt_TruongSo08.Enabled = true;
                dataGridView1.Enabled = false;
            }
        }
    }
}