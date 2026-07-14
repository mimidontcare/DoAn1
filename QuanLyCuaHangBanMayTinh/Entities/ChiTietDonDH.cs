using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChiTietDonDH
    {
        string _MaDDH;
        string _MaMT;
        int _SLDat;
        double _GiaDat;

        public string MaDDH { get => _MaDDH; set => _MaDDH = value; }
        public string MaMT { get => _MaMT; set => _MaMT = value; }
        public int SLDat { get => _SLDat; set => _SLDat = value; }
        public double GiaDat { get => _GiaDat; set => _GiaDat = value; }
    }
}
