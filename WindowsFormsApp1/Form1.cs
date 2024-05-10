using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MyMethod(object sender, EventArgs e)
        {
            MessageBox.Show("MyMethod executed");
            button1.Click -= MyMethod2;
            button1.Click -= MyMethod;

        }
        private void MyMethod2(object sender, EventArgs e)
        {
            MessageBox.Show("MyMethod2 executed");
        }

        

    }

}
