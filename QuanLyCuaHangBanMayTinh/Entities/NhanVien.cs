using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NhanVien
    {
        string _MaNV;
        string _TenNV;
        string _SDT;
        string _Email;
        string _DiaChi;
        public string MaNV { get => _MaNV; set => _MaNV = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public string SDT_NV { get => _SDT; set => _SDT = value; }
        public string GioiTinh { get => _Email; set => _Email = value; }
        public string DiaChi_NV { get => _DiaChi; set => _DiaChi = value; }
    }
}
