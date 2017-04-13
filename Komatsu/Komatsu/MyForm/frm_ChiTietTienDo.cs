using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace KOMTSU.MyForm
{
    public partial class frm_ChiTietTienDo : XtraForm
    {
        public string Loai;
        public frm_ChiTietTienDo()
        {
            InitializeComponent();
        }

        private void frm_ChiTietTienDo_Load(object sender, EventArgs e)
        {
            lb_TongSoHinh.Text =(from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text select w.idimage).Count().ToString();
            if (Loai=="DESO")
            {
                lb_SoHinhChuaNhap.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDESO == "Image remaining" select w.idimage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDESO == "Image is doing" select w.idimage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDESO == "Image waiting for check" select w.idimage).Count().ToString();
                lb_SoHinhDangCheck.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDESO == "Image is checking" select w.idimage).Count().ToString();
                lb_SoHinhHoanThanh.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDESO == "Image completed" select w.idimage).Count().ToString();

                gridControl1.DataSource = null;
                gridControl1.DataSource = Global.db.ChiTietTienDo_DeSo(lb_fBatchName.Text);
                gridView1.RowCellStyle += GridView1_RowCellStyle;
            }
            else
            {
                lb_SoHinhChuaNhap.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Image remaining" select w.idimage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Image is doing" select w.idimage).Count().ToString();
                lb_SoHinhChoCheck.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Image waiting for check" select w.idimage).Count().ToString();
                lb_SoHinhDangCheck.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Image is checking" select w.idimage).Count().ToString();
                lb_SoHinhHoanThanh.Text = (from w in Global.db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Image completed" select w.idimage).Count().ToString();
                gridControl1.DataSource = null;
                gridControl1.DataSource = Global.db.ChiTietTienDo_DeJP(lb_fBatchName.Text);
                gridView1.RowCellStyle += GridView1_RowCellStyle;
            }
        }

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            
            if (e.Column.FieldName == "ThongTin")
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ThongTin"]);
                if (category == "Image is doing")
                {
                    e.Appearance.BackColor = Color.HotPink;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Image waiting for check")
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Image is checking")
                {
                    e.Appearance.BackColor = Color.Purple;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Image completed")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
        private void popupContainerControl1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void repositoryItemPopupContainerEdit1_Click(object sender, EventArgs e)
        {
            string idimage = gridView1.GetFocusedRowCellValue("idimage").ToString();
            gridControl2.DataSource = null;
            if (Loai == "DESO")
            {
                gridControl2.DataSource = Global.db.ChiTietUserDeSo(lb_fBatchName.Text, idimage);
            }
            else
            {
                gridControl2.DataSource = Global.db.ChiTietUserDeJP(lb_fBatchName.Text, idimage);
            }
        }
    }
}