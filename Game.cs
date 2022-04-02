using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Ejemplo
{
    public class Game: GameWindow
    {
        public Game()
            : base(GameWindowSettings.Default, NativeWindowSettings.Default) { 
            this.CenterWindow(new Vector2i(1250,760));
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnLoad()
        {
            base.OnLoad();
        }
        protected override void OnUnload()
        {
            base.OnUnload();
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {   if(KeyboardState.IsKeyDown(Keys.Escape))
                Close();
            base.OnUpdateFrame(args);
        } // Para que al pulsar escp salga del programa
        //Aqui  se actualiza el codigo

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(0.3f, 0.3f, 0.2f, 0.2f); // esto decide el color 
            GL.Clear(ClearBufferMask.ColorBufferBit);
            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }// Renderiza el codigo como que en realidad aqui se dibuja todo 
    }

    
}
