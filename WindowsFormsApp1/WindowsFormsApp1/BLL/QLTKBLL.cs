using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using System.Xml;
using System.Windows.Forms;

namespace WindowsFormsApp1.BLL
{
    class QLTKBLL
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string fileName = @"D:\XML và Ứng dụng\quanlysinhvien\WindowsFormsApp1\WindowsFormsApp1\QLTK.xml";
        public QLTKBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }
        public void Hienthi(DataGridView dvg)
        {
            dvg.Rows.Clear();
            dvg.ColumnCount = 2;
            XmlNodeList QLTK = root.SelectNodes("ListTK");
            int sd = 0;
            foreach(XmlNode item in QLTK)
            {
                dvg.Rows.Add();
                dvg.Rows[sd].Cells[0].Value = item.SelectSingleNode("Taikhoan").InnerText;
                dvg.Rows[sd].Cells[1].Value = item.SelectSingleNode("Matkhau").InnerText;
                sd++;
            }
        }
        public void Them(QLTKDTO themQLTK)
        {
            XmlNode qltk = doc.CreateElement("ListTK");

            XmlElement taikhoan = doc.CreateElement("Taikhoan");
            taikhoan.InnerText = themQLTK.TaiKhoan;
            qltk.AppendChild(taikhoan);

            XmlElement matkhau = doc.CreateElement("Matkhau");
            matkhau.InnerText = themQLTK.MatKhau;
            qltk.AppendChild(matkhau);

            root.AppendChild(qltk);
            doc.Save(fileName);

        }
        public void Sua(QLTKDTO suaQLTK)

        {
            XmlNode tk = root.SelectSingleNode("ListTK[Taikhoan='" + suaQLTK.TaiKhoan + "']");

            if (tk !=null)
            {
                XmlNode suaTk = doc.CreateElement("ListTK");

                XmlElement taikhoan = doc.CreateElement("Taikhoan");
                taikhoan.InnerText = suaQLTK.TaiKhoan;
                suaTk.AppendChild(taikhoan);

                XmlElement matkhau = doc.CreateElement("Matkhau");
                matkhau.InnerText = suaQLTK.MatKhau;
                suaTk.AppendChild(matkhau);

                root.ReplaceChild(suaTk, tk);
                doc.Save(fileName);
            }
        }
        public void Xoa(QLTKDTO xoaQLTk)
        {
            XmlNode qltk = root.SelectSingleNode("ListTK[Taikhoan='" + xoaQLTk.TaiKhoan + "']");
            if(qltk != null)
            {
                root.RemoveChild(qltk);
                doc.Save(fileName);
            }
        }
    }
}
