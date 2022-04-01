using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Ejemplo
{
    public class Game: GameWindow
    {
        public Game()
            : base(GameWindowSettings.Default, NativeWindowSettings.Default) { 
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {   if(KeyboardState.IsKeyDown(Keys.Escape))
                Close();
            base.OnUpdateFrame(args);
        } // Para que al pulsar escp salga del programa
        //Aqui  se actualiza el codigo

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
        }// Renderiza el codigo como que en realidad aqui se dibuja todo 
    }

    
}
