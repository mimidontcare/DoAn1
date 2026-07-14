using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SanPham
    {
        string maSP;
        string tenSP;
        int soLuong;
        int donGia;
        string maNCC;
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }

    }
}
