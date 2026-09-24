using System;

namespace Lab2
{
    class Bai3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Nhap so hang n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m = ");
            int m = int.Parse(Console.ReadLine());

            double[,] mat = new double[n, m];

            // 1. Nhập ma trận
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    mat[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // 2. Hiển thị ma trận
            Console.WriteLine("\n--- Ma tran vua nhap ---");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // 3. Tìm số âm nhỏ nhất
            double minAm = 0;
            bool coSoAm = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mat[i, j] < 0)
                    {
                        if (!coSoAm)
                        {
                            minAm = mat[i, j];
                            coSoAm = true;
                        }
                        else if (mat[i, j] < minAm)
                        {
                            minAm = mat[i, j];
                        }
                    }
                }
            }
            if (coSoAm)
                Console.WriteLine($"\nSo am nho nhat: {minAm}");
            else
                Console.WriteLine("\nKhong co so am trong ma tran.");

            // 4. Sắp xếp từng cột tăng dần
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    for (int k = i + 1; k < n; k++)
                    {
                        if (mat[i, j] > mat[k, j])
                        {
                            double temp = mat[i, j];
                            mat[i, j] = mat[k, j];
                            mat[k, j] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("\n--- Ma tran sau khi sap xep cot tang dan ---");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // 5. Xóa cột thứ k
            Console.Write("\nNhap cot k can xoa (0 den m-1): ");
            int k_col = int.Parse(Console.ReadLine());
            if (k_col >= 0 && k_col < m)
            {
                double[,] mat_new = new double[n, m - 1];
                for (int i = 0; i < n; i++)
                {
                    int col_idx = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (j == k_col) continue;
                        mat_new[i, col_idx] = mat[i, j];
                        col_idx++;
                    }
                }
                m--;
                mat = mat_new;

                Console.WriteLine($"\n--- Ma tran sau khi xoa cot {k_col} ---");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(mat[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Chi so k khong hop le.");
            }

            // 6. Tính trung bình cộng các phần tử có giá trị chẵn
            double sumChan = 0;
            int countChan = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Kiem tra phan tu la so nguyen va chan
                    if (Math.Floor(mat[i, j]) == mat[i, j] && mat[i, j] % 2 == 0)
                    {
                        sumChan += mat[i, j];
                        countChan++;
                    }
                }
            }
            if (countChan > 0)
                Console.WriteLine($"\nTrung binh cong cac so chan: {sumChan / countChan}");
            else
                Console.WriteLine("\nKhong co so chan trong ma tran.");

            Console.ReadLine();
        }
    }
}
