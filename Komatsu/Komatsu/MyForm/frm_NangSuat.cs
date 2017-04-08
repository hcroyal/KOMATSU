using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Komatsu.Properties;

namespace KOMTSU.MyForm
{
    public partial class frm_NangSuat : DevExpress.XtraEditors.XtraForm
    {
        private DateTime firstDateTime;
        private DateTime lastDateTime;
        public frm_NangSuat()
        {
            InitializeComponent();
        }

        private void frm_NangSuat_Load(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            LoadDataGrid(firstDateTime, lastDateTime);
        }
        private void LoadDataGrid(DateTime TuNgay, DateTime DenNgay)
        {
            gridControl_DeSo.DataSource = Global.db.NangSuatDeSo(TuNgay, DenNgay);
            gridControl_DeJP.DataSource = Global.db.NangSuatDeJP(TuNgay, DenNgay);
            //gridView1.RowCellStyle += GridView1_RowCellStyle;
            //gridView2.RowCellStyle += GridView1_RowCellStyle;
        }

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            //doi mau row chan
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)//    {
                    e.Appearance.BackColor = Color.LavenderBlush;
                else
                {
                    e.Appearance.BackColor = Color.BlanchedAlmond;
                }
            }
        }

        private void dtp_FirstDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            gridControl_DeJP.DataSource = null;
            if (firstDateTime >= lastDateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

        private void dtp_EndDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            gridControl_DeJP.DataSource = null;
            if (firstDateTime > lastDateTime)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }

        }
        public bool TableToExcel(String strfilename, DataGridView dgv)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Microsoft.Office.Interop.Excel.Sheets _sheet = (Microsoft.Office.Interop.Excel.Sheets) book.Sheets;
                Microsoft.Office.Interop.Excel.Worksheet wrksheet =
                    (Microsoft.Office.Interop.Excel.Worksheet) book.ActiveSheet;
                int h = 1;
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    wrksheet.Cells[h + 2, 1] = h;

                    wrksheet.Cells[h + 2, 2] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : "";
                    wrksheet.Cells[h + 2, 3] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";
                    wrksheet.Cells[h + 2, 4] = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : "";
                    wrksheet.Cells[h + 2, 5] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : "";
                    wrksheet.Cells[h + 2, 6] = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : "";
                    wrksheet.Cells[h + 2, 7] = dr.Cells[5].Value != null ? dr.Cells[5].Value.ToString() : "";
                    wrksheet.Cells[h + 2, 8] = dr.Cells[6].Value != null ? dr.Cells[6].Value.ToString() : "";

                    h++;
                }
            
                string savePath = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                if(xtraTabControl1.SelectedTabPage==tp_DeJP)
                {
                    saveFileDialog1.FileName = "NangSuat_DeJP_" + dtp_FirstDay.Value.Day + "-" + dtp_EndDay.Value.Day;
                }
                else if(xtraTabControl1.SelectedTabPage==tp_DeSo)
                {
                    saveFileDialog1.FileName = "NangSuat_DeSo_Loai2_" + dtp_FirstDay.Value.Day + "-" + dtp_EndDay.Value.Day;
                }
                else
                    saveFileDialog1.FileName = "NangSuat_DeSo_Loai4_" + dtp_FirstDay.Value.Day + "-" + dtp_EndDay.Value.Day;

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable dt;
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            
            if(xtraTabControl1.SelectedTabPage==tp_DeJP)
            {
                dataGridView1.DataSource = Global.db.NangSuatDeJP(firstDateTime, lastDateTime);
                if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Productivity_DEJP.xls"))
                {
                    System.IO.File.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Productivity_DEJP.xls");
                    System.IO.File.WriteAllBytes((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Productivity_DEJP.xls"), Resources.Productivity_DEJP);
                }
                else
                {
                    System.IO.File.WriteAllBytes((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Productivity_DEJP.xls"), Resources.Productivity_DEJP);
                }
                TableToExcel((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Productivity_DEJP.xls"), dataGridView1);
            }
            else if(xtraTabControl1.SelectedTabPage==tp_DeSo)
            {
                dataGridView1.DataSource = Global.db.NangSuatDeSo(firstDateTime, lastDateTime);
                if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Productivity_DESO.xls"))
                {
                    System.IO.File.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Productivity_DESO.xls");
                    System.IO.File.WriteAllBytes((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Productivity_DESO.xls"), Resources.Productivity_DESO);
                }
                else
                {
                    System.IO.File.WriteAllBytes((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Productivity_DESO.xls"), Resources.Productivity_DESO);
                }
                TableToExcel((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Productivity_DESO.xls"), dataGridView1);
            }
        }
    }
}