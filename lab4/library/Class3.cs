namespace library
{
    public class Class3
    {
        public static void Lab3Execute(string inputFileName, string outputFileName)
        {
            using (StreamReader reader = new StreamReader(inputFileName))
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                string[] input = reader.ReadLine().Split();
                int n = int.Parse(input[0]);
                int k = int.Parse(input[1]);

                char[][] roads = new char[n][];
                for (int i = 0; i < n; i++)
                {
                    roads[i] = reader.ReadLine().ToCharArray();
                }

                List<int[]> routes = new List<int[]>();
                for (int i = 0; i < k; i++)
                {
                    int[] route = reader.ReadLine().Split().Select(int.Parse).ToArray();
                    routes.Add(route);
                }

                int[] order = GetOptimalOrder(n, routes, roads);
                string output;
                if (order == null)
                {
                    writer.WriteLine("-1");
                }
                else
                {
                    output = "1 " + string.Join(" ", order) + " 7";
                    writer.WriteLine(output);
                }
            }
        }

        static int[] GetOptimalOrder(int n, List<int[]> routes, char[][] roads)
        {
            List<int> order = new List<int>();
            bool[] visited = new bool[n];
            visited[0] = true;

            foreach (var route in routes)
            {
                int startIndex = Array.IndexOf(route, 1);
                int endIndex = Array.IndexOf(route, n);

                if (startIndex > endIndex)
                {
                    Array.Reverse(route);
                    int temp = startIndex;
                    startIndex = endIndex;
                    endIndex = temp;
                }

                for (int i = startIndex + 1; i < endIndex; i++)
                {
                    int city = route[i] - 1;
                    if (!visited[city])
                    {
                        order.Add(city + 1);
                        visited[city] = true;
                    }
                }
            }

            return order.Count == n - 2 ? order.ToArray() : null;
        }
    }
}