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
    public partial class wokoutReportSelf : Form
    {

        public static int planID = 0; 
        public wokoutReportSelf()
        {
            InitializeComponent();
            showDataPlan2();
            showDataExercises();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void wokoutReportSelf_Load(object sender, EventArgs e)
        {
            showDataPlan2();
            showDataExercises();

        }
        private void showDataPlan2 ()
        {

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;
            planID = 0;

            query = "SELECT workoutPlanID FROM MemberFollowPlan WHERE MemberID = @MemberID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MemberID", MembernewLogin.MemberID);

                // Execute the query and retrieve MemberFollowsPlanID and PlanID
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {


                        planID = reader.GetInt32(0); // Assuming PlanID is stored as int
                    }
                }
            }



            query = "select * from workoutPlan where PlanId = @id";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@id", planID);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void showDataExercises() {


            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;

            query = "select * from Exercises where ExerciseID In  (select ExerciseID from ExercisesInWorkoutPlan where PlanID = @id )";


            //cm = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@id", planID);
            adpt.Fill(dt);
            dataGridView2.DataSource = dt;

        }

    }
}
