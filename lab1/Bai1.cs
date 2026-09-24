using System;

namespace Lab1
{
    class Phanso
    {
        public int tuso;
        public int mauso;

        public Phanso()
        {
            tuso = 0;
            mauso = 1;
        }

        public Phanso(int tu, int mau)
        {
            tuso = tu;
            mauso = mau != 0 ? mau : 1;
        }

        ~Phanso() { }

        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            tuso = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Nhap mau so (khac 0): ");
                mauso = int.Parse(Console.ReadLine());
            } while (mauso == 0);
        }

        public void Xuat()
        {
            Console.WriteLine($"{tuso}/{mauso}");
        }

        public Phanso Cong(Phanso p)
        {
            Phanso kq = new Phanso();
            kq.tuso = this.tuso * p.mauso + p.tuso * this.mauso;
            kq.mauso = this.mauso * p.mauso;
            return kq;
        }

        public Phanso Tru(Phanso p)
        {
            Phanso kq = new Phanso();
            kq.tuso = this.tuso * p.mauso - p.tuso * this.mauso;
            kq.mauso = this.mauso * p.mauso;
            return kq;
        }

        public Phanso Nhan(Phanso p)
        {
            Phanso kq = new Phanso();
            kq.tuso = this.tuso * p.tuso;
            kq.mauso = this.mauso * p.mauso;
            return kq;
        }

        public Phanso Chia(Phanso p)
        {
            Phanso kq = new Phanso();
            kq.tuso = this.tuso * p.mauso;
            kq.mauso = this.mauso * p.tuso;
            return kq;
        }
    }

    class Bai1
    {
        static void Main(string[] args)
        {
            Phanso obj1 = new Phanso();
            Console.WriteLine("Nhap phan so 1:");
            obj1.Nhap();

            Phanso obj2 = new Phanso();
            Console.WriteLine("Nhap phan so 2:");
            obj2.Nhap();

            Console.Write("Phan so 1: "); obj1.Xuat();
            Console.Write("Phan so 2: "); obj2.Xuat();

            Console.Write("Tong: ");
            obj1.Cong(obj2).Xuat();

            Console.Write("Hieu: ");
            obj1.Tru(obj2).Xuat();

            Console.Write("Tich: ");
            obj1.Nhan(obj2).Xuat();

            Console.Write("Thuong: ");
            obj1.Chia(obj2).Xuat();

            Console.ReadLine();
        }
    }
}
