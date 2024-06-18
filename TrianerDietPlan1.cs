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

    

    public partial class TrianerDietPlan1 : Form
    {

        public static string DietName= "";
        public static string Dur = "";
        public static string Des = "";

        public static string Type = "";
        public static string goal = "";
        public static string Allergens = "";



        public TrianerDietPlan1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DietName = textBox1.Text ;
         Dur = textBox2.Text;
        Des = textBox3.Text;

         Type = textBox4.Text;
         goal = textBox5.Text;
            Allergens = textBox6.Text; 



        Hide();
            using (TrainerDeitPlan2 form2 = new TrainerDeitPlan2())
                form2.ShowDialog();
            Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
