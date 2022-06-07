using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quan_Ly_Chuyen_Bay.DTO
{
    public class SoLuongGheDTO
    {
        private int maHangVe;
        private string tenHangVe;
        private float phanTramDonGia;
        private int soLuongGhe;

        public int MaHangVe { get => maHangVe; set => maHangVe = value; }
        public string TenHangVe { get => tenHangVe; set => tenHangVe = value; }
        public float PhanTramDonGia { get => phanTramDonGia; set => phanTramDonGia = value; }
        public int SoLuongGhe { get => soLuongGhe; set => soLuongGhe = value; }

        public SoLuongGheDTO(string tenHangVe, float phanTramDonGia, int soLuongGhe)
        {
            this.TenHangVe = tenHangVe;
            this.PhanTramDonGia = phanTramDonGia;
            this.SoLuongGhe = soLuongGhe;
        }

        public SoLuongGheDTO(DataRow row)
        {
            this.TenHangVe = row["tenHangVe"].ToString();
            this.PhanTramDonGia = (float)row["phanTramDonGia"];
            this.SoLuongGhe = (int)row["soLuongGhe"];

        }
    }
}
