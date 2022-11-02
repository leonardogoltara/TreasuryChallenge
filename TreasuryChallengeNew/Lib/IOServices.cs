using System.IO;
using System.Threading.Tasks;

namespace TreasuryChallengeNew.Lib
{
    public static class IOServices
    {
        public static void WriteFile(string content, string filePath)
        {
            File.WriteAllText(filePath, content);
        }

        public static void AppendAllText(string content, string filePath)
        {
            File.AppendAllText(filePath, content);
        }

        public static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public static bool ExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
