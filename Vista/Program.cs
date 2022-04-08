using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using System;


namespace Grafica
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindowSettings config = new GameWindowSettings();
            config.RenderFrequency = 30.0;
            config.UpdateFrequency = 60.0;
            NativeWindowSettings nativo = new NativeWindowSettings();
            nativo.Size = new Vector2i(800, 600);
            nativo.Title = "Programacion Grafica";
            using (Game game = new Game(config, nativo))
            {
                game.Run();
            }
        }

    }

}

