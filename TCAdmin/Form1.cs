using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCAdmin
{
    public partial class Form1 : Form, IView
    {
        public string[,] Data
        {
            set
            {
                dataGridView1.Rows.Clear();
                for(int i = 0; i < value.Length/5; i++)
                {
                    string[] r = new string[5];
                    for (int j = 0; j < 5; j++)
                    {
                        r[j] = value[i, j];
                    }
                    dataGridView1.Rows.Add(r);
                }
            }
        }

        public event Action Load;

        public Form1()
        {
            InitializeComponent();

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Load?.Invoke();
        }
    }
}
