using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;


namespace WindowsFormsApp1
{
    public partial class QLTK : Form
    {
        public QLTK()
        {
            InitializeComponent();
            qLTKBLL.Hienthi(dvgQLTK);
        }

        private QLTKBLL qLTKBLL = new QLTKBLL();
        private QLTKDTO qLTKDTO = new QLTKDTO();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow >= 0 && indexRow < dvgQLTK.RowCount - 1)
            {
                txtTaikhoan.Text = dvgQLTK.Rows[indexRow].Cells[0].Value.ToString();
                txtMatkhau.Text = dvgQLTK.Rows[indexRow].Cells[1].Value.ToString();

            }
            }
            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void QLTK_Load(object sender, EventArgs e)
        {

        }


        private void btThem_Click(object sender, EventArgs e)
        {
            if(txtTaikhoan.Text.Trim() != "")
            {
                qLTKDTO.TaiKhoan = txtTaikhoan.Text.ToLower();
                qLTKDTO.MatKhau = txtMatkhau.Text;
                qLTKBLL.Them(qLTKDTO);
                qLTKBLL.Hienthi(dvgQLTK);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if(txtTaikhoan.Text.Trim() !="")
            {
                qLTKDTO.TaiKhoan = txtTaikhoan.Text.ToLower();
                qLTKDTO.MatKhau = txtMatkhau.Text;
                qLTKBLL.Sua(qLTKDTO);
                qLTKBLL.Hienthi(dvgQLTK);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtTaikhoan.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                qLTKDTO.TaiKhoan = txtTaikhoan.Text.ToLower();

                qLTKBLL.Xoa(qLTKDTO);
                qLTKBLL.Hienthi(dvgQLTK);
            }
        }
    }
}
