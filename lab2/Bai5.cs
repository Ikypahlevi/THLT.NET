using System;
using System.Text.RegularExpressions;

namespace Lab2
{
    class Bai5
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // 1. Nhap vao xau ky tu
            Console.Write("Nhap vao xau ky tu: ");
            string str = Console.ReadLine();
            Console.WriteLine($"\nXau vua nhap: {str}");

            // 2. Dem chu thuong, chu hoa
            int countHoa = 0;
            int countThuong = 0;
            foreach (char c in str)
            {
                if (char.IsUpper(c)) countHoa++;
                if (char.IsLower(c)) countThuong++;
            }
            Console.WriteLine($"So chu hoa: {countHoa}");
            Console.WriteLine($"So chu thuong: {countThuong}");

            // 3. Dem so tu trong xau
            // Trim() va Split theo khoang trang (bo qua phan tu rong)
            string[] words = str.Trim().Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"So tu trong xau: {words.Length}");

            // 4. Dem so phu am va nguyen am
            int nguyenAm = 0;
            int phuAm = 0;
            string strLower = str.ToLower();
            foreach (char c in strLower)
            {
                if (char.IsLetter(c))
                {
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                        nguyenAm++;
                    else
                        phuAm++;
                }
            }
            Console.WriteLine($"So nguyen am: {nguyenAm}");
            Console.WriteLine($"So phu am: {phuAm}");

            // 5. Nhap xau con, dem so lan xuat hien
            Console.Write("\nNhap vao xau con can tim: ");
            string subStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(subStr))
            {
                int countSub = 0;
                int idx = 0;
                while ((idx = str.IndexOf(subStr, idx)) != -1)
                {
                    countSub++;
                    idx += subStr.Length;
                }
                Console.WriteLine($"So lan xuat hien xau con '{subStr}' la: {countSub}");
            }
            else
            {
                Console.WriteLine("Xau con rong.");
            }

            Console.ReadLine();
        }
    }
}
