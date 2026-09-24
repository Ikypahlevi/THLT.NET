using System;

namespace Lab2
{
    public abstract class SinhVienUneti
    {
        public string HoTen { get; set; }
        public string Nganh { get; set; }

        public SinhVienUneti(string hoTen, string nganh)
        {
            HoTen = hoTen;
            Nganh = nganh;
        }

        public abstract double getDiem();

        public string getXepLoaiHL()
        {
            double diem = getDiem();
            if (diem < 5) return "Yeu";
            if (diem < 6.5) return "Trung binh";
            if (diem < 7.5) return "Kha";
            if (diem < 9) return "Gioi";
            return "Xuat sac";
        }

        public void Xuat()
        {
            Console.WriteLine($"Ho ten: {HoTen} | Nganh: {Nganh} | Diem: {getDiem()} | Hoc luc: {getXepLoaiHL()}");
        }
    }
}
