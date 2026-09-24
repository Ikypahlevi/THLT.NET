using System;

namespace Lab2
{
    // Lớp dẫn xuất để có thể kiểm thử lớp trừu tượng SinhVienUneti
    public class SinhVienIT : SinhVienUneti
    {
        public double DiemJava { get; set; }
        public double DiemCSharp { get; set; }

        public SinhVienIT(string hoTen, double java, double csharp) : base(hoTen, "IT")
        {
            DiemJava = java;
            DiemCSharp = csharp;
        }

        public override double getDiem()
        {
            return (DiemJava + DiemCSharp) / 2;
        }
    }

    class Bai1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Kiem thu Bai 1 ---");
            SinhVienIT sv = new SinhVienIT("Nguyen Van A", 7.5, 8.0);
            sv.Xuat();
            Console.ReadLine();
        }
    }
}
