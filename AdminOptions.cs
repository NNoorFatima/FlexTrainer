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
    public partial class AdminOptions : Form
    {
        public AdminOptions()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdminOptions_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdminGeneratePerformaceGym form2 = new AdminGeneratePerformaceGym())
                form2.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            using (adminRemoveTrainer form2 = new adminRemoveTrainer())
                form2.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdminApproveGymandOwner form2 = new AdminApproveGymandOwner())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdminRevokeGym form2 = new AdminRevokeGym())
                form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (adminRemoveMember form2 = new adminRemoveMember())
                form2.ShowDialog();
            Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            using (AdditionalReportsButtons form2 = new AdditionalReportsButtons())
                form2.ShowDialog();
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            using (adminCompareGym form2 = new adminCompareGym())
            {
                form2.ShowDialog();
            }
            Show();
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            using (RequiredReportsButtons form2 = new RequiredReportsButtons())
            {
                form2.ShowDialog();
            }
            Show();
        }
    }
}
