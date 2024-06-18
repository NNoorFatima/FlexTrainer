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
    public partial class TrainerOptionscs : Form
    {
        public TrainerOptionscs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (TrianerDietPlan1 form2 = new TrianerDietPlan1())
                form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (TrainerAppointment form2 = new TrainerAppointment())
                form2.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            using (TrianerWorkoutPlanCreation form2 = new TrianerWorkoutPlanCreation())
                form2.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Hide();
            using (Trainergymregistration form2 = new Trainergymregistration())
                form2.ShowDialog();
            Show();
        }

        private void TrainerOptionscs_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            using (TrainerFeedbackReport form2 = new TrainerFeedbackReport())
                form2.ShowDialog();
            Show();
        }
    }
}
