using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form2 : Form
    {
        private Form1 frm1;
        private string name;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtName.Text.Equals(""))
            {
                name = txtName.Text;
                frm1 = new Form1(name);
                frm1.Show();
                frm1.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
            }
            else
                MessageBox.Show("chua nhap ten");
        }

    }
}
