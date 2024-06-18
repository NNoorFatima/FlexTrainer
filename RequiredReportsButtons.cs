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
    public partial class RequiredReportsButtons : Form
    {
        public RequiredReportsButtons()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (Report form2 = new Report())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdminFollowDiet form2 = new AdminFollowDiet())
            {
                form2.ShowDialog();
            }
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            using (meberSpecificGymReport form2 = new meberSpecificGymReport())
            {
                form2.ShowDialog();
            }
            Show();
        }
    }
}
