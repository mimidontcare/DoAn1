using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChiTietHD
    {
        string _MaHDB;
        string _MaMT;
        int _SLBan;
        double _GiaBan;

        public string MaHDB { get => _MaHDB; set => _MaHDB = value; }
        public string MaMT { get => _MaMT; set => _MaMT = value; }
        public int SLBan { get => _SLBan; set => _SLBan = value; }
        public double GiaBan { get => _GiaBan; set => _GiaBan = value; }
    }
}
