using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NhapHang
    {
        string maPhieu, maNCC, maNV;
        decimal tongTien;
        DateTime ngayNhan;

        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public DateTime NgayNhan { get => ngayNhan; set => ngayNhan = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
