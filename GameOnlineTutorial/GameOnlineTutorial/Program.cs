using System;

namespace UnderworlD
{
#if WINDOWS || LINUX
   
    public static class Program
    {
        [STAThread]

        static void Main()
        {
            using (var game = new GameOnlineTutorial.UnderworlD())
                game.Run();

        }
    }
#endif
}
