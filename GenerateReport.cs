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
    public partial class GenerateReport : Form
    {
        public GenerateReport()
        {
            InitializeComponent();
            string report = ReportsInterface.report;

            if (report == ReportsInterface.Report5)
            {
                Report5_code();
            }
            else if (report == ReportsInterface.Report6)
            {
                Report6_code();
            }
            else if (report == ReportsInterface.Report7)
            {
                Report7_code();
            }
            else if (report == ReportsInterface.Report8)
            {
                Report8_code();
            }
            else if (report == ReportsInterface.Add_R4)
            {

                Add_R4_code();
            }
            else if (report == ReportsInterface.Add_R5)
            {

                Add_R5_code();
            }
            else if (report == ReportsInterface.Add_R6)
            {

                Add_R6_code();
            }
            else if (report == ReportsInterface.Add_R7)
            {

                Add_R7_code();
            }
            else if (report == ReportsInterface.Add_R9)
            {

                Add_R9_code();
            }
            else if (report == ReportsInterface.Add_R3)
            {

                Add_R3_code();
            }
            else
            {
                // Code to handle unknown report selection
            }
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {

            string report = ReportsInterface.report;



            if (report == ReportsInterface.Report5)
            {
                Report5_code();
            }
            else if (report == ReportsInterface.Report6)
            {
                Report6_code();
            }
            else if (report == ReportsInterface.Report7)
            {
                Report7_code();
            }
            else if (report == ReportsInterface.Report8)
            {
                Report8_code();
            }
            else if (report == ReportsInterface.Add_R4) {

                Add_R4_code(); 
            }
            else if (report == ReportsInterface.Add_R5 )
            {

                Add_R5_code();
            }
            else if (report == ReportsInterface.Add_R6)
            {

                Add_R6_code();
            }
            else if (report == ReportsInterface.Add_R7)
            {

                Add_R7_code();
            }
            else if (report == ReportsInterface.Add_R9)
            {

                Add_R9_code();
            }
            else if (report == ReportsInterface.Add_R3)
            {

                Add_R3_code();
            }
            else
            {
                // Code to handle unknown report selection
            }





        }


        private void Report5_code()
        {

            int calories = int.Parse( ReportsInterface.input  );

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;
            


query = @"SELECT dp.*
FROM DietPlan dp
WHERE dp.DietPlanID IN (
    SELECT dp.DietPlanID
    FROM DietPlan dp
    JOIN Mealsindietplan dpm ON dp.DietPlanID = dpm.PlanID
    JOIN Meals m ON dpm.MealsID = m.MealsID
    WHERE m.MealType = 'Breakfast' AND m.Calories < @cal
);";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@cal", calories );
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;


            conn.Close();

        }

        private void Report6_code()
        {
            int carb= int.Parse(ReportsInterface.input);

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;



            query = @"select * from DietPlan where Tcarb < @carb ";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@carb", carb );
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();


        }
        private void Add_R4_code()
        {
            int carb = int.Parse(ReportsInterface.input);

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;



            query = @"select * from DietPlan where Tprotien < @carb ";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@carb", carb );
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



            conn.Close();
        }

        private void Add_R5_code()
        {
            int carb = int.Parse(ReportsInterface.input);

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;



            query = @"select * from DietPlan where Tfat < @carb ";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@carb", carb);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;


            conn.Close();

        }

        private void Add_R6_code()
        {


            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;



            query = @"select * from DietPlan where DietType =  @type";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@type", ReportsInterface.input );
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



            conn.Close();
        }

        private void Add_R7_code()
        {


            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;



            query = @"select * from Exercises e1 
join ExercisesInWorkoutPlan e2
on e1.ExerciseID = e2.ExerciseID 
join WorkOutPlan wp on wp.PlanID = e2.PlanID 
where wp.PlanID = @id ;
";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@id", ReportsInterface.input);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



            conn.Close();
        }

        private void Add_R9_code()
        {


            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            


            string query = @"SELECT PlanID, planName, Goal, Duration FROM Workoutplan WHERE goal LIKE '%" + ReportsInterface.input + "%'";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@choice", ReportsInterface.input);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



            conn.Close();
        }

        private void Add_R3_code()
        {


            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;



            string query = @"Select ExerciseName from Exercises where Musclegroup = @grp";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@grp", ReportsInterface.input);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;



            conn.Close();
        }
        private void Report7_code()
        {
            
            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;



query = @"SELECT DISTINCT WP.*
FROM WorkOutPlan WP
WHERE NOT EXISTS (
    SELECT 1
    FROM ExercisesInWorkoutPlan ewp 
    JOIN Exercises e ON ewp.ExerciseID = e.ExerciseID
    LEFT JOIN Machine m ON e.ExerciseID = m.ExerciseID AND m.MachineName = @mac
    WHERE WP.PlanID = ewp.PlanID AND m.MachineID IS NOT NULL )" ;




            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@mac", ReportsInterface.input);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }
        private void Report8_code()
        {

            SqlDataAdapter adpt;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            //SqlCommand cm;
            string query;


            query = "select * from DietPlan where Allergens != @all ";



            DataTable dt = new DataTable();
            adpt = new SqlDataAdapter(query, conn);
            adpt.SelectCommand.Parameters.AddWithValue("@all", ReportsInterface.input);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }




    }
}
