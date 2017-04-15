using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Komatsu.Properties;
using KOMTSU.MyUserControl;
using ScrollOrientation = DevExpress.XtraEditors.ScrollOrientation;

namespace KOMTSU.MyForm
{
    public partial class frm_Check_DeSo : XtraForm
    {
        public frm_Check_DeSo()
        {
            InitializeComponent();
        }
        private void ResetData()
        {
            if (Global.LoaiPhieu == "Loai1")
            {
                //uc_DeJP_Loai12.ResetData();
                //uc_DeJP_Loai11.ResetData();
            }
            else if (Global.LoaiPhieu == "Loai2")
            {
                uc_DeJP_Loai22.ResetData();
                uc_DeJP_Loai21.ResetData();
            }
            uc_PictureBox1.imageBox1.Image = null;
        }

        private int row_user1 = 0,row_user2=0;
        public void LoadBatchMoi()
        {
            if (MessageBox.Show("Want to do the next batch?", "Notification", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                ResetData();
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                cbb_Batch_Check.DataSource = (from w in Global.db.GetBatNotFinishCheckerDeSo(Global.StrUsername) select w.fBatchName).ToList();
                cbb_Batch_Check.DisplayMember = "fBatchName";
            }
            else
            {
                TabControl_User1.TabPages.Remove(tp_Loai1_User1);
                TabControl_User1.TabPages.Remove(tp_Loai2_User1);
                TabControl_User2.TabPages.Remove(tp_Loai1_User2);
                TabControl_User2.TabPages.Remove(tp_Loai2_User2);

                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;

                ResetData();

                cbb_Batch_Check.DataSource = (from w in Global.db.GetBatNotFinishCheckerDeSo(Global.StrUsername) select w.fBatchName).ToList();
                cbb_Batch_Check.DisplayMember = "fBatchName";
                double soloi = Math.Round(Convert.ToDouble((from w in Global.db.GetSoLoi_CheckDeSo(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault()), 0);
                lb_Loi.Text = soloi + " Error";
                Global.BatCoDeSo = Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch_Check.Text select w.CoDeSo).FirstOrDefault());
                Global.LoaiPhieu = (from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch_Check.Text select w.LoaiBatch).FirstOrDefault();
                if (Global.LoaiPhieu == "Loai1")
                {
                    TabControl_User1.TabPages.Add(tp_Loai1_User1);
                    TabControl_User2.TabPages.Add(tp_Loai1_User2);
                }
                else if (Global.LoaiPhieu == "Loai2")
                {
                    TabControl_User1.TabPages.Add(tp_Loai2_User1);
                    TabControl_User2.TabPages.Add(tp_Loai2_User2);
                }btn_Start_Click(null, null);
            }
        }
        private void Load_Truong06_08(uc_DeJP_Loai1 uc)
        {
            Global.Truong06_A = (from w in Global.db.tbl_Images where w.fbatchname == cbb_Batch_Check.Text && w.idimage == lb_Image.Text select w.TruongSo06).FirstOrDefault();
            Global.Truong08_A = (from w in Global.db.tbl_Images where w.fbatchname == cbb_Batch_Check.Text && w.idimage == lb_Image.Text select w.TruongSo08).FirstOrDefault();
            if (Global.LoaiPhieu == "Loai1")
            {
                uc.txt_Truong06.Text = Global.Truong06_A;
                uc.txt_Truong08.Text = Global.Truong08_A;
            }
        }
        private void frm_Check_Load(object sender, EventArgs e)
        {
            try
            {
                TabControl_User1.TabPages.Remove(tp_Loai1_User1);
                TabControl_User1.TabPages.Remove(tp_Loai2_User1);
                TabControl_User2.TabPages.Remove(tp_Loai1_User2);
                TabControl_User2.TabPages.Remove(tp_Loai2_User2);
                cbb_Batch_Check.DataSource = (from w in Global.db.GetBatNotFinishCheckerDeSo(Global.StrUsername) select w.fBatchName).ToList();
                cbb_Batch_Check.DisplayMember = "fBatchName";
                double soloi = Math.Round(Convert.ToDouble((from w in Global.db.GetSoLoi_CheckDeSo(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault()), 0);
                lb_Loi.Text = soloi + " Error";
                Global.BatCoDeSo = Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName ==cbb_Batch_Check.Text select w.CoDeSo).FirstOrDefault());
                Global.LoaiPhieu = (from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch_Check.Text select w.LoaiBatch).FirstOrDefault();
                if (Global.LoaiPhieu == "Loai1")
                {
                    TabControl_User1.TabPages.Add(tp_Loai1_User1);
                    TabControl_User2.TabPages.Add(tp_Loai1_User2);
                }
                else if (Global.LoaiPhieu == "Loai2")
                {

                    TabControl_User1.TabPages.Add(tp_Loai2_User1);
                    TabControl_User2.TabPages.Add(tp_Loai2_User2);
                }
                uc_DeJP_Loai21.CheckBatch_CoDeSo();
                uc_DeJP_Loai22.CheckBatch_CoDeSo();

                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                
                uc_DeJP_Loai21.Changed += UC_Row_01_Changed;
                
                uc_DeJP_Loai22.Changed += UC_Row_01_Changed1;
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i);
            }
        }
        
        private void UC_Row_01_Changed1(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void UC_Row_01_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                var nhap =
                (from w in Global.db.tbl_Images
                    where w.fbatchname == cbb_Batch_Check.Text && w.ReadImageDESo == 2
                    select w.idimage).Count();
                var sohinh =
                    (from w in Global.db.tbl_Images where w.fbatchname == cbb_Batch_Check.Text select w.idimage).Count();
                var check =
                (from w in Global.db.tbl_MissImage_DESOs
                    where w.fBatchName == cbb_Batch_Check.Text && w.Submit == 0
                    select w.IdImage).Count();
                if (sohinh > nhap)
                {
                    MessageBox.Show("Not finished yet DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var listUser =
                    (from w in Global.db.tbl_MissImage_DESOs
                        where w.fBatchName == cbb_Batch_Check.Text && w.Submit == 0
                        select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in listUser)
                    {
                        sss += item + "\r\n";
                    }

                    if (listUser.Count > 0)
                    {
                        MessageBox.Show("The user took the picture but did not enter: \r\n" + sss);
                        return;
                    }
                }
                
                uc_DeJP_Loai21.CheckBatch_CoDeSo();
                uc_DeJP_Loai22.CheckBatch_CoDeSo();

                string temp = GetImage_DeSo();
                if (temp == "NULL")
                {
                uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show("Out of image!");
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show("Error load image");
                    return;
                }
                Load_DeSo(cbb_Batch_Check.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                btn_Start.Visible = false;
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi : " + i.Message);
            }
        }
        private string GetImage_DeSo()
        {
            var temp = (from w in Global.db.tbl_MissCheck_DESOs
                        where w.fBatchName == cbb_Batch_Check.Text && w.UserName == Global.StrUsername && w.Submit == 0
                        select w.IdImage).FirstOrDefault();
            if (string.IsNullOrEmpty(temp))
            {
                var getFilename =
                    (from w in Global.db.ImageCheck_DeSo(cbb_Batch_Check.Text, Global.StrUsername)
                     select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(getFilename))
                {
                    return "NULL";
                }
                else
                {
                    lb_Image.Text = getFilename;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_Batch_Check.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }}
            }
            else
            {
                lb_Image.Text = temp;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_Batch_Check.Text + "/" + temp, temp, Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            //Load_Truong06_08();
            return "ok";
        }

        private void Load_DeSo(string strBatch, string idimage)
        {
            double soloi = Math.Round(Convert.ToDouble((from w in Global.db.GetSoLoi_CheckDeSo(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault()), 0);
            lb_Loi.Text = soloi + " Error";

            var deso = (from w in Global.db.tbl_DESOs
                        where w.fBatchName == strBatch && w.IdImage == idimage
                        select new
                        {
                            w.UserName,
                            w.Truong_03,
                            w.Truong_04,
                            w.Truong_05,
                            w.Truong_06,
                            w.Truong_07,
                            w.Truong_08,
                            w.Truong_09,
                            w.Truong_10,
                            w.Truong_11,
                            w.Truong_11B,
                            w.Truong_12,
                            w.IdPhieu
                        }).ToList();
            lb_username1.Text = deso[0].UserName;
            lb_username2.Text = deso[deso.Count-1].UserName;

            if (Global.LoaiPhieu == "Loai1")
            {
                btn_ThemPhieu1.Visible = true;
                btn_ThemPhieu2.Visible = true;
                btn_XoaPhieu1.Visible = true;
                btn_XoaPhieu2.Visible = true;

                int countRowUser1 = 0, countRowUser2 = 0, r1 = 0, r2 = 0;

                for (int i = 0; i < deso.Count - 1; i++)
                {
                    if (deso[i].UserName != deso[i + 1].UserName)
                    {
                        countRowUser1 = i;
                        row_user1 = deso[i].IdPhieu;
                        countRowUser2 = deso.Count - 1;
                        row_user2 = deso.Count - row_user1;
                        break;
                    }
                }

                //----------------------------------------
                tp_Loai1_User1.Controls.Clear();
                tp_Loai1_User2.Controls.Clear();
                for (int i = 0; i < row_user1; i++)
                {
                    uc_DeJP_Loai1 uc_1 = new uc_DeJP_Loai1();
                    Point p = new Point();
                    foreach (uc_DeJP_Loai1 ct in tp_Loai1_User1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height + 20;

                    }
                    uc_1.Location = p;
                    uc_1.Tag = (i + 1).ToString();
                    tp_Loai1_User1.Controls.Add(uc_1);
                    uc_1.Changed += UC_Row_01_Changed;
                    uc_1.CheckBatch_CoDeSo();

                }
                for (int i = 0; i < row_user2; i++)
                {
                    uc_DeJP_Loai1 uc_2 = new uc_DeJP_Loai1();
                    Point p = new Point();
                    foreach (uc_DeJP_Loai1 ct in tp_Loai1_User2.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height + 20;

                    }
                    uc_2.Location = p;
                    uc_2.Tag = (i + 1).ToString();
                    tp_Loai1_User2.Controls.Add(uc_2);
                    uc_2.Changed += UC_Row_01_Changed1;
                    uc_2.CheckBatch_CoDeSo();
                }
                //---------------------------------

                foreach (uc_DeJP_Loai1 item in tp_Loai1_User1.Controls)
                {
                    item.txt_Truong03.Text = deso[r1].Truong_03;
                    item.txt_Truong04.Text = deso[r1].Truong_04;
                    item.txt_Truong05.Text = deso[r1].Truong_05;
                    item.txt_Truong06.Text = deso[r1].Truong_06;
                    item.txt_Truong07.Text = deso[r1].Truong_07;
                    item.txt_Truong08.Text = deso[r1].Truong_08;
                    item.txt_Truong09.Text = deso[r1].Truong_09;
                    item.txt_Truong10.Text = deso[r1].Truong_10;
                    item.txt_Truong11.Text = deso[r1].Truong_11;
                    item.txt_Truong12.Text = deso[r1].Truong_12;
                    if (r1 == countRowUser1)
                    {
                        r2 = r1 + 1;
                        break;
                    }
                    r1++;
                }
                foreach (uc_DeJP_Loai1 item in tp_Loai1_User2.Controls)
                {
                    item.txt_Truong03.Text = deso[r2].Truong_03;
                    item.txt_Truong04.Text = deso[r2].Truong_04;
                    item.txt_Truong05.Text = deso[r2].Truong_05;
                    item.txt_Truong06.Text = deso[r2].Truong_06;
                    item.txt_Truong07.Text = deso[r2].Truong_07;
                    item.txt_Truong08.Text = deso[r2].Truong_08;
                    item.txt_Truong09.Text = deso[r2].Truong_09;
                    item.txt_Truong10.Text = deso[r2].Truong_10;
                    item.txt_Truong11.Text = deso[r2].Truong_11;
                    item.txt_Truong12.Text = deso[r2].Truong_12;
                    if (r2 == countRowUser2)
                    {
                        break;
                    }
                    r2++;
                }

                txt_Truong06.Visible = false;
                txt_Truong08.Visible = false;
                labelControl17.Visible = false;
                labelControl18.Visible = false;

            }
            else if (Global.LoaiPhieu == "Loai2")
            {
                txt_Truong06.Visible = true;
                txt_Truong08.Visible = true;
                txt_Truong06.Text = (from w in Global.db.tbl_Images where w.fbatchname == strBatch && w.idimage == idimage select w.TruongSo06).FirstOrDefault();
                txt_Truong08.Text = (from w in Global.db.tbl_Images where w.fbatchname == strBatch && w.idimage == idimage select w.TruongSo08).FirstOrDefault();

                int countRowUser1 =0, countRowUser2=0,r1=0,r2=0;
                TabControl_User1.TabPages.Add(tp_Loai2_User1);
                TabControl_User2.TabPages.Add(tp_Loai2_User2);
                for (int i = 0; i < deso.Count-1; i++)
                {
                    if (deso[i].UserName != deso[i + 1].UserName)
                    {
                        countRowUser1 = i;
                        row_user1 = deso[i].IdPhieu;
                        countRowUser2 = deso.Count - 1;
                        row_user2 = deso.Count - row_user1;
                        break;
                    }
                }
                foreach (uc_DeJP_Row item  in uc_DeJP_Loai21.Controls)
                {
                    item.lb_stt.Text = deso[r1].IdPhieu.ToString();
                    item.txt_Truong03.Text = deso[r1].Truong_03;
                    item.txt_Truong03.Text = deso[r1].Truong_03;
                    item.txt_Truong04.Text = deso[r1].Truong_04;
                    item.txt_Truong05.Text = deso[r1].Truong_05;
                    item.txt_Truong10.Text = deso[r1].Truong_10;
                    item.txt_Truong11_1.Text = deso[r1].Truong_11;
                    item.txt_Truong11_2.Text = deso[r1].Truong_11B;
                    if(r1==countRowUser1)
                    {
                        r2 = r1 + 1;
                        break;
                    }
                    r1++;
                }
                foreach (uc_DeJP_Row item in uc_DeJP_Loai22.Controls)
                {
                    item.lb_stt.Text = deso[r2].IdPhieu.ToString();
                    item.txt_Truong03.Text = deso[r2].Truong_03;
                    item.txt_Truong03.Text = deso[r2].Truong_03;
                    item.txt_Truong04.Text = deso[r2].Truong_04;
                    item.txt_Truong05.Text = deso[r2].Truong_05;
                    item.txt_Truong10.Text = deso[r2].Truong_10;
                    item.txt_Truong11_1.Text = deso[r2].Truong_11;
                    item.txt_Truong11_2.Text = deso[r2].Truong_11B;
                    if (r2 == countRowUser2)
                    {
                        break;
                    }
                    r2++;
                }

            }

            foreach (uc_DeJP_Loai1 item_User1 in tp_Loai1_User1.Controls)
            {
                foreach (uc_DeJP_Loai1 item_User2 in tp_Loai1_User2.Controls)
                {
                    if (tp_Loai1_User1.Controls.Count < 1 || tp_Loai1_User2.Controls.Count < 1)
                        return;
                    if (item_User1.Tag.ToString() == item_User2.Tag.ToString())
                    {
                        Compare_TextEdit(item_User1.txt_Truong03, item_User2.txt_Truong03);
                        Compare_TextEdit(item_User1.txt_Truong04, item_User2.txt_Truong04);
                        Compare_TextEdit(item_User1.txt_Truong05, item_User2.txt_Truong05);
                        Compare_TextEdit(item_User1.txt_Truong06, item_User2.txt_Truong06);
                        Compare_TextEdit(item_User1.txt_Truong07, item_User2.txt_Truong07);
                        Compare_TextEdit(item_User1.txt_Truong08, item_User2.txt_Truong08);
                        Compare_TextEdit(item_User1.txt_Truong09, item_User2.txt_Truong09);
                        Compare_TextEdit(item_User1.txt_Truong10, item_User2.txt_Truong10);
                        Compare_TextEdit(item_User1.txt_Truong11, item_User2.txt_Truong11);
                        Compare_TextEdit(item_User1.txt_Truong12, item_User2.txt_Truong12);
                    }
                }
            }

            foreach (uc_DeJP_Row item_User1 in uc_DeJP_Loai21.Controls)
            {
                foreach (uc_DeJP_Row item_User2 in uc_DeJP_Loai22.Controls)
                {
                    if (item_User1.Tag.ToString()==item_User2.Tag.ToString())
                    {
                        if (string.IsNullOrEmpty(item_User1.lb_stt.Text) && string.IsNullOrEmpty(item_User2.lb_stt.Text))
                            return;
                        Compare_TextEdit(item_User1.txt_Truong03, item_User2.txt_Truong03);
                        Compare_TextEdit(item_User1.txt_Truong04, item_User2.txt_Truong04);
                        Compare_TextEdit(item_User1.txt_Truong05, item_User2.txt_Truong05);
                        Compare_TextEdit(item_User1.txt_Truong10, item_User2.txt_Truong10);
                        Compare_TextEdit(item_User1.txt_Truong11_1, item_User2.txt_Truong11_1);
                        Compare_TextEdit(item_User1.txt_Truong11_2, item_User2.txt_Truong11_2);
                    }
                }
            }
        }
        private void Compare_TextBox(TextBox t1, TextBox t2)
        {
            if (!string.IsNullOrEmpty(t1.Text) || !string.IsNullOrEmpty(t2.Text))
            {
                if (t1.Text != t2.Text)
                {
                    t1.BackColor = Color.PaleVioletRed;
                    t2.BackColor = Color.PaleVioletRed;
                }
            }
            else
            {
                t1.BackColor = Color.White;
                t2.BackColor = Color.White;
            }
        }
        private void Compare_TextEdit(TextEdit t1, TextEdit t2)
        {
            if (!string.IsNullOrEmpty(t1.Text) || !string.IsNullOrEmpty(t2.Text))
            {
                if (t1.Text != t2.Text)
                {
                    t1.BackColor = Color.PaleVioletRed;
                    t2.BackColor = Color.PaleVioletRed;
                }
            }
            else
            {
                t1.BackColor = Color.White;
                t2.BackColor = Color.White;
            }
        }
        private void Compare_LockupEdit(LookUpEdit t1, LookUpEdit t2)
        {
            if (t1.ItemIndex!=0 || t2.ItemIndex != 0)
            {
                if (t1.ItemIndex != t2.ItemIndex)
                {
                    t1.BackColor = Color.PaleVioletRed;
                    t2.BackColor = Color.PaleVioletRed;
                }
            }
            else
            {
                t1.BackColor = Color.White;
                t2.BackColor = Color.White;
            }
        }
        
        private void btn_Luu_DeSo1_Click(object sender, EventArgs e)
        {
            Global.db.LuuDESo(lb_Image.Text, cbb_Batch_Check.Text, lb_username1.Text, lb_username2.Text, Global.StrUsername);
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show("Hết Hình!");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                return;
            }
            Load_DeSo(cbb_Batch_Check.Text, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void btn_Luu_DeSo2_Click(object sender, EventArgs e)
        {
            Global.db.LuuDESo(lb_Image.Text, cbb_Batch_Check.Text, lb_username2.Text, lb_username1.Text, Global.StrUsername);
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show("Out of image!");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Error load image");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                return;
            }
            Load_DeSo(cbb_Batch_Check.Text, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void btn_SuaVaLuu_User1_Click(object sender, EventArgs e)
        {
            if (Global.LoaiPhieu == "Loai1")
            {
                foreach (uc_DeJP_Loai1 variable in tp_Loai1_User1.Controls)
                {
                    if (variable.IsError_Color())
                    {
                        MessageBox.Show("You entered the wrong data. Please check again!");
                        return;
                    }
                }
                bool c = false;
                foreach (uc_DeJP_Loai1 variable in tp_Loai1_User1.Controls)
                {
                    if (variable.IsEmpty())
                    {
                        c = true;
                    }
                }
                if (c)
                {
                    if (MessageBox.Show("You are empty one or more fields.Do you want to submit ? \r\nYes = Submit and next Image < Press Enter >\r\nNo = Enter the blank field for this image. < Press N > ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        return;
                }
                string rownumber = "";
                foreach (uc_DeJP_Loai1 item in tp_Loai1_User1.Controls)
                {
                    rownumber = item.Tag.ToString();
                    item.SuaVaLuu_DESO(lb_username1.Text, lb_username2.Text, cbb_Batch_Check.Text, lb_Image.Text, item.Tag.ToString());
                }
                int irowrumber = Convert.ToInt32(rownumber);
                if (irowrumber < row_user1)
                {
                    for (int i = irowrumber; i < row_user1; i++)
                    {
                        Global.db.DelecteRow_DeSo(lb_Image.Text, cbb_Batch_Check.Text, i+1);
                    }
                }
            }
            else if(Global.LoaiPhieu=="Loai2")
            {
                if (uc_DeJP_Loai21.IsError_Color())
                {
                    MessageBox.Show("You entered the wrong data. Please check again!");
                    return;
                }
                uc_DeJP_Loai21.SuaVaLuu_DESO(row_user1,lb_username1.Text, lb_username2.Text,cbb_Batch_Check.Text, lb_Image.Text, txt_Truong06.Text, txt_Truong08.Text);
            }
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show("Out of image!");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Error load image");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                return;
            }
            Load_DeSo(cbb_Batch_Check.Text, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void btn_SuaVaLuu_User2_Click(object sender, EventArgs e)
        {
            if (Global.LoaiPhieu == "Loai1")
            {
                foreach (uc_DeJP_Loai1 variable in tp_Loai1_User2.Controls)
                {
                    if (variable.IsError_Color())
                    {
                        MessageBox.Show("You entered the wrong data. Please check again!");
                        return;
                    }
                }
                bool c = false;
                foreach (uc_DeJP_Loai1 variable in tp_Loai1_User2.Controls)
                {
                    if (variable.IsEmpty())
                    {
                        c = true;
                    }
                }
                if (c)
                {
                    if (MessageBox.Show("You are empty one or more fields.Do you want to submit ? \r\nYes = Submit and next Image < Press Enter >\r\nNo = Enter the blank field for this image. < Press N > ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        return;
                }
                string rownumber = "";
                foreach (uc_DeJP_Loai1 item in tp_Loai1_User2.Controls)
                {
                    rownumber = item.Tag.ToString();
                    item.SuaVaLuu_DESO(lb_username2.Text, lb_username2.Text, cbb_Batch_Check.Text, lb_Image.Text, item.Tag.ToString());
                }
                int irowrumber = Convert.ToInt32(rownumber);
                if (irowrumber < row_user2)
                {
                    for (int i = irowrumber; i < row_user2; i++)
                    {
                        Global.db.DelecteRow_DeSo(lb_Image.Text, cbb_Batch_Check.Text, i+1);
                    }
                }
            }
            else if (Global.LoaiPhieu == "Loai2")
            {
                if (uc_DeJP_Loai22.IsError_Color())
                {
                    MessageBox.Show("You entered the wrong data. Please check again!");
                    return;
                }
                uc_DeJP_Loai22.SuaVaLuu_DESO(row_user2,lb_username2.Text, lb_username1.Text, cbb_Batch_Check.Text,lb_Image.Text, txt_Truong06.Text, txt_Truong08.Text);
            }
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show("Out of image!!");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Error load image");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                return;
            }
            Load_DeSo(cbb_Batch_Check.Text, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //uC_DESO2.setRandom(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //uC_DESO1.setRandom(false);
        }

        private void uc_DeJP_Loai11_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_DeJP_Loai11.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_DeJP_Loai12.VerticalScroll.Value = e.NewValue;
        }

        private void uc_DeJP_Loai12_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_DeJP_Loai12.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_DeJP_Loai11.VerticalScroll.Value = e.NewValue;
        }

        private void uc_DeJP_Loai21_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_DeJP_Loai21.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_DeJP_Loai22.VerticalScroll.Value = e.NewValue;
        }

        private void uc_DeJP_Loai22_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_DeJP_Loai22.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_DeJP_Loai21.VerticalScroll.Value = e.NewValue;
        }
        public void ScrollToBottom(XtraTabPage p)
        {
            using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
            {
                p.ScrollControlIntoView(c);
                c.Parent = null;
            }
        }

        private void btn_ThemPhieu1_Click(object sender, EventArgs e)
        {
            uc_DeJP_Loai1 uc = new uc_DeJP_Loai1();
            Point p = new Point();
            foreach (uc_DeJP_Loai1 ct in tp_Loai1_User1.Controls)
            {
                p = ct.Location;
                p.Y += ct.Size.Height + 20;

            }
            uc.Location = p;
            uc.Tag = (tp_Loai1_User1.Controls.Count+1).ToString();
            Load_Truong06_08(uc);
            tp_Loai1_User1.Controls.Add(uc);
            uc.CheckBatch_CoDeSo();
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
            uc.Changed += UC_Row_01_Changed;
            ScrollToBottom(tp_Loai1_User1);
        }

        private void btn_XoaPhieu1_Click(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
            if (tp_Loai1_User1.Controls.Count > 1)
            {
                tp_Loai1_User1.Controls.RemoveAt(tp_Loai1_User1.Controls.Count - 1);
                ScrollToBottom(tp_Loai1_User1);
            }
        }

        private void btn_ThemPhieu2_Click(object sender, EventArgs e)
        {
            uc_DeJP_Loai1 uc = new uc_DeJP_Loai1();
            Point p = new Point();
            foreach (uc_DeJP_Loai1 ct in tp_Loai1_User2.Controls)
            {
                p = ct.Location;
                p.Y += ct.Size.Height + 20;

            }
            uc.Location = p;
            uc.Tag = (tp_Loai1_User2.Controls.Count + 1).ToString();
            Load_Truong06_08(uc);
            tp_Loai1_User2.Controls.Add(uc);
            uc.CheckBatch_CoDeSo();uc.Changed += UC_Row_01_Changed1;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
            ScrollToBottom(tp_Loai1_User2);
        }

        private void btn_XoaPhieu2_Click(object sender, EventArgs e)
        {
            if (tp_Loai1_User2.Controls.Count > 1)
            {
                tp_Loai1_User2.Controls.RemoveAt(tp_Loai1_User2.Controls.Count - 1);
                ScrollToBottom(tp_Loai1_User2);
            }
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void tp_Loai1_User1_Scroll(object sender, XtraScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                tp_Loai1_User1.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                tp_Loai1_User2.VerticalScroll.Value = e.NewValue;
        }

        private void tp_Loai1_User2_Scroll(object sender, XtraScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                tp_Loai1_User2.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                tp_Loai1_User1.VerticalScroll.Value = e.NewValue;
        }

        private void cbb_Batch_Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            tp_Loai1_User1.PageVisible = false;
            tp_Loai1_User2.PageVisible = false;
            tp_Loai2_User1.PageVisible = false;
            tp_Loai2_User2.PageVisible = false;

            btn_ThemPhieu1.Visible = false;
            btn_ThemPhieu2.Visible = false;
            btn_XoaPhieu1.Visible = false;
            btn_XoaPhieu2.Visible = false;

            btn_Luu_DeSo1.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
            
            double soloi =Math.Round( Convert.ToDouble((from w in Global.db.GetSoLoi_CheckDeSo(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault()),0);
            lb_Loi.Text = soloi + " Error";
            Global.BatCoDeSo = Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch_Check.Text select w.CoDeSo).FirstOrDefault());
            Global.LoaiPhieu = (from w in Global.db.tbl_Batches where w.fBatchName == cbb_Batch_Check.Text select w.LoaiBatch).FirstOrDefault();
            ResetData();
            if (Global.LoaiPhieu == "Loai1")
            {
                tp_Loai1_User1.PageVisible = true;
                tp_Loai1_User2.PageVisible = true;
                
            }
            else if (Global.LoaiPhieu == "Loai2")
            {
                tp_Loai2_User1.PageVisible = true;
                tp_Loai2_User2.PageVisible = true;
            }
            tp_Loai1_User1.Controls.Clear();
            tp_Loai1_User2.Controls.Clear();
            
            uc_DeJP_Loai21.CheckBatch_CoDeSo();
            uc_DeJP_Loai22.CheckBatch_CoDeSo();
            btn_Start.Visible = true;
        }
    }
}