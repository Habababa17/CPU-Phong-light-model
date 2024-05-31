using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Wypełnianie_siatki_trójkątów
{
    class Object3
    {
        public VertexProjection[] vertices;
        public List<FaceProjection> Faces = new List<FaceProjection>();
        public Object3(Point[] points, IList<Face> faces, IList<Normal> normals)
        {
          
            vertices = new VertexProjection[points.Count()];
            for (int i = 0; i < points.Length; i++)
            {
                vertices[i] = new VertexProjection();
                vertices[i].Vertex = points[i];
                vertices[i].color = new Color();
                
            }

            foreach (var face in faces)
            {
                
                Faces.Add(new FaceProjection(face, vertices));
            }


            //calc normal in ver
        }
        public List<Normal> CalcNormals(IList<Face> faces, IList<Normal> normals)
        {
            List<Normal> ret = new List<Normal>();
            List<List<int>> VerticesNormalsIndexes = new List<List<int>>();
            for (int i = 0; i < vertices.Count(); i++)
                VerticesNormalsIndexes.Add(new List<int>());

            foreach (var face in faces)
                for (int i = 0; i < face.Count; i++)
                {
                    VerticesNormalsIndexes[face[i].VertexIndex - 1].Add(face[i].NormalIndex - 1);
                }


            foreach (List<int> indexes in VerticesNormalsIndexes)
            {
                float X = 0;
                float Y = 0;
                float Z = 0;
                foreach (int inx in indexes)
                {
                    X += normals[inx].X;
                    Y += normals[inx].Y;
                    Z += normals[inx].Z;
                }
                X /= indexes.Count;
                Y /= indexes.Count;
                Z /= indexes.Count;
                Random r = new Random();
                //vertices[i++].normal = new Normal(X, Y, Z);
                
               // vertices[i++].normal = normals[r.Next(0, indexes.Count)];
                ret.Add(new Normal(X, Y, Z));
            }
            return ret;
        }

        
    }
    
    public class VertexProjection
    {
        public Normal normal;
        public Color color;
        public Point Vertex;
        public Normal normalFromMap;
    }

    public class FaceProjection
    {
        public Edge[] edges;
        public Normal[] normals;
        public List<int> verIndexes;
        public int normalinx;
        public FaceProjection(Face face, VertexProjection[] points)
        {
            List<Edge> edges = new List<Edge>();
            normals = new Normal[3];
            verIndexes = new List<int>();
            VertexProjection ver1 = points[face[face.Count - 1].VertexIndex - 1];
            VertexProjection ver2;
            for (int i = 0; i < face.Count; i++)
            {
                ver2 = points[face[i].VertexIndex - 1];
                edges.Add(new Edge(ver1, ver2));
                verIndexes.Add(i);
                ver1 = ver2;

            }
            verIndexes = verIndexes.OrderBy(x => edges[x].p1.Vertex.Y).ToList();
            this.edges = edges.ToArray();
            normalinx = face[0].NormalIndex - 1;
        }

            public Normal GetDistanceFromVertices(Point p)
        {
            //only for triangles
            return new Normal(
                GetDistance(p, edges[0].p1.Vertex),
                GetDistance(p, edges[1].p1.Vertex),
                GetDistance(p, edges[2].p1.Vertex)
                );
        }
        private float GetDistance(Point p1,Point p2)
        {
            return (float)Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }

    }
    
    public class Edge
    {
        public VertexProjection p1;
        public VertexProjection p2;
        public float slope; //ay=x, slope:=a
        public float x;
        public int y { get { return Math.Min(p1.Vertex.Y, p2.Vertex.Y); } }
        public int Y { get { return Math.Max(p1.Vertex.Y, p2.Vertex.Y); } }

        public Edge(VertexProjection point1, VertexProjection point2)
        {
            p1 = point1;
            p2 = point2;
            if (p2.Vertex.Y != p1.Vertex.Y)
                slope = (p2.Vertex.X - p1.Vertex.X) / (p2.Vertex.Y - p1.Vertex.Y);
            else
                slope = 0;
        }


    }
    class AETNode
    {
        public int id;
        public float x;
        public float slope;
        public AETNode(int id, float x, float slope)
        {
            this.id = id;
            this.x = x;
            this.slope = slope;
        }
    }

    public class Cloud
    {
        public Point[] points;
        private int step=0;

        public Cloud(Point[] points)
        {
            this.points = points;
        }
     
        public void MoveCloud()
        {
            if (step<40)
            {
                for(int i =0;i<points.Count();i++)
                    points[i].X += 10;
            }
            else
            {
                for (int i = 0; i < points.Count(); i++)
                    points[i].X -= 10;
            }
            step++;
            step %= 80;
        }
        public Point[] GetShadow(Normal Lightnormal, float cloudHeight,int w,int h)
        {
            Normal LightPos = new Normal(w / 2 + Lightnormal.X * w, h / 2 + Lightnormal.Y * h, Lightnormal.Z*4 + cloudHeight);
            List<Point> ret = new List<Point>();
            float k = (LightPos.Z - cloudHeight) / LightPos.Z;
            foreach (var p in points) {

                //int X = (int)(-(p.X - LightPos.X)/k + p.X);
                int X = (int)((-LightPos.X * cloudHeight + p.X * LightPos.Z) / (LightPos.Z - cloudHeight));
                int Y = (int)((-LightPos.Y * cloudHeight + p.Y * LightPos.Z) / (LightPos.Z - cloudHeight));
                ret.Add(new Point(X, Y));
            }
           

            return ret.ToArray();
        }

       

    }

}
