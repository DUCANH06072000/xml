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
    public class KhoaBLL
    {

        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string fileName = @"E:\quanlysinhvien\WindowsFormsApp1\WindowsFormsApp1\Khoa.xml";
        public KhoaBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Rows.Add();
            dgv.ColumnCount = 3;

            XmlNodeList ds = root.SelectNodes("khoa");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("makhoa").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("tenkhoa").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("sdt").InnerText;
                sd++;
            }
        }

        public void Them(KhoaDTO khoaThem)
        {
            XmlNode khoa = doc.CreateElement("khoa");

            XmlNode makhoa = doc.CreateElement("makhoa");
            makhoa.InnerText = khoaThem.MKhoa1;
            khoa.AppendChild(makhoa);

            XmlNode tenkhoa = doc.CreateElement("tenkhoa");
            tenkhoa.InnerText = khoaThem.TKhoa1;
            khoa.AppendChild(tenkhoa);

            XmlNode sdt = doc.CreateElement("sdt");
            sdt.InnerText = khoaThem.SDTKhoa1;
            khoa.AppendChild(sdt);

            root.AppendChild(khoa);
            doc.Save(fileName);
        }

        public void Sua(KhoaDTO khoaSua)

        {
            XmlNode k = root.SelectSingleNode("khoa[makhoa='" + khoaSua.MKhoa1 + "']");

            if (k != null)
            {
                XmlNode suakhoa = doc.CreateElement("khoa");

                XmlElement makhoa = doc.CreateElement("makhoa");
                makhoa.InnerText = khoaSua.MKhoa1;
                suakhoa.AppendChild(makhoa);

                XmlElement tenkhoa = doc.CreateElement("tenkhoa");
                tenkhoa.InnerText = khoaSua.TKhoa1;
                suakhoa.AppendChild(tenkhoa);

                XmlElement sdt = doc.CreateElement("sdt");
                sdt.InnerText = khoaSua.SDTKhoa1;
                suakhoa.AppendChild(sdt);

                root.ReplaceChild(suakhoa, k);
                doc.Save(fileName);
            }
        }
        public void Xoa(KhoaDTO khoaXoa)
        {
            XmlNode xk = root.SelectSingleNode("khoa[makhoa='" + khoaXoa.MKhoa1 + "']");
            if (xk != null)
            {
                root.RemoveChild(xk);
                doc.Save(fileName);
            }
        }



    }
}
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
    public class KhoaBLL
    {

        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string fileName = @"E:\quanlysinhvien\WindowsFormsApp1\WindowsFormsApp1\Khoa.xml";
        public KhoaBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Rows.Add();
            dgv.ColumnCount = 3;

            XmlNodeList ds = root.SelectNodes("khoa");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("makhoa").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("tenkhoa").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("sdt").InnerText;
                sd++;
            }
        }

        public void Them(KhoaDTO khoaThem)
        {
            XmlNode khoa = doc.CreateElement("khoa");

            XmlNode makhoa = doc.CreateElement("makhoa");
            makhoa.InnerText = khoaThem.MKhoa1;
            khoa.AppendChild(makhoa);

            XmlNode tenkhoa = doc.CreateElement("tenkhoa");
            tenkhoa.InnerText = khoaThem.TKhoa1;
            khoa.AppendChild(tenkhoa);

            XmlNode sdt = doc.CreateElement("sdt");
            sdt.InnerText = khoaThem.SDTKhoa1;
            khoa.AppendChild(sdt);

            root.AppendChild(khoa);
            doc.Save(fileName);
        }

        public void Sua(KhoaDTO khoaSua)

        {
            XmlNode k = root.SelectSingleNode("khoa[makhoa='" + khoaSua.MKhoa1 + "']");

            if (k != null)
            {
                XmlNode suakhoa = doc.CreateElement("khoa");

                XmlElement makhoa = doc.CreateElement("makhoa");
                makhoa.InnerText = khoaSua.MKhoa1;
                suakhoa.AppendChild(makhoa);

                XmlElement tenkhoa = doc.CreateElement("tenkhoa");
                tenkhoa.InnerText = khoaSua.TKhoa1;
                suakhoa.AppendChild(tenkhoa);

                XmlElement sdt = doc.CreateElement("sdt");
                sdt.InnerText = khoaSua.SDTKhoa1;
                suakhoa.AppendChild(sdt);

                root.ReplaceChild(suakhoa, k);
                doc.Save(fileName);
            }
        }
        public void Xoa(KhoaDTO khoaXoa)
        {
            XmlNode xk = root.SelectSingleNode("khoa[makhoa='" + khoaXoa.MKhoa1 + "']");
            if (xk != null)
            {
                root.RemoveChild(xk);
                doc.Save(fileName);
            }
        }



    }
}
