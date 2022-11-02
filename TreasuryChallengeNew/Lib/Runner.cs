using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TreasuryChallengeNew.Lib
{
    public static class Runner
    {
        public const int CodeLength = 7;
        public const string FilePath = "aleatory-file-v2.txt";
        public const int CutFileWriting = 100000;
        public const bool CanRepeatLine = true;

        public static void Run(int quantity = 0)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Diga-me o número de linhas que você precisa e pressione enter.");
                quantity = int.Parse(Console.ReadLine());
            }

            string codeQuantity = string.Format("{0:N}", quantity).Replace(",00", "");
            Console.WriteLine($"Iniciando geração de {codeQuantity} códigos");
            var t = Stopwatch.StartNew();

            if (CanRepeatLine)
                WriteCodesCanRepeat(quantity);
            else
                WriteCodesCantRepeat(quantity);

            t.Stop();

            var second = Math.Round(t.Elapsed.TotalSeconds, 2);
            Console.WriteLine($"{codeQuantity} códigos em {second} segundos ({t.ElapsedMilliseconds}ms).");
        }

        private static void WriteCodesCanRepeat(int length)
        {
            StringBuilder sb = new StringBuilder();
            int cutFileWritingCount = 0;
            string code = "";
            for (int i = 0; i < length; i++)
            {

                code = CodeGenerator.GenerateCode(CodeLength);

                sb.AppendLine(code);

                if (CutFileWriting != 0 && cutFileWritingCount >= CutFileWriting)
                {
                    IOServices.AppendAllText(sb.ToString(), FilePath);
                    sb = new StringBuilder();
                    cutFileWritingCount = 0;
                }

                cutFileWritingCount++;
            }

            if (!string.IsNullOrEmpty(sb.ToString()) && sb.Length > 0)
                IOServices.AppendAllText(sb.ToString(), FilePath);
        }

        private static void WriteCodesCantRepeat(int length)
        {
            StringBuilder sb = new StringBuilder();
            List<string> listCodes = new List<string>();
            string code = "";

            for (int i = 0; i < length; i++)
            {

                code = CodeGenerator.GenerateCode(CodeLength);

                if (listCodes.Any(c => c == code))
                {
                    i--;
                }
                else
                {
                    sb.AppendLine(code);
                    listCodes.Add(code);
                }
            }

            if (!string.IsNullOrEmpty(sb.ToString()) && sb.Length > 0)
                IOServices.AppendAllText(sb.ToString(), FilePath);
        }
    }
}
