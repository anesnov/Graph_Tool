using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Graph
{    
    public partial class Form1 : Form
    {

        GGraph graph;
        int clicked_v = -1;
        int current = -1;

        public Form1()
        {
            InitializeComponent();
            graph = new GGraph(new List<Point>(), new List<List<bool>>());
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.DrawRectangle(graph.np, panel1.Location.X, panel1.Location.Y, panel1.Width+panel1.Location.X, panel1.Height);            
            
            for (int i = 0; i < graph.adj_matrix.Count; i++)
            {
                for (int j = i+1; j < graph.adj_matrix[i].Count; j++)
                {
                    if (graph.adj_matrix[i][j])
                    {
                        Point p1 = new Point(graph.vertexes[i].X + graph.size / 2, graph.vertexes[i].Y + graph.size / 2);
                        Point p2 = new Point(graph.vertexes[j].X + graph.size / 2, graph.vertexes[j].Y + graph.size / 2);
                        g.DrawLine(graph.np, p1, p2);
                    }
                }
            }

            if (graph.vertexes != null)
            {
                foreach (var v in graph.vertexes)
                {
                    Rectangle rect = new Rectangle(v.X, v.Y, graph.size, graph.size);

                    g.DrawEllipse(graph.np, rect);
                    g.FillEllipse(graph.nb, rect);
                    g.DrawString((graph.vertexes.IndexOf(v) + 1).ToString(), graph.drawFont, graph.fontb, new Point(v.X, v.Y));
                }
            }
            if (clicked_v >= 0)
            {
                Rectangle rect = new Rectangle(graph.vertexes[clicked_v].X, graph.vertexes[clicked_v].Y, graph.size, graph.size);

                Brush sb = new SolidBrush(Color.FromArgb(255, 200, 40, 40));
                g.DrawEllipse(graph.np, rect);
                g.FillEllipse(sb, rect);

                g.DrawString((clicked_v + 1).ToString(), graph.drawFont, graph.nb, graph.vertexes[clicked_v]);
            }
        }       

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (AddE.Checked) 
            {
                
                int vc = graph.vertex_click(e.X, e.Y);

                if (vc != -1)
                {
                    if (clicked_v == -1)
                        clicked_v = vc;
                    else
                    {
                        graph.adj_matrix[vc][clicked_v] = graph.adj_matrix[clicked_v][vc] = true;
                        clicked_v = -1;
                    }
                }
                else clicked_v = -1;

            }
            if (AddV.Checked)
            {
                if (e.X < panel1.Width && e.Y < panel1.Height)
                {
                    graph.vertexes.Add(new Point(e.X, e.Y));
                    graph.adj_matrix.Add(new List<bool>(graph.adj_matrix.Count+1));
                    for (int i = 0; i < graph.adj_matrix.Count; i++)
                    {
                        graph.adj_matrix[i].Add(false);
                        graph.adj_matrix[graph.adj_matrix.Count - 1].Add(false);
                    }
                }
            }
            if (remove.Checked)
            {
                var ec = graph.edge_click(e.X, e.Y);
                int vc = graph.vertex_click(e.X, e.Y);
                
                if (vc != -1)
                {
                    graph.vertexes.RemoveAt(vc);
                    graph.adj_matrix.RemoveAt(vc);
                    for (int i = 0; i < graph.adj_matrix.Count; i++)
                        graph.adj_matrix[i].RemoveAt(vc);
                }
                
                else if (ec != null) graph.adj_matrix[ec.Item1][ec.Item2] = graph.adj_matrix[ec.Item2][ec.Item1] = false;

            }
            this.Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (move.Checked)
            {
                if (current == -1)
                {
                    foreach (var vertex in graph.vertexes)
                    {
                        if (Math.Pow(vertex.X + graph.size/2 - e.X, 2) + Math.Pow(vertex.Y + graph.size / 2 - e.Y, 2) < graph.size * graph.size)
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
                    graph.vertexes[current] = new Point(e.X, e.Y);
                    this.Refresh();
                }
            }
        }

        private void adjacencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(graph.adj_matrix);
            form2.ShowDialog();


            if (form2.changed)
            {
                Func<int, bool> reverse = x => x > 0;
                graph.adj_matrix = new List<List<bool>>();
                for (int i = 0; i < form2.dt.Columns.Count; i++)
                {
                    graph.adj_matrix.Add(new List<bool>());
                    for (int j = 0; j < form2.dt.Rows.Count; j++)
                    {
                        var cellvaue = form2.dt.Rows[i][j];
                        graph.adj_matrix[i].Add(reverse(int.Parse(cellvaue.ToString())));
                    }
                }
            }

            this.Refresh();
        }
    }

    class GGraph
    {
        public List<Point> vertexes = new List<Point>(); // TODO изменить список кортежей на список точек
        public List<List<bool>> adj_matrix = new List<List<bool>>();

        public Pen np;
        public Brush nb;
        public Font drawFont;
        public Brush fontb;
        public int size;

        public GGraph(List<Point> vertexes, List<List<bool>> matrix)
        {
            this.vertexes = vertexes;
            this.adj_matrix = matrix;

            np = new Pen(Color.Black, 2);
            nb = new SolidBrush(Color.Wheat);
            fontb = new SolidBrush(Color.Black);
            drawFont = new Font("Arial", 12);
            size = 25;
        }

        public int vertex_click(int x, int y)
        {
            foreach(var vertex in vertexes)
            {
                if (Math.Pow(vertex.X+size/2 - x, 2) + Math.Pow(vertex.Y + size / 2 - y, 2) < size * size)
                    return vertexes.IndexOf(vertex);
            }
            return -1;
        }

        public Tuple<int, int> edge_click(int x, int y)
        {
            for (int i = 0; i < adj_matrix.Count; i++)
                for (int j = i+1; j < adj_matrix.Count; j++)
                {
                    if (adj_matrix[i][j])
                    {
                        double d1 = Math.Sqrt(Math.Pow(x - vertexes[i].X, 2) + Math.Pow(y - vertexes[i].Y, 2));
                        double d2 = Math.Sqrt(Math.Pow(x - vertexes[j].X, 2) + Math.Pow(y - vertexes[j].Y, 2));
                        double d = Math.Sqrt(Math.Pow(vertexes[i].X - vertexes[j].Y, 2) + Math.Pow(vertexes[i].Y - vertexes[j].Y, 2));
                        if ((d - 2 < d1 + d2) && (d1 + d2 < d + 2))
                            return new Tuple<int, int>(i, j);

                    }
                }

            return null;
        }

        public double distance(int x1, int y1 ,int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

    }
}
