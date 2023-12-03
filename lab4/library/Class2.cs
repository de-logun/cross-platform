namespace library
{
    public class Class2
    {
        public static void Lab2Execute(string inputFilePath, string outputFilePath)
        {

            // Read input from the file
            string[] lines = File.ReadAllLines(inputFilePath);
            if (lines.Length != 2)
            {
                Console.WriteLine("Вхідний файл має містити дві строки.");
                return;
            }

            string s1 = lines[0];
            string s2 = lines[1];
            int size1 = s1.Length;
            int size2 = s2.Length;

            List<List<short>> maxSuffix = new List<List<short>>(size1 + 1);
            for (int i = 0; i <= size1; i++)
            {
                maxSuffix.Add(new List<short>(size2 + 1));
                for (int j = 0; j <= size2; j++)
                {
                    maxSuffix[i].Add(0);
                }
            }

            for (int last1 = 0; last1 < size1; last1++)
            {
                for (int last2 = 0; last2 < size2; last2++)
                {
                    if (s1[last1] == s2[last2])
                    {
                        maxSuffix[last1 + 1][last2 + 1] = (short)(maxSuffix[last1][last2] + 1);
                    }
                }
            }

            List<List<short>> maxPrefix = new List<List<short>>(size1 + 1);
            for (int i = 0; i <= size1; i++)
            {
                maxPrefix.Add(new List<short>(size2 + 1));
                for (int j = 0; j <= size2; j++)
                {
                    maxPrefix[i].Add(0);
                }
            }

            for (int first_1 = size1 - 1; first_1 >= 0; first_1--)
            {
                for (int first_2 = size2 - 1; first_2 >= 0; first_2--)
                {
                    if (s1[first_1] == s2[first_2])
                    {
                        maxPrefix[first_1][first_2] = (short)(maxPrefix[first_1 + 1][first_2 + 1] + 1);
                    }
                }
            }

            List<List<short>> maxLen = new List<List<short>>(size1 + 1);
            for (int i = 0; i <= size1; i++)
            {
                maxLen.Add(new List<short>(size2 + 1));
                for (int j = 0; j <= size2; j++)
                {
                    maxLen[i].Add(0);
                }
            }

            for (int len1 = 1; len1 <= size1; len1++)
            {
                for (int len2 = 1; len2 <= size2; len2++)
                {
                    maxLen[len1][len2] = (short)Math.Max(Math.Max(maxLen[len1 - 1][len2], maxLen[len1][len2 - 1]), maxSuffix[len1][len2]);
                }
            }

            int bestLen1 = -1;
            int bestLen2 = -1;
            int bestSum = -1;
            for (int len1 = 0; len1 <= size1; len1++)
            {
                for (int len2 = 0; len2 <= size2; len2++)
                {
                    int sum = maxLen[len1][len2] + maxPrefix[len1][len2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestLen1 = len1;
                        bestLen2 = len2;
                    }
                }
            }

            if (bestSum < 0)
            {
                throw new Exception("Invalid bestSum");
            }

            int currentLen1 = bestLen1;
            int currentLen2 = bestLen2;
            string sub1;
            while (true)
            {
                if (maxLen[currentLen1][currentLen2] == maxSuffix[currentLen1][currentLen2])
                {
                    int after_cur_1 = currentLen1;
                    int first_cur_1 = after_cur_1 - maxSuffix[currentLen1][currentLen2];
                    sub1 = s1.Substring(first_cur_1, after_cur_1 - first_cur_1);
                    int after_cur_2 = currentLen2;
                    int first_cur_2 = after_cur_2 - maxSuffix[currentLen1][currentLen2];
                    string sub2 = s2.Substring(first_cur_2, after_cur_2 - first_cur_2);

                    if (sub1 != sub2)
                    {
                        throw new Exception("sub1 is not equal to sub2");
                    }
                    break;
                }

                if (currentLen1 - 1 >= 0 && maxLen[currentLen1][currentLen2] == maxLen[currentLen1 - 1][currentLen2])
                {
                    currentLen1--;
                }
                else if (currentLen2 - 1 >= 0 && maxLen[currentLen1][currentLen2] == maxLen[currentLen1][currentLen2 - 1])
                {
                    currentLen2--;
                }
                else
                {
                    throw new Exception("Invalid currentLen1 and currentLen2");
                }
            }

            int first1 = bestLen1;
            int after1 = first1 + maxPrefix[bestLen1][bestLen2];
            string sub1Prefix = s1.Substring(first1, after1 - first1);
            int first2 = bestLen2;
            int after2 = first2 + maxPrefix[bestLen1][bestLen2];
            string sub2Prefix = s2.Substring(first2, after2 - first2);

            if (sub1Prefix != sub2Prefix)
            {
                throw new Exception("sub1Prefix is not equal to sub2Prefix");
            }

            // Write the output to a file
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(sub1);
                writer.WriteLine(sub1Prefix);
            }
        }
    }
}