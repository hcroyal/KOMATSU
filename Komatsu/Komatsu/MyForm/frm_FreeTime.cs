using System;
using System.Windows.Forms;

namespace KOMTSU.MyForm
{
    public partial class frm_FreeTime : DevExpress.XtraEditors.XtraForm
    {
        private int gio, phut, giay;
        public frm_FreeTime()
        {
            InitializeComponent();
        }

        private void frm_FreeTime_Load(object sender, EventArgs e)
        {
            giay = Global.FreeTime;
            gio = giay / 3600;
            phut = (giay - (gio * 3600)) / 60;
            giay = giay - (gio * 3600 + phut * 60);

            lb_time.Text = gio.ToString("D2") + ":" + phut.ToString("D2") + ":" + giay.ToString("D2");

            timer1.Start();
        }

        private void frm_FreeTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                Close();
            }
            
        }

        private void frm_FreeTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Global.FreeTime++;
            giay = Global.FreeTime;
            gio = giay / 3600;
            phut = (giay - (gio * 3600)) / 60;
            giay = giay - (gio * 3600 + phut * 60);

            lb_time.Text = gio.ToString("D2") + ":" + phut.ToString("D2") + ":" + giay.ToString("D2");
        }
    }
}