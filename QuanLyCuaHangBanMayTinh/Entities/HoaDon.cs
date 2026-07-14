using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HoaDon
    {
        string maHDB;
        string maNV;
        string maKH;
        string ngayLapHD;
        double tongTien;
        public string MaHDB { get => maHDB; set => maHDB = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string NgayLapHD { get => ngayLapHD; set => ngayLapHD = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }

    }
}
