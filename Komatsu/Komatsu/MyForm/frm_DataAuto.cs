﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace KOMTSU.MyForm
{
    public partial class frm_DataAuto : XtraForm
    {
        public frm_DataAuto()
        {
            InitializeComponent();
        }
        public bool Cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
            return true;
        }

        private void LoadSttGridView(RowIndicatorCustomDrawEventArgs e, GridView dgv)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            SizeF size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
            int width = Convert.ToInt32(size.Width) + 20;
            BeginInvoke(new MethodInvoker(delegate { Cal(width, dgv); }));
        }
        private void frm_DataAuto_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource =(from w in Global.db.tbl_DataAutoCompletes select new {w.Id, w.DataAutoComplete}).ToList();}

        private void dgv_data_auto_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, dgv_data_auto);
        }

        private void dgv_data_auto_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            txt_data.Text = dgv_data_auto.GetRowCellValue(dgv_data_auto.FocusedRowHandle, "DataAutoComplete").ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            int r = Global.db.InSertDataAutoComplete(txt_data.Text);

            if (r == 1)
            {
                MessageBox.Show(@"Data already exists. Please check again");
            }
            else if (r == 0)
            {
                gridControl1.DataSource =
                    (from w in Global.db.tbl_DataAutoCompletes select new {w.Id, w.DataAutoComplete}).ToList();
                MessageBox.Show(@"Save the data successfully");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string data = dgv_data_auto.GetRowCellValue(dgv_data_auto.FocusedRowHandle, "DataAutoComplete").ToString();
            DialogResult thongbao = MessageBox.Show(@"You want to edit the data : " + data + @" to : "+txt_data.Text+"", @"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes){
                int r = Global.db.UpdateDataAutoComplete(Convert.ToInt32(dgv_data_auto.GetRowCellValue(dgv_data_auto.FocusedRowHandle, "Id").ToString()), txt_data.Text);
                if (r == 1)
                {
                    gridControl1.DataSource =
                   (from w in Global.db.tbl_DataAutoCompletes select new { w.Id, w.DataAutoComplete }).ToList();
                    MessageBox.Show(@"Save the data successfully");
                }
                else if (r == 0)
                {
                    MessageBox.Show(@"Fix failed data, Please check again");
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string data = dgv_data_auto.GetRowCellValue(dgv_data_auto.FocusedRowHandle, "Id").ToString();
            DialogResult thongbao = MessageBox.Show(@"You want to delete row data : '" + data + "'", @"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.db.DeleteDataAutoComplete(Convert.ToInt32(dgv_data_auto.GetRowCellValue(dgv_data_auto.FocusedRowHandle, "Id").ToString()));
                if (r == 1)
                {
                    gridControl1.DataSource =
                   (from w in Global.db.tbl_DataAutoCompletes select new { w.Id, w.DataAutoComplete }).ToList();
                    MessageBox.Show(@"Delete the data successfully");
                }
                else if (r == 0)
                {
                    MessageBox.Show(@"Delete failed data, Please check again");
                }
            }
        }
    }
}