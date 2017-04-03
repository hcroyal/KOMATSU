using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace KOMTSU.MyUserControl
{
    public partial class uc_DeJP_Row : UserControl
    {
        public event AllTextChange Changed;

        public uc_DeJP_Row()
        {
            InitializeComponent();
        }

        public void ResetData()
        {
            lb_stt.Text = "";
            txt_Truong03.Text = @"28";
            txt_Truong04.Text = "";
            txt_Truong05.Text = "";
            txt_Truong10.Text = "";
            txt_Truong11_1.Text = "";
            txt_Truong11_2.Text = "";

            txt_Truong03.BackColor = Color.White;
            txt_Truong04.BackColor = Color.White;
            txt_Truong05.BackColor = Color.White;
            //txt_Truong06.BackColor = Color.White;
            //txt_Truong08.BackColor = Color.White;
            txt_Truong10.BackColor = Color.White;
            txt_Truong11_1.BackColor = Color.White;
            txt_Truong11_2.BackColor = Color.White;

            txt_Truong03.ForeColor = Color.Black;
            txt_Truong04.ForeColor = Color.Black;
            txt_Truong05.ForeColor = Color.Black;
            //txt_Truong06.ForeColor = Color.Black;
            //txt_Truong08.ForeColor = Color.Black;
            txt_Truong10.ForeColor = Color.Black;
            txt_Truong11_1.ForeColor = Color.Black;
            txt_Truong11_2.ForeColor = Color.Black;

            txt_Truong03.Focus();
        }

        public bool IsEmpty()
        {
            if (//string.IsNullOrEmpty(txt_Truong03.Text) &&
                string.IsNullOrEmpty(txt_Truong04.Text) &&
                string.IsNullOrEmpty(txt_Truong05.Text) &&
                //string.IsNullOrEmpty(txt_Truong06.Text) &&
                //string.IsNullOrEmpty(txt_Truong08.Text) &&
                string.IsNullOrEmpty(txt_Truong10.Text) &&
                string.IsNullOrEmpty(txt_Truong11_1.Text) &&
                string.IsNullOrEmpty(txt_Truong11_2.Text))
                return true;
            return false;
        }

        private void txt_Truong03_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong03.Text.IndexOf('?') >= 0)
                txt_Truong03.Text = @"?";
            if (txt_Truong03.Text.Length != 2 && txt_Truong03.Text != "" && txt_Truong03.Text != @"?" && txt_Truong03.Text.IndexOf('●') < 0)
            {
                txt_Truong03.BackColor = Color.Red;
                txt_Truong03.ForeColor = Color.White;
            }
            else
            {
                txt_Truong03.BackColor = Color.White;
                txt_Truong03.ForeColor = Color.Black;

            }
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong04_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong04.Text.IndexOf('?') >= 0)
                txt_Truong04.Text = @"?";
            if (txt_Truong04.Text != @"?" && txt_Truong04.Text.IndexOf('●') < 0 && txt_Truong04.Text != "")
            {
                if (Convert.ToInt32(txt_Truong04.Text) <= 0 || Convert.ToInt32(txt_Truong04.Text) > 12)
                {
                    txt_Truong04.BackColor = Color.Red;
                    txt_Truong04.ForeColor = Color.White;
                }
                else
                {
                    txt_Truong04.BackColor = Color.White;
                    txt_Truong04.ForeColor = Color.Black;
                }
            }
            else
            {
                txt_Truong04.BackColor = Color.White;
                txt_Truong04.ForeColor = Color.Black;

            }
            Changed?.Invoke(sender, e);
        }

        int Hople(int ngay, int thang)
        {
            if (thang > 12 || thang < 1) return 0;
            else
            {
                if (thang == 2)
                {
                    if (ngay > 29) return 0;
                    else return 1;
                }
                else if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
                {
                    if (ngay > 30) return 0;
                    else return 1;
                }
                else if (thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12)
                {
                    if (ngay > 31) return 0;
                    else return 1;
                }
                return 0;
            }
        }

        private void txt_Truong05_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong05.Text.IndexOf('?') >= 0)
                txt_Truong05.Text = @"?";
            if (txt_Truong05.Text != "" && txt_Truong05.Text != @"?" && txt_Truong05.Text.IndexOf('●') < 0)
            {
                if (txt_Truong04.Text != "" && txt_Truong04.Text != @"?" && txt_Truong04.Text.IndexOf('●') < 0)
                {
                    if (Hople(Convert.ToInt32(txt_Truong05.Text), Convert.ToInt32(txt_Truong04.Text)) == 0)
                    {
                        txt_Truong05.BackColor = Color.Red;
                        txt_Truong05.ForeColor = Color.White;
                    }
                    else
                    {
                        txt_Truong05.BackColor = Color.White;
                        txt_Truong05.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                txt_Truong05.BackColor = Color.White;
                txt_Truong05.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong10_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }
       
        private void txt_Truong11_1_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong11_1.Text.IndexOf('?') >= 0)
                txt_Truong11_1.Text = @"?";

            if (txt_Truong11_1.Text != "")
            {
                txt_Truong11_2.Text = "";
                if (txt_Truong11_1.Text != @"?" && txt_Truong11_1.Text.IndexOf('●') < 0)
                {
                    if (Convert.ToDouble(txt_Truong11_1.Text) < 1)
                    {
                        txt_Truong11_1.BackColor = Color.Red;
                        txt_Truong11_1.ForeColor = Color.White;
                    }
                    else
                    {
                        txt_Truong11_1.BackColor = Color.White;
                        txt_Truong11_1.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                txt_Truong11_1.BackColor = Color.White;
                txt_Truong11_1.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong11_2_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong11_2.Text.IndexOf('?') >= 0)
                txt_Truong11_2.Text = @"?";
            if (txt_Truong11_2.Text != "")
            {
                txt_Truong11_1.Text = "";
                if (txt_Truong11_2.Text != @"?" && txt_Truong11_2.Text.IndexOf('●') < 0)
                {
                    if (Convert.ToDouble( txt_Truong11_2.Text) <1)
                    {
                        txt_Truong11_2.BackColor = Color.Red;
                        txt_Truong11_2.ForeColor = Color.White;
                    }
                    else
                    {
                        txt_Truong11_2.BackColor = Color.White;
                        txt_Truong11_2.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                txt_Truong11_2.BackColor = Color.White;
                txt_Truong11_2.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }
        private void SetDataToCollection()
        {
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txt_Truong10.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Truong10.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var arrayName = (from w in Global.db.tbl_DataAutoCompletes select w.DataAutoComplete).ToList();

            foreach (string name in arrayName)
            {
                auto1.Add(name);
            }
            txt_Truong10.MaskBox.AutoCompleteCustomSource = auto1;

        }

        private void uc_DeJP_Row_Load(object sender, EventArgs e)
        {
            SetDataToCollection();
            ResetData();
            txt_Truong03.GotFocus += Txt_Truong03_GotFocus;
            txt_Truong04.GotFocus += Txt_Truong03_GotFocus;
            txt_Truong05.GotFocus += Txt_Truong03_GotFocus;
            //txt_Truong06.GotFocus += Txt_Truong03_GotFocus;
            //txt_Truong08.GotFocus += Txt_Truong03_GotFocus;
            txt_Truong10.GotFocus += Txt_Truong03_GotFocus;
            txt_Truong11_1.GotFocus += Txt_Truong03_GotFocus;
            txt_Truong11_2.GotFocus += Txt_Truong03_GotFocus;
        }

        private void Txt_Truong03_GotFocus(object sender, EventArgs e)
        {
            ((TextEdit) sender).SelectAll();
        }
    }
}
