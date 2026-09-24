using System;

namespace Lab2
{
    class Bai4
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Nhap cap cua ma tran vuong n = ");
            int n = int.Parse(Console.ReadLine());

            double[,] mat = new double[n, n];

            // 1. Nhập ma trận
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    mat[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // 2. Hiển thị ma trận
            Console.WriteLine("\n--- Ma tran vua nhap ---");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // 3. Tính tổng các phần tử nằm trên đường chéo phụ
            double sumCheoPhu = 0;
            for (int i = 0; i < n; i++)
            {
                sumCheoPhu += mat[i, n - 1 - i];
            }
            Console.WriteLine($"\nTong cac phan tu tren duong cheo phu: {sumCheoPhu}");

            // 4. Tìm số âm lớn nhất trên đường chéo chính
            double maxAm = 0;
            bool coSoAm = false;
            for (int i = 0; i < n; i++)
            {
                if (mat[i, i] < 0)
                {
                    if (!coSoAm)
                    {
                        maxAm = mat[i, i];
                        coSoAm = true;
                    }
                    else if (mat[i, i] > maxAm)
                    {
                        maxAm = mat[i, i];
                    }
                }
            }
            if (coSoAm)
                Console.WriteLine($"So am lon nhat tren duong cheo chinh: {maxAm}");
            else
                Console.WriteLine("Khong co so am tren duong cheo chinh.");

            // 5. Đếm các phần tử có giá trị chia hết cho 3 và 5
            int count35 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Floor(mat[i, j]) == mat[i, j])
                    {
                        int val = (int)mat[i, j];
                        if (val % 3 == 0 && val % 5 == 0)
                        {
                            count35++;
                        }
                    }
                }
            }
            Console.WriteLine($"So luong phan tu chia het cho 3 va 5: {count35}");

            Console.ReadLine();
        }
    }
}
