using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;


using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Graph.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.IO;
using System.Xml;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace Graph
{    
    public partial class Form1 : Form
    {

        GGraph graph;
        int clicked_v = -1;
        int current = -1;
        List<List<int>> dfs = null;
        Tuple<List<int>, int> v_colors = null;
        List<Color> colors = null;

        public Form1()
        {
            InitializeComponent();
            graph = new GGraph(new List<Point>(), new List<List<bool>>());
            colors = new List<Color>();
            ColoringMenu.SelectedItem = "Greedy";

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            void draw_vertex(Font font, Brush f_brush, Pen pen, Brush v_brush, Point p)
            {
                Rectangle rect = new Rectangle(p.X, p.Y, graph.size, graph.size);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.FillEllipse(v_brush, rect);
                g.DrawEllipse(pen, rect);
                Point sp = new Point(p.X + graph.size / 2 + 1, p.Y + graph.size / 2 + 1);
                g.DrawString((graph.vertexes.IndexOf(p) + 1).ToString(), font, f_brush, sp, sf);
            }

            void draw_edge(Point from, Point to, Pen pen, Boolean directed)
            {             
                if (from == to)
                {
                    Rectangle rect = new Rectangle(from.X - graph.size/3, from.Y - (int)(graph.size), (int)(graph.size * 1.5), (int)(graph.size * 1.5));
                    g.DrawEllipse(pen, rect);
                }

                else
                {
                    Point p2 = new Point(to.X + graph.size / 2, to.Y + graph.size / 2);
                    if (directed)
                    {
                        double sin()
                        {
                            return (Math.Abs(from.Y - to.Y) / graph.distance(from.X, from.Y, to.X, to.Y));
                        }

                        pen.CustomEndCap = new AdjustableArrowCap(5, 5);

                        int x_diff = (int)(graph.size / 2 * Math.Sqrt(1 - Math.Pow(sin(), 2)));
                        int y_diff = (int)(graph.size / 2 * sin());

                        Func<bool, int, int> swap = (x, y) => x ? y * -1 : y;
                        p2 = new Point(to.X + graph.size / 2 + swap(to.X > from.X, x_diff), to.Y + graph.size / 2 + swap(to.Y > from.Y, y_diff));
                    }
                    Point p1 = new Point(from.X + graph.size / 2, from.Y + graph.size / 2);

                    g.DrawLine(pen, p1, p2);
                }                
            }

            g.DrawRectangle(graph.np, panel1.Location.X, panel1.Location.Y, panel1.Width+panel1.Location.X, panel1.Height);            
            
            for (int i = 0; i < graph.adj_matrix.Count; i++)
            {
                for (int j = 0; j < graph.adj_matrix[i].Count; j++)
                {
                    if (graph.adj_matrix[i][j] && graph.adj_matrix[j][i])
                    {
                        draw_edge(graph.vertexes[i], graph.vertexes[j], graph.np, false);
                    }
                    else if (graph.adj_matrix[i][j] && !graph.adj_matrix[j][i])
                    {
                        draw_edge(graph.vertexes[i], graph.vertexes[j], graph.np, true);
                    }
                }
            }

            if (graph.vertexes != null)
            {
                foreach (var v in graph.vertexes)
                {
                    draw_vertex(graph.drawFont, graph.fontb, graph.np, graph.nb, v);
                }
            }
            if (clicked_v >= 0)
            {
                draw_vertex(graph.drawFont, graph.fontb, graph.np, new SolidBrush(Color.FromArgb(255, 230, 150, 150)), graph.vertexes[clicked_v]);
            }

            if (dfs != null)
            {
                label.Text = "Поиск в глубину: ";
                Pen pen = new Pen(Color.FromArgb(255, 230, 190, 0), 3);                

                for (int i = 1; i < dfs[0].Count; i++)
                {
                    draw_edge(graph.vertexes[dfs[1][i]], graph.vertexes[dfs[0][i]], pen, true);
                }
                foreach (var v in dfs[0])
                {
                    label.Text = label.Text + (v + 1).ToString() + " => ";
                    draw_vertex(graph.drawFont, graph.fontb, graph.np, new SolidBrush(Color.FromArgb(200, 220, 100, 100)), graph.vertexes[v]);
                }
                label.Text = label.Text.ToString().Remove(label.Text.Length - 4, 4);
                label.Refresh();
            }

            if (v_colors != null)
            {
                Random rnd = new Random();
                label.Text = "Количество цветов: " + v_colors.Item2.ToString();
                for (int i = colors.Count; i < v_colors.Item2; i++)
                {
                    colors.Add(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                }
                
                for (int i = 0; i < v_colors.Item1.Count; i++)
                {
                    draw_vertex(graph.drawFont, graph.fontb, graph.np, new SolidBrush(colors[v_colors.Item1[i]-1]), graph.vertexes[i]);
                    Point p = new Point(graph.vertexes[i].X + graph.size/2, graph.vertexes[i].Y - graph.size/2);
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString((v_colors.Item1[i]).ToString(), graph.drawFont, graph.fontb, p, sf);
                }
                v_colors = null;
            }             
        }       

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (AddE.Checked) // Добавить диалог с ориентацией ребра
            {                
                int vc = graph.VertexClicked(e.X, e.Y);

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
                if (e.X < panel1.Width + panel1.Location.X - graph.size && e.Y < panel1.Height + panel1.Location.Y - graph.size &&
                    e.X > panel1.Location.X && e.Y > panel1.Location.Y)
                {
                    graph.vertexes.Add(new Point(e.X, e.Y));
                    graph.adj_matrix.Add(Enumerable.Range(0, graph.adj_matrix.Count+1).Select(x => false).ToList());
                    for (int i = 0; i < graph.adj_matrix.Count-1; i++)
                    {
                        graph.adj_matrix[i].Add(false);
                    }
                }
            }

            if (remove.Checked) 
            {                
                var ec = graph.EdgeClicked(e.X, e.Y);
                int vc = graph.VertexClicked(e.X, e.Y);
                
                if (vc != -1)
                {
                    graph.remove_v(vc);
                }
                
                else if (ec != null) graph.adj_matrix[ec.Item1][ec.Item2] = graph.adj_matrix[ec.Item2][ec.Item1] = false;
            }
            if (DFS.Checked)
            {                
                int vc = graph.VertexClicked(e.X, e.Y);
                if (vc != -1)
                {
                    dfs = graph.DFS(vc);
                }
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
            if (move.Checked && current != -1) // TODO fix out of bounds
            {
                if (e.X < panel1.Location.X || e.Y < panel1.Location.Y)
                {
                    graph.vertexes[current] = new Point(Math.Max(e.X, panel1.Location.X), Math.Max(e.Y, panel1.Location.Y));
                }
                else if (e.X > panel1.Width - graph.size || e.Y > panel1.Height + panel1.Location.Y - graph.size)
                {
                    graph.vertexes[current] = new Point(Math.Min(e.X, panel1.Width - graph.size / 2), Math.Min(e.Y, panel1.Height + panel1.Location.Y - graph.size));

                }
                else graph.vertexes[current] = new Point(e.X, e.Y);
                this.Refresh();
            }
        }

        private void adjacencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(graph.adj_matrix);

            if (form2.ShowDialog() == DialogResult.OK)
            {
                Random rnd = new Random();
                Func<int, bool> reverse = x => x > 0;
                graph.adj_matrix = new List<List<bool>>();
                for (int i = 0; i < form2.dt.Columns.Count; i++)
                {
                    graph.adj_matrix.Add(new List<bool>());
                    for (int j = 0; j < form2.dt.Rows.Count-1; j++)
                    {
                        var cellvaue = form2.dt.Rows[i][j];
                        graph.adj_matrix[i].Add(reverse(int.Parse(cellvaue.ToString())));
                    }                    
                }
                if (graph.adj_matrix.Count > graph.vertexes.Count)
                {
                    for (int i = graph.vertexes.Count; i < graph.adj_matrix.Count; i++)
                        graph.vertexes.Add(new Point(rnd.Next(panel1.Location.X, panel1.Width - graph.size), rnd.Next(panel1.Location.Y, panel1.Height - graph.size)));
                }
                else
                {
                    graph.vertexes.RemoveRange(graph.adj_matrix.Count, graph.vertexes.Count - graph.adj_matrix.Count);
                }
            }

            this.Refresh();
        }

        private void AddV_Click(object sender, EventArgs e)
        {
            label.Text = locale.AddV;
            this.Refresh();
        }

        private void AddE_Click(object sender, EventArgs e)
        {
            clicked_v = -1;
            label.Text = locale.AddE;
            this.Refresh();
        }

        private void move_CheckedChanged(object sender, EventArgs e)
        {
            label.Text = locale.MoveV;
            this.Refresh();
        }

        private void remove_CheckedChanged(object sender, EventArgs e)
        {            
            label.Text = locale.RemoveE;
            this.Refresh();
        }

        private void DFS_CheckedChanged(object sender, EventArgs e)
        {
            dfs = null;            
            label.Text = locale.DFS_Start;
            this.Refresh();            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();

            colorDialog1.AllowFullOpen = true;
            colorDialog1.Color = graph.v_color;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                graph.v_color = colorDialog1.Color;
                graph.nb = new SolidBrush(graph.v_color);
                this.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            CultureInfo ci = CultureInfo.GetCultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = ci;
            label.Text = locale.AddV;
        }

        private void Coloring_MouseClick(object sender, MouseEventArgs e)
        {
            if (ColoringMenu.SelectedItem.ToString() == "Greedy")
            {
                v_colors = graph.coloring(null);
            }
            if (ColoringMenu.SelectedItem.ToString() == "Descending")
            {
                v_colors = graph.descColoring();
            }
            if (ColoringMenu.SelectedItem.ToString() == "Ascending")
            {
                v_colors = graph.ascColoring();
            }

            this.Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowHelp = true;
            sfd.FileName = "graph.grf";
            sfd.Filter = "Graph|*.grf";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextWriter file = new StreamWriter(sfd.FileName);
                    file.WriteLine(graph.vertexes.Count.ToString());
                    foreach (var v in graph.vertexes)
                    {
                        file.WriteLine(v.ToString());
                    }
                    foreach (var v in graph.adj_matrix)
                    {
                        foreach (var j in v)
                            file.WriteLine(j.ToString());
                    }
                    file.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowHelp = true;
            ofd.FileName = "graph.grf";
            ofd.Filter = "Graph|*.grf";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextReader file = new StreamReader(ofd.FileName);
                    int count = int.Parse(file.ReadLine());
                    graph.vertexes.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        var s = file.ReadLine().Split(',');
                        var s1 = s[0].Substring(3);
                        var s2 = s[1].Substring(2);                        

                        int x = int.Parse(s1);
                        int y = int.Parse(s2.Remove(s2.Length - 1));
                        Point p = new Point(x, y);
                        graph.vertexes.Add(p);
                    }
                    graph.adj_matrix.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        graph.adj_matrix.Add(new List<bool>());
                        for (int j = 0; j < count; j++)
                        {
                            graph.adj_matrix[i].Add(bool.Parse(file.ReadLine()));
                        }
                    }
                    file.Close();
                    this.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    
}

// TODO Добавить окно настройек (цвет, размер вершин, язык, (уровень логгирования)?)
// TODO Добавить возможность отрисовки петель и дуг +
// TODO (?) Добавить небольшой буфер состояний
// TODO Добавить сохранение/загрузку(матрицы смежн. и позиций вершин) +
// TODO Добавить логгирование
// TODO Добавить локаль +-
