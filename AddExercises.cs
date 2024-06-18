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
    public partial class AddExercises : Form
    {

        public static string E1, E2, E3; // these will be to display the names of exercises. 
        public AddExercises()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            E1 = comboBox2.Text;
            E2 = comboBox3.Text; E3 = comboBox4.Text;



            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            SqlCommand cm;
            conn.Open();
            string query = "select max(planid) from workoutplan";
            int tempid = 0;
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    tempid = da.GetInt32(0);
                    break;
                }
            }
            tempid += 1;



            // phele add data in database 
            string Today = "";
            // phele add data in database 
            query = "SELECT concat(DATEPART(YYYY, GETDATE()),'-', DATEPART(mm, GETDATE()),'-', DATEPART(dd, GETDATE())) ";
            cm = new SqlCommand(query, conn);

            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    Today = da.GetValue(0).ToString();
                    break;
                }
            }



            string Trainerid = TrianerWorkoutPlanCreation.Trainerid;
            string Plandes = TrianerWorkoutPlanCreation.Plandes ;
           string PlanName = TrianerWorkoutPlanCreation.PlanName ;
          string Goal =   TrianerWorkoutPlanCreation.Goal ;
          string  Duration = TrianerWorkoutPlanCreation.Duration;

            bool flag = true;

            if (Trainerid == "" || Plandes == "" || PlanName == "" || Goal == "" || Duration == "" || E1 == "" || E2 == ""  || E3 == "")
            {
                flag = false;
            }



            if (flag)
            {
                string insertQuery = "INSERT INTO workoutplan (CreationDate, Trainerid, PlanDescription, PlanName, PlanID, Goal, Duration ) " +
                          "VALUES (@creationdate, @Trainerid, @Plandes, @PlanName, @PlanId, @Goal, @Duration)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@creationdate", Today );
                insertCmd.Parameters.AddWithValue("@Trainerid", Trainerid );
                insertCmd.Parameters.AddWithValue("@Plandes", Plandes );
                insertCmd.Parameters.AddWithValue("@PlanName", PlanName);
                insertCmd.Parameters.AddWithValue("@PlanId", tempid);
                insertCmd.Parameters.AddWithValue("@Goal", Goal );
                insertCmd.Parameters.AddWithValue("@Duration", Duration );
                insertCmd.ExecuteNonQuery();
                insertCmd.Dispose();

                 query = "SELECT ExerciseId FROM Exercises WHERE ExerciseName IN (@e1, @e2, @e3)";
                 cm = new SqlCommand(query, conn);

                cm.Parameters.AddWithValue("@e1", E1);
                cm.Parameters.AddWithValue("@e2", E2);
                cm.Parameters.AddWithValue("@e3", E3);

                // Initialize variables to store ExerciseIDs
                int e1 = 0, e2 = 0, e3 = 0;

                using (SqlDataReader da = cm.ExecuteReader())
                {
                    int index = 0; // Index to keep track of which exercise's ID is being retrieved
                    while (da.Read())
                    {
                        // Check the index to assign the ExerciseID to the appropriate variable
                        switch (index)
                        {
                            case 0:
                                e1 = da.GetInt32(0);
                                break;
                            case 1:
                                e2 = da.GetInt32(0);
                                break;
                            case 2:
                                e3 = da.GetInt32(0);
                                break;
                            default:
                                break;
                        }
                        index++; // Increment the index for the next exercise
                    }
                }


                // now add exercises . 
                query = "insert into ExercisesInWorkoutPlan values ( @id , @e1 ) ";
                cm = new SqlCommand( query, conn);
                cm.Parameters.AddWithValue("@id", tempid);
                cm.Parameters.AddWithValue("@e1", e1);
                cm.ExecuteNonQuery();

                query = "insert into ExercisesInWorkoutPlan values ( @id , @e2 ) ";
                cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@id", tempid);
                cm.Parameters.AddWithValue("@e2", e2 );
                cm.ExecuteNonQuery();


                query = "insert into ExercisesInWorkoutPlan values ( @id , @e3 ) ";
                cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@id", tempid);
                cm.Parameters.AddWithValue("@e3", e3 );
                cm.ExecuteNonQuery();







                string msg = "Insertion done";
                MessageBox.Show(msg);
                conn.Close();
                
                Hide();
                using (TrainerOptionscs form2 = new TrainerOptionscs())
                    form2.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Fill all the boxes.");
            }
        }

        private void AddExercises_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;


            query = "select ExerciseName from Exercises";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox2.Items.Add(da["ExerciseName"].ToString());
                    comboBox3.Items.Add(da["ExerciseName"].ToString());
                    comboBox4.Items.Add(da["ExerciseName"].ToString());

                }
            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            E1 = comboBox2.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            E2 = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            E3 = comboBox4.Text;
        }
    }
}
