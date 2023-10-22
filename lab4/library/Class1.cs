using System;
using System.IO;

namespace library
{
    public class Class1
    {
        public static void Main()
        {
            if (!File.Exists("INPUT1.TXT"))
            {
                Console.WriteLine("Вхідний файл не знайдено.");
                return;
            }

            using (StreamReader reader = new StreamReader("INPUT1.TXT"))
            {
                string line = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Вхідний файл порожній.");
                    return;
                }

                string[] input = line.Split();

                if (input.Length != 3)
                {
                    Console.WriteLine("Вхідний файл має неправильний формат.");
                    return;
                }

                if (!int.TryParse(input[0], out int a) || !int.TryParse(input[1], out int b) || !int.TryParse(input[2], out int c))
                {
                    Console.WriteLine("Помилка введення значень, формат: число а число б число с");
                    return;
                }

                string x = a.ToString();
                string y = b.ToString();

                char[] xArray = x.ToCharArray();
                char[] yArray = y.ToCharArray();

                Array.Sort(xArray);
                Array.Sort(yArray);

                bool permutationFound = false;

                do
                {
                    x = new string(xArray);
                    y = new string(yArray);
                    a = int.Parse(x);
                    if (a > c) break;

                    string z = (c - a).ToString().PadLeft(y.Length, '0');

                    char[] zArray = z.ToCharArray();
                    Array.Sort(zArray);
                    z = new string(zArray);

                    if (z == y)
                    {
                        permutationFound = true;
                        break;
                    }
                } while (NextPermutation(xArray));

                using (StreamWriter writer = new StreamWriter("OUTPUT1.TXT"))
                {
                    if (permutationFound)
                    {
                        writer.WriteLine("YES");
                        writer.WriteLine($"{a} {c - a}");
                    }
                    else
                    {
                        writer.WriteLine("NO");
                    }
                }
            }
        }

        static bool NextPermutation(char[] array)
        {
            int i = array.Length - 2;
            while (i >= 0 && array[i] >= array[i + 1])
                i--;

            if (i < 0)
                return false;

            int j = array.Length - 1;
            while (array[j] <= array[i])
                j--;

            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            Array.Reverse(array, i + 1, array.Length - i - 1);
            return true;
        }
    }
}
