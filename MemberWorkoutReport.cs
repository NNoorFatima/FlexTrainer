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
    public partial class MemberWorkoutReport : Form
    {
        public MemberWorkoutReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (MemberWorkoutReportReport form2 = new MemberWorkoutReportReport())
                form2.ShowDialog();
            Show();
        }
    }
}
