using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraTab;
using Komatsu.MyForm;
using Komatsu.Properties;
using KOMTSU.MyUserControl;


namespace KOMTSU.MyForm
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void setValue()
        {
            if (Global.StrRole == "DEJP")
            {
                lb_SoHinhConLai.Text = (from w in Global.db.tbl_Images
                    where
                    w.ReadImageDEJP < 2 && w.fbatchname == Global.StrBatch &&
                    (w.UserNameDEJP != Global.StrUsername || w.UserNameDEJP == null || w.UserNameDEJP == "")
                    select w.idimage).Count().ToString();
                lb_SoHinhLamDuoc.Text = (from w in Global.db.tbl_MissImage_DEJPs
                    where w.UserName == Global.StrUsername && w.fBatchName == Global.StrBatch
                    select w.IdImage).Count().ToString();
            }
            if (Global.StrRole == "DESO")
            {
                lb_SoHinhConLai.Text = (from w in Global.db.tbl_Images
                    where
                    w.ReadImageDESo < 2 && w.fbatchname == Global.StrBatch &&
                    (w.UserNameDESo != Global.StrUsername || w.UserNameDESo == null || w.UserNameDESo == "")
                    select w.idimage).Count().ToString();
                lb_SoHinhLamDuoc.Text = (from w in Global.db.tbl_MissImage_DESOs
                    where w.UserName == Global.StrUsername && w.fBatchName == Global.StrBatch
                    select w.IdImage).Count().ToString();
            }
            tp_Loai1_JP_Main.Controls.Clear();
            btn_ThemPhieu_Click(null, null);
        }

        private void Load_Truong06_08()
        {
            Global.Truong06 = (from w in Global.db.tbl_Images where w.fbatchname == Global.StrBatch && w.idimage == lb_IdImage.Text select w.TruongSo06).FirstOrDefault();
            Global.Truong08 = (from w in Global.db.tbl_Images where w.fbatchname == Global.StrBatch && w.idimage == lb_IdImage.Text select w.TruongSo08).FirstOrDefault();
            if (Global.LoaiPhieu == "Loai2")
            {
                txt_Truong06.Text = Global.Truong06;
                txt_Truong08.Text = Global.Truong08;
            }
        }

        public string GetImage()
        {
            if (Global.StrRole == "DEJP")
            {
                string temp = (from w in Global.db.tbl_MissImage_DEJPs
                               where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0
                               select w.IdImage).FirstOrDefault();
                if (string.IsNullOrEmpty(temp))
                {
                    try
                    {
                        var getFilename =
                            (from w in Global.db.LayHinhMoi_DeJP(Global.StrBatch, Global.StrUsername)
                             select w.Column1).FirstOrDefault();
                        if (string.IsNullOrEmpty(getFilename))
                        {
                            return "NULL";
                        }
                        lb_IdImage.Text = getFilename;
                        uc_PictureBox1.imageBox1.Image = null;
                        if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,
                            Settings.Default.ZoomImage) == "Error")
                        {
                            uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                            return "Error";

                        }
                    }
                    catch (Exception i)
                    {
                        return "NULL";
                    }
                }
                else
                {
                    lb_IdImage.Text = temp;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp,
                        Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }
                }
            }
            if (Global.StrRole == "DESO")
            {
                string temp = (from w in Global.db.tbl_MissImage_DESOs
                               where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0
                               select w.IdImage).FirstOrDefault();
                if (string.IsNullOrEmpty(temp))
                {
                    try
                    {
                        var getFilename =
                            (from w in Global.db.LayHinhMoi_DeSo(Global.StrBatch, Global.StrUsername)
                             select w.Column1).FirstOrDefault();
                        if (string.IsNullOrEmpty(getFilename))
                        {
                            return "NULL";
                        }
                        lb_IdImage.Text = getFilename;
                        uc_PictureBox1.imageBox1.Image = null;
                        if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,
                            Settings.Default.ZoomImage) == "Error")
                        {
                            uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                            return "Error";

                        }
                    }
                    catch (Exception i)
                    {
                        return "NULL";
                    }
                }
                else
                {
                    lb_IdImage.Text = temp;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp,
                        Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }
                }
            }
            Load_Truong06_08();
            return "OK";
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                Global.auto1 = new AutoCompleteStringCollection();
                List<string> arrayName = (from w in Global.db.tbl_DataAutoCompletes select w.DataAutoComplete).ToList();
                foreach (string name in arrayName)
                {
                    Global.auto1.Add(name);
                }
                Global.BatCoDeSo =Convert.ToBoolean((from w in Global.db.tbl_Batches where w.fBatchName == Global.StrBatch select w.CoDeSo).FirstOrDefault());
                Global.LoaiPhieu = (from w in Global.db.tbl_Batches where w.fBatchName == Global.StrBatch select w.LoaiBatch).FirstOrDefault();
                
                lb_IdImage.Text = "";
                lb_fBatchName.Text = Global.StrBatch;
                lb_UserName.Text = Global.StrUsername;
                lb_TongSoHinh.Text = (from w in Global.db.tbl_Images where w.fbatchname == Global.StrBatch select w.idimage).Count().ToString();

                tabControl_Main.TabPages.Remove(tp_Loai1_JP_Main);
                tabControl_Main.TabPages.Remove(tp_Loai2_JP_Main);
                tp_Loai1_JP_Main.Visible = true;
                menu_quanly.Enabled = false;
                btn_Submit_Logout.Enabled = false;

                if (Global.LoaiPhieu == "Loai1")
                {
                    btn_ThemPhieu.Visible = true;
                    btn_XoaPhieu.Visible = true;
                }
                else
                {
                    btn_ThemPhieu.Visible = false;
                    btn_XoaPhieu.Visible = false;
                }
                if (Global.BatCoDeSo)
                {
                    if (Global.StrRole == "DEJP" || Global.StrRole == "DESO")
                    {
                        if (Global.LoaiPhieu == "Loai1")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai1_JP_Main);
                        }
                        else if (Global.LoaiPhieu == "Loai2")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai2_JP_Main);
                            uc_DeJP_Loai21.CheckBatch_CoDeSo();
                        }
                    }
                    else
                    {
                        btn_Start_Submit.Enabled = false;
                        btn_Submit_Logout.Enabled = false;
                        menu_quanly.Enabled = true;
                    }
                }
                else
                {
                    if (Global.StrRole == "DEJP")
                    {
                        if (Global.LoaiPhieu == "Loai1")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai1_JP_Main);
                        }
                        else if (Global.LoaiPhieu == "Loai2")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai2_JP_Main);
                        }
                    }
                    else if (Global.StrRole == "DESO")
                    {
                        btn_Start_Submit.Enabled = false;
                        btn_Submit_Logout.Enabled = false;
                    }
                    else
                    {
                        btn_Start_Submit.Enabled = false;
                        btn_Submit_Logout.Enabled = false;
                        menu_quanly.Enabled = true;
                    }
                }
                setValue();
            }
            catch (Exception i)
            {
                MessageBox.Show("Error Load Main: " + i.Message);
            }
        }

        private void btn_exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btn_Start_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);
                //Kiểm tra token
                var token = (from w in Global.db_BPO.tbl_TokenLogins
                             where w.UserName == Global.StrUsername && w.IDProject == Global.StrIdProject
                             select w.Token).FirstOrDefault();

                if (token != Global.Strtoken)
                {
                    MessageBox.Show("User logged on to another PC, please login again!");
                    DialogResult = DialogResult.Yes;
                }

                if (btn_Start_Submit.Text == "Start")
                {
                    if (string.IsNullOrEmpty(Global.StrBatch))
                    {
                        MessageBox.Show("Please log in again and select Batch!");
                        return;
                    }

                    string temp = GetImage();
                    if (temp == "NULL")
                    {
                        MessageBox.Show("Picture is out!");
                        btn_logout_ItemClick(null, null);
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Can not load image!");
                        btn_logout_ItemClick(null, null);
                    }
                    uc_DeJP_Loai21.ResetData();
                    btn_Start_Submit.Text = "Submit";
                    btn_Submit_Logout.Enabled = true;
                }
                else
                {
                    if (Global.StrRole == "DEJP")
                    {
                        if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                        {
                            foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                            {
                                if (variable.IsError_Color())
                                {
                                    MessageBox.Show("You entered the wrong data. Please check again!");
                                    return;
                                }
                            }
                            bool c = false;
                            foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
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
                            int k = 1;
                            foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                            {
                                variable.SaveData_Loai1_DeJP(lb_IdImage.Text,k);
                                k++;
                            }
                            //Xứ lý 2 user nhập số lượng dòng khác nhau
                            Global.db.CheckRowNumber(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                        }
                        else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                        {
                            if (uc_DeJP_Loai21.IsError_Color())
                            {
                                MessageBox.Show("You entered the wrong data. Please check again!");
                                return;
                            }
                            if (uc_DeJP_Loai21.IsEmpty())
                            {
                                if (MessageBox.Show("You are empty one or more fields.Do you want to submit ? \r\nYes = Submit and next Image < Press Enter >\r\nNo = Enter the blank field for this image. < Press N > ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    Global.db.Insert_Loai2(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                    "", "", txt_Truong06.Text, txt_Truong08.Text,"","", "",Global.LoaiPhieu, "1");
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                uc_DeJP_Loai21.SaveData_Loai2_DeJP(lb_IdImage.Text,txt_Truong06.Text,txt_Truong08.Text);
                            }
                            //Xứ lý 2 user nhập số lượng dòng khác nhau
                            Global.db.CheckRowNumber(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                        }
                        uc_DeJP_Loai21.ResetData();
                    }
                    else if (Global.StrRole == "DESO")
                    {
                        if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                        {
                            foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                            {
                                if (variable.IsError_Color())
                                {
                                    MessageBox.Show("You entered the wrong data. Please check again!");
                                    return;
                                }
                            }
                            bool c = false;
                            foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
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
                            int k = 1;
                            foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                            {
                                variable.SaveData_Loai1_DeSo(lb_IdImage.Text, k);
                                k++;
                            }
                            //Xứ lý 2 user nhập số lượng dòng khác nhau
                            Global.db.CheckRowNumber_DeSo(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                        }
                        else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                        {
                            if (uc_DeJP_Loai21.IsError_Color())
                            {
                                MessageBox.Show("You entered the wrong data. Please check again!");
                                return;
                            }
                            if (uc_DeJP_Loai21.IsEmpty())
                            {
                                if (MessageBox.Show("You are empty one or more fields. Do you want to submit? \r\nYes = Submit and next Image <Press Enter>\r\nNo = Enter the blank field for this image. <Press N>", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    Global.db.Insert_Loai2_DeS0(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                        "", "", txt_Truong06.Text, txt_Truong08.Text, "", "", "", Global.LoaiPhieu, "1");
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                uc_DeJP_Loai21.SaveData_Loai2_DeSo(lb_IdImage.Text, txt_Truong06.Text, txt_Truong08.Text);
                            }
                            //Xứ lý 2 user nhập số lượng dòng khác nhau
                            Global.db.CheckRowNumber_DeSo(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                        }
                        uc_DeJP_Loai21.ResetData();
                    }

                    string temp = GetImage();
                    
                    if (temp == "NULL")
                    {
                        MessageBox.Show("Picture is out!");
                        btn_logout_ItemClick(null, null);
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Can not load image!");
                        btn_logout_ItemClick(null, null);
                    }
                }
                setValue();
            }
            catch (Exception i)
            {
                MessageBox.Show("Error Submit" + i.Message);
            }
        }

        private void btn_Submit_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);//Kiểm tra token
                var token = (from w in Global.db_BPO.tbl_TokenLogins
                             where w.UserName == Global.StrUsername && w.IDProject == Global.StrIdProject
                             select w.Token).FirstOrDefault();

                if (token != Global.Strtoken)
                {
                    MessageBox.Show("User logged on to another PC, please login again!");
                    DialogResult = DialogResult.Yes;
                }
                
                if (Global.StrRole == "DEJP")
                {
                    if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                    {
                        foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                        {
                            if (variable.IsError_Color())
                            {
                                MessageBox.Show("You entered the wrong data. Please check again!");
                                return;
                            }
                        }
                        bool c = false;
                        foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                        {
                            if (variable.IsEmpty())
                            {
                                c = true;
                            }
                        }
                        if (c)
                        {
                            if (MessageBox.Show("You are empty one or more fields. Do you want to submit? \r\nYes = Submit and next Image <Press Enter>\r\nNo = Enter the blank field for this image. <Press N>", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        int k = 1;
                        foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                        {
                            variable.SaveData_Loai1_DeJP(lb_IdImage.Text, k);
                            k++;
                        }
                        //Xứ lý 2 user nhập số lượng dòng khác nhau
                        Global.db.CheckRowNumber(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                    }
                    else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                    {
                        if (uc_DeJP_Loai21.IsError_Color())
                        {
                            MessageBox.Show("You entered the wrong data. Please check again!");
                            return;
                        }
                        if (uc_DeJP_Loai21.IsEmpty())
                        {
                            if (MessageBox.Show("You are empty one or more fields. Do you want to submit? \r\nYes = Submit and next Image <Press Enter>\r\nNo = Enter the blank field for this image. <Press N>", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                            {
                                Global.db.Insert_Loai2(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                    "", "", txt_Truong06.Text, txt_Truong08.Text, "", "", "", Global.LoaiPhieu, "1");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            uc_DeJP_Loai21.SaveData_Loai2_DeJP(lb_IdImage.Text, txt_Truong06.Text, txt_Truong08.Text);
                        }
                        //Xứ lý 2 user nhập số lượng dòng khác nhau
                        Global.db.CheckRowNumber(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                    }
                }
                if (Global.StrRole == "DESO")
                {
                    if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                    {
                        foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                        {
                            if (variable.IsError_Color())
                            {
                                MessageBox.Show("You entered the wrong data. Please check again!");
                                return;
                            }
                        }
                        bool c = false;
                        foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                        {
                            if (variable.IsEmpty())
                            {
                                c = true;
                            }
                        }
                        if (c)
                        {
                            if (MessageBox.Show("You are empty one or more fields. Do you want to submit? \r\nYes = Submit and next Image <Press Enter>\r\nNo = Enter the blank field for this image. <Press N>", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        int k = 1;
                        foreach (uc_DeJP_Loai1 variable in tp_Loai1_JP_Main.Controls)
                        {
                            variable.SaveData_Loai1_DeSo(lb_IdImage.Text, k);
                            k++;
                        }
                        //Xứ lý 2 user nhập số lượng dòng khác nhau
                        Global.db.CheckRowNumber_DeSo(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                    }
                    else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                    {
                        if (uc_DeJP_Loai21.IsError_Color())
                        {
                            MessageBox.Show("You entered the wrong data. Please check again!");
                            return;
                        }
                        if (uc_DeJP_Loai21.IsEmpty())
                        {
                            if (MessageBox.Show("You are empty one or more fields. Do you want to submit? \r\nYes = Submit and next Image <Press Enter>\r\nNo = Enter the blank field for this image. <Press N>", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                            {
                                Global.db.Insert_Loai2_DeS0(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                    "", "", txt_Truong06.Text, txt_Truong08.Text, "", "", "", Global.LoaiPhieu, "1");
                            }
                            else
                            {return;
                            }
                        }
                        else
                        {
                            uc_DeJP_Loai21.SaveData_Loai2_DeSo(lb_IdImage.Text, txt_Truong06.Text, txt_Truong08.Text);
                        }
                        //Xứ lý 2 user nhập số lượng dòng khác nhau
                        Global.db.CheckRowNumber_DeSo(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                    }
                }
                btn_logout_ItemClick(null, null);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error Submit_Logout" + i.Message);
            }
        }

        private void btn_quanlyuser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_User().ShowDialog();
        }

        private void btn_qyanlybatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ManagerBatch().ShowDialog();
        }

        private void btn_Zoomimage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ChangeZoom().ShowDialog();
        }

        private void btn_checkdeso_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.StrCheck = "CHECKDESO";
            new frm_Check_DeSo().ShowDialog();
            frm_Main_Load(sender,e);
        }
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());

            if (e.Control && e.KeyCode == Keys.Enter)
                btn_Start_Submit_Click(null, null);
            if (e.Control && e.KeyCode == Keys.Left)
                uc_PictureBox1.btn_Xoaytrai_Click(null, null);
            if (e.Control && e.KeyCode == Keys.Right)
                uc_PictureBox1.btn_xoayphai_Click(null, null);
            if (e.KeyCode == Keys.Escape)
            {
                new frm_FreeTime().ShowDialog();
                Global.db_BPO.UpdateTimeFree(Global.Strtoken, Global.FreeTime);
            }
            if (e.Control && e.KeyCode == Keys.Add)
            {
                btn_ThemPhieu_Click(null,null);
            }
            if (e.Control && e.KeyCode == Keys.Subtract)
            {
                btn_XoaPhieu_Click(null, null);
            }
            if (e.Control && e.KeyCode == Keys.Down)
            {int i = 1;
                string[] s = new string[12];
                foreach (uc_DeJP_Row item  in uc_DeJP_Loai21.Controls)
                {
                    if (i == Global.Tag_UcRow)
                    {
                        if (Global.tb_Forcus == "3")
                        {
                            item.txt_Truong03.Text = s[3];
                            item.txt_Truong03.SelectionStart = item.txt_Truong03.Text.Length;

                        }
                        else if (Global.tb_Forcus == "4")
                        {
                            item.txt_Truong04.Text = s[4];
                            item.txt_Truong04.SelectionStart = item.txt_Truong04.Text.Length;
                        }
                        else if (Global.tb_Forcus == "5")
                        {
                            item.txt_Truong05.Text = s[5];
                            item.txt_Truong05.SelectionStart = item.txt_Truong05.Text.Length;

                        }
                        else if (Global.tb_Forcus == "11_1")
                        {
                            item.txt_Truong11_1.Text = s[10];
                            item.txt_Truong11_1.SelectionStart = item.txt_Truong11_1.Text.Length;

                        }
                        else if (Global.tb_Forcus == "11_2")
                        {
                            item.txt_Truong11_2.Text = s[11];
                            item.txt_Truong11_2.SelectionStart = item.txt_Truong11_2.Text.Length;

                        }
                        break;}
                    s[3] = item.txt_Truong03.Text;
                    s[4] = item.txt_Truong04.Text;
                    s[5] = item.txt_Truong05.Text;
                    s[10] = item.txt_Truong11_1.Text;
                    s[11] = item.txt_Truong11_2.Text;
                    i++;
                }
            }
        }
        private void btn_checkqc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.StrCheck = "CHECKDEJP";
            new frm_Check_DeJP().ShowDialog();
            frm_Main_Load(sender, e);
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);
            Global.db_BPO.UpdateTimeLogout(Global.Strtoken);
            Global.db_BPO.ResetToken(Global.StrUsername, Global.StrIdProject, Global.Strtoken);
            Settings.Default.Save();
        }

        private void btn_xuatexcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ExportExcel().ShowDialog();
        }
        
        private void btn_tiendo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_TienDo().ShowDialog();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            new frm_FreeTime().ShowDialog();
            Global.db_BPO.UpdateTimeFree(Global.Strtoken, Global.FreeTime);
        }

        private void btn_data_auto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_DataAuto().ShowDialog();
        }
        
        private void btn_nangsuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             new frm_NangSuat().ShowDialog();
        }

        private int count;
        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            uc_DeJP_Loai1 uc = new uc_DeJP_Loai1();
            Point p = new Point();
            foreach (uc_DeJP_Loai1 ct in tp_Loai1_JP_Main.Controls)
            {
                p = ct.Location;
                p.Y += ct.Size.Height + 20;

            }
            uc.Location = p;
            count++;
            uc.Tag = count.ToString();
            uc.CheckBatch_CoDeSo();
            tp_Loai1_JP_Main.Controls.Add(uc);

            uc.txt_Truong06.Text = Global.Truong06;
            uc.txt_Truong08.Text = Global.Truong08;

            ScrollToBottom(tp_Loai1_JP_Main);
        }
        public void ScrollToBottom(XtraTabPage p)
        {
            using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
            {
                p.ScrollControlIntoView(c);
                c.Parent = null;
            }
        }

        private void btn_XoaPhieu_Click(object sender, EventArgs e)
        {
            if (tp_Loai1_JP_Main.Controls.Count > 1)
            {tp_Loai1_JP_Main.Controls.RemoveAt(tp_Loai1_JP_Main.Controls.Count - 1);
                ScrollToBottom(tp_Loai1_JP_Main);
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();}
    }
}
