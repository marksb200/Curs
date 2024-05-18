using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Curs
{
    public partial class Form1 : Form
    {
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actionButton.Enabled = false;
            createTable.Enabled = false;
            button1.Enabled = false;
            alg.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode.SelectedIndex == 0) 
            {
                createTable.Enabled = false;
                actionButton.Enabled = true;
                button1.Enabled = false;
            } 
            if (mode.SelectedIndex == 1) 
            { 
                createTable.Enabled = true;
                button1.Enabled = true;
                actionButton.Enabled = false;
            } 
        }
        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != e.RowIndex)
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int newValue) || (newValue <= 0))
                {
                    e.Cancel = true;
                    DGV.Rows[e.RowIndex].ErrorText = "Invalid value. Please enter a valid integer.";
                }
                else
                {
                    DGV.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j) { continue; }
                    if (Convert.ToInt32(DGV.Rows[i - 1].Cells[j - 1].Value) <= 0)
                    {
                        flag = true;
                        MessageBox.Show("В таблице не должно быть пустых ячеек!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        actionButton.Enabled = false;
                        break;
                    }
                    else
                    {
                        actionButton.Enabled = true;
                    }
                }
                if (flag)
                {
                    createTable.PerformClick();
                    break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericCountGuests.Text);
            DGV.ColumnCount = n;
            DGV.RowCount = n;
            DGV.AutoResizeColumnHeadersHeight();
            if (mode.SelectedIndex == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            DGV.Rows[i].Cells[j].Value = "---";
                            DGV.Rows[i].Cells[j].ReadOnly = true;
                            continue;
                        }
                        DGV.Rows[i].Cells[j].ReadOnly = false;
                        if(DGV.Rows[i].Cells[j].Value == null)
                        {
                            actionButton.Enabled = false;
                        }
                    }
                    DGV.Columns[i].HeaderText = $"Гость {i + 1}";
                    DGV.Rows[i].HeaderCell.Value = $"Гость {i + 1}";
                }
            }
        }

        void actionButton_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericCountGuests.Text);
            DGV.ColumnCount = n;
            DGV.RowCount = n;
            DGV.AutoResizeColumnHeadersHeight();
            Random random = new Random();
            if (mode.SelectedIndex == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            DGV.Rows[i].Cells[j].Value = "---";
                            DGV.Rows[i].Cells[j].ReadOnly = true;
                            continue;
                        }
                        int rd = random.Next(1, 10);
                        DGV.Rows[i].Cells[j].Value = rd;
                        DGV.Rows[j].Cells[i].Value = rd;
                        DGV.Rows[i].Cells[j].ReadOnly = true;
                    }
                    DGV.Columns[i].HeaderText = $"Гость {i + 1}";
                    DGV.Rows[i].HeaderCell.Value = $"Гость {i + 1}";
                }
            }
            Graph graph = new Graph(Enumerable.Range(1, n).ToArray());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j) { continue; }
                    graph.addEdge(i, j, Convert.ToInt32(DGV.Rows[i - 1].Cells[j - 1].Value));
                }
            }
            if (alg.SelectedIndex == 0)
            {
                answerSpace.Text = Convert.ToString(graph.tsp().weight + " | Way:");
                for (int i = graph.tr.Count - n; i < graph.tr.Count; i++)
                {
                    answerSpace.Text += Convert.ToString(graph.tr[i] + "-");
                }
                answerSpace.Text += Convert.ToString(graph.tr[graph.tr.Count - n]);
                graph.tr.Clear();
            }
            if (alg.SelectedIndex == 1)
            {
                List<int> temp = new List<int>();
                int max = 0;
                for (int i = 0; i < n; i++)
                {
                    if (max < graph.findMaxRoute(i)[n])
                    { 
                        max = graph.findMaxRoute(i)[n];
                        temp = graph.findMaxRoute(i).GetRange(0, n);
                    }
                }
                answerSpace.Text = Convert.ToString(max + " | Way:");
                for (int i = 0; i < temp.Count; i++)
                {
                    answerSpace.Text += Convert.ToString(temp[i] + 1 + "-");
                }
                answerSpace.Text += Convert.ToString(temp[0] + 1);
            }
        }
        class Graph
        {
            public List<int> tr = new List<int>();
            int[] vertices;
            int size;
            int[,] edges;
            public Graph(int[] vertices)
            {
                this.vertices = vertices;
                size = vertices.Length;
                edges = new int[size, size];
            }
            public void addEdge(int row, int column, int weight)
            {
                edges[row - 1, column - 1] = weight;
                edges[column - 1, row - 1] = weight;
            }
            public Route tsp() // функция, которая обходит вершины и возвращает тот путь, который стоит меньше всего
            {
                HashSet<int> seen = new HashSet<int>(); // множество, в котором хранятся пройденные вершины
                Route max = null; // переменная, которая хранит минимальный путь 
                Action<int, Route> bruteforce = null; // делегат
                bruteforce = new Action<int, Route>((i, current) => // внутренняя рекурсивная функция. 
                                                                    // В качестве параметров принимает: индекс следующей вершины, уже построенный маршрут.
                {
                    seen.Add(i); // добавляем вершину, от которой начинается обход
                    if (count(seen) == size) // если мы обошли все вершины
                    {
                        int weight = edges[i, seen.First()]; // проверяем наличие дароги в стартовую вершину
                        if (weight != 0) // если обход вершин замкнутый
                        {
                            Route route = current.add(vertices[seen.First()], edges[i, seen.First()]);
                            // добавляем замыкающую вершину в переменную с патенциальным минимальным путем
                            if (max == null || max.weight < route.weight) // если минимум еще не определен или он больше нового минимума
                            {
                                max = route; // переопределяем минимум
                                foreach (int k in seen)
                                {
                                    tr.Add(k+1); 
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < edges.GetLength(0); j += 1) // перебираем возможные пути от вершины i 
                        {
                            int weight = edges[i, j]; // стоимость дороги от i-ой вершины до j-ой (путь от i-ой до j-ой = i-ой = 0)
                            if (weight != 0 && !seen.TryGetValue(j, out int actualValue))
                            // проверяем, что не идем в туже вершину или в вершину, которую обходили ранее
                            {
                                Route route = current.add(vertices[j], weight); // переменная, которая хранит путь с новой вершиной
                                bruteforce(j, route); // ныряем в рекурсию, передаваяя ей новую вершину и путь
                            }
                        }
                    }
                    seen.Remove(i); // удаляем последнюю вершину 
                });
                int[] v = { vertices[0] };
                for (int k = 0; k < size; k++)
                {
                    bruteforce(k, new Route(v, 0)); // вызываем рекурсивную функцию
                }
                return max; // ответ
            }
            public List<int> findMaxRoute(int fGuest)
            {
                int sum = 0;
                int counter = 0;
                int j = 0, i = fGuest;
                int max = 0;
                List<int> visitedRouteList = new List<int>
                {
                    fGuest
                };
                int[] route = new int[edges.Length];

                while (i < edges.GetLength(0) &&
                    j < edges.GetLength(1))
                {
                    if (counter >= edges.GetLength(0) - 1)
                    {
                        break;
                    }

                    if (j != i &&
                        !visitedRouteList.Contains(j))
                    {
                        if (edges[i, j] > max)
                        {
                            max = edges[i, j];
                            route[counter] = j + 1;
                        }
                    }
                    j++;

                    if (j == edges.GetLength(0))
                    {
                        sum += max;
                        max = 0;
                        visitedRouteList.Add(route[counter] - 1);

                        j = 0;
                        i = route[counter] - 1;
                        counter++;
                    }
                }
                sum += edges[visitedRouteList[edges.GetLength(0) - 1], visitedRouteList[0]];
                visitedRouteList.Add(sum);
                return visitedRouteList;
            }
            int count(HashSet<int> seen) // длина множества
            {
                int counter = 0;
                foreach (int k in seen)
                {
                    counter++;
                }
                return counter;
            }
        }
        class Route // класс, который хранит суммарную длину пути и список вершин, который алгоритм успел пройти.
        {
            public int[] vertices; // вершины, которые успели обойти 
            public int weight; // сколько стоило нам обойти вершины
            public Route(int[] vertices, int weight) // конструктор, который в впоследствии переопределяет vertices и weight. 
            {
                this.vertices = vertices;
                this.weight = weight;
            }
            public Route add(int vertex, int incWeight) // метод, который обновляет vertices и добавляет к weight новые веса. 
                                                        //vertex - вершина, incWeight - вес.
            {
                int[] nextVertices = new int[1]; // массив под след. вершину
                nextVertices.Append(vertex).ToArray(); // добавляем следующую вершину
                int nextWeight = weight + incWeight; // прибавляем вес от старой вершины до следующей к уже подсчитанным весам
                return new Route(nextVertices, nextWeight); // возращаем объект класса Route с новыми данными
            }
        }
    }
}