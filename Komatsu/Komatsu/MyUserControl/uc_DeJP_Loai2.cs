using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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
                uc.Tag = i + 1;
                Controls.Add(uc);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down && Global.Flag)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                return true;
            }
            if (keyData == Keys.Up && Global.Flag)
            {
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
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
            if (sender is TextEdit)
            {
                Changed?.Invoke(sender, e);
            }
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

        public void SaveData_Loai2(string idImage)
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                if (!item.IsEmpty())
                {
                    item.Save_Data(idImage,Global.Truong06,Global.Truong08);
                }
            }
        }

        public void SuaVaLuu(int RowNumber,string usersaiit, string usersainhieu, string idimage )
        {
            string rownumber = "";
            foreach (uc_DeJP_Row item in Controls)
            {
                if (string.IsNullOrEmpty(item.lb_stt.Text))
                    break;
                rownumber = item.lb_stt.Text;
                item.SuaVaLuu(usersaiit,usersainhieu,idimage, Global.Truong06, Global.Truong08);
            }
            int irowrumber = Convert.ToInt32(rownumber);
            if (irowrumber<RowNumber)
            {
                for (int i = irowrumber; i < RowNumber; i++)
                {
                    Global.db.DelecteRow(idimage, Global.StrBatch, i + 1);
                }
            }
        }
    }
}
