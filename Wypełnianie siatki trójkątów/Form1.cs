using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjLoader.Loader.Loaders;
using System.IO;
using ObjLoader.Loader.Data.Elements;
using System.Runtime.InteropServices;
using ObjLoader.Loader.Data.VertexData;

namespace Wypełnianie_siatki_trójkątów
{
    public partial class Form1 : Form
    {
        private Bitmap drawArea;

        private LoadResult obj;
        private Object3 pointProjection;
        private double TickNum = 0;
        private Normal lightNormal;


        private Bitmap TextureBitmap;
        private Int32[] TextureBits;
        private GCHandle TextureHandle;


        private Bitmap normalMapBitmap;
        private Int32[] normalMapBits;
        private GCHandle normalMapHandle;



        private Cloud cloud;

        private Bitmap cloudBitmap;
        private Int32[] cloudBits;
        private GCHandle cloudHandle;

        public Form1()
        {
            InitializeComponent();

            //obj
            obj = LoadSphere();
            
            List<Point> points = new List<Point>();
            foreach (var Ver in obj.Vertices)
            {
                points.Add(VerToPoint(Ver));
            }
            pointProjection = new Object3(points.ToArray(), obj.Groups[0].Faces, obj.Normals);

            LoadTexture("brick.jpg");

            LoadMap("brick_normalmap.png");

            LoadCloud("cloud.jpg");

            //Bitmapa
            CreateBitmap();

            //rysowanie sfery krawędzie i wierzchołki
            DrawObject();

            FrameUpdateTimer.Enabled = true;
  
            //bez tego wektory nie działają
            var x = pointProjection.CalcNormals(obj.Groups[0].Faces, obj.Normals);
            for(int i=0;i<x.Count;i++)
            pointProjection.vertices[i].normal = Normalize(x[i]);

            int h = Canvas.Height / 2;
            Point[] p = { new Point(10, h), new Point(40, h+20), new Point(80, h-10), new Point(100, h-30), new Point(120, h),new Point(140,h+20),new Point(120,h-40),new Point(60,h-40),new Point(20,h-30)  };
            cloud = new Cloud(p);

            ColorInterpolationButton.Checked = true;
        }
        private void CreateBitmap() 
        {
            drawArea = new Bitmap(Canvas.Size.Width, Canvas.Size.Height);
            Canvas.Image = drawArea;
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.White);
            g.Dispose();
        }
        private void LoadTexture(string path)
        {
            LoadImage(ref TextureBitmap, ref TextureBits, ref TextureHandle, path);
        }
        private void LoadMap(string path)
        {
            LoadImage(ref normalMapBitmap, ref normalMapBits, ref normalMapHandle, path);
            foreach (var ver in pointProjection.vertices)
            {
                ver.normalFromMap = ModifyVectorByMap(ver.normal, GetMapNormal(ver.Vertex.X, ver.Vertex.Y));
            }
        }
        private void LoadCloud(string path)
        {
            LoadImage(ref cloudBitmap, ref cloudBits, ref cloudHandle, path);
        }


        private Normal ModifyVectorByMap(Normal originalNormal, Normal mapNormal)
        {
            float X, Y, Z;
            X = mapNormal.X * (-1) * originalNormal.X * originalNormal.Z +
                 mapNormal.Y * originalNormal.Y +
                 mapNormal.Z * originalNormal.X;

           Y = mapNormal.X * (-1) * originalNormal.Y * originalNormal.Z +
                 mapNormal.Y * (-1) * originalNormal.X +
                 mapNormal.Z * originalNormal.Y;

            Z = mapNormal.X * (float)(Math.Pow(originalNormal.X, 2) + Math.Pow(originalNormal.Y, 2)) +
                 mapNormal.Z * originalNormal.Z;

            return new Normal(X, Y, Z);

        }
        private void FrameUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (CloudBox.Checked)
                cloud.MoveCloud();
            TickNum++;
            lightNormal = GetLightNormal();
            DrawObject();
        }
        private void DrawPoint(int x, int y, FaceProjection face, Color color)
        {
            Normal normal = obj.Normals[face.normalinx];
            if (NormalMapBox.Checked)
            {
                normal = ModifyVectorByMap(normal, GetMapNormal(x, y));
                color = CalculateFaceColor(normal);
            }
            if (FromTextureBox.Checked)
            {
                color = CalculateFaceColor(normal, x, y);
            }

            drawArea.SetPixel(x, y, color);
        }
        private void DrawInterpolatedPoint(int x, int y, FaceProjection face, Color color)
        {
            color = CalculateInterpolatedColor(new Point(x, y), face);
            drawArea.SetPixel(x, y, color);
        }
        private void DrawInterpolatedVectorsPoint(int x, int y, FaceProjection face, Color color)
        {

            Normal normal;
            Normal[] normals = new Normal[3];
         
            //if (NormalMapBox.Checked)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        normals[i] = face.edges[i].p1.normalFromMap;
            //    }
            //}
            //else
            for (int i = 0; i < 3; i++)
                {
                    normals[i] = face.edges[i].p1.normal;
                }
            normal = CalculateInterpolatedVector(new Point(x, y), face, normals);

            if (NormalMapBox.Checked)
            {
                normal = ModifyVectorByMap(normal, GetMapNormal(x, y));
            }


                if (FromTextureBox.Checked)
                color = CalculateFaceColor(normal, x, y);
            else
                color = CalculateFaceColor(normal);


                drawArea.SetPixel(x, y, color);
        }
        private Normal GetMapNormal(int x, int y)
        {
            return NormalColorFromInt(normalMapBits[x + y * Canvas.Width]);
        }
        private void DrawObject()
        {
            
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
                if (FillTriangleButton.Checked)
                    foreach (var face in pointProjection.Faces)
                    {
                        Normal normal = obj.Normals[face.normalinx];
                        FillTriangle(face, DrawPoint, CalculateFaceColor(normal));
                    }
                if (ColorInterpolationButton.Checked)
                {
                    CalculateVerColors();

                    foreach (var face in pointProjection.Faces)
                    {
                        
                        if (NormalMapBox.Checked)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Normal[] normals = new Normal[3];
                                Point p = face.edges[i].p1.Vertex;
                                normals[i] = face.edges[i].p1.normal;
                                if (FromTextureBox.Checked)
                                {
                                    face.edges[i].p1.color = CalculateFaceColor(ModifyVectorByMap(normals[i], GetMapNormal(p.X, p.Y)), p.X, p.Y);
                                }
                                else
                                {
                                face.edges[i].p1.color = CalculateFaceColor(ModifyVectorByMap(normals[i], GetMapNormal(p.X, p.Y)));
                                }
                            }
                        }
                        if (FromTextureBox.Checked)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Point p = face.edges[i].p1.Vertex;
                                face.edges[i].p1.color = CalculateFaceColor(face.edges[i].p1.normal, p.X, p.Y);
                            }
                        }
                        FillTriangle(face, DrawInterpolatedPoint, Color.White);
                    }
                }
                if (VectorInterpolationButton.Checked)
                {
                    foreach (var face in pointProjection.Faces)
                    {

                        FillTriangle(face, DrawInterpolatedVectorsPoint, Color.White);
                    }
                }

                if (GridBox.Checked)
                {
                    foreach (var ver in pointProjection.vertices)
                    {
                        Point p = ver.Vertex;
                        int Radius = 4;
                        g.FillEllipse(Brushes.Black, p.X - Radius / 2, p.Y - Radius / 2, Radius, Radius);
                    }
                    foreach (var face in pointProjection.Faces)
                    {

                        for (int i = 0; i < face.edges.Length; i++)
                        {
                            Edge e = face.edges[i];
                            g.DrawLine(new Pen(Brushes.Black, 1), e.p1.Vertex, e.p2.Vertex);

                        }
                    }
                }
                int c = kaBar.Value / kaBar.Maximum;
                if (CloudBox.Checked)
                {
                    FillPolygon(cloud.GetShadow(GetLightNormal(false), cloudheightBar.Value,Canvas.Width,Canvas.Height), Color.FromArgb(c, c, c));
                    FillPolygon(cloud.points, Color.LightBlue);
                }


            }

            Canvas.Refresh();
        }
        private void CalculateVerColors()
        {
            
            for (int i = 0; i < pointProjection.vertices.Length; i++)
            {
                pointProjection.vertices[i].color = CalculateFaceColor(pointProjection.vertices[i].normal);
                //Random random = new Random();
                //pointProjection.vertices[i].color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            }
        }
        private LoadResult LoadSphere()
        {
            ObjLoaderFactory objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();

            var fileStream = new FileStream("sfera.obj", FileMode.Open);
            var result = objLoader.Load(fileStream);
            return result;
        }
        private void Swap<T>(ref T a,ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
        private void FillScanLine(int x, int y,FaceProjection face, Color color)
        {
            drawArea.SetPixel(x, y, color);
        }
        private void FillScanlineColorInterpolation(int x, int y,FaceProjection face, Color c)
        {
            Color color = CalculateInterpolatedColor(new Point(x, y), face);
            drawArea.SetPixel(x, y, color);
        }
        private Color CalculateInterpolatedColor(Point p, FaceProjection face)
        {
            (float w0, float w1, float w2) = CalcWeights(p, face);

            int R = scoop(0,(int)((w0 * face.edges[0].p1.color.R + w1 * face.edges[1].p1.color.R + w2 * face.edges[2].p1.color.R)),255);
            int G = scoop(0,(int)((w0 * face.edges[0].p1.color.G + w1 * face.edges[1].p1.color.G + w2 * face.edges[2].p1.color.G)),255);
            int B = scoop(0, (int)((w0 * face.edges[0].p1.color.B + w1 * face.edges[1].p1.color.B + w2 * face.edges[2].p1.color.B)),255);
            return Color.FromArgb(R, G, B);
        }

        private Normal CalculateInterpolatedVector(Point p, FaceProjection face, Normal[] normals)
        {

            (float w0, float w1, float w2) = CalcWeights(p, face);

            float X = scoop(0, (w0 * normals[0].X + w1 * normals[1].X + w2 * normals[2].X), 255);
            float Y = scoop(0, (w0 * normals[0].Y + w1 * normals[1].Y + w2 * normals[2].Y), 255);
            float Z = scoop(0, (w0 * normals[0].Z + w1 * normals[1].Z + w2 * normals[2].Z), 255);
            return new Normal(X, Y, Z);
        }
        private (float, float, float) CalcWeights(Point p, FaceProjection face)
        {
            Point p0 = face.edges[0].p1.Vertex;
            Point p1 = face.edges[1].p1.Vertex;
            Point p2 = face.edges[2].p1.Vertex;
            float sum = (p1.Y - p2.Y) * (p0.X - p2.X) + (p2.X - p1.X) * (p0.Y - p2.Y);
            float w0 = ((p1.Y - p2.Y) * (p.X - p2.X) + (p2.X - p1.X) * (p.Y - p2.Y)) / sum;
            float w1 = ((p2.Y - p0.Y) * (p.X - p2.X) + (p0.X - p2.X) * (p.Y - p2.Y)) / sum;
            float w2 = 1 - w0 - w1;
            return (w0, w1, w2);
        }

        private Color CalculateFaceColor(Normal faceNormal, int x, int y)
        {
            //I = kd*IL*IO*cos(kąt(N,L)) + ks*IL*IO*cosm(kąt(V,R))
            //kd i ks - współczynniki opisujące wpływ danej składowej na wynik(0 - 1)
            //IL(kolor światła) - możliwość wyboru z menu->domyślnie kolor biały(1,1,1)
            //IO(kolor obiektu)
            //L(wersor do światła)
            //N(Wektor normalny) po wyznaczeniu musi on zostać znormalizowany do długości 1(wersor)
            //V =[0, 0, 1], R = 2 < N,L > N - L gdzie < N,L > -iloczyn skalarny wersorów N i L
            //m - współczynnik opisujący jak bardzo dany trókat jest zwierciadlany(1 - 100)

            Normal LightColor = GetLightColor();
            Normal ObjectColor = GetObjectColor(x, y);
            int red = CalcColorVal(LightColor.X, ObjectColor.X, faceNormal);
            int green = CalcColorVal(LightColor.Y, ObjectColor.Y, faceNormal);
            int blue = CalcColorVal(LightColor.Z, ObjectColor.Z, faceNormal);
            return Color.FromArgb(red, green, blue);

        }
        private Color CalculateFaceColor(Normal faceNormal)
        {     
                
            Normal LightColor = GetLightColor();
            Normal ObjectColor = GetObjectColor();
            int red = CalcColorVal(LightColor.X, ObjectColor.X, faceNormal);
            int green = CalcColorVal(LightColor.Y, ObjectColor.Y, faceNormal);
            int blue = CalcColorVal(LightColor.Z, ObjectColor.Z, faceNormal);
            return Color.FromArgb(red, green, blue);

        }
        private int CalcColorVal(float light, float obj, Normal normal)
        {
           
            float dotPr = dotProduct(normal, lightNormal);
            float rozproszenie = Math.Max(0, 255 * ((float)kdBar.Value / kdBar.Maximum) * obj * light * dotPr);
            Normal V = new Normal(0, 0, 1);
            Normal R = new Normal(
                2 * dotPr * normal.X - lightNormal.X,
                2 * dotPr * normal.Y - lightNormal.Y,
                2 * dotPr * normal.Z - lightNormal.Z);
            R = Normalize(R);
            float dotPrVR = dotProduct(V, R);
            float zwierciadlo = Math.Max(0, 255 * ((float)ksBar.Value / ksBar.Maximum) * obj * light * (float)Math.Pow((double)dotPrVR,mBar.Value));
            return scoop(0,(int)(kaBar.Value/kaBar.Maximum*25 + rozproszenie+zwierciadlo),255);
        }
        private float dotProduct(Normal n1, Normal n2)
        {
            return -(n1.X * n2.X + n1.Y * n2.Y + n1.Z * n2.Z);
        }
        private bool AddOrDeleteFromAET(Edge e, int y, List<Edge> AET,int newx)
        {
            if (e.Y < y)
               return AET.Remove(e);
            else
            {
                e.x = newx+e.slope;
                //e.x = newx;
                AET.Add(e);
                return true;
            }
        }
        private Normal GetLightNormal(bool normalize = true)
        {
            int speed = speedBar.Value;
            float X = (float)Math.Sin(Math.PI*TickNum / speed);
            float Y = (float)Math.Cos(Math.PI*TickNum / speed);
            float Z = HeightBar.Value/20; //heigth
            Normal a = new Normal(X, Y, Z);
            if (normalize)
                a = Normalize(a);

            return a;
        }
        private Normal GetLightColor()
        {
            return new Normal(
                (float)LightColorChooser.Color.R / 255, 
                (float)LightColorChooser.Color.G / 255, 
                (float)LightColorChooser.Color.B / 255);
        }
        private Normal GetObjectColor(int x, int y)
        {
            if (FromTextureBox.Checked)
                return NormalColorFromInt(TextureBits[x + y * Canvas.Width]);


            return new Normal(
                (float)ObjectColorChooser.Color.R / 255,
                (float)ObjectColorChooser.Color.G / 255,
                (float)ObjectColorChooser.Color.B / 255);
        }

        private Normal GetcloudColor(int x, int y)
        {
          
                return NormalColorFromInt(cloudBits[x + y * Canvas.Width]);

        }

        private Normal GetObjectColor()
        {

            return new Normal(
                (float)ObjectColorChooser.Color.R / 255,
                (float)ObjectColorChooser.Color.G / 255,
                (float)ObjectColorChooser.Color.B / 255);
        }
        private Normal NormalColorFromInt(int color)
        {
            float R, G, B;
            R = ((float)((color & 0xff0000) >> 16)) / 255;
            G = ((float)((color & 0xff00) >> 8)) / 255;
            B = ((float)(color & 0xff)) / 255;
            return new Normal(R, G, B);
        }

        private Normal Normalize(Normal normal)
        {
            float len = (float)Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y + normal.Z * normal.Z);
            return new Normal(normal.X / len, normal.Y / len, normal.Z / len);
        }

        //private void FillTriangle(FaceProjection face)
        //{
        //    int y = face.edges[face.verIndexes[0]].p1.Vertex.Y;
        //    int curVer = 0;
        //    List<Edge> AET = new List<Edge>();
        //    Color color = CalculateFaceColor(obj.Normals[face.normalinx]);
        //    while(y <= face.edges[face.verIndexes[2]].p1.Vertex.Y)
        //    {
        //        //update AET
        //        while (face.edges[face.verIndexes[curVer]].p1.Vertex.Y == y - 1)
        //        {
        //            AddOrDeleteFromAET(face.edges[face.verIndexes[curVer]], y, AET, face.edges[face.verIndexes[curVer]].p1.Vertex.X);
        //            AddOrDeleteFromAET(face.edges[(face.verIndexes[curVer] + 2) % 3], y, AET, face.edges[face.verIndexes[curVer]].p1.Vertex.X);
        //            curVer++;
        //        }

        //        //order AET
        //        AET = AET.OrderBy(x => x.x).ToList();

        //        //draw
        //        foreach (var pair in AET.Zip(AET.Skip(1), (a, b) => Tuple.Create(a, b)).Where((x, i) => i % 2 == 0)) 
        //        {
        //            for (int j = (int)pair.Item1.x; j < (int)pair.Item2.x; j++)
        //            {
        //                drawArea.SetPixel(j, y, color);
        //            }
        //        }

        //        //update x
        //        foreach (var x in AET) 
        //        {
        //            x.x += x.slope;
        //        }

        //        //next y
        //        y++;
        //    }
        //}

        //private void FillT(FaceProjection face)
        //{
        //    List<VertexProjection> vers = new List<VertexProjection>(); 
        //    foreach(var a in face.edges)
        //    {
        //        vers.Add(a.p1);
        //    }
        //    int y = face.edges[face.verIndexes[0]].p1.Vertex.Y;
        //    int curVer = 0;
        //    List<Edge> AET = new List<Edge>();
        //    Color color = CalculateFaceColor(obj.Normals[face.normalinx]);
        //    while (y <= face.edges[face.verIndexes[2]].p1.Vertex.Y)
        //    {
        //        //update AET
        //        while (face.edges[face.verIndexes[curVer]].p1.Vertex.Y == y - 1)
        //        {
        //            AddOrDeleteFromAET(face.edges[face.verIndexes[curVer]], y, AET, face.edges[face.verIndexes[curVer]].p1.Vertex.X);
        //            AddOrDeleteFromAET(face.edges[(face.verIndexes[curVer] + 2) % 3], y, AET, face.edges[face.verIndexes[curVer]].p1.Vertex.X);
        //            curVer++;
        //        }

        //        //order AET
        //        AET = AET.OrderBy(x => x.x).ToList();

        //        //draw
        //        foreach (var pair in AET.Zip(AET.Skip(1), (a, b) => Tuple.Create(a, b)).Where((x, i) => i % 2 == 0))
        //        {
        //            for (int j = (int)pair.Item1.x; j < (int)pair.Item2.x; j++)
        //            {
        //                drawArea.SetPixel(j, y, color);
        //            }
        //        }

        //        //update x
        //        foreach (var x in AET)
        //        {
        //            x.x += x.slope;
        //        }

        //        //next y
        //        y++;
        //    }
        //}
        public Point VerToPoint(Vertex ver)
        {
            int w = (Canvas.Width - 1);
            int h = (Canvas.Height - 1);
            return new Point(scoop(0, w / 2 + (int)(ver.X * w / 2), w), scoop(0, h / 2 + (int)(ver.Y * h / 2), h));
        }
        private int scoop(int min, int num, int max)
        {
            return Math.Min(max, Math.Max(min, num));
        }
        private float scoop(float min, float num, float max)
        {
            return Math.Min(max, Math.Max(min, num));
        }

        private void ChooseLightColor_Click(object sender, EventArgs e)
        {
            LightColorChooser.ShowDialog();
        }

        private void StopBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                FrameUpdateTimer.Stop();
            else
                FrameUpdateTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectColorChooser.ShowDialog();
        }
        public void FillTriangle(FaceProjection face, Action<int, int, FaceProjection, Color> FillPixel, Color color)
        {
            List<Point> points = new List<Point>();
            foreach (var x in face.edges)
            {
                points.Add(x.p1.Vertex);
            }
            List<int> indexes = Enumerable.Range(0, points.Count).ToList();
            indexes = indexes.OrderBy(x => points[x].Y).ToList();

            int index = 0;

            List<AETNode> AET = new List<AETNode>();
           
            for (int y = points[indexes[0]].Y; y <= points[indexes[points.Count - 1]].Y; y++)
            {
                while (index < points.Count && y - 1 == points[indexes[index]].Y)
                {
                    int prev = (indexes[index] + points.Count - 1) % points.Count;
                    int curr = indexes[index];
                    int next = (indexes[index] + 1) % points.Count;

                    if (points[prev].Y >= points[curr].Y)
                    {
                        float dx = points[curr].X - points[prev].X;
                        float dy = points[curr].Y - points[prev].Y;

                        if (points[prev].Y != points[curr].Y)
                            AET.Add(new AETNode(prev, points[curr].X, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == prev);
                    }

                    if (points[next].Y >= points[curr].Y)
                    {
                        float dx = points[curr].X - points[next].X;
                        float dy = points[curr].Y - points[next].Y;

                        if (points[next].Y != points[curr].Y)
                            AET.Add(new AETNode(curr, points[curr].X, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == curr);
                    }

                    index++;
                }
                AET = AET.OrderBy(x => x.x).ToList();
                
                foreach (var pair in AET.Zip(AET.Skip(1), (a, b) => Tuple.Create(a, b)).Where((x, i) => i % 2 == 0))
                {
                    for (int x = (int)pair.Item1.x; x < (int)pair.Item2.x; x++)
                    {
                        FillPixel(x, y,face, color);
                    }
                }

                foreach (var x in AET)
                {
                    x.x += x.slope;
                }
            }
        }

        public void FillPolygon(Point[] poi, Color color)
        {
            List<Point> points = poi.ToList();
          
            List<int> indexes = Enumerable.Range(0, points.Count).ToList();
            indexes = indexes.OrderBy(x => points[x].Y).ToList();

            int index = 0;

            List<AETNode> AET = new List<AETNode>();

            for (int y = Math.Max(0,points[indexes[0]].Y); y <= Math.Min(points[indexes[points.Count - 1]].Y,Canvas.Height-1); y++)
            {
                while (index < points.Count && y - 1 == points[indexes[index]].Y)
                {
                    int prev = (indexes[index] + points.Count - 1) % points.Count;
                    int curr = indexes[index];
                    int next = (indexes[index] + 1) % points.Count;

                    if (points[prev].Y >= points[curr].Y)
                    {
                        float dx = points[curr].X - points[prev].X;
                        float dy = points[curr].Y - points[prev].Y;

                        if (points[prev].Y != points[curr].Y)
                            AET.Add(new AETNode(prev, points[curr].X, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == prev);
                    }

                    if (points[next].Y >= points[curr].Y)
                    {
                        float dx = points[curr].X - points[next].X;
                        float dy = points[curr].Y - points[next].Y;

                        if (points[next].Y != points[curr].Y)
                            AET.Add(new AETNode(curr, points[curr].X, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == curr);
                    }

                    index++;
                }
                AET = AET.OrderBy(x => x.x).ToList();

                foreach (var pair in AET.Zip(AET.Skip(1), (a, b) => Tuple.Create(a, b)).Where((x, i) => i % 2 == 0))
                {
                    for (int x = Math.Max(0,(int)pair.Item1.x); x <Math.Min(Canvas.Width-1, (int)pair.Item2.x); x++)
                    {
                        
                        drawArea.SetPixel(x, y, color);
                    }
                }

                foreach (var x in AET)
                {
                    x.x += x.slope;
                }
            }
        }





        private void LoadImage(ref Bitmap bitmap,ref Int32[] table, ref GCHandle handle,  string path)
        {
            Image sourceImage = new Bitmap(path);


            table = new Int32[Canvas.Height * Canvas.Width];
            handle = GCHandle.Alloc(table, GCHandleType.Pinned);
            bitmap = new Bitmap(Canvas.Width,
                                          Canvas.Height,
                                          Canvas.Width * 4,
                                          System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
                                          handle.AddrOfPinnedObject());

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(sourceImage, 0, 0, Canvas.Width, Canvas.Height);
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            FrameUpdateTimer_Tick(sender, e);
        }

        private void ColorInterpolationButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            lightNormal=GetLightNormal();
            DrawObject();
        }

        private void LoadTextureButton_Click(object sender, EventArgs e)
        {
            TextureFileLoader.ShowDialog();
            LoadTexture(TextureFileLoader.FileName);
        }

        private void LoadMapButton_Click(object sender, EventArgs e)
        {
            MapFileLoader.ShowDialog();
            LoadMap(MapFileLoader.FileName);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }

}
