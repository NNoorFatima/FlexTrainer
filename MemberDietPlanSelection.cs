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
    public partial class MemberDietPlanSelection : Form
    {
        public MemberDietPlanSelection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (DeitPlanSelectionReport form2 = new DeitPlanSelectionReport())
                form2.ShowDialog();
            Show();
        }
    }
}
