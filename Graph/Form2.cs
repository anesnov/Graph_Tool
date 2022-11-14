using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form2 : Form
    {
        public Form2(List<List<bool>> matrix)
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            adj_matrix.RowHeadersWidth = 30;


            for (int i = 0; i < matrix.Count; i++)
            {                
                dt.Columns.Add(new DataColumn((i+1).ToString()));
                dt.Rows.Add();             
            }

            adj_matrix.DataSource = dt;
            Func<bool, int> func = x => x ? 1 : 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                adj_matrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
                adj_matrix.Rows[i].Height = 20;
                adj_matrix.Columns[i].Width = 20;
                for (int j = 0; j < matrix.Count; j++)
                    adj_matrix.Rows[i].Cells[j].Value = func(matrix[i][j]);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
