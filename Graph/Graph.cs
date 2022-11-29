using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{    class GGraph
    {
        public List<Point> vertexes = new List<Point>();
        public List<List<bool>> adj_matrix = new List<List<bool>>();

        public Pen np;
        public Brush nb;
        public Font drawFont;
        public Brush fontb;
        public Color v_color;
        public int size;


        public GGraph(List<Point> vertexes, List<List<bool>> matrix)
        {
            this.vertexes = vertexes;
            this.adj_matrix = matrix;

            v_color = Color.Wheat;
            np = new Pen(Color.Black, 2);
            nb = new SolidBrush(v_color);
            fontb = new SolidBrush(Color.Black);
            drawFont = new Font("Arial", 12);
            size = 25;
        }

        public int VertexClicked(int x, int y)
        {
            foreach (var vertex in vertexes)
            {
                if (Math.Pow(vertex.X + size / 2 - x, 2) + Math.Pow(vertex.Y + size / 2 - y, 2) < size * size)
                    return vertexes.IndexOf(vertex);
            }
            return -1;
        }

        public Tuple<int, int> EdgeClicked(int x, int y)
        {
            for (int i = 0; i < adj_matrix.Count; i++)
                for (int j = i + 1; j < adj_matrix.Count; j++)
                {
                    if (adj_matrix[i][j] || adj_matrix[j][i])
                    {
                        double d1 = Math.Sqrt(Math.Pow(x - vertexes[i].X, 2) + Math.Pow(y - vertexes[i].Y, 2));
                        double d2 = Math.Sqrt(Math.Pow(x - vertexes[j].X, 2) + Math.Pow(y - vertexes[j].Y, 2));
                        double d = Math.Sqrt(Math.Pow(vertexes[i].X - vertexes[j].X, 2) + Math.Pow(vertexes[i].Y - vertexes[j].Y, 2));
                        if ((d - 2 < d1 + d2) && (d1 + d2 < d + 2))
                            return new Tuple<int, int>(i, j);
                    }
                }

            return null;
        }

        public List<List<int>> DFS(int start)
        {
            var result = new List<int>();
            var pre = new List<int>();
            result.Add(start);
            pre.Add(-1);

            var arr = Enumerable.Range(0, adj_matrix.Count).Select(x => true).ToList();

            void DFSrecursion(int v)
            {
                arr[v] = false;
                for (int i = 0; i < arr.Count; i++)
                {
                    if (adj_matrix[v][i] && arr[i])
                    {
                        result.Add(i);
                        pre.Add(v);
                        DFSrecursion(i);
                    }
                }
            }

            DFSrecursion(start);
            return new List<List<int>>() { result, pre };
        }

        public Tuple<List<int>, int> greedyColoring(List<int> order = null)
        {
            if (adj_matrix.Count > 0)
            {
                var result = Enumerable.Range(0, adj_matrix.Count).Select(x => -1).ToList();
                var avialible = Enumerable.Range(0, adj_matrix.Count).Select(x => false).ToList();

                if (order == null) result[0] = 1;
                else result[order[0]] = 1;


                for (int i = 1; i < adj_matrix.Count; i++)
                {
                    if (order != null)
                        if (result[order[i]] != -1)
                            continue;
                    for (int j = 0; j < avialible.Count; j++)
                    {
                        if (order == null)
                        {
                            if (result[j] != -1 && adj_matrix[i][j])
                                avialible[result[j]] = true;
                        }
                        else
                        {
                            if (result[order[j]] != -1 && adj_matrix[order[i]][order[j]])
                                avialible[result[order[j]]] = true;
                        }
                    }

                    int cr = 1;
                    while (cr < adj_matrix.Count)
                    {
                        if (avialible[cr] == false)
                            break;
                        cr++;
                    }

                    if (order == null) result[i] = cr;
                    else result[order[i]] = cr;


                    for (int j = 0; j < avialible.Count; j++)
                    {
                        if (result[j] != -1)
                            avialible[j] = false;
                    }

                }

                return new Tuple<List<int>, int>(result, LMax(result));
            }
            else return null;
        }

        public Tuple<List<int>, int> coloring(List<int> order)
        {
            if (order == null)
                order = Enumerable.Range(0, adj_matrix.Count).ToList();
            List<int> colors = Enumerable.Range(0, adj_matrix.Count).Select(x => 0).ToList();
           
            colors[order[0]] = 1;

            for (int i=1; i<adj_matrix.Count; i++)
            {
                List<int> taken = new List<int>();
                for (int j = 0; j < adj_matrix.Count; j++)
                {
                    if (adj_matrix[order[i]][j] && taken.IndexOf(colors[j]) == -1 && colors[j] > 0)
                        taken.Add(colors[j]);
                }
                taken.Sort();
                for (int j = 0; j < taken.Count; j++)
                {
                    if(j+1 != taken[j])
                    {
                        colors[order[i]] = j + 1;
                        break;
                    }
                }
                if (colors[order[i]] == 0)
                    colors[order[i]] = taken.Count+1;   
            }

            return new Tuple<List<int>, int>(colors, LMax(colors));
        }

        public Tuple<List<int>, int> descColoring()
        {
            List<Tuple<int, int>> v_deg = new List<Tuple<int, int>>();
            for (int i = 0; i < adj_matrix.Count; i++)
                v_deg.Add(new Tuple<int, int>(i, degree(i)));
            v_deg = v_deg.OrderBy(x => x.Item2).ToList();
            v_deg.Reverse();
            var q = from x in v_deg
                    group x by x.Item2 into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };

            foreach (var v in q)
            {
                if (v.Count > 1)
                {
                    Tuple<int, int> temp = null;
                    var index = v_deg.FindIndex(t => t.Item2 == v.Value);
                    for (int i = index; i < index + v.Count - 1; i++)
                    {
                        for (int j = i; j < index + v.Count - 1; j++)
                        {
                            var ndeg1 = ndegree(v_deg[i].Item1, 2);
                            var ndeg2 = ndegree(v_deg[j].Item1, 2);
                            if (ndeg1 < ndeg2)
                            {
                                temp = v_deg[i];
                                v_deg[i] = v_deg[j];
                                v_deg[j] = temp;
                            }
                        }
                    }
                }
            }

            var result = Enumerable.Range(0, v_deg.Count).Select(x => v_deg[x].Item1).ToList();
            return coloring(result);
        }

        public Tuple<List<int>, int> ascColoring()
        {
            var result = new List<int>();
            var matrix = new List<List<bool>>();
            for (int i = 0; i<adj_matrix.Count;i++)
            {
                matrix.Add(new List<bool>());
                for (int j = 0; j < adj_matrix[i].Count; j++)
                    matrix[i].Add(adj_matrix[i][j]);
            }

            var count = Enumerable.Range(0, matrix.Count).Select(x => true).ToList();
            for (int v = 0; v < matrix.Count-1; v++)
            {
                int min = int.MaxValue;
                int min_i = 0;
                for (int i = 0; i < matrix.Count; i++)
                {
                    int deg = degree(i, matrix);
                    if (0 < deg && deg < min)
                    {
                        min_i = i;
                        min = deg;
                    }
                    
                }
                matrix = remove_v(min_i, matrix);
                result.Add(min_i);
                count[min_i] = false;
            }

            result.Add(count.IndexOf(true));
            result.Reverse();
            return coloring(result);
        }

        public double distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public int degree(int v, List<List<bool>> matrix = null)
        {
            int deg = 0;
            if (matrix == null)
            {
                for (int i = 0; i < adj_matrix.Count; i++)
                {
                    if (adj_matrix[i][v]) deg++;
                }
            }
            else
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i][v]) deg++;
                }
            }
            return deg;
        }

        public int ndegree(int v, int n)
        {
            if (n > 1)
            {
                int sum = 0;
                for (int i = 0; i < adj_matrix.Count; i++)
                {
                    if (adj_matrix[v][i])
                    {
                        sum += ndegree(i, n - 1);
                    }
                }
                return sum;
            }
            else return degree(v);
        }

        public List<List<bool>> remove_v(int v, List<List<bool>> matrix = null)
        {
            if (matrix == null)
            {
                vertexes.RemoveAt(v);
                adj_matrix.RemoveAt(v);
                for (int i = 0; i < adj_matrix.Count; i++)
                    adj_matrix[i].RemoveAt(v);
                return null;
            }
            else
            {
                //matrix.RemoveAt(v);
                //for (int i = 0; i < matrix.Count; i++)
                //    matrix[i].RemoveAt(v);

                for (int i=0; i<matrix.Count; i++)
                {
                    matrix[i][v] = matrix[v][i] = false;
                }
                return matrix;
            }
        }

        public int LMax(List<int> list)
        {
            int max = -1;
            foreach (var i in list)
            {
                if (i > max) max = i;
            }
            return max;
        }

    }
}
