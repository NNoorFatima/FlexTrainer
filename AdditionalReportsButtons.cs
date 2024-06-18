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
    public partial class AdditionalReportsButtons : Form
    {
        public AdditionalReportsButtons()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (ExpofatrainerReport form2 = new ExpofatrainerReport())
                form2.ShowDialog();
            Show();
        }

        private void AdditionalReportsButtons_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (ViewDataOfspeicifcGymReport form2 = new ViewDataOfspeicifcGymReport())
                form2.ShowDialog();
            Show();
        }
    }
}
