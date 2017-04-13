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
            if (keyData == Keys.Down && Global.Flag && !Global.BatCoDeSo)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                return true;
            }
            if (keyData == Keys.Up && Global.Flag && !Global.BatCoDeSo)
            {
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                return true;
            }
            if (keyData == Keys.Down && Global.Flag && Global.BatCoDeSo)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
                return true;
            }
            if (keyData == Keys.Up && Global.Flag && Global.BatCoDeSo)
            {
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");return true;
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
                if (Global.BatCoDeSo && Global.StrRole == "DEJP")
                {
                    item.txt_Truong10.Focus();
                }
                else
                {
                    item.txt_Truong03.Focus();
                }
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

        public bool IsError_Color()
        {
            bool empty = false;
            foreach (uc_DeJP_Row item in Controls)
            {
                if (item.txt_Truong03.BackColor == Color.Red ||
                    item.txt_Truong04.BackColor == Color.Red ||
                    item.txt_Truong05.BackColor == Color.Red ||
                    item.txt_Truong10.BackColor == Color.Red ||
                    item.txt_Truong11_1.BackColor == Color.Red ||
                    item.txt_Truong11_2.BackColor == Color.Red)
                {
                    empty = true;
                    break;
                }
            }
            return empty;
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

        public void CheckBatch_CoDeSo()
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                if ((Global.StrRole == "DEJP" && Global.BatCoDeSo) || (Global.StrCheck == "CHECKDEJP" && Global.BatCoDeSo))
                {
                    item.txt_Truong03.Enabled = false;
                    item.txt_Truong04.Enabled = false;
                    item.txt_Truong05.Enabled = false;
                    item.txt_Truong11_1.Enabled = false;
                    item.txt_Truong11_2.Enabled = false;
                    
                    item.txt_Truong10.Enabled = true;
                }
                else if ((Global.StrRole == "DESO" && Global.BatCoDeSo) || (Global.StrCheck == "CHECKDESO" && Global.BatCoDeSo))
                {
                    item.txt_Truong03.Enabled = true;
                    item.txt_Truong04.Enabled = true;
                    item.txt_Truong05.Enabled = true;
                    item.txt_Truong11_1.Enabled = true;
                    item.txt_Truong11_2.Enabled = true;
                    
                    item.txt_Truong10.Enabled = false;
                }
                else
                {
                    item.txt_Truong03.Enabled = true;
                    item.txt_Truong04.Enabled = true;
                    item.txt_Truong05.Enabled = true;
                    item.txt_Truong11_1.Enabled = true;
                    item.txt_Truong11_2.Enabled = true;
                    item.txt_Truong10.Enabled = true;
                }
            }
        }
        public void SaveData_Loai2_DeJP(string idImage, string truong06, string truong08)
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                if (!item.IsEmpty())
                {
                    item.Save_Data(idImage, truong06, truong08);
                }
            }
        }

        public void SaveData_Loai2_DeSo(string idImage, string truong06, string truong08)
        {
            foreach (uc_DeJP_Row item in Controls)
            {
                if (!item.IsEmpty())
                {
                    item.Save_Data_DeSo(idImage,truong06,truong08);
                    //item.Save_Data_DeSo(idImage, Global.Truong06, Global.Truong08);
                }
            }
        }

        public void SuaVaLuu_DEJP(int rowNumber,string usersaiit, string usersainhieu,string batch, string idimage, string truong06, string truong08)
        {
            string rownumber = "";
            foreach (uc_DeJP_Row item in Controls)
            {
                if (!string.IsNullOrEmpty(item.lb_stt.Text))
                {
                    rownumber = item.lb_stt.Text;
                    item.SuaVaLuu_DEJP(usersaiit, usersainhieu, batch,idimage,truong06,truong08);
                    //item.SuaVaLuu_DEJP(usersaiit, usersainhieu, idimage, Global.Truong06, Global.Truong08);
                }
            }
            int irowrumber = Convert.ToInt32(rownumber);
            if (irowrumber<rowNumber)
            {
                for (int i = irowrumber; i < rowNumber; i++)
                {
                    Global.db.DelecteRow(idimage,batch, i + 1);
                }
            }
        }
        public void SuaVaLuu_DESO(int rowNumber, string usersaiit, string usersainhieu, string batch, string idimage, string truong06, string truong08)
        {
            string rownumber = "";
            foreach (uc_DeJP_Row item in Controls)
            {
                if (!string.IsNullOrEmpty(item.lb_stt.Text))
                {
                    rownumber = item.lb_stt.Text;
                    item.SuaVaLuu_DESO(usersaiit, usersainhieu,batch, idimage,truong06,truong08);
                }
            }
            int irowrumber = Convert.ToInt32(rownumber);
            if (irowrumber < rowNumber)
            {
                for (int i = irowrumber; i < rowNumber; i++)
                {
                    Global.db.DelecteRow_DeSo(idimage, batch, i + 1);
                }
            }
        }

        private void uc_DeJP_Loai2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
