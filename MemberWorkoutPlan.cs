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
    public partial class MemberWorkoutPlan : Form
    {

        public static string memberID = "";
        public static int PlanID = 0;
        public static string preferences = "";

        public MemberWorkoutPlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           memberID =  MembernewLogin.MemberID;
            int Dietplanid = memberDietPlanning.DietPlanID;
  /*          MessageBox.Show(memberID.ToString() );
            MessageBox.Show(Dietplanid .ToString());*/


            // plan id is the workout ID 

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();



            // Construct the SQL query with column names for the insert operation
            string query = "INSERT INTO MemberFollowPlan (MemberID, WorkoutPlanID, DietPlanID) VALUES (@memid, @eid, @did)";

            // Create a SqlCommand object and set its parameters
            SqlCommand cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@memid", memberID);
            cm.Parameters.AddWithValue("@eid", PlanID);
            cm.Parameters.AddWithValue("@did", Dietplanid);

            // Execute the insert query
            cm.ExecuteNonQuery();


            MessageBox.Show("Success");

            //////cm.Parameters.AddWithValue("@name", preferences);


            // open member options. 
             Hide();
             using (MemberOptions form2 = new  MemberOptions())
                 form2.ShowDialog();
             Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;
            preferences = comboBox1.Text ;


           // MessageBox.Show(preferences); 


            query = "select PlanID from workoutplan where goal = @name";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@name", preferences);
            SqlDataReader da2 = cm.ExecuteReader();

           

            while (da2.Read())
            {
                // MessageBox.Show(da2.GetValue(0).ToString() );
                PlanID = da2.GetInt32(0);
                break;
            }

           // MessageBox.Show(PlanID.ToString()); 


            conn.Close();
            conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            // Construct the SQL query to select all attributes of the diet plan based on DietPlanId
            query = "SELECT * FROM workoutPlan WHERE PlanId = @id" ;

            // Create a SqlCommand object and set its parameters
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@id", PlanID);

            // Execute the query and retrieve the data
            SqlDataReader da3 = cm.ExecuteReader();
            if (da3.Read())
            {
                // Display the attributes in different labels
                textBox1.Text = da3["PlanName"].ToString();
                textBox7.Text = da3["Duration"].ToString();
                textBox5.Text = da3["PlanDescription"].ToString();

            }

          


            conn.Close();


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void MemberWorkoutPlan_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;



            query = "select goal from workoutplan";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["Goal"].ToString()) ;
                }
            }





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
