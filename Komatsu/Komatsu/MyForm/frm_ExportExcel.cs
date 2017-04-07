using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Komatsu.Properties;
using Microsoft.Office.Interop.Excel;

namespace KOMTSU.MyForm
{
    public partial class frm_ExportExcel : Form
    {
        string LoaiPhieu = "";

        public frm_ExportExcel()
        {
            InitializeComponent();
        }

        private String getcharacter(int n, String str)
        {
            String kq = "";
            for (int i = 1; i <= n; i++)
            {
                kq = kq.Insert(kq.Length, str);
            }

            return kq;
        }

        private String ThemKyTubatKyPhiatruoc(String input, int iByte, string str)
        {
            if (input.Length >= iByte)
                return input.Substring(input.Length - iByte, iByte);

            return input.Insert(0, getcharacter(iByte - input.Length, str));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbb_Batch.Items.Clear();
            var result = from w in Global.db.tbl_Batches
                select w.fBatchName;

            if (result.Count() > 0)
            {
                cbb_Batch.Items.AddRange(result.ToArray());
                cbb_Batch.DisplayMember = "fBatchName";
                cbb_Batch.ValueMember = "fbatchname";
                cbb_Batch.Text = Global.StrBatch;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);
            if (string.IsNullOrEmpty(cbb_Batch.Text))
            {
                MessageBox.Show("Chưa chọn batch.");
                return;
            }

            //Kiểm tra nhập xong chưa?



            var result = Global.db.InputFinish(cbb_Batch.Text);
            if (result == 1)
            {
                MessageBox.Show("Batch này chưa nhập xong. Vui lòng nhập xong batch trước khi ExportExcel.");
                return;
            }
            var userMissimage = Global.db.UserMissIMage(cbb_Batch.Text).ToList();
            string sss = "";
            foreach (var item in userMissimage)
            {
                sss += item + "\r\n";
            }

            if (userMissimage.Count > 0)
            {
                MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                return;
            }

            //Kiểm tra check xong chưa
            var xyz = Global.db.CheckerFinish(cbb_Batch.Text);

            if (xyz != 0)
            {
                MessageBox.Show("Chưa check xong hoặc có user lấy về nhưng chưa check. Vui lòng check trước");

                var u = (from w in Global.db.UserMissIMageCheck(cbb_Batch.Text)
                    select w.UserName).ToList();
                string sssss = "";
                foreach (var item in u)
                {
                    sssss += item + "\r\n";
                }

                if (u.Count > 0)
                {
                    MessageBox.Show("Danh sách checker lấy hình về nhưng chưa check: \r\n" + sssss);
                }

                return;
            }
            LoaiPhieu =(from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch.Text select w.LoaiBatch).FirstOrDefault();

            if (LoaiPhieu == "Loai1")
            {
                //EXport Excel Loại 1

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\ExportExcel_Loai1.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\ExportExcel_Loai1.xlsx");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel_Loai1.xlsx"),Resources.ExportExcel_Loai1);
                }
                else
                {
                    File.WriteAllBytes(
                        (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel_Loai1.xlsx"),Resources.ExportExcel_Loai1);
                }
                TableToExcel_Loai1(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\ExportExcel_Loai1.xlsx");
            }
            else if (LoaiPhieu == "Loai2")
            {
                //EXport Excel Loại 2
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Loai2.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\ExportExcel_Loai2.xlsx");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel_Loai2.xlsx"), Resources.ExportExcel_Loai2);
                }
                else
                {
                    File.WriteAllBytes(
                        (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel_Loai2.xlsx"), Resources.ExportExcel_Loai2);
                }
                TableToExcel_Loai2(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Loai2.xlsx");
            }
        }

        public bool TableToExcel_Loai1(String strfilename)
        {
            try
            {
                bool DeSo =Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch.Text select w.CoDeSo).FirstOrDefault());
                dataGridView1.DataSource = null;
                if (DeSo)
                {
                    dataGridView1.DataSource = Global.db.ExportExcel_Loai1_CoDeSo(cbb_Batch.Text);
                }
                else
                {
                    dataGridView1.DataSource = Global.db.ExportExcel_Loai1(cbb_Batch.Text);
                }

                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false, XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
                Sheets _sheet = book.Sheets;
                Worksheet wrksheet = (Worksheet) book.ActiveSheet;
                int h = 2;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : ""; //số trang
                    wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : ""; //truong 02
                    wrksheet.Cells[h, 3] = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : ""; //03
                    wrksheet.Cells[h, 4] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : ""; //04
                    wrksheet.Cells[h, 5] = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : ""; //05
                    wrksheet.Cells[h, 6] = dr.Cells[5].Value != null ? dr.Cells[5].Value.ToString() : ""; //06
                    wrksheet.Cells[h, 7] = dr.Cells[6].Value != null ? dr.Cells[6].Value.ToString() : ""; //07
                    wrksheet.Cells[h, 8] = dr.Cells[7].Value != null ? dr.Cells[7].Value.ToString() : ""; //08
                    wrksheet.Cells[h, 9] = dr.Cells[8].Value != null ? dr.Cells[8].Value.ToString() : ""; //09
                    wrksheet.Cells[h, 10] = dr.Cells[9].Value != null ? dr.Cells[9].Value.ToString() : ""; //10
                    wrksheet.Cells[h, 11] = dr.Cells[10].Value != null ? dr.Cells[10].Value.ToString() : ""; //11
                    wrksheet.Cells[h, 12] = dr.Cells[11].Value != null ? dr.Cells[11].Value.ToString() : ""; //12

                    lb_SoDong.Text = (h - 1) + "/" + dataGridView1.Rows.Count;
                    Range rowHead = wrksheet.get_Range("A2", "L" + h);
                    rowHead.Borders.LineStyle = Constants.xlSolid;
                    h++;
                }
                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = cbb_Batch.Text;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    App.Quit();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xuất excel!");
                    return false;
                }
                Process.Start(savePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool TableToExcel_Loai2(String strfilename)
        {
            try
            {
                bool DeSo = Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch.Text select w.CoDeSo).FirstOrDefault());
                dataGridView1.DataSource = null;
                if (DeSo)
                {
                    dataGridView1.DataSource = Global.db.ExportExcel_Loai2_CoDeSo(cbb_Batch.Text);
                }
                else
                {
                    dataGridView1.DataSource = Global.db.ExportExcel_Loai2(cbb_Batch.Text);
                }

                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false, XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
                Sheets _sheet = book.Sheets;
                Worksheet wrksheet = (Worksheet) book.ActiveSheet;
                int h = 2;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : ""; //số trang
                    wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";//truong 02
                    wrksheet.Cells[h, 3] = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : ""; //03
                    wrksheet.Cells[h, 4] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : ""; //04
                    wrksheet.Cells[h, 5] = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : ""; //05
                    wrksheet.Cells[h, 6] = dr.Cells[5].Value != null ? dr.Cells[5].Value.ToString() : ""; //06
                    wrksheet.Cells[h, 7] = dr.Cells[6].Value != null ? dr.Cells[6].Value.ToString() : ""; //08
                    wrksheet.Cells[h, 8] = dr.Cells[7].Value != null ? dr.Cells[7].Value.ToString() : ""; //10
                    wrksheet.Cells[h, 9] = dr.Cells[8].Value != null ? dr.Cells[8].Value.ToString() : ""; //11

                    lb_SoDong.Text = (h - 1) + "/" + dataGridView1.Rows.Count;
                    Range rowHead = wrksheet.get_Range("A2", "I" + h);
                    rowHead.Borders.LineStyle = Constants.xlSolid;
                    h++;
                }

                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = cbb_Batch.Text + "_QC";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    App.Quit();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xuất excel!");
                    return false;
                }
                Process.Start(savePath);

                return true;
            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
