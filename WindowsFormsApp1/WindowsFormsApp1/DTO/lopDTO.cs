using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class lopDTO
    {
        private string _MaLop;
        private string _TenLop;
        private string _HDT;
        private string _Siso;

        public string MaLop { get => _MaLop; set => _MaLop = value; }
        public string TenLop { get => _TenLop; set => _TenLop = value; }
        public string HDT { get => _HDT; set => _HDT = value; }
        public string Siso { get => _Siso; set => _Siso = value; }
    }
}
