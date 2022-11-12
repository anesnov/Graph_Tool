using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{    
    public partial class Form1 : Form
    {

        GGraph graph;
        Tuple<int, int> clicked = null;
        int current = -1;

        public Form1()
        {
            InitializeComponent();
            graph = new GGraph(new List<Tuple<int, int>>(), new List<Tuple<int, int>>());
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.DrawRectangle(graph.np, panel1.Location.X, panel1.Location.Y, panel1.Width+panel1.Location.X, panel1.Height);            
            
            if (graph.edges != null)
            {
                foreach (Tuple<int, int> edge in graph.edges)
                {                    
                    graph.vertexes[edge.Item1].Deconstruct<int, int>(out int x1, out int y1);
                    graph.vertexes[edge.Item2].Deconstruct<int, int>(out int x2, out int y2);
                    g.DrawLine(graph.np, x1+graph.size/2, y1 + graph.size / 2, x2 + graph.size / 2, y2 + graph.size / 2);
                }
            }
            if (graph.vertexes != null)
            {
                for (int i = 0; i < graph.vertexes.Count; i++)
                {
                    graph.vertexes[i].Deconstruct<int, int>(out int x, out int y);
                    Rectangle rect = new Rectangle(x, y, graph.size, graph.size);

                    g.DrawEllipse(graph.np, rect);
                    g.FillEllipse(graph.nb, rect);
                    g.DrawString((i + 1).ToString(), graph.drawFont, graph.fontb, new Point(x, y));
                }
            }
            if (clicked != null)
            {
                clicked.Deconstruct<int, int>(out int x, out int y);
                Rectangle rect = new Rectangle(x, y, graph.size, graph.size);

                Brush sb = new SolidBrush(Color.Crimson);
                g.DrawEllipse(graph.np, rect);
                g.FillEllipse(sb, rect);
                g.DrawString((graph.vertexes.IndexOf(clicked) + 1).ToString(), graph.drawFont, sb, new Point(x, y));
            }
        }        
        
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            graph.vertexes.Add(new Tuple<int, int>(rnd.Next(0, 480), rnd.Next(0, 380)));
            this.Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (AddE.Checked)
            {
                foreach (Tuple<int, int> vertex in graph.vertexes)
                {
                    if (Math.Pow(vertex.Item1 - e.X, 2) + Math.Pow(vertex.Item2 - e.Y, 2) < graph.size * graph.size)
                    {
                        if (clicked == null)
                        {
                            clicked = vertex;
                            break;
                        }
                        else
                        {
                            foreach (Tuple<int, int> nvertex in graph.vertexes)
                            {
                                if (clicked != nvertex && Math.Pow(nvertex.Item1 - e.X, 2) + Math.Pow(nvertex.Item2 - e.Y, 2) < graph.size * graph.size)
                                {
                                    int v1 = Math.Min(graph.vertexes.IndexOf(clicked), graph.vertexes.IndexOf(nvertex));
                                    int v2 = Math.Max(graph.vertexes.IndexOf(clicked), graph.vertexes.IndexOf(nvertex));
                                    graph.edges.Add(new Tuple<int, int>(v1, v2));
                                    clicked = null;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                
            }
            if (AddV.Checked)
            {
                graph.vertexes.Add(new Tuple<int, int>(e.X, e.Y));
            }
            this.Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (move.Checked)
            {
                if (current == -1)
                {
                    foreach (Tuple<int, int> vertex in graph.vertexes)
                    {
                        if (Math.Pow(vertex.Item1 - e.X, 2) + Math.Pow(vertex.Item2 - e.Y, 2) < graph.size * graph.size)
                        {
                            current = graph.vertexes.IndexOf(vertex);
                            break;
                        }
                    }
                }
                this.Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (move.Checked)
            {
                current = -1;
                this.Refresh();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move.Checked)
            {
                if (current != -1)
                {
                    graph.vertexes[current] = new Tuple<int, int>(e.X, e.Y);
                    this.Refresh();
                }
            }
        }
    }

    class GGraph
    {
        public List<Tuple<int, int>> vertexes = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
        public Pen np;
        public Brush nb;
        public Font drawFont;
        public Brush fontb;
        public int size;

        public GGraph(List<Tuple<int, int>> vertexes, List<Tuple<int, int>> edges)
        {
            this.vertexes = vertexes;
            this.edges = edges;

            np = new Pen(Color.Black, 2);
            nb = new SolidBrush(Color.Wheat);
            fontb = new SolidBrush(Color.Black);
            drawFont = new Font("Arial", 12);
            size = 20;
        }

    }
}
