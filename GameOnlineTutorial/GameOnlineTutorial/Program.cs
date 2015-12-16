using System;

namespace UnderworlD
{
#if WINDOWS || LINUX
   
    public static class Program
    {
        [STAThread]

        static void Main()
        {
            using (var game = new UnderworlD())
                game.Run();

        }
    }
#endif
}
