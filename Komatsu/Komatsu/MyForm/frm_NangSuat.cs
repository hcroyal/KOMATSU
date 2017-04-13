using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Komatsu.Properties;
using Microsoft.Office.Interop.Excel;

namespace KOMTSU.MyForm
{
    public partial class frm_NangSuat : XtraForm
    {
        private DateTime _firstDateTime;
        private DateTime _lastDateTime;
        public frm_NangSuat()
        {
            InitializeComponent();
        }

        private void frm_NangSuat_Load(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            _firstDateTime = DateTime.Parse(firstdate);
            _lastDateTime = DateTime.Parse(lastdate);
            LoadDataGrid(_firstDateTime, _lastDateTime);
        }
        private void LoadDataGrid(DateTime TuNgay, DateTime DenNgay)
        {
            gridControl_DeSo.DataSource = Global.db.NangSuatDeSo(TuNgay, DenNgay);
            gridControl_DeJP.DataSource = Global.db.NangSuatDeJP(TuNgay, DenNgay);
        }
        
        private void dtp_FirstDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            _firstDateTime = DateTime.Parse(firstdate);
            _lastDateTime = DateTime.Parse(lastdate);
            gridControl_DeJP.DataSource = null;
            if (_firstDateTime >= _lastDateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc");
            }
            else
            {
                LoadDataGrid(_firstDateTime, _lastDateTime);
            }
        }

        private void dtp_EndDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            _firstDateTime = DateTime.Parse(firstdate);
            _lastDateTime = DateTime.Parse(lastdate);
            gridControl_DeJP.DataSource = null;
            if (_firstDateTime > _lastDateTime)
            {
                MessageBox.Show(@"Start date must be less than end date");
            }
            else
            {
                LoadDataGrid(_firstDateTime, _lastDateTime);
            }

        }
        public bool TableToExcel(string strfilename, DataGridView dgv)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false,XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Worksheet wrksheet =(Worksheet) book.ActiveSheet;
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
                saveFileDialog1.Title = @"Save Excel Files";
                saveFileDialog1.Filter = @"Excel files (*.xls)|*.xls";
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
                    MessageBox.Show(@"Error export excel!");
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
            _firstDateTime = DateTime.Parse(firstdate);
            _lastDateTime = DateTime.Parse(lastdate);
            
            if(xtraTabControl1.SelectedTabPage==tp_DeJP)
            {
                dataGridView1.DataSource = Global.db.NangSuatDeJP(_firstDateTime, _lastDateTime);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity_DEJP.xls"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity_DEJP.xls");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity_DEJP.xls"), Resources.Productivity_DEJP);
                }
                else
                {
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity_DEJP.xls"), Resources.Productivity_DEJP);
                }
                TableToExcel((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity_DEJP.xls"), dataGridView1);
            }
            else if(xtraTabControl1.SelectedTabPage==tp_DeSo)
            {
                dataGridView1.DataSource = Global.db.NangSuatDeSo(_firstDateTime, _lastDateTime);
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity_DESO.xls"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity_DESO.xls");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity_DESO.xls"), Resources.Productivity_DESO);
                }
                else
                {
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity_DESO.xls"), Resources.Productivity_DESO);
                }
                TableToExcel((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity_DESO.xls"), dataGridView1);
            }
        }
    }
}