using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;


namespace DB_forms
{
    public partial class TrianerWorkoutPlanCreation : Form
    {
        public static string creationdate ="";
        public static string Trainerid = "";
        public static string Plandes = "";
        public static string PlanId = "";
        public static string PlanName = "";
        public static string Goal = "";
        public static string Duration = "";

        public TrianerWorkoutPlanCreation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainerid = trainer.TrainerID ;

            Plandes = textBox3.Text;
            PlanName = textBox4.Text;
            Goal = textBox6.Text;
            Duration = textBox7.Text;

            
            if (Trainerid == "" || Plandes == "" || PlanName == "" || Goal == "" || Duration == "")
            {
                MessageBox.Show("Fill all the boxes.");
            }
            else
            {
                Hide();
                using (AddExercises form2 = new AddExercises())
                    form2.ShowDialog();
                Show();



            }




        }

        private void TrianerWorkoutPlanCreation_Load(object sender, EventArgs e)
        {

        }
    }
}