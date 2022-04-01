using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;


namespace Ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game()) {
                game.Run();
            }
        }

    }
}
