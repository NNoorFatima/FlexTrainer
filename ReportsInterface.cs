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

    
    public partial class ReportsInterface : Form
    {
        public static string Report5 = "List of Diet plans that have less than specific calorie meals as breakfast.";
        public static string Report6 = "List of diet plans in which total carbohydrate intake is less than specific grams.";
        public static string Report7 = "List of workout plans that don’t require using a specific machine.";
        public static string Report8 = "List of diet plans which doesn’t have specific allergens.";
        public static string Add_R4 = "List of diet plans in which total protien intake is less than specific grams.";
        public static string Add_R5 = "List of diet plans in which total fat intake is less than specific grams.";


        public static string Add_R3 = "List of Exercises based on specific muscle group.";

        public static string Add_R6 = "List of diet plans based on Diet Type.";
        public static string Add_R7 = "List of Exercises of a Specific Workoutplan.";

        public static string Add_R9 = "List of Workout Plan Based on a specific Goal.";



        public static string report = "";
        public static string input = "";



        public ReportsInterface()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(700, 500);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            report = comboBox1.Text;

            


        }

        private void ReportsInterface_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(Report5);
            comboBox1.Items.Add(Report6);
            comboBox1.Items.Add(Report7);
            comboBox1.Items.Add(Report8);
            comboBox1.Items.Add(Add_R4 );
            comboBox1.Items.Add(Add_R5 );
            comboBox1.Items.Add(Add_R6 );

            comboBox1.Items.Add(Add_R7);
            comboBox1.Items.Add(Add_R9);
            comboBox1.Items.Add(Add_R3);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (report == Report6 || report == Add_R4 || report == Add_R5)
            {
                label2.Text = "Enter Grams: ";
            }

            else if (report == Report7)
            {
                label2.Text = "Enter Machine Name: ";
            }
            else if (report == Report5)
            {
                label2.Text = "Enter Calories: ";
            }
            else if (report == Report8)
            {
                label2.Text = "Enter Allergens: ";
            }
            else if (report == Add_R6 )
            {
                label2.Text = "Enter Type (Vegan or Non-Vegan): ";
            }
            else if (report == Add_R7)
            {
                label2.Text = "Enter Plan ID: ";
            }
            else if (report == Add_R9)
            {
                label2.Text = "Enter Goal: ";
            }
            else if (report == Add_R3)
            {
                label2.Text = "Enter Muscle group: ";
            }
            else
            {
                // Code to handle unknown report selection
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {
            // yaha pr cout of the thing 


        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            // run the report or queries here.
            if (textBox1.Text == "")
            {
                MessageBox.Show("An input is required.");

            }
            else
            {
                // call the form ( Grid )

                Hide();
                using (GenerateReport form2 = new GenerateReport())
                    form2.ShowDialog();
                Show(); 

            }



        }


        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
