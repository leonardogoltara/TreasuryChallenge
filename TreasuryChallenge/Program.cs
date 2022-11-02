using TreasuryChallengeNew.Lib;

namespace TreasuryChallenge
{
    class Program
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