using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form2 : Form
    {
        public DataTable dt = new DataTable();
        public bool changed = false;
        private int temp = -1;
        private List<List<bool>> tmatrix;


        public Form2(List<List<bool>> matrix)
        {
            InitializeComponent();
            tmatrix = matrix;
            dt = new DataTable();
            adj_matrix.DataError += new DataGridViewDataErrorEventHandler(dataerrorHandler);
        }

        private void dataerrorHandler(object sender, DataGridViewDataErrorEventArgs anError)
        {
            adj_matrix.RefreshEdit();
            anError.ThrowException = false;
        }

        private void adj_matrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {            
            changed = true;
            confirm.Enabled = true;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in adj_matrix.Columns)
            {
                dt.Columns.Add();
            }

            object[] cellValues = new object[adj_matrix.Columns.Count];
            foreach (DataGridViewRow row in adj_matrix.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            changed = false;
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void adj_matrix_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (temp != -1)
            {
                adj_matrix.Columns.Add('v' + adj_matrix.ColumnCount.ToString(), (adj_matrix.ColumnCount+1).ToString());
                adj_matrix.Columns[adj_matrix.ColumnCount-1].SortMode = DataGridViewColumnSortMode.NotSortable;
                adj_matrix.Columns[adj_matrix.ColumnCount - 1].ValueType = typeof(int);
                adj_matrix.Columns[adj_matrix.ColumnCount - 1].Width = 20;
                adj_matrix.Rows[adj_matrix.ColumnCount - 1].HeaderCell.Value = adj_matrix.ColumnCount.ToString();
                for (int i = 0; i < adj_matrix.ColumnCount; i++)
                {
                    adj_matrix.Rows[i].Cells[adj_matrix.ColumnCount - 1].Value = adj_matrix.Rows[adj_matrix.ColumnCount - 1].Cells[i].Value = 0;
                }
            }
        }

        private void adj_matrix_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (int.Parse(adj_matrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) != 0 && int.Parse(adj_matrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) != 1)
            {
                adj_matrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = temp;
            }
        }

        private void adj_matrix_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < adj_matrix.RowCount-1)
                temp = int.Parse(adj_matrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            else temp = 0;
        }

        private void adj_matrix_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            adj_matrix.Columns.RemoveAt(e.RowIndex);
            changed = true;
            confirm.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (tmatrix.Count > 0)
            {
                for (int i = 0; i < tmatrix.Count; i++)
                {
                    adj_matrix.Columns.Add("v" + (i + 1).ToString(), (i + 1).ToString());
                    adj_matrix.Rows.Add();
                    adj_matrix.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                Func<bool, int> func = x => x ? 1 : 0;
                for (int i = 0; i < tmatrix.Count; i++)
                {
                    adj_matrix.Columns[i].ValueType = typeof(int);
                    adj_matrix.Rows[i].HeaderCell.Value = (i+1).ToString();
                    adj_matrix.Columns[i].Width = 25;
                    for (int j = 0; j < tmatrix.Count; j++)
                        adj_matrix.Rows[i].Cells[j].Value = func(tmatrix[i][j]);
                }
            }
            else
            {
                adj_matrix.Columns.Add("v1", "1");
                adj_matrix.Columns[0].Width = 20;
                adj_matrix.Rows.Add();
                adj_matrix.Rows[0].HeaderCell.Value = "1";
                adj_matrix.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                adj_matrix.Columns[0].ValueType = typeof(int);
                adj_matrix.Rows[0].Cells[0].Value = 0;

            }
            adj_matrix.RowHeadersWidth = 51;
            this.Width = adj_matrix.RowHeadersWidth + adj_matrix.ColumnCount*25 + 40;
            this.Height = (adj_matrix.RowCount + 2) * 22 + 40;
            confirm.Enabled = false;
            changed = false;
            temp = 0;
        }

        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                MessageBox.Show(s);
            }

            catch (FormatException)
            {

            }
        }

    }
}

// TODO (?)Возможность вставлять из буфера
