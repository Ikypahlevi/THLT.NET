using System;
using System.Linq;

namespace Lab1
{
    class VanDongVien
    {
        public string hoten;
        public int tuoi;
        public string monthidau;
        public double cannang;
        public double chieucao;

        public VanDongVien()
        {
            hoten = "";
            tuoi = 0;
            monthidau = "";
            cannang = 0;
            chieucao = 0;
        }

        public VanDongVien(string ht, int t, string mon, double cn, double cc)
        {
            hoten = ht;
            tuoi = t;
            monthidau = mon;
            cannang = cn;
            chieucao = cc;
        }

        ~VanDongVien() { }

        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            hoten = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhap mon thi dau: ");
            monthidau = Console.ReadLine();
            Console.Write("Nhap can nang: ");
            cannang = double.Parse(Console.ReadLine());
            Console.Write("Nhap chieu cao: ");
            chieucao = double.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"Ho ten: {hoten}, Tuoi: {tuoi}, Mon: {monthidau}, Can nang: {cannang}, Chieu cao: {chieucao}");
        }
    }

    class Bai3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // - Khai báo p là đối tượng lớp Vandongvien (sử dụng hàm thiết lập 5 tham số), hiển thị
            VanDongVien p = new VanDongVien("Nguyen Van A", 20, "Boi loi", 65.5, 1.75);
            Console.WriteLine("Thong tin van dong vien p:");
            p.Xuat();

            // - Nhập vào một mảng gồm n vận động viên.
            Console.Write("\nNhap so luong van dong vien n = ");
            int n = int.Parse(Console.ReadLine());
            VanDongVien[] mang = new VanDongVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap thong tin VDV thu {i + 1}:");
                mang[i] = new VanDongVien();
                mang[i].Nhap();
            }

            // - Hiển thị danh sách đã nhập ra màn hình.
            Console.WriteLine("\nDanh sach cac VDV vua nhap:");
            for (int i = 0; i < n; i++)
            {
                mang[i].Xuat();
            }

            // - Sắp xếp mảng đã nhập theo thứ tự tăng dần, hiển thị danh sách đã sắp (ví dụ sắp xếp theo tuổi)
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (mang[i].tuoi > mang[j].tuoi)
                    {
                        VanDongVien temp = mang[i];
                        mang[i] = mang[j];
                        mang[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nDanh sach cac VDV sau khi sap xep tang dan theo tuoi:");
            for (int i = 0; i < n; i++)
            {
                mang[i].Xuat();
            }

            Console.ReadLine();
        }
    }
}
