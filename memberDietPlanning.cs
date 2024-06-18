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
    public partial class memberDietPlanning : Form
    {

        public static int DietPlanID =0;
        public static string DietPlanName = "";


        public memberDietPlanning()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (MemberWorkoutPlan form2 = new MemberWorkoutPlan())
                form2.ShowDialog();
            Show();

            //Application.Run(new MemberWorkoutPlan());


        }

        private void memberDietPlanning_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;





            query = "select PlanName from dietplan";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["PlanName"].ToString());
                }
            }
      

          




            conn.Close();

            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;
            DietPlanName = comboBox1.Text;

            query = "select DietPlanID from dietplan where PlanName = @name";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@name", DietPlanName);
            SqlDataReader da2 = cm.ExecuteReader();

            while (da2.Read())
            {
               // MessageBox.Show(da2.GetValue(0).ToString() );
                DietPlanID = da2.GetInt32(0);
                break;
            }

            conn.Close(); 
            conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

    
            // Construct the SQL query to select all attributes of the diet plan based on DietPlanId
             query = "SELECT * FROM dietplan WHERE DietPlanId = @id";

            // Create a SqlCommand object and set its parameters
             cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@id", DietPlanID);

            // Execute the query and retrieve the data
            SqlDataReader da3 = cm.ExecuteReader();
            if (da3.Read())
            {
                // Display the attributes in different labels
                label11.Text = da3["Tfat"].ToString();
                label10.Text = da3["Tprotein"].ToString();
                label9.Text = da3["Tcarb"].ToString();
                label12.Text = da3["Allergens"].ToString();
                label14.Text = da3["DietType"].ToString();
                label8.Text = da3["TotalCalories"].ToString();
                // Add more labels for other attributes as needed
            }


            



        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
