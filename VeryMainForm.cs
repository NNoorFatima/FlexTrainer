using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_forms
{
    public partial class VeryMainForm : Form
    {
        public VeryMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (MainForm form2 = new MainForm())
            {
                form2.ShowDialog();
            }
            Show();
        }
    }
}
