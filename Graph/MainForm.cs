using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Graph.Properties;
using System.IO;

using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Xml;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace Graph
{    
    public partial class MainForm : Form
    {

        GGraph graph;
        int clicked_v = -1;
        int current = -1;
        List<List<int>> dfs = null;
        Tuple<List<int>, int> v_colors = null;
        Tuple<List<List<int>>, int> e_colors = null;
        List<Color> colors = null;
        TextWriter log = null;

        public MainForm()
        {
            InitializeComponent();           

            graph = new GGraph(new List<Point>(), new List<List<bool>>());
            colors = new List<Color>();
            ColoringMenu.SelectedItem = "Последовательная";

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var t = DateTime.Now.ToString("yy:MM:dd:H:mm:ss tt").Replace(':', '_');
            log = new StreamWriter(string.Format("GrapthTool [{0:S}].log", t));
            AddV_Click(this, new EventArgs());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            log.WriteLine("Начало отрисовки.");
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

            void draw_edge(Point from, Point to, Pen pen, bool directed=false, bool dfsp = false)
            {             
                if (from == to)
                {
                    Rectangle rect = new Rectangle(from.X - graph.size/3, from.Y - (int)(graph.size), (int)(graph.size * 1.5), (int)(graph.size * 1.5));
                    g.DrawEllipse(pen, rect);
                }

                else
                {
                    Point p1 = new Point(from.X + graph.size / 2, from.Y + graph.size / 2);
                    Point p2 = new Point(to.X + graph.size / 2, to.Y + graph.size / 2);
                    if (directed)
                    {
                        double sin()
                        {
                            return (Math.Abs(from.Y - to.Y) / graph.distance(from.X, from.Y, to.X, to.Y));
                        }

                        Pen arrowpen = new Pen(Color.Black, pen.Width);
                        arrowpen.CustomEndCap = new AdjustableArrowCap(5, 5);
                        if (dfsp)
                        {
                            arrowpen.Width = 4;
                            arrowpen.Color = Color.FromArgb(255, 230, 190, 0);
                        }

                        int x_diff = (int)(graph.size / 2 * Math.Sqrt(1 - Math.Pow(sin(), 2)));
                        int y_diff = (int)(graph.size / 2 * sin());

                        Func<bool, int, int> swap = (x, y) => x ? y * -1 : y;
                        p2 = new Point(to.X + graph.size / 2 + swap(to.X > from.X, x_diff), to.Y + graph.size / 2 + swap(to.Y > from.Y, y_diff));
                        g.DrawLine(arrowpen, p1, p2);
                    }
                    else g.DrawLine(pen, p1, p2);
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

            if (e_colors != null)
            {
                Random rnd = new Random();
                label.Text = "Количество цветов: " + e_colors.Item2.ToString();
                colors.Clear();
                for (int i = 0; i < e_colors.Item2; i++) // for (int i = colors.Count; i < e_colors.Item2; i++)
                {
                    colors.Add(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                }
                for (int i = 0; i < e_colors.Item1.Count; i++)
                {
                    for (int j = 0; j < e_colors.Item1[i].Count; j++)
                    {
                        if (e_colors.Item1[i][j] > 0)
                        {
                            Pen colorpen = new Pen(colors[e_colors.Item1[i][j]-1], 3);
                            draw_edge(graph.vertexes[i], graph.vertexes[j], colorpen);
                        }
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

                for (int i = 1; i < dfs[0].Count; i++)
                {
                    draw_edge(graph.vertexes[dfs[1][i]], graph.vertexes[dfs[0][i]], graph.np, true, true);
                }

                
                var t = string.Format("DFS [{0:S}].log", DateTime.Now.ToString("yy:MM:dd:H:mm:ss tt").Replace(':', '_'));
                TextWriter dfslog = new StreamWriter(t);
                log.WriteLine("Результат поиска в глубину записан в файл [" + t + ']');

                dfslog.Write("Порядок обхода: ");
                foreach (var v in dfs[0])
                {
                    dfslog.Write((v+1).ToString() + " ");
                    label.Text = label.Text + (v + 1).ToString() + " => ";
                    draw_vertex(graph.drawFont, graph.fontb, graph.np, new SolidBrush(Color.FromArgb(255, 220, 100, 100)), graph.vertexes[v]);
                }
                dfslog.Close();
                label.Text = label.Text.ToString().Remove(label.Text.Length - 4, 4);
                label.Refresh();
            }

            if (v_colors != null)
            {
                Random rnd = new Random();
                label.Text = "Количество цветов: " + v_colors.Item2.ToString();
                colors.Clear();
                for (int i = 0; i < v_colors.Item2; i++) // for (int i = colors.Count; i < v_colors.Item2; i++)
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
            }
            log.WriteLine("Конец отрисовки.");
        }       

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (AddE.Checked) 
            {
                int vc = graph.vertexClicked(e.X, e.Y);

                if (vc != -1)
                {
                    if (clicked_v == -1)
                    {
                        clicked_v = vc;
                        log.WriteLine("Выбрана вершина " + vc);
                    }
                    else
                    {
                        EdgeDialogue choice = new EdgeDialogue(clicked_v+1, vc+1);

                        if ((graph.adj_matrix[vc][clicked_v] == false) || (graph.adj_matrix[clicked_v][vc] == false))
                        {
                            if (choice.ShowDialog() == DialogResult.OK)
                            {
                                if (choice.isDirected)
                                {
                                    graph.adj_matrix[clicked_v][vc] = true;
                                    log.WriteLine(string.Format("Добавлена дуга ({0:S},{1:S})", clicked_v.ToString(), vc.ToString()));
                                }
                                else
                                {
                                    graph.adj_matrix[vc][clicked_v] = graph.adj_matrix[clicked_v][vc] = true;
                                    log.WriteLine(string.Format("Добавлено ребро ({0:S},{1:S})", clicked_v.ToString(), vc.ToString()));
                                }
                            }
                        }
                        clicked_v = -1;
                    }
                }
                else
                {
                    clicked_v = -1;
                    log.WriteLine("Вершина не была выбрана.");
                }
                }

            if (AddV.Checked)
            {                
                if (e.X < panel1.Width + panel1.Location.X - graph.size && 
                    e.Y < panel1.Height + panel1.Location.Y - graph.size &&
                    e.X > panel1.Location.X && e.Y > panel1.Location.Y)
                {
                    log.WriteLine("Добавлена вершина " + graph.adj_matrix.Count);
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
                var ec = graph.edgeClicked(e.X, e.Y);
                int vc = graph.vertexClicked(e.X, e.Y);

                if (vc != -1)
                {
                    graph.remove_v(vc);
                    log.WriteLine("Удалена вершина " + vc);
                }

                else if (ec != null)
                {
                    graph.adj_matrix[ec.Item1][ec.Item2] = graph.adj_matrix[ec.Item2][ec.Item1] = false;
                    log.WriteLine("Удалено ребро " + ec);
                }
            }
            if (DFS.Checked)
            {                
                int vc = graph.vertexClicked(e.X, e.Y);
                if (vc != -1)
                {
                    dfs = graph.DFS(vc);
                    log.WriteLine("Выполнен поиск в глубину.");
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
                    current = graph.vertexClicked(e.X, e.Y);
                    log.WriteLine("Перемещение вершины " + current);
                }
                this.Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (move.Checked)
            {
                log.WriteLine("Конец перемещения.");
                current = -1;
                this.Refresh();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move.Checked && current != -1) 
            {
                int x = graph.vertexes[current].X;
                if (panel1.Location.X < e.X && e.X < panel1.Width + panel1.Location.X - graph.size)
                    x = e.X;

                int y = graph.vertexes[current].Y;
                if (panel1.Location.Y < e.Y && e.Y < panel1.Height + panel1.Location.Y - graph.size)
                    y = e.Y;

                graph.vertexes[current] = new Point(x, y);
                this.Refresh();
            }
        }

        private void adjacencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.WriteLine("Открытие матрицы смежности.");
            AdjMatrix dialoge = new AdjMatrix(graph.adj_matrix);

            if (dialoge.ShowDialog() == DialogResult.OK)
            {
                log.WriteLine("Изменение матрицы смежности.");
                Random rnd = new Random();
                Func<int, bool> reverse = x => x > 0;
                graph.adj_matrix = new List<List<bool>>();
                for (int i = 0; i < dialoge.dt.Rows.Count-1; i++)
                {
                    graph.adj_matrix.Add(new List<bool>());
                    for (int j = 0; j < dialoge.dt.Columns.Count; j++)
                    {
                        var cellvaue = dialoge.dt.Rows[i][j];
                        graph.adj_matrix[i].Add(reverse(int.Parse(cellvaue.ToString())));
                    }                    
                }
                log.WriteLine("Обновление списка точек вершин");
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
            label.Text = "Щелкните на поле для добавления вершины";
            this.Refresh();
        }

        private void AddE_Click(object sender, EventArgs e)
        {
            clicked_v = -1;
            label.Text = "Выберите вершину";
            this.Refresh();
        }

        private void move_CheckedChanged(object sender, EventArgs e)
        {
            label.Text = "Зажмите и перемещайте вершину";
            this.Refresh();
        }

        private void remove_CheckedChanged(object sender, EventArgs e)
        {            
            label.Text = "Щелкните по вершине или ребру для его удаления";
            this.Refresh();
        }

        private void DFS_CheckedChanged(object sender, EventArgs e)
        {
            dfs = null;            
            label.Text = "Выберите вершину для поиска в глубину";
            this.Refresh();            
        }

        private void Coloring_MouseClick(object sender, MouseEventArgs e)
        {
            if (Coloring.Checked)
            {
                log.WriteLine("Раскраская графа.");
                switch (ColoringMenu.SelectedItem.ToString())
                {
                    case "Последовательная":
                        v_colors = graph.coloring(null);
                        break;

                    case "НП - нисходящая":
                        v_colors = graph.descColoring();
                        break;

                    case "ПН - восходящая":
                        v_colors = graph.ascColoring();
                        break;

                    case "Рёберная":
                        e_colors = graph.edgeColoring();
                        break;
                }
                this.Refresh();
            }
        }
        private void Coloring_CheckedChanged(object sender, EventArgs e)
        {
            if (Coloring.Checked == false)
            {
                v_colors = null;
                e_colors = null;
            }
            this.Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.WriteLine("Попытка сохранить в файл.");
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
                    log.WriteLine("Сохранено в файл [" + sfd.FileName + ']');
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.WriteLine("Попытка загрузить из файла.");
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

                    var list = new List<Point>();                    
                    for (int i = 0; i < count; i++)
                    {
                        var s = file.ReadLine().Split(',');
                        var s1 = s[0].Substring(3);
                        var s2 = s[1].Substring(2);                        

                        int x = int.Parse(s1);
                        int y = int.Parse(s2.Remove(s2.Length - 1));
                        Point p = new Point(x, y);
                        list.Add(p);
                    } 

                    var result = Enumerable.Range(0, count).Select(
                x => Enumerable.Range(0, count).Select(y => false).ToList()).ToList();
                    
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            result[i][j] = bool.Parse(file.ReadLine());
                        }
                    }
                    file.Close();

                    graph.vertexes.Clear();
                    graph.vertexes = list;
                    graph.adj_matrix.Clear();
                    graph.adj_matrix = result;

                    dfs = null;
                    v_colors = null;
                    e_colors = null;

                    log.WriteLine("Граф был загружен из файла [" + ofd.FileName + ']');
                    this.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.WriteLine("Завершение работы.");
            log.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearField_Click(object sender, EventArgs e)
        {
            graph.vertexes.Clear();
            graph.adj_matrix.Clear();
            dfs = null;
            v_colors = null;
            e_colors= null;
            label.Text = "Поле очищено.";

            this.Refresh();
        }
    }
    
}

// TODO Добавить окно настроек (цвет, размер вершин, язык, (уровень логгирования)?) -
// TODO Добавить возможность отрисовки петель и дуг +
// TODO (?) Добавить небольшой буфер состояний
// TODO Добавить сохранение/загрузку(матрицы смежн. и позиций вершин) +
// TODO Добавить логгирование +
// TODO Добавить локаль +-
