using System;
using System.Collections.Generic;

namespace Lab1
{
    class KhachHang
    {
        public string maKH;
        public int soLuong;
        public double donGia;
        public double thanhTien;
        public DateTime ngayHoaDon;
        public string hoTenKH;

        public KhachHang() { }
        ~KhachHang() { }

        public virtual void Nhap()
        {
            Console.Write("Nhap ma khach hang: ");
            maKH = Console.ReadLine();
            Console.Write("Nhap ho ten khach hang: ");
            hoTenKH = Console.ReadLine();
            Console.Write("Nhap ngay hoa don (dd/MM/yyyy): ");
            ngayHoaDon = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Nhap so luong (KW): ");
            soLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhap don gia: ");
            donGia = double.Parse(Console.ReadLine());
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Ma KH: {maKH} | Ho ten: {hoTenKH} | Ngay HD: {ngayHoaDon.ToString("dd/MM/yyyy")} | So luong: {soLuong} | Don gia: {donGia} | Thanh tien: {thanhTien}");
        }

        public virtual void TinhThanhTien() { }
    }

    class KhachHangNuocNgoai : KhachHang
    {
        public string quocTich;

        public KhachHangNuocNgoai() { }
        ~KhachHangNuocNgoai() { }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap quoc tich: ");
            quocTich = Console.ReadLine();
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Quoc tich: {quocTich}");
        }

        public override void TinhThanhTien()
        {
            thanhTien = soLuong * donGia;
        }
    }

    class KhachHangVietNam : KhachHang
    {
        public string loaiKH;
        public int dinhMuc;

        public KhachHangVietNam() { }
        ~KhachHangVietNam() { }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap loai khach hang (sinh hoat, kinh doanh, san xuat...): ");
            loaiKH = Console.ReadLine();
            Console.Write("Nhap dinh muc: ");
            dinhMuc = int.Parse(Console.ReadLine());
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loai KH: {loaiKH} | Dinh muc: {dinhMuc}");
        }

        public override void TinhThanhTien()
        {
            if (soLuong <= dinhMuc)
            {
                thanhTien = soLuong * donGia;
            }
            else
            {
                thanhTien = soLuong * donGia * 2.5; // Gia su vuot dinh muc tinh gia = 2.5 lan don gia.
            }
        }
    }

    class Bai5
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<KhachHang> ds = new List<KhachHang>();
            Console.Write("Nhap so luong hoa don: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap hoa don thu {i + 1}:");
                Console.WriteLine("1. Khach hang Viet Nam");
                Console.WriteLine("2. Khach hang Nuoc Ngoai");
                Console.Write("Chon loai khach hang (1/2): ");
                int loai = int.Parse(Console.ReadLine());
                if (loai == 1)
                {
                    KhachHangVietNam khvn = new KhachHangVietNam();
                    khvn.Nhap();
                    khvn.TinhThanhTien();
                    ds.Add(khvn);
                }
                else if (loai == 2)
                {
                    KhachHangNuocNgoai khnn = new KhachHangNuocNgoai();
                    khnn.Nhap();
                    khnn.TinhThanhTien();
                    ds.Add(khnn);
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le.");
                    i--;
                }
            }

            Console.WriteLine("\n--- Danh sach hoa don khach hang ---");
            foreach (var kh in ds)
            {
                kh.Xuat();
                Console.WriteLine("------------------");
            }

            int tongSLVN = 0;
            int tongSLNN = 0;
            foreach (var kh in ds)
            {
                if (kh is KhachHangVietNam) tongSLVN += kh.soLuong;
                if (kh is KhachHangNuocNgoai) tongSLNN += kh.soLuong;
            }
            Console.WriteLine($"\nTong so luong dien tieu thu cua KH Viet Nam: {tongSLVN}");
            Console.WriteLine($"Tong so luong dien tieu thu cua KH Nuoc Ngoai: {tongSLNN}");

            double tongTienNN = 0;
            int countNN = 0;
            foreach (var kh in ds)
            {
                if (kh is KhachHangNuocNgoai)
                {
                    tongTienNN += kh.thanhTien;
                    countNN++;
                }
            }
            if (countNN > 0)
            {
                Console.WriteLine($"Trung binh thanh tien cua KH Nuoc Ngoai: {tongTienNN / countNN}");
            }
            else
            {
                Console.WriteLine("Khong co KH Nuoc Ngoai.");
            }

            Console.WriteLine("\n--- Cac hoa don trong thang 09/2020 ---");
            foreach (var kh in ds)
            {
                if (kh.ngayHoaDon.Month == 9 && kh.ngayHoaDon.Year == 2020)
                {
                    kh.Xuat();
                    Console.WriteLine("------------------");
                }
            }

            Console.ReadLine();
        }
    }
}
