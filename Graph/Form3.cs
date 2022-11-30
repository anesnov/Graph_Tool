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
    public partial class Form3 : Form
    {
        public bool isDirected = false;
        public Form3(int v1, int v2)
        {
            InitializeComponent();
            if (v1 != v2)
            {
                label.Text += "{" + v1.ToString() + ", " + v2.ToString() + "}";
                undirected.Checked = true;
            }

            else
            {
                label.Text = "Adding loop {" + v1.ToString() + ", " + v2.ToString() + "}";
                EdgeChoice.Enabled = false;
            }            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            isDirected = directed.Checked;
            Close();
        }
    }
}
