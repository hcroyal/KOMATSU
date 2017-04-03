using System;
using System.Drawing;
using System.Windows.Forms;

namespace KOMTSU.MyUserControl
{
    public partial class uc_DeJP_Loai2 : UserControl
    {
        
        public event AllTextChange Changed;

        public int iStt=0;
        public uc_DeJP_Loai2()
        {
            InitializeComponent();
        }

        private void uc_DeJP_Loai2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                uc_DeJP_Row uc = new uc_DeJP_Row();
                Point p = new Point();
                uc.Changed += Uc_Changed;
                foreach (Control ct in Controls)
                {
                    p = ct.Location;
                    p.Y += ct.Size.Height;
                }
                uc.Location = p;
                Controls.Add(uc);
            }
        }

        public void Focus_Truong03()
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                item.txt_Truong03.Focus();
                return;
            }
        }
        void UpdateStt()
        {
            iStt = 1;
            foreach (uc_DeJP_Row item in Controls)
            {
                item.lb_stt.Text = "";
                if (!item.IsEmpty())
                {
                    if (iStt < 10)
                    {
                        item.lb_stt.Text = @"0"+iStt; }
                    else
                    {
                        item.lb_stt.Text = iStt.ToString();
                    }
                    iStt++;
                }
            }
        }
        private void Uc_Changed(object sender, EventArgs e)
        {
            UpdateStt();
        }

        public void ResetData()
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                item.ResetData();
            }
            Focus_Truong03();
        }

        public bool IsEmpty()
        {
            bool empty=true;
            foreach (uc_DeJP_Row item in Controls)
            {
                if (item.IsEmpty() == false)
                {
                    empty= false;
                    break;
                }
            }
            return empty;
        }

        public void SaveData_Loai2(string idImage, string truong06, string truong08)
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                if (!item.IsEmpty())
                {
                    string truong11 ;
                    if (!string.IsNullOrEmpty(item.txt_Truong11_2.Text))
                    {
                        var temp = truong06;
                        truong06 = truong08;
                        truong08 = temp;
                        truong11 = item.txt_Truong11_2.Text;
                    }
                    else
                    {
                        truong11 = item.txt_Truong11_1.Text;
                    }
                    Global.db.Insert_Loai2(idImage, Global.StrBatch, Global.StrUsername, item.txt_Truong03.Text,
                        item.txt_Truong04.Text, item.txt_Truong05.Text, truong06, truong08, item.txt_Truong10.Text,
                        truong11,
                        Global.LoaiPhieu, item.lb_stt.Text);
                }
            }
        }
    }
}
