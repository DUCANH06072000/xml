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
    class lopBLL
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string fileName = @"D:\XML và Ứng dụng\xml\WindowsFormsApp1\WindowsFormsApp1\lop.xml";
        public lopBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Rows.Add();
            dgv.ColumnCount = 4;

            XmlNodeList ds = root.SelectNodes("lop");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("malop").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("tenlop").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("hdt").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("siso").InnerText;
                sd++;
            }
        }

        public void Them(lopDTO lopThem)
        {
            XmlNode lop = doc.CreateElement("lop");

            XmlNode malop = doc.CreateElement("malop");
            malop.InnerText = lopThem.MaLop;
            lop.AppendChild(malop);

            XmlNode tenlop = doc.CreateElement("tenlop");
            tenlop.InnerText = lopThem.TenLop;
            lop.AppendChild(tenlop);

            XmlNode hdt = doc.CreateElement("hdt");
            hdt.InnerText = lopThem.HDT;
            lop.AppendChild(hdt);

            XmlNode siso = doc.CreateElement("siso");
            hdt.InnerText = lopThem.Siso;
            lop.AppendChild(siso);

            root.AppendChild(lop);
            doc.Save(fileName);
        }

        public void Sua(lopDTO lopSua)

        {
            XmlNode l = root.SelectSingleNode("lop[malop='" + lopSua.MaLop + "']");

            if (l != null)
            {
                XmlNode sualop = doc.CreateElement("lop");

                XmlElement malop = doc.CreateElement("malop");
                malop.InnerText = lopSua.MaLop;
                sualop.AppendChild(malop);

                XmlElement tenlop = doc.CreateElement("tenlop");
                tenlop.InnerText = lopSua.TenLop;
                sualop.AppendChild(tenlop);

                XmlElement hdt = doc.CreateElement("hdt");
                hdt.InnerText = lopSua.HDT;
                sualop.AppendChild(hdt);

                XmlElement siso = doc.CreateElement("siso");
                siso.InnerText = lopSua.Siso;
                sualop.AppendChild(siso);

                root.ReplaceChild(sualop, l);
                doc.Save(fileName);
            }
        }

        public void Xoa(lopDTO lopxoa)
        {
            XmlNode xl = root.SelectSingleNode("lop[malop='" + lopxoa.MaLop + "']");
            if (xl != null)
            {
                root.RemoveChild(xl);
                doc.Save(fileName);
            }
        }

    }

}
