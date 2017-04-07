using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Komatsu.MyForm;
using Komatsu.Properties;


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
                                        where w.ReadImageDEJP < 2 && w.fbatchname == Global.StrBatch &&( w.UserNameDEJP != Global.StrUsername || w.UserNameDEJP == null || w.UserNameDEJP == "")
                                        select w.idimage).Count().ToString();
                lb_SoHinhLamDuoc.Text = (from w in Global.db.tbl_MissImage_DEJPs
                                         where w.UserName == Global.StrUsername && w.fBatchName == Global.StrBatch
                                         select w.IdImage).Count().ToString();
            }
            if (Global.StrRole == "DESO")
            {
                lb_SoHinhConLai.Text = (from w in Global.db.tbl_Images
                                        where w.ReadImageDESo < 2 && w.fbatchname == Global.StrBatch && (w.UserNameDESo != Global.StrUsername || w.UserNameDESo == null || w.UserNameDESo == "")
                                        select w.idimage).Count().ToString();
                lb_SoHinhLamDuoc.Text = (from w in Global.db.tbl_MissImage_DESOs
                                         where w.UserName == Global.StrUsername && w.fBatchName == Global.StrBatch
                                         select w.IdImage).Count().ToString();
            }
        }

        private void Load_Truong06_08()
        {
            Global.Truong06 = (from w in Global.db.tbl_Images where w.fbatchname == Global.StrBatch select w.TruongSo06).FirstOrDefault();
            Global.Truong08 = (from w in Global.db.tbl_Images where w.fbatchname == Global.StrBatch select w.TruongSo08).FirstOrDefault();
            if (Global.LoaiPhieu == "Loai1")
            {
                uc_DeJP_Loai11.txt_Truong06.Text = Global.Truong06;
                uc_DeJP_Loai11.txt_Truong08.Text = Global.Truong08;
            }
            else if (Global.LoaiPhieu == "Loai2")
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
                menu_quanly.Enabled = false;

                if (Global.BatCoDeSo)
                {
                    if (Global.StrRole == "DEJP")
                    {
                        if (Global.LoaiPhieu == "Loai1")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai1_JP_Main);
                            uc_DeJP_Loai11.CheckBatch_CoDeSo();
                        }
                        else if (Global.LoaiPhieu == "Loai2")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai2_JP_Main);
                            uc_DeJP_Loai21.CheckBatch_CoDeSo();
                        }
                    }
                    else if (Global.StrRole == "DESO")
                    {
                        if (Global.LoaiPhieu == "Loai1")
                        {
                            tabControl_Main.TabPages.Add(tp_Loai1_JP_Main);
                            uc_DeJP_Loai11.CheckBatch_CoDeSo();
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
                MessageBox.Show("Lỗi Load Main: " + i.Message);
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
                    MessageBox.Show("User đã đăng nhập ở PC khác, bạn vui lòng đăng nhập lại!");
                    DialogResult = DialogResult.Yes;
                }

                if (btn_Start_Submit.Text == "Start")
                {
                    if (string.IsNullOrEmpty(Global.StrBatch))
                    {
                        MessageBox.Show("Vui lòng đăng nhập lại và chọn Batch!");
                        return;
                    }

                    string temp = GetImage();
                    if (temp == "NULL")
                    {
                        MessageBox.Show("Hết Hình!");
                        btn_logout_ItemClick(null, null);
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Không thể load hình!");
                        btn_logout_ItemClick(null, null);
                    }
                    uc_DeJP_Loai11.ResetData();
                    uc_DeJP_Loai21.ResetData();
                    btn_Start_Submit.Text = "Submit";
                    btn_Submit_Logout.Visible = true;
                }
                else
                {
                    if (Global.StrRole == "DEJP")
                    {
                        if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                        {
                            if (uc_DeJP_Loai11.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                    return;
                            }
                            else
                            uc_DeJP_Loai11.SaveData_Loai1_DeJP(lb_IdImage.Text);
                        }
                        else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                        {
                            if (uc_DeJP_Loai21.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                    return;
                                Global.db.Insert_Loai2(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                "", "", txt_Truong06.Text, txt_Truong08.Text,"","", "",Global.LoaiPhieu, "1");
                            }
                            else
                            {uc_DeJP_Loai21.SaveData_Loai2_DeJP(lb_IdImage.Text);
                            }
                            //Xứ lý 2 user nhập số lượng dòng khác nhau
                            Global.db.CheckRowNumber(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                        }
                        uc_DeJP_Loai11.ResetData();
                        uc_DeJP_Loai21.ResetData();
                    }
                    else if (Global.StrRole == "DESO")
                    {
                        if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                        {
                            if (uc_DeJP_Loai11.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                    return;
                            }
                            else
                                uc_DeJP_Loai11.SaveData_Loai1_DeSo(lb_IdImage.Text);
                        }
                        else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                        {
                            if (uc_DeJP_Loai21.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                    return;
                                Global.db.Insert_Loai2_DeS0(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                "", "", txt_Truong06.Text, txt_Truong08.Text, "", "", "", Global.LoaiPhieu, "1");
                            }
                            else
                            {
                                uc_DeJP_Loai21.SaveData_Loai2_DeSo(lb_IdImage.Text);
                            }
                            //Xứ lý 2 user nhập số lượng dòng khác nhau
                            Global.db.CheckRowNumber_DeSo(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                        }
                        uc_DeJP_Loai11.ResetData();
                        uc_DeJP_Loai21.ResetData();
                    }

                    string temp = GetImage();
                    
                    if (temp == "NULL")
                    {
                        MessageBox.Show("Hết Hình!");
                        btn_logout_ItemClick(null, null);
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Không thể load hình!");
                        btn_logout_ItemClick(null, null);
                    }
                }
                setValue();
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi khi Submit" + i.Message);
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
                    MessageBox.Show("User đã đăng nhập ở PC khác, bạn vui lòng đăng nhập lại!");
                    DialogResult = DialogResult.Yes;
                }
                
                if (Global.StrRole == "DEJP")
                {
                    if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                    {
                        if (uc_DeJP_Loai11.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        uc_DeJP_Loai11.SaveData_Loai1_DeJP(lb_IdImage.Text);
                    }
                    else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                    {
                        if (uc_DeJP_Loai21.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                return;
                            Global.db.Insert_Loai2(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                "", "", txt_Truong06.Text, txt_Truong08.Text, "", "", "", Global.LoaiPhieu, "1");
                        }
                        else
                        {
                            uc_DeJP_Loai21.SaveData_Loai2_DeJP(lb_IdImage.Text);
                        }
                        //Xứ lý 2 user nhập số lượng dòng khác nhau
                        Global.db.CheckRowNumber(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                    }
                }
                if (Global.StrRole == "DESO")
                {
                    if (tabControl_Main.SelectedTabPage == tp_Loai1_JP_Main)
                    {
                        if (uc_DeJP_Loai11.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        uc_DeJP_Loai11.SaveData_Loai1_DeSo(lb_IdImage.Text);
                    }
                    else if (tabControl_Main.SelectedTabPage == tp_Loai2_JP_Main)
                    {
                        if (uc_DeJP_Loai21.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                                return;
                            Global.db.Insert_Loai2_DeS0(lb_IdImage.Text, Global.StrBatch, Global.StrUsername, "",
                                "", "", txt_Truong06.Text, txt_Truong08.Text, "", "", "", Global.LoaiPhieu, "1");
                        }
                        else
                        {
                            uc_DeJP_Loai21.SaveData_Loai2_DeSo(lb_IdImage.Text);
                        }
                        //Xứ lý 2 user nhập số lượng dòng khác nhau
                        Global.db.CheckRowNumber_DeSo(lb_IdImage.Text, Global.StrBatch, Global.StrUsername);
                    }
                }
                btn_logout_ItemClick(null, null);
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi khi Submit_Logout" + i.Message);
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
        }
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                btn_Start_Submit_Click(null, null);
            if (e.Control && e.KeyCode == Keys.Up)
                uc_PictureBox1.btn_Xoaytrai_Click(null, null);
            if (e.Control && e.KeyCode == Keys.Down)
                uc_PictureBox1.btn_xoayphai_Click(null, null);
            if (e.KeyCode == Keys.Escape)
            {
                new frm_FreeTime().ShowDialog();
                Global.db_BPO.UpdateTimeFree(Global.Strtoken, Global.FreeTime);
            }
            if (!e.Control && e.KeyCode == Keys.Enter)
            {
                //if (tabControl_Main.SelectedTabPage == tp_AEON_Main)
                //    uc_AEON1.txt_Truong03_1.Focus();
                //else if (tabControl_Main.SelectedTabPage == tp_Asahi_Main)
                //    uc_ASAHI1.txt_Truong03_1.Focus();
            }
        }
        private void btn_checkqc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.StrCheck = "CHECKDEJP";
            new frm_Check_DeJP().ShowDialog();
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

        private void btn_nangsuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new frm_NangSuat().ShowDialog();
        }

        private void btn_tiendo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new frm_TienDo().ShowDialog();
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
    }
}
