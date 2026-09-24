using System;
using System.Collections.Generic;

namespace Lab2
{
    class Bai2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Student> ds = new List<Student>();

            // 1. Nhap vao danh sach sinh vien
            Console.Write("Nhap so luong sinh vien n = ");
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap thong tin sinh vien thu {i + 1}:");
                Student st = new Student();
                st.input();
                ds.Add(st);
            }

            // 2. Hien thi danh sach
            Console.WriteLine("\n--- Danh sach sinh vien vua nhap ---");
            foreach (var st in ds)
            {
                st.display();
            }

            // 3. Tim kiem thong tin sinh vien ten la "Nam"
            Console.WriteLine("\n--- Ket qua tim kiem sinh vien ten 'Nam' ---");
            bool found = false;
            foreach (var st in ds)
            {
                if (st.Name != null && st.Name.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                {
                    st.display();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay sinh vien nao ten 'Nam'.");
            }

            Console.ReadLine();
        }
    }
}
