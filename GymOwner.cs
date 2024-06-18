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
    public partial class GymOwner : Form
    {
        public GymOwner()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            using (GymTrainerReport form2 = new GymTrainerReport())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (GymMemberReport form2 = new GymMemberReport())
                form2.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            using (GymRemoveTrainer form2 = new GymRemoveTrainer())
                form2.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            using (GymRemoveMember form2 = new GymRemoveMember())
                form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (GymAddingNewTrainers form2 = new GymAddingNewTrainers())
                form2.ShowDialog();
            Show();
        }

        private void GymOwner_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            using (gymOwnerMembersData form2 = new gymOwnerMembersData())
                form2.ShowDialog();
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            using (gymOwnerTrainerFeedback form2 = new gymOwnerTrainerFeedback())
                form2.ShowDialog();
            Show();
        }
    }
}
