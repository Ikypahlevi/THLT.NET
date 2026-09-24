using System;

namespace Lab1
{
    class Vemaybay
    {
        public string tenchuyen;
        public string ngaybay;
        public double giave;

        public Vemaybay() { }
        ~Vemaybay() { }

        public void Nhap()
        {
            Console.Write("Nhap ten chuyen: ");
            tenchuyen = Console.ReadLine();
            Console.Write("Nhap ngay bay: ");
            ngaybay = Console.ReadLine();
            Console.Write("Nhap gia ve: ");
            giave = double.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"Ten chuyen: {tenchuyen}, Ngay bay: {ngaybay}, Gia ve: {giave}");
        }

        public double getgiave()
        {
            return giave;
        }
    }

    class Nguoi
    {
        public string hoten;
        public string gioitinh;
        public int tuoi;

        public Nguoi() { }
        ~Nguoi() { }

        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            hoten = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            gioitinh = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            tuoi = int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"Ho ten: {hoten}, Gioi tinh: {gioitinh}, Tuoi: {tuoi}");
        }
    }

    class Hanhkhach : Nguoi
    {
        public Vemaybay[] ve;
        public int soluong;

        public Hanhkhach() { }
        ~Hanhkhach() { }

        public new void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so luong ve: ");
            soluong = int.Parse(Console.ReadLine());
            ve = new Vemaybay[soluong];
            for (int i = 0; i < soluong; i++)
            {
                Console.WriteLine($"Nhap thong tin ve thu {i + 1}:");
                ve[i] = new Vemaybay();
                ve[i].Nhap();
            }
        }

        public new void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"So luong ve: {soluong}");
            for (int i = 0; i < soluong; i++)
            {
                ve[i].Xuat();
            }
        }

        public double tongtien()
        {
            double sum = 0;
            for (int i = 0; i < soluong; i++)
            {
                sum += ve[i].getgiave();
            }
            return sum;
        }
    }

    class Bai4
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Nhap so luong hanh khach n = ");
            int n = int.Parse(Console.ReadLine());
            Hanhkhach[] ds = new Hanhkhach[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap thong tin hanh khach thu {i + 1}:");
                ds[i] = new Hanhkhach();
                ds[i].Nhap();
            }

            Console.WriteLine("\n--- Danh sach hanh khach va so tien phai tra ---");
            for (int i = 0; i < n; i++)
            {
                ds[i].Xuat();
                Console.WriteLine($"=> Tong tien phai tra: {ds[i].tongtien()}");
                Console.WriteLine("--------------------------------");
            }

            // Sắp xếp danh sách giảm dần theo tổng tiền
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (ds[i].tongtien() < ds[j].tongtien())
                    {
                        Hanhkhach temp = ds[i];
                        ds[i] = ds[j];
                        ds[j] = temp;
                    }
                }
            }

            Console.WriteLine("\n--- Danh sach hanh khach sau khi sap xep giam dan theo tong tien ---");
            for (int i = 0; i < n; i++)
            {
                ds[i].Xuat();
                Console.WriteLine($"=> Tong tien phai tra: {ds[i].tongtien()}");
                Console.WriteLine("--------------------------------");
            }

            Console.ReadLine();
        }
    }
}
