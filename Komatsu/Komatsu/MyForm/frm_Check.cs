using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KOMTSU.Properties;

namespace KOMTSU.MyForm
{
    public partial class frm_Check : XtraForm
    {
        public frm_Check()
        {
            InitializeComponent();
        }
        private void ResetData()
        {
            uC_DESO1.ResetData();
            uC_DESO2.ResetData();
            uc_PictureBox1.imageBox1.Image = null;
        }
        private void uC_DESO1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uC_DESO1.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uC_DESO2.VerticalScroll.Value = e.NewValue;
        }

        private void uC_DESO2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uC_DESO2.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uC_DESO1.VerticalScroll.Value = e.NewValue;
        }

        private void frm_Check_Load(object sender, EventArgs e)
        {
            try
            {
                lb_fBatchName.Text = Global.StrBatch;

                var soloi = ((from w in Global.db.tbl_DESOs where w.fBatchName == Global.StrBatch && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
                lb_Loi.Text = soloi + " Lỗi";

                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;

                uC_DESO1.Changededit+= UC_Row_01_Changed;
                uC_DESO1.uC_Row_01.Changed += UC_Row_01_Changed;
                uC_DESO1.uC_Row_02.Changed += UC_Row_01_Changed;
              

                uC_DESO2.Changededit+= UC_Row_01_Changed1;
                uC_DESO2.uC_Row_01.Changed += UC_Row_01_Changed1;
                uC_DESO2.uC_Row_02.Changed += UC_Row_01_Changed1;
                
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi" + i);
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
            if (Global.BatchChiaUser)
            {
                var result = Global.db.InputFinish_Group(Global.StrBatch);
                if (result == 1)
                {
                    MessageBox.Show("Batch này chưa nhập xong. Vui lòng nhập cho xong trước đã.");
                    return;
                }
            }
            else
            {
                var result = Global.db.InputFinish(Global.StrBatch);
                if (result == 1)
                {
                    MessageBox.Show("Batch này chưa nhập xong. Vui lòng nhập cho xong trước đã.");
                    return;
                }
            }
           
            var userMissimage = (from w in Global.db.MissImage_DESO(Global.StrBatch) select w.username).ToList();
            string sss = "";
            foreach (var item in userMissimage)
            {
                sss += item + "\r\n";
            }

            if (userMissimage.Count > 0)
            {
                MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                return;
            }
            string temp = GetImage_DeSo();
            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Dispose();
                MessageBox.Show("Hết Hình!");
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                return;
            }
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
            btn_Start.Visible = false;
        }
        private string GetImage_DeSo()
        {
            var temp = (from w in Global.db.tbl_MissCheck_DESOs
                        where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0
                        select w.IdImage).FirstOrDefault();
            if (string.IsNullOrEmpty(temp))
            {
                var getFilename =
                    (from w in Global.db.ImageCheck(Global.StrBatch, Global.StrUsername)
                     select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(getFilename))
                {
                    return "NULL";
                }
                else
                {
                    lb_Image.Text = getFilename;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,Properties.Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }
                }
            }
            else
            {
                lb_Image.Text = temp;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp,Properties.Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            return "ok";
        }

        private void Load_DeSo(string strBatch, string idimage)
        {
            var deso = (from w in Global.db.tbl_DESOs
                        where w.fBatchName == strBatch && w.IdImage == idimage
                        select new
                        {
                            w.UserName,
                            w.Truong_01,
                            w.Truong_02,
                            w.Truong_03,
                            w.IdPhieu,
                            w.Truong_04,
                            w.Truong_05,
                            w.Truong_06,
                            w.Truong_07,
                            w.Truong_08,
                            w.STT
                        }).ToList();
            lb_username1.Text = deso[0].UserName;
            lb_username2.Text = deso[32].UserName;

            uC_DESO1.txt_TruongSo01.Text = deso[0].Truong_01;
            uC_DESO1.txt_TruongSo02.Text = deso[0].Truong_02;
            uC_DESO1.txt_TruongSo03.Text = deso[0].Truong_03;

            uC_DESO1.uC_Row_01.loadData(deso[0].STT, deso[0].Truong_04, deso[0].Truong_05, deso[0].Truong_06, deso[0].Truong_07, deso[0].Truong_08);
            uC_DESO1.uC_Row_02.loadData(deso[1].STT, deso[1].Truong_04, deso[1].Truong_05, deso[1].Truong_06, deso[1].Truong_07, deso[1].Truong_08);
            uC_DESO1.uC_Row_03.loadData(deso[2].STT, deso[2].Truong_04, deso[2].Truong_05, deso[2].Truong_06, deso[2].Truong_07, deso[2].Truong_08);
            uC_DESO1.uC_Row_04.loadData(deso[3].STT, deso[3].Truong_04, deso[3].Truong_05, deso[3].Truong_06, deso[3].Truong_07, deso[3].Truong_08);
            uC_DESO1.uC_Row_05.loadData(deso[4].STT, deso[4].Truong_04, deso[4].Truong_05, deso[4].Truong_06, deso[4].Truong_07, deso[4].Truong_08);
            uC_DESO1.uC_Row_06.loadData(deso[5].STT, deso[5].Truong_04, deso[5].Truong_05, deso[5].Truong_06, deso[5].Truong_07, deso[5].Truong_08);
            uC_DESO1.uC_Row_07.loadData(deso[6].STT, deso[6].Truong_04, deso[6].Truong_05, deso[6].Truong_06, deso[6].Truong_07, deso[6].Truong_08);
            uC_DESO1.uC_Row_08.loadData(deso[7].STT, deso[7].Truong_04, deso[7].Truong_05, deso[7].Truong_06, deso[7].Truong_07, deso[7].Truong_08);
            uC_DESO1.uC_Row_09.loadData(deso[8].STT, deso[8].Truong_04, deso[8].Truong_05, deso[8].Truong_06, deso[8].Truong_07, deso[8].Truong_08);
            uC_DESO1.uC_Row_10.loadData(deso[9].STT, deso[9].Truong_04, deso[9].Truong_05, deso[9].Truong_06, deso[9].Truong_07, deso[9].Truong_08);
            uC_DESO1.uC_Row_11.loadData(deso[10].STT, deso[10].Truong_04, deso[10].Truong_05, deso[10].Truong_06, deso[10].Truong_07, deso[10].Truong_08);
            uC_DESO1.uC_Row_12.loadData(deso[11].STT, deso[11].Truong_04, deso[11].Truong_05, deso[11].Truong_06, deso[11].Truong_07, deso[11].Truong_08);
            uC_DESO1.uC_Row_13.loadData(deso[12].STT, deso[12].Truong_04, deso[12].Truong_05, deso[12].Truong_06, deso[12].Truong_07, deso[12].Truong_08);
            uC_DESO1.uC_Row_14.loadData(deso[13].STT, deso[13].Truong_04, deso[13].Truong_05, deso[13].Truong_06, deso[13].Truong_07, deso[13].Truong_08);
            uC_DESO1.uC_Row_15.loadData(deso[14].STT, deso[14].Truong_04, deso[14].Truong_05, deso[14].Truong_06, deso[14].Truong_07, deso[14].Truong_08);
            uC_DESO1.uC_Row_16.loadData(deso[15].STT, deso[15].Truong_04, deso[15].Truong_05, deso[15].Truong_06, deso[15].Truong_07, deso[15].Truong_08);
            uC_DESO1.uC_Row_17.loadData(deso[16].STT, deso[16].Truong_04, deso[16].Truong_05, deso[16].Truong_06, deso[16].Truong_07, deso[16].Truong_08);
            uC_DESO1.uC_Row_18.loadData(deso[17].STT, deso[17].Truong_04, deso[17].Truong_05, deso[17].Truong_06, deso[17].Truong_07, deso[17].Truong_08);
            uC_DESO1.uC_Row_19.loadData(deso[18].STT, deso[18].Truong_04, deso[18].Truong_05, deso[18].Truong_06, deso[18].Truong_07, deso[18].Truong_08);
            uC_DESO1.uC_Row_20.loadData(deso[19].STT, deso[19].Truong_04, deso[19].Truong_05, deso[19].Truong_06, deso[19].Truong_07, deso[19].Truong_08);
            uC_DESO1.uC_Row_21.loadData(deso[20].STT, deso[20].Truong_04, deso[20].Truong_05, deso[20].Truong_06, deso[20].Truong_07, deso[20].Truong_08);
            uC_DESO1.uC_Row_22.loadData(deso[21].STT, deso[21].Truong_04, deso[21].Truong_05, deso[21].Truong_06, deso[21].Truong_07, deso[21].Truong_08);
            uC_DESO1.uC_Row_23.loadData(deso[22].STT, deso[22].Truong_04, deso[22].Truong_05, deso[22].Truong_06, deso[22].Truong_07, deso[22].Truong_08);
            uC_DESO1.uC_Row_24.loadData(deso[23].STT, deso[23].Truong_04, deso[23].Truong_05, deso[23].Truong_06, deso[23].Truong_07, deso[23].Truong_08);
            uC_DESO1.uC_Row_25.loadData(deso[24].STT, deso[24].Truong_04, deso[24].Truong_05, deso[24].Truong_06, deso[24].Truong_07, deso[24].Truong_08);
            uC_DESO1.uC_Row_26.loadData(deso[25].STT, deso[25].Truong_04, deso[25].Truong_05, deso[25].Truong_06, deso[25].Truong_07, deso[25].Truong_08);
            uC_DESO1.uC_Row_27.loadData(deso[26].STT, deso[26].Truong_04, deso[26].Truong_05, deso[26].Truong_06, deso[26].Truong_07, deso[26].Truong_08);
            uC_DESO1.uC_Row_28.loadData(deso[27].STT, deso[27].Truong_04, deso[27].Truong_05, deso[27].Truong_06, deso[27].Truong_07, deso[27].Truong_08);
            uC_DESO1.uC_Row_29.loadData(deso[28].STT, deso[28].Truong_04, deso[28].Truong_05, deso[28].Truong_06, deso[28].Truong_07, deso[28].Truong_08);
            uC_DESO1.uC_Row_30.loadData(deso[29].STT, deso[29].Truong_04, deso[29].Truong_05, deso[29].Truong_06, deso[29].Truong_07, deso[29].Truong_08);
            uC_DESO1.uC_Row_31.loadData(deso[30].STT, deso[30].Truong_04, deso[30].Truong_05, deso[30].Truong_06, deso[30].Truong_07, deso[30].Truong_08);

            uC_DESO2.txt_TruongSo01.Text = deso[31].Truong_01;
            uC_DESO2.txt_TruongSo02.Text = deso[31].Truong_02;
            uC_DESO2.txt_TruongSo03.Text = deso[31].Truong_03;
            
            uC_DESO2.uC_Row_01.loadData(deso[31].STT, deso[31].Truong_04, deso[31].Truong_05, deso[31].Truong_06, deso[31].Truong_07, deso[31].Truong_08);
            uC_DESO2.uC_Row_02.loadData(deso[32].STT, deso[32].Truong_04, deso[32].Truong_05, deso[32].Truong_06, deso[32].Truong_07, deso[32].Truong_08);
            uC_DESO2.uC_Row_03.loadData(deso[33].STT, deso[33].Truong_04, deso[33].Truong_05, deso[33].Truong_06, deso[33].Truong_07, deso[33].Truong_08);
            uC_DESO2.uC_Row_04.loadData(deso[34].STT, deso[34].Truong_04, deso[34].Truong_05, deso[34].Truong_06, deso[34].Truong_07, deso[34].Truong_08);
            uC_DESO2.uC_Row_05.loadData(deso[35].STT, deso[35].Truong_04, deso[35].Truong_05, deso[35].Truong_06, deso[35].Truong_07, deso[35].Truong_08);
            uC_DESO2.uC_Row_06.loadData(deso[36].STT, deso[36].Truong_04, deso[36].Truong_05, deso[36].Truong_06, deso[36].Truong_07, deso[36].Truong_08);
            uC_DESO2.uC_Row_07.loadData(deso[37].STT, deso[37].Truong_04, deso[37].Truong_05, deso[37].Truong_06, deso[37].Truong_07, deso[37].Truong_08);
            uC_DESO2.uC_Row_08.loadData(deso[38].STT, deso[38].Truong_04, deso[38].Truong_05, deso[38].Truong_06, deso[38].Truong_07, deso[38].Truong_08);
            uC_DESO2.uC_Row_09.loadData(deso[39].STT, deso[39].Truong_04, deso[39].Truong_05, deso[39].Truong_06, deso[39].Truong_07, deso[39].Truong_08);
            uC_DESO2.uC_Row_10.loadData(deso[40].STT, deso[40].Truong_04, deso[40].Truong_05, deso[40].Truong_06, deso[40].Truong_07, deso[40].Truong_08);
            uC_DESO2.uC_Row_11.loadData(deso[41].STT, deso[41].Truong_04, deso[41].Truong_05, deso[41].Truong_06, deso[41].Truong_07, deso[41].Truong_08);
            uC_DESO2.uC_Row_12.loadData(deso[42].STT, deso[42].Truong_04, deso[42].Truong_05, deso[42].Truong_06, deso[42].Truong_07, deso[42].Truong_08);
            uC_DESO2.uC_Row_13.loadData(deso[43].STT, deso[43].Truong_04, deso[43].Truong_05, deso[43].Truong_06, deso[43].Truong_07, deso[43].Truong_08);
            uC_DESO2.uC_Row_14.loadData(deso[44].STT, deso[44].Truong_04, deso[44].Truong_05, deso[44].Truong_06, deso[44].Truong_07, deso[44].Truong_08);
            uC_DESO2.uC_Row_15.loadData(deso[45].STT, deso[45].Truong_04, deso[45].Truong_05, deso[45].Truong_06, deso[45].Truong_07, deso[45].Truong_08);
            uC_DESO2.uC_Row_16.loadData(deso[46].STT, deso[46].Truong_04, deso[46].Truong_05, deso[46].Truong_06, deso[46].Truong_07, deso[46].Truong_08);
            uC_DESO2.uC_Row_17.loadData(deso[47].STT, deso[47].Truong_04, deso[47].Truong_05, deso[47].Truong_06, deso[47].Truong_07, deso[47].Truong_08);
            uC_DESO2.uC_Row_18.loadData(deso[48].STT, deso[48].Truong_04, deso[48].Truong_05, deso[48].Truong_06, deso[48].Truong_07, deso[48].Truong_08);
            uC_DESO2.uC_Row_19.loadData(deso[49].STT, deso[49].Truong_04, deso[49].Truong_05, deso[49].Truong_06, deso[49].Truong_07, deso[49].Truong_08);
            uC_DESO2.uC_Row_20.loadData(deso[50].STT, deso[50].Truong_04, deso[50].Truong_05, deso[50].Truong_06, deso[50].Truong_07, deso[50].Truong_08);
            uC_DESO2.uC_Row_21.loadData(deso[51].STT, deso[51].Truong_04, deso[51].Truong_05, deso[51].Truong_06, deso[51].Truong_07, deso[51].Truong_08);
            uC_DESO2.uC_Row_22.loadData(deso[52].STT, deso[52].Truong_04, deso[52].Truong_05, deso[52].Truong_06, deso[52].Truong_07, deso[52].Truong_08);
            uC_DESO2.uC_Row_23.loadData(deso[53].STT, deso[53].Truong_04, deso[53].Truong_05, deso[53].Truong_06, deso[53].Truong_07, deso[53].Truong_08);
            uC_DESO2.uC_Row_24.loadData(deso[54].STT, deso[54].Truong_04, deso[54].Truong_05, deso[54].Truong_06, deso[54].Truong_07, deso[54].Truong_08);
            uC_DESO2.uC_Row_25.loadData(deso[55].STT, deso[55].Truong_04, deso[55].Truong_05, deso[55].Truong_06, deso[55].Truong_07, deso[55].Truong_08);
            uC_DESO2.uC_Row_26.loadData(deso[56].STT, deso[56].Truong_04, deso[56].Truong_05, deso[56].Truong_06, deso[56].Truong_07, deso[56].Truong_08);
            uC_DESO2.uC_Row_27.loadData(deso[57].STT, deso[57].Truong_04, deso[57].Truong_05, deso[57].Truong_06, deso[57].Truong_07, deso[57].Truong_08);
            uC_DESO2.uC_Row_28.loadData(deso[58].STT, deso[58].Truong_04, deso[58].Truong_05, deso[58].Truong_06, deso[58].Truong_07, deso[58].Truong_08);
            uC_DESO2.uC_Row_29.loadData(deso[59].STT, deso[59].Truong_04, deso[59].Truong_05, deso[59].Truong_06, deso[59].Truong_07, deso[59].Truong_08);
            uC_DESO2.uC_Row_30.loadData(deso[60].STT, deso[60].Truong_04, deso[60].Truong_05, deso[60].Truong_06, deso[60].Truong_07, deso[60].Truong_08);
            uC_DESO2.uC_Row_31.loadData(deso[61].STT, deso[61].Truong_04, deso[61].Truong_05, deso[61].Truong_06, deso[61].Truong_07, deso[61].Truong_08);

            Compare_TextEdit(uC_DESO1.txt_TruongSo01, uC_DESO2.txt_TruongSo01);
            Compare_TextEdit(uC_DESO1.txt_TruongSo02, uC_DESO2.txt_TruongSo02);
            Compare_TextEdit(uC_DESO1.txt_TruongSo03, uC_DESO2.txt_TruongSo03);

            Compare_TextBox(uC_DESO1.uC_Row_01.txt_TruongSo04, uC_DESO2.uC_Row_01.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_01.txt_TruongSo05, uC_DESO2.uC_Row_01.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_01.txt_TruongSo06, uC_DESO2.uC_Row_01.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_01.txt_TruongSo07, uC_DESO2.uC_Row_01.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_01.txt_TruongSo08, uC_DESO2.uC_Row_01.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_02.txt_TruongSo04, uC_DESO2.uC_Row_02.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_02.txt_TruongSo05, uC_DESO2.uC_Row_02.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_02.txt_TruongSo06, uC_DESO2.uC_Row_02.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_02.txt_TruongSo07, uC_DESO2.uC_Row_02.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_02.txt_TruongSo08, uC_DESO2.uC_Row_02.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_03.txt_TruongSo04, uC_DESO2.uC_Row_03.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_03.txt_TruongSo05, uC_DESO2.uC_Row_03.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_03.txt_TruongSo06, uC_DESO2.uC_Row_03.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_03.txt_TruongSo07, uC_DESO2.uC_Row_03.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_03.txt_TruongSo08, uC_DESO2.uC_Row_03.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_04.txt_TruongSo04, uC_DESO2.uC_Row_04.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_04.txt_TruongSo05, uC_DESO2.uC_Row_04.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_04.txt_TruongSo06, uC_DESO2.uC_Row_04.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_04.txt_TruongSo07, uC_DESO2.uC_Row_04.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_04.txt_TruongSo08, uC_DESO2.uC_Row_04.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_05.txt_TruongSo04, uC_DESO2.uC_Row_05.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_05.txt_TruongSo05, uC_DESO2.uC_Row_05.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_05.txt_TruongSo06, uC_DESO2.uC_Row_05.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_05.txt_TruongSo07, uC_DESO2.uC_Row_05.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_05.txt_TruongSo08, uC_DESO2.uC_Row_05.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_06.txt_TruongSo04, uC_DESO2.uC_Row_06.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_06.txt_TruongSo05, uC_DESO2.uC_Row_06.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_06.txt_TruongSo06, uC_DESO2.uC_Row_06.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_06.txt_TruongSo07, uC_DESO2.uC_Row_06.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_06.txt_TruongSo08, uC_DESO2.uC_Row_06.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_07.txt_TruongSo04, uC_DESO2.uC_Row_07.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_07.txt_TruongSo05, uC_DESO2.uC_Row_07.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_07.txt_TruongSo06, uC_DESO2.uC_Row_07.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_07.txt_TruongSo07, uC_DESO2.uC_Row_07.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_07.txt_TruongSo08, uC_DESO2.uC_Row_07.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_08.txt_TruongSo04, uC_DESO2.uC_Row_08.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_08.txt_TruongSo05, uC_DESO2.uC_Row_08.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_08.txt_TruongSo06, uC_DESO2.uC_Row_08.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_08.txt_TruongSo07, uC_DESO2.uC_Row_08.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_08.txt_TruongSo08, uC_DESO2.uC_Row_08.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_09.txt_TruongSo04, uC_DESO2.uC_Row_09.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_09.txt_TruongSo05, uC_DESO2.uC_Row_09.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_09.txt_TruongSo06, uC_DESO2.uC_Row_09.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_09.txt_TruongSo07, uC_DESO2.uC_Row_09.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_09.txt_TruongSo08, uC_DESO2.uC_Row_09.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_10.txt_TruongSo04, uC_DESO2.uC_Row_10.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_10.txt_TruongSo05, uC_DESO2.uC_Row_10.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_10.txt_TruongSo06, uC_DESO2.uC_Row_10.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_10.txt_TruongSo07, uC_DESO2.uC_Row_10.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_10.txt_TruongSo08, uC_DESO2.uC_Row_10.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_11.txt_TruongSo04, uC_DESO2.uC_Row_11.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_11.txt_TruongSo05, uC_DESO2.uC_Row_11.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_11.txt_TruongSo06, uC_DESO2.uC_Row_11.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_11.txt_TruongSo07, uC_DESO2.uC_Row_11.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_11.txt_TruongSo08, uC_DESO2.uC_Row_11.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_12.txt_TruongSo04, uC_DESO2.uC_Row_12.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_12.txt_TruongSo05, uC_DESO2.uC_Row_12.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_12.txt_TruongSo06, uC_DESO2.uC_Row_12.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_12.txt_TruongSo07, uC_DESO2.uC_Row_12.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_12.txt_TruongSo08, uC_DESO2.uC_Row_12.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_13.txt_TruongSo04, uC_DESO2.uC_Row_13.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_13.txt_TruongSo05, uC_DESO2.uC_Row_13.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_13.txt_TruongSo06, uC_DESO2.uC_Row_13.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_13.txt_TruongSo07, uC_DESO2.uC_Row_13.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_13.txt_TruongSo08, uC_DESO2.uC_Row_13.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_14.txt_TruongSo04, uC_DESO2.uC_Row_14.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_14.txt_TruongSo05, uC_DESO2.uC_Row_14.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_14.txt_TruongSo06, uC_DESO2.uC_Row_14.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_14.txt_TruongSo07, uC_DESO2.uC_Row_14.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_14.txt_TruongSo08, uC_DESO2.uC_Row_14.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_15.txt_TruongSo04, uC_DESO2.uC_Row_15.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_15.txt_TruongSo05, uC_DESO2.uC_Row_15.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_15.txt_TruongSo06, uC_DESO2.uC_Row_15.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_15.txt_TruongSo07, uC_DESO2.uC_Row_15.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_15.txt_TruongSo08, uC_DESO2.uC_Row_15.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_16.txt_TruongSo04, uC_DESO2.uC_Row_16.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_16.txt_TruongSo05, uC_DESO2.uC_Row_16.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_16.txt_TruongSo06, uC_DESO2.uC_Row_16.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_16.txt_TruongSo07, uC_DESO2.uC_Row_16.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_16.txt_TruongSo08, uC_DESO2.uC_Row_16.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_17.txt_TruongSo04, uC_DESO2.uC_Row_17.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_17.txt_TruongSo05, uC_DESO2.uC_Row_17.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_17.txt_TruongSo06, uC_DESO2.uC_Row_17.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_17.txt_TruongSo07, uC_DESO2.uC_Row_17.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_17.txt_TruongSo08, uC_DESO2.uC_Row_17.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_18.txt_TruongSo04, uC_DESO2.uC_Row_18.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_18.txt_TruongSo05, uC_DESO2.uC_Row_18.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_18.txt_TruongSo06, uC_DESO2.uC_Row_18.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_18.txt_TruongSo07, uC_DESO2.uC_Row_18.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_18.txt_TruongSo08, uC_DESO2.uC_Row_18.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_19.txt_TruongSo04, uC_DESO2.uC_Row_19.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_19.txt_TruongSo05, uC_DESO2.uC_Row_19.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_19.txt_TruongSo06, uC_DESO2.uC_Row_19.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_19.txt_TruongSo07, uC_DESO2.uC_Row_19.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_19.txt_TruongSo08, uC_DESO2.uC_Row_19.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_20.txt_TruongSo04, uC_DESO2.uC_Row_20.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_20.txt_TruongSo05, uC_DESO2.uC_Row_20.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_20.txt_TruongSo06, uC_DESO2.uC_Row_20.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_20.txt_TruongSo07, uC_DESO2.uC_Row_20.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_20.txt_TruongSo08, uC_DESO2.uC_Row_20.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_21.txt_TruongSo04, uC_DESO2.uC_Row_21.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_21.txt_TruongSo05, uC_DESO2.uC_Row_21.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_21.txt_TruongSo06, uC_DESO2.uC_Row_21.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_21.txt_TruongSo07, uC_DESO2.uC_Row_21.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_21.txt_TruongSo08, uC_DESO2.uC_Row_21.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_22.txt_TruongSo04, uC_DESO2.uC_Row_22.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_22.txt_TruongSo05, uC_DESO2.uC_Row_22.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_22.txt_TruongSo06, uC_DESO2.uC_Row_22.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_22.txt_TruongSo07, uC_DESO2.uC_Row_22.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_22.txt_TruongSo08, uC_DESO2.uC_Row_22.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_23.txt_TruongSo04, uC_DESO2.uC_Row_23.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_23.txt_TruongSo05, uC_DESO2.uC_Row_23.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_23.txt_TruongSo06, uC_DESO2.uC_Row_23.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_23.txt_TruongSo07, uC_DESO2.uC_Row_23.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_23.txt_TruongSo08, uC_DESO2.uC_Row_23.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_24.txt_TruongSo04, uC_DESO2.uC_Row_24.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_24.txt_TruongSo05, uC_DESO2.uC_Row_24.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_24.txt_TruongSo06, uC_DESO2.uC_Row_24.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_24.txt_TruongSo07, uC_DESO2.uC_Row_24.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_24.txt_TruongSo08, uC_DESO2.uC_Row_24.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_25.txt_TruongSo04, uC_DESO2.uC_Row_25.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_25.txt_TruongSo05, uC_DESO2.uC_Row_25.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_25.txt_TruongSo06, uC_DESO2.uC_Row_25.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_25.txt_TruongSo07, uC_DESO2.uC_Row_25.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_25.txt_TruongSo08, uC_DESO2.uC_Row_25.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_26.txt_TruongSo04, uC_DESO2.uC_Row_26.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_26.txt_TruongSo05, uC_DESO2.uC_Row_26.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_26.txt_TruongSo06, uC_DESO2.uC_Row_26.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_26.txt_TruongSo07, uC_DESO2.uC_Row_26.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_26.txt_TruongSo08, uC_DESO2.uC_Row_26.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_27.txt_TruongSo04, uC_DESO2.uC_Row_27.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_27.txt_TruongSo05, uC_DESO2.uC_Row_27.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_27.txt_TruongSo06, uC_DESO2.uC_Row_27.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_27.txt_TruongSo07, uC_DESO2.uC_Row_27.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_27.txt_TruongSo08, uC_DESO2.uC_Row_27.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_28.txt_TruongSo04, uC_DESO2.uC_Row_28.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_28.txt_TruongSo05, uC_DESO2.uC_Row_28.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_28.txt_TruongSo06, uC_DESO2.uC_Row_28.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_28.txt_TruongSo07, uC_DESO2.uC_Row_28.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_28.txt_TruongSo08, uC_DESO2.uC_Row_28.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_29.txt_TruongSo04, uC_DESO2.uC_Row_29.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_29.txt_TruongSo05, uC_DESO2.uC_Row_29.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_29.txt_TruongSo06, uC_DESO2.uC_Row_29.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_29.txt_TruongSo07, uC_DESO2.uC_Row_29.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_29.txt_TruongSo08, uC_DESO2.uC_Row_29.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_30.txt_TruongSo04, uC_DESO2.uC_Row_30.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_30.txt_TruongSo05, uC_DESO2.uC_Row_30.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_30.txt_TruongSo06, uC_DESO2.uC_Row_30.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_30.txt_TruongSo07, uC_DESO2.uC_Row_30.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_30.txt_TruongSo08, uC_DESO2.uC_Row_30.txt_TruongSo08);

            Compare_TextBox(uC_DESO1.uC_Row_31.txt_TruongSo04, uC_DESO2.uC_Row_31.txt_TruongSo04);
            Compare_LockupEdit(uC_DESO1.uC_Row_31.txt_TruongSo05, uC_DESO2.uC_Row_31.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.uC_Row_31.txt_TruongSo06, uC_DESO2.uC_Row_31.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.uC_Row_31.txt_TruongSo07, uC_DESO2.uC_Row_31.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.uC_Row_31.txt_TruongSo08, uC_DESO2.uC_Row_31.txt_TruongSo08);

            var soloi = ((from w in Global.db.tbl_DESOs where w.fBatchName == Global.StrBatch && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
            lb_Loi.Text = soloi + " Lỗi";
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

            uC_DESO1.LuuDeSo(lb_Image.Text, Global.StrBatch, lb_username1.Text, lb_username2.Text, Global.StrUsername);
            ResetData();
            string temp = GetImage_DeSo();
            
            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Dispose();
                MessageBox.Show("Hết Hình!");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
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
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void btn_Luu_DeSo2_Click(object sender, EventArgs e)
        {
            uC_DESO2.LuuDeSo(lb_Image.Text, Global.StrBatch, lb_username2.Text, lb_username1.Text, Global.StrUsername);
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Dispose();
                MessageBox.Show("Hết Hình!");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
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
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void btn_SuaVaLuu_User1_Click(object sender, EventArgs e)
        {
            uC_DESO1.SuaVaLuu(lb_username1.Text, lb_username2.Text, lb_Image.Text, Global.StrBatch, Global.StrUsername);
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Dispose();
                MessageBox.Show("Hết Hình!");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
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
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }

        private void btn_SuaVaLuu_User2_Click(object sender, EventArgs e)
        {
            uC_DESO2.SuaVaLuu(lb_username2.Text, lb_username1.Text, lb_Image.Text, Global.StrBatch, Global.StrUsername);
            ResetData();
            string temp = GetImage_DeSo();

            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Dispose();
                MessageBox.Show("Hết Hình!");
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
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
            Load_DeSo(Global.StrBatch, lb_Image.Text);
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
    }
}