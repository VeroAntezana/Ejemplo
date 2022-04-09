using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Grafica
{
    public class Game : GameWindow
    {
        //  private Escenario escenario = new Escenario();
        //  private cubo cubito = new cubo(new Vector3(0, 0, 0), 2, 2, 2);
        private int vertexBufferHandle;
        private int shaderProgramHandle;
        public Game(GameWindowSettings config, NativeWindowSettings nativo) : base(config, nativo) { }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
        float[] vertices = new float[] {

                0.0f,0.3f,0f,
                0.3f,-0.3f,0f,//2
                -0.3f,-0.3f,0f, //3
              
              0.0f,0.3f,0f, //1 
              0.5f,0.3f,0f,//2 // triangulo 2
              0.3f,-0.3f,0f,//3
             
             0.3f,-0.3f,0f,//1
             0.5f,0.3f,0f,   //2   //triangulo3
             0.8f,-0.3f,0f,//3

            -0.3f,-0.3f,0f,//1
             -0.3f,-0.8f,0f,//2 //triangulo 4
             0.3f,-0.3f,0f,//3

             0.3f,-0.3f,0f,//1
             -0.3f,-0.8f,0f,//2 //triangulo5
             0.3f,-0.8f,0f, //3

             0.3f,-0.3f,0f,//1
             0.3f,-0.8f,0f,//2 //triangulo 6
             0.8f,-0.8f,0f,//3

             0.3f,-0.3f,0f,//1
             0.8f,-0.3f,0f,//2  triangulo 7
             0.8f,-0.8f,0f//3


            };

        int vao;
        int vbo;
        
        protected override void OnLoad()
        {
             GL.ClearColor(new Color4(0.3f, 0.3f, 0.2f, 0.2f)); // esto decide el color  
            Color4 coral = new Color4(1.0f, 0.5f, 0.31f, 1.0f);
            vao = GL.GenVertexArray();
             GL.BindVertexArray(vao);
             GL.GenBuffer();
             vbo= GL.GenBuffer();
             GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
             GL.BufferData(
                 BufferTarget.ArrayBuffer,
                 vertices.Length * sizeof(float),
                 vertices.ToArray(),
                 BufferUsageHint.StaticDraw);
             GL.EnableVertexAttribArray(0);
             GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, true, 0, 0);



             this.vertexBufferHandle = GL.GenBuffer();
             GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferHandle);
             GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
             GL.BindBuffer(BufferTarget.ArrayBuffer, 0);



            // escenario.addDibujo("cubo", cubito);
            string vertexShaderCode = @"

            #version 330  core
            in vec3 aPosition;
            void main(){
                gl_Position=vec4(aPosition, 1f);
             }


            ";

            string pixelShaderCode =
              @"
               #version 330 core
                out vec4 pixeColor;
                void main(){
                    pixeColor= vec4(0.8,0.8f,0.1f,1f);
                }
                ";

            int vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShaderHandle, vertexShaderCode);
            GL.CompileShader(vertexShaderHandle);

            int pixelShaderHandle = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(pixelShaderHandle, pixelShaderCode);
            GL.CompileShader (pixelShaderHandle);

            this.shaderProgramHandle = GL.CreateProgram();
            GL.AttachShader(this.shaderProgramHandle, vertexShaderHandle);
            GL.AttachShader(this.shaderProgramHandle, pixelShaderHandle);
            GL.LinkProgram(this.shaderProgramHandle);

            GL.DetachShader(this.shaderProgramHandle, vertexShaderHandle);
            GL.DetachShader (this.shaderProgramHandle, pixelShaderHandle);

            GL.DeleteShader(vertexShaderHandle);
            GL.DeleteShader (pixelShaderHandle);



            base.OnLoad();
        }
        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(this.vertexBufferHandle);

            GL.UseProgram(0);
            GL.DeleteProgram(this.shaderProgramHandle);



            base.OnUnload();
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (KeyboardState.IsKeyDown(Keys.Escape))
                Close();
            base.OnUpdateFrame(args);
        } // Para que al pulsar escp salga del programa
        //Aqui  se actualiza el codigo

        protected override void OnRenderFrame(FrameEventArgs args)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.UseProgram(this.shaderProgramHandle);
           GL.BindVertexArray(vao);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.DrawArrays(BeginMode.Triangles, 0, vertices.Length);
           // this.Context.SwapBuffers();
          /*  base.OnRenderFrame(args);
        }// Renderiza el codigo como que en realidad aqui se dibuja todo */
          //  GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            Context.SwapBuffers();
            base.OnRenderFrame(args);

        }


    }
}
