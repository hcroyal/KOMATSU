using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KOMTSU;
using KOMTSU.MyForm;

namespace Komatsu.MyForm
{
    public partial class frm_ManagerBatch : DevExpress.XtraEditors.XtraForm
    {
        public frm_ManagerBatch()
        {
            InitializeComponent();
        }

        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
            new frm_CreateBatch().ShowDialog();
            RefreshBatch();
        }
        private void RefreshBatch()
        {
            var temp = from var in Global.db.tbl_Batches orderby var.fdatecreated select var;
            gridControl1.DataSource = temp;
        }

        private void frm_ManagerBatch_Load(object sender, EventArgs e)
        {
            RefreshBatch();
        }

        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            string fbatchname = gridView1.GetFocusedRowCellValue("fBatchName").ToString();
            string temp = Global.StrPath + "\\" + fbatchname;
            if (MessageBox.Show("You definitely want to delete the batch: " + fbatchname + "?", "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Global.db.XoaBatch(fbatchname);
                    Directory.Delete(temp, true);
                    MessageBox.Show("Delete the batch successfully!");

                }
                catch (Exception)
                {

                    MessageBox.Show("Delete batch Error!");

                }

            }
            RefreshBatch();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string fbatchname = gridView1.GetFocusedRowCellValue("fBatchName").ToString();
            int kt = (from w in Global.db.tbl_Images where w.ReadImageDESo != 0 || w.ReadImageDEJP != 0 select w.idimage).Count();
            if (kt>0)
            {
                MessageBox.Show("Batch này đã có người nhập!");
                RefreshBatch();
                return;
            }
            if (e.Column.FieldName == "CoDeSo")
            {
                bool check_ = (bool)e.Value;

                if (check_)
                {
                    Global.db.CoDeSo(fbatchname, true);
                    //MessageBox.Show("Đã công khai batch: " + fbatchname);
                }
                else
                {
                    Global.db.CoDeSo(fbatchname, false);
                    //MessageBox.Show("Đã tắt công khai batch: " + fbatchname);
                }
            }
            RefreshBatch();
        }
    }
}