using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Komatsu.Properties;

namespace KOMTSU.MyForm
{
    public partial class frm_ChangeZoom : XtraForm
    {
        public frm_ChangeZoom()
        {
            InitializeComponent();
        }

        private void frm_ChangeZoom_Load(object sender, EventArgs e)
        {
            trackBarControl1.EditValue = Settings.Default.ZoomImage;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.ZoomImage = Convert.ToInt32(trackBarControl1.EditValue);
            Settings.Default.Save();
            MessageBox.Show(string.Format("Thay {0}đổi Zoom thành công!", ""));
            Close();
        }
    }
}