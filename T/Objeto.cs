using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace T
{
    internal class Objeto
    {
        public Vector3 Posicion { get; set; }   
  
        public Objeto(Vector3 posicion) 
        {
            Posicion= posicion;
        }

        public void Dibujar() 
        {
            GL.PushMatrix();  // Guarda la matriz actual

            // Aplica la traslación para mover el objeto a su posición
            GL.Translate(Posicion);

            GL.Begin(PrimitiveType.Quads);

            // Dibuja la barra horizontal de la "T"
            DibujarObjeto(0.0f, 0.3f, 0.0f, 1.0f, 0.2f, 0.2f);

            // Dibuja la barra vertical de la "T"
            DibujarObjeto(0.0f, -0.4f, 0.0f, 0.2f, 0.8f, 0.2f);

            GL.End();

            GL.PopMatrix();
        }

        private void DibujarObjeto(float x, float y, float z, float width, float height, float depth)
        {
            float x0 = x - width / 2, x1 = x + width / 2;
            float y0 = y, y1 = y + height;
            float z0 = z - depth / 2, z1 = z + depth / 2;

            // cara frontal
            GL.Color4(Color.BlueViolet);
            GL.Vertex3(x0, y0, z1);
            GL.Vertex3(x1, y0, z1);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x0, y1, z1);

            // cara de atras
            GL.Color4(Color.Coral);
            GL.Vertex3(x0, y0, z0);
            GL.Vertex3(x1, y0, z0);
            GL.Vertex3(x1, y1, z0);
            GL.Vertex3(x0, y1, z0);

            // cara izquierda
            GL.Vertex3(x0, y0, z0);
            GL.Vertex3(x0, y0, z1);
            GL.Vertex3(x0, y1, z1);
            GL.Vertex3(x0, y1, z0);

            // cara derecha
            GL.Vertex3(x1, y0, z0);
            GL.Vertex3(x1, y0, z1);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x1, y1, z0);

            //
            GL.Vertex3(x0, y1, z0);
            GL.Vertex3(x1, y1, z0);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x0, y1, z1);

            //
            GL.Vertex3(x0, y0, z0);
            GL.Vertex3(x1, y0, z0);
            GL.Vertex3(x1, y0, z1);
            GL.Vertex3(x0, y0, z1);
        }

    }
}
