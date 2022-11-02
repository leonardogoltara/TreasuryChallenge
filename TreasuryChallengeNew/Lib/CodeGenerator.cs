using System;

namespace TreasuryChallengeNew.Lib
{
    public static class CodeGenerator
    {
        private const string availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static char[] chars;

        public static string GenerateCode(int length)
        {
            if(length > availableChars.Length)
            {
                throw new ArgumentException($"Os códigos possíveis sem repetir nenhum " +
                    $"caracter podem ter no máximo {availableChars.Length} caracteres.");
            }

            chars = availableChars.ToCharArray(0, 26);
            string code = GetChar();
            for (int i = 0; i < length; i++)
            {
                var newChar = GetChar();
                if (code.Contains(newChar))
                    i--;
                else
                    code += newChar;

                if (code.Length >= length)
                    break;
            }

            return code;
        }

        private static string GetChar()
        {
            Random random = new Random();

            return chars[random.Next(25)].ToString();
        }
    }
}
