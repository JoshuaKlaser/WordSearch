using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Random;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtWords.Text = $"Joshua,Klaser,Funny,Haha,What,Banana,Lovely,Destroy,Home,Keyboard";
            txtHeight.Text = "14";
            txtWidth.Text = "14";

            Generate();
        }

        private void Generate()
        {
            var grid = new Grid(Convert.ToInt32(txtHeight.Text), Convert.ToInt32(txtWidth.Text));

            var words = txtWords.Text.Split(',');

            foreach (var word in words)
            {
                grid.SubmitText(word);
                Thread.Sleep(80);
            }

            panel1.Controls.Clear();

            for (int i = 0; i < grid.Height; i++)
            {
                for (int q = 0; q < grid.Width; q++)
                {
                    var label = new Label();

                    label.Font = new Font(FontFamily.GenericSansSerif, 16);
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Location = new Point(50 * q, 50 * i);
                    label.Size = new Size(50, 50);
                    label.Text = grid.GridData[i][q].Value;

                    panel1.Controls.Add(label);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void btnClearWords_Click(object sender, EventArgs e)
        {
            txtWords.Text = string.Empty;
        }

        private void btnOriginalWords_Click(object sender, EventArgs e)
        {
            txtWords.Text = $"Joshua,Klaser,Funny,Haha,What,Banana,Lovely,Destroy,Home,Keyboard";
        }
    }
}
