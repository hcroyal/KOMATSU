using System;
using System.Data;
using System.Linq;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace KOMTSU.MyForm
{
    public partial class frm_TienDo : XtraForm
    {
        private string loai;
        public frm_TienDo()
        {
            InitializeComponent();
        }

        private void frm_TienDo_Load(object sender, EventArgs e)
        {
            //btn_ChiTiet.Visible = false;
            //radioGroup1.Visible = false;
            var fBatchName = (from w in Global.db.tbl_Batches orderby w.IDBatch select new { w.fBatchName }).ToList();
            cbb_Batch.Properties.DataSource = fBatchName;
            cbb_Batch.Properties.DisplayMember = "fBatchName";
            cbb_Batch.Properties.ValueMember = "fBatchName";
            cbb_Batch.Text = Global.StrBatch;
            //if (cbb_Batch.Text == "Không có batch")
            //{
            //    btn_ChiTiet.Visible = false;
            //    radioGroup1.Visible = false;//}
            //else
            //{
            //    btn_ChiTiet.Visible = true;
            //    radioGroup1.Visible = true;
            //}
        }
        private void ThongKe()
        {
            try
            {
                bool CoDeSo = Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch.Text select w.CoDeSo).FirstOrDefault());

                if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value == "DESO" && !CoDeSo)
                {
                    chartControl1.DataSource = null;chartControl1.Series.Clear();
                    btn_ChiTiet.Visible = false;
                }
                else if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value == "DESO" && CoDeSo)
                {
                    chartControl1.DataSource = null;
                    chartControl1.Series.Clear();
                    chartControl1.DataSource = Global.db.ThongKeTienDo_DeSo(cbb_Batch.Text);
                    Series series1 = new Series("Series1", ViewType.Pie);
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "name";
                    series1.ValueScaleType = ScaleType.Numerical;
                    series1.ValueDataMembers.AddRange(new string[] { "soluong" });
                    chartControl1.Series.Add(series1);
                    ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                    chartControl1.PaletteName = "Palette 1";
                    loai = "DESO";
                    btn_ChiTiet.Visible = true;
                }
                else
                {
                    chartControl1.DataSource = null;
                    chartControl1.Series.Clear();
                    chartControl1.DataSource = Global.db.ThongKeTienDo_DeJP(cbb_Batch.Text);
                    Series series1 = new Series("Series1", ViewType.Pie);
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "name";
                    series1.ValueScaleType = ScaleType.Numerical;
                    series1.ValueDataMembers.AddRange(new string[] { "soluong" });
                    chartControl1.Series.Add(series1);
                    ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                    chartControl1.PaletteName = "Palette 1";
                    loai = "DEJP";
                    btn_ChiTiet.Visible = true;}
               
            }
            catch (Exception)
            {

            }

        }

        private void cbb_Batch_EditValueChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            var frm = new frm_ChiTietTienDo();
            frm.lb_fBatchName.Text = cbb_Batch.Text;
            frm.Loai = loai;
            frm.ShowDialog();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe();
        }
    }
}