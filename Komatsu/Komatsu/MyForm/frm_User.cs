using System;
using System.Windows.Forms;

namespace KOMTSU.MyForm
{
    public partial class frm_User : DevExpress.XtraEditors.XtraForm
    {
        public frm_User()
        {
            InitializeComponent();
        }

        private void frm_User_Load(object sender, EventArgs e)
        {
            dgv_listuser.DataSource = Global.db_BPO.GetListUser();
            cbb_idrole.DataSource = Global.db_BPO.GetListRole();
            cbb_idrole.DisplayMember = "RoleName";
            cbb_idrole.ValueMember = "RoleID";
        }
        private void btn_suauser_Click(object sender, EventArgs e)
        {
            string roleid, nhanvien;
            nhanvien = txt_FullName.Text;
            roleid = cbb_idrole.SelectedValue != null ? cbb_idrole.SelectedValue.ToString() : "";

            if (!string.IsNullOrEmpty(roleid) && !string.IsNullOrEmpty(nhanvien) && !string.IsNullOrEmpty(txt_username.Text) && !string.IsNullOrEmpty(txt_password.Text))
            {
                DialogResult thongbao = MessageBox.Show("Bạn chắc chắn muốn sửa UserName '" + txt_username.Text + "'", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    Global.db_BPO.UpdateUsername(txt_username.Text, txt_password.Text, roleid, nhanvien, txt_grouplevel.Text);
                    frm_User_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin trước khi lưu !");
            }
        }
        
        private void btn_themuser_Click(object sender, EventArgs e)
        {

            string roleid, nhanvien;
            int r;

            nhanvien = txt_FullName.Text;
            roleid = cbb_idrole.SelectedValue != null ? cbb_idrole.SelectedValue.ToString() : "";

            if (!string.IsNullOrEmpty(roleid)&&!string.IsNullOrEmpty(nhanvien)&& !string.IsNullOrEmpty(txt_username.Text)&&!string.IsNullOrEmpty(txt_password.Text))
            {
                r = Global.db_BPO.InsertUsername(txt_username.Text, txt_password.Text, roleid,nhanvien, txt_grouplevel.Text);
                if (r == 0)
                {
                    MessageBox.Show("UserName đã tồn tại, Vui lòng nhập UserName khác !");
                }
                if (r == 1)
                {
                    MessageBox.Show("Đã thêm UserName '" + txt_username.Text + "' !");
                    frm_User_Load(sender, e);
                    txt_username.Text = "";
                    txt_FullName.Text = "";
                    txt_username.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin trước khi lưu !");
            }
        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string username = gridView1.GetFocusedRowCellValue("Username") != null ? gridView1.GetFocusedRowCellValue("Username").ToString() : "";
            DialogResult thongbao = MessageBox.Show("Bạn chắc chắn muốn xóa UserName '" +username + "'", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                if(!string.IsNullOrEmpty(username))
                {
                    Global.db_BPO.DeleteUsername(username);
                    frm_User_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Username rỗng, không thể xóa!");
                }
            }
        }
        
        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //string Username, Password, grouplevel, roleid, idnhanvien;

            //Username = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username").ToString() : "";
            //grouplevel = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level").ToString() : "";
            //Password = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString() : "";
            //roleid = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole").ToString() : "";
            //idnhanvien = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName").ToString() : "";

            //txt_username.Text = Username;
            //txt_password.Text = Password;
            //txt_grouplevel.Text = grouplevel;
            //txt_FullName.Text = idnhanvien;

            //cbb_idrole.DataSource = Global.db_BPO.GetListRole();
            //cbb_idrole.DisplayMember = "RoleName";
            //cbb_idrole.ValueMember = "RoleID";
            //cbb_idrole.SelectedValue = roleid;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            try
            {
                txt_username.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username").ToString() : "";
                txt_grouplevel.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level").ToString() : "";
                txt_password.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString() : "";
                cbb_idrole.SelectedValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole").ToString() : "";
                txt_FullName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName").ToString() : "";

            }
            catch (Exception i)
            {

            }

        }
        
    }
}