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
    }
}