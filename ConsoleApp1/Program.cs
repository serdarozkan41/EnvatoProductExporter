using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class envataExportModel
    {
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            string rawColumns = "";


            var colonlar = rawColumns.Split("	");
            List<string> colons = new List<string>();
            for (int i = 0; i < colonlar.Length; i++)
            {
                string rc =
                    colonlar[i]
                    .Trim()
                    .Replace(" ", string.Empty)
                    .ToLowerInvariant()
                    .Replace(":", string.Empty)
                    .Replace("(", string.Empty)
                    .Replace(")", string.Empty)
                    .Replace(".", string.Empty)
                    .TrimStart()
                    .TrimEnd();

                var rc2 = $"public string {rc} ";
                colons.Add(rc2 + "{ get; set; }");
            }

            string result = string.Join(Environment.NewLine, colons);


            for (int i = 0; i < colonlar.Length; i++)
            {
                Console.WriteLine(colonlar[i]);

            }

            Console.WriteLine(colonlar.Length);

            Console.ReadLine();
        }
    }
}
