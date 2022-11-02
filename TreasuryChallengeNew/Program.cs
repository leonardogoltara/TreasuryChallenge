using TreasuryChallengeNew.Lib;

namespace TreasuryChallengeNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IOServices.DeleteFile(Runner.FilePath);
                Runner.Run();
            }
        }
    }
}
