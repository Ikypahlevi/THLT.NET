using System;
using System.Collections.Generic;

namespace Lab1
{
    class SinhVien
    {
        public string HoTen { get; set; }
        public string QueQuan { get; set; }
        public int NamSinh { get; set; }
        public double DiemTongKet { get; set; }

        public SinhVien() { }

        ~SinhVien() { }

        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap que quan: ");
            QueQuan = Console.ReadLine();
            Console.Write("Nhap nam sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem tong ket: ");
            DiemTongKet = double.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"Ho ten: {HoTen} | Que quan: {QueQuan} | Nam sinh: {NamSinh} | Diem TK: {DiemTongKet}");
        }
    }

    class Bai2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<SinhVien> ds = new List<SinhVien>();
            int luaChon;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Tao danh sach hoc sinh");
                Console.WriteLine("2. Sua thong tin mot hoc sinh");
                Console.WriteLine("3. Xoa thong tin mot hoc sinh");
                Console.WriteLine("4. Dua ra hoc sinh co que o Nam Dinh");
                Console.WriteLine("5. Dua ra hoc sinh co diem tong ket lon nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhap so luong sinh vien: ");
                        int n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Nhap thong tin sinh vien thu {i + 1}:");
                            SinhVien sv = new SinhVien();
                            sv.Nhap();
                            ds.Add(sv);
                        }
                        break;
                    case 2:
                        Console.Write("Nhap ten sinh vien can sua: ");
                        string tenSua = Console.ReadLine();
                        bool found = false;
                        foreach (var sv in ds)
                        {
                            if (sv.HoTen.Equals(tenSua, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Nhap thong tin moi:");
                                sv.Nhap();
                                found = true;
                                break;
                            }
                        }
                        if (!found) Console.WriteLine("Khong tim thay sinh vien!");
                        break;
                    case 3:
                        Console.Write("Nhap ten sinh vien can xoa: ");
                        string tenXoa = Console.ReadLine();
                        int removed = ds.RemoveAll(x => x.HoTen.Equals(tenXoa, StringComparison.OrdinalIgnoreCase));
                        if (removed > 0) Console.WriteLine("Da xoa thanh cong.");
                        else Console.WriteLine("Khong tim thay sinh vien!");
                        break;
                    case 4:
                        Console.WriteLine("Cac sinh vien co que quan Nam Dinh:");
                        foreach (var sv in ds)
                        {
                            if (sv.QueQuan.Equals("Nam Dinh", StringComparison.OrdinalIgnoreCase) || 
                                sv.QueQuan.Equals("Nam Định", StringComparison.OrdinalIgnoreCase))
                            {
                                sv.Xuat();
                            }
                        }
                        break;
                    case 5:
                        if (ds.Count == 0)
                        {
                            Console.WriteLine("Danh sach trong!");
                            break;
                        }
                        double maxDiem = ds[0].DiemTongKet;
                        foreach (var sv in ds)
                        {
                            if (sv.DiemTongKet > maxDiem) maxDiem = sv.DiemTongKet;
                        }
                        Console.WriteLine("Cac sinh vien co diem tong ket lon nhat:");
                        foreach (var sv in ds)
                        {
                            if (sv.DiemTongKet == maxDiem) sv.Xuat();
                        }
                        break;
                }
            } while (luaChon != 0);
        }
    }
}
