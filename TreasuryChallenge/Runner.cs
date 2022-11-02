using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TreasuryChallenge
{
    public static class Runner
    {
        static List<string> Lines;
        static string AllLines = "";
        public static string FilePath = "aleatory-file-v1.txt";

        public static void Run(int l = 0)
        {
            Lines = new List<string>();

            if (l <= 0)
            {
                Console.WriteLine("Tell me the number of lines do you need and press enter.");
                l = int.Parse(Console.ReadLine());
            }

            string codeQuantity = string.Format("{0:N}", l).Replace(",00", "");
            Console.WriteLine($"Iniciando geração de {codeQuantity} códigos");
            var t = Stopwatch.StartNew();

            Write(l);

            t.Stop();

            var second = Math.Round(t.Elapsed.TotalSeconds, 2);
            Console.WriteLine($"{codeQuantity} códigos em {second} segundos ({t.ElapsedMilliseconds}ms).");
        }

        static string GetChar()
        {
            Random random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

            return chars[random.Next(25)].ToString();
        }

        static void Write(int l)
        {
            for (int i = 0; i < l; i++)
            {
                Lines.Add(GetLine() + "\n");
            }
            var partialLines = new List<string>();
            foreach (var line in Lines)
            {
                AllLines += line;

                partialLines.Add(AllLines);
            }

            System.Console.WriteLine($"A file with {partialLines.Count} lines was generated.");

            File.WriteAllText(FilePath, AllLines);
        }

        static string GetLine(string l = "")
        {
            if (l.Length == 7) return l;

            var c = GetChar();

            int totalL = l.Length;
            int count = 0;
            bool found = false;
            while (totalL != count)
            {
                for (int i = 0; i < totalL; i++)
                {
                    if (l[i].ToString() == c)
                    {
                        found = true;
                        break;
                    }

                    count++;
                }

                if (found)
                {
                    c = GetChar();
                    count = 0;
                    found = false;
                }
            }

            return GetLine(l + c);
        }
    }
}
