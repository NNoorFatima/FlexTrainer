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

    public partial class TrainerDeitPlan2 : Form
    {
        public static string M1 = "";
        public static string M2 = ""; 
        public static string M3 = "";
        public static string M4 = "";
        

        public static int mealID1 , mealID2 , mealID3, mealID4;
        public static int calories1 , calories2 , calories3 ,calories4;
        public static int fat1 , fat2 , fat3, fat4;
        public static int protein1 , protein2 , protein3, protein4;

        public static int NewDietPlanID = 0; 

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            M2 = comboBox2.Text;
            // Assuming you've opened the connection
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            // Define the SQL query to retrieve data for the meal named "Sushi"
            string query = "SELECT * FROM Meals WHERE MealName = @MealName";

            // Create a SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, conn);

            // Add a parameter for the meal name
            cmd.Parameters.AddWithValue("@MealName", M2);

            // Execute the query and get the data
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Store data in variables
                    mealID2 = reader.GetInt32(reader.GetOrdinal("MealsID"));
                    calories2 = reader.GetInt32(reader.GetOrdinal("Calories"));
                    fat2 = reader.GetInt32(reader.GetOrdinal("Fat"));
                    protein2 = reader.GetInt32(reader.GetOrdinal("Protien"));
                    carb2 = reader.GetInt32(reader.GetOrdinal("Carb"));
                    mealName2 = reader.GetString(reader.GetOrdinal("MealName"));
                    mealType2 = reader.GetString(reader.GetOrdinal("MealType"));

                    // Now you have all attributes stored in variables, you can use them as needed


                }
                textBox2.Text = calories2.ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            M4 = comboBox4.Text;
            // Assuming you've opened the connection
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            // Define the SQL query to retrieve data for the meal named "Sushi"
            string query = "SELECT * FROM Meals WHERE MealName = @MealName";

            // Create a SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, conn);

            // Add a parameter for the meal name
            cmd.Parameters.AddWithValue("@MealName", M4);

            // Execute the query and get the data
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Store data in variables
                    mealID4 = reader.GetInt32(reader.GetOrdinal("MealsID"));
                    calories4 = reader.GetInt32(reader.GetOrdinal("Calories"));
                    fat4 = reader.GetInt32(reader.GetOrdinal("Fat"));
                    protein4 = reader.GetInt32(reader.GetOrdinal("Protien"));
                    carb4 = reader.GetInt32(reader.GetOrdinal("Carb"));
                    mealName4 = reader.GetString(reader.GetOrdinal("MealName"));
                    mealType4 = reader.GetString(reader.GetOrdinal("MealType"));

                    // Now you have all attributes stored in variables, you can use them as needed


                }
                textBox4.Text = calories4.ToString();

            }

        }

        public static int carb1 , carb2 , carb3 , carb4 ;
        public static string mealName1 , mealName2 , mealName3 , mealName4 ;
        public static string mealType1 , mealType2 , mealType3 , mealType4 ;  


        public TrainerDeitPlan2()
        {
            InitializeComponent();
        }

        private void TrainerDeitPlan2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;


            query = "select MealName from Meals  where MealType = 'Breakfast' ";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["MealName"].ToString());
                    
                    
                }
            }

            query = "select MealName from Meals  where MealType = 'Lunch' ";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox2.Items.Add(da["MealName"].ToString());

                }
            }


            query = "select MealName from Meals  where MealType = 'Snacks' ";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox3.Items.Add(da["MealName"].ToString());

                }
            }

            query = "select MealName from Meals  where MealType = 'Dinner' ";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox4.Items.Add(da["MealName"].ToString());

                }
            }




        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            M3 = comboBox3.Text;
            // Assuming you've opened the connection
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            // Define the SQL query to retrieve data for the meal named "Sushi"
            string query = "SELECT * FROM Meals WHERE MealName = @MealName";

            // Create a SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, conn);

            // Add a parameter for the meal name
            cmd.Parameters.AddWithValue("@MealName", M3);

            // Execute the query and get the data
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Store data in variables
                    mealID3 = reader.GetInt32(reader.GetOrdinal("MealsID"));
                    calories3 = reader.GetInt32(reader.GetOrdinal("Calories"));
                    fat3 = reader.GetInt32(reader.GetOrdinal("Fat"));
                    protein3 = reader.GetInt32(reader.GetOrdinal("Protien"));
                    carb3 = reader.GetInt32(reader.GetOrdinal("Carb"));
                    mealName3 = reader.GetString(reader.GetOrdinal("MealName"));
                    mealType3 = reader.GetString(reader.GetOrdinal("MealType"));

                    // Now you have all attributes stored in variables, you can use them as needed


                }
                textBox3.Text = calories3.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insertion karni hai

            // 1 diet plan , 
            // 4 in the MealsInDietplan 

            // Connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;";

            string query1 = "select Max (DietPlanID) from DietPlan ";

            NewDietPlanID =0 ;

            // Create and open connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand with the query
                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    // Execute the query and get the result
                    object result = cmd.ExecuteScalar();

                    // Check if the result is not null and convert it to an integer
                    if (result != DBNull.Value)
                    {
                        NewDietPlanID = Convert.ToInt32(result);
                    }
                }
            }

            NewDietPlanID += 1; 




            // SQL query to insert data
            string query = @"INSERT INTO DietPlan ( DietPlanID , PlanName, Allergens, DietType, Duration, TotalCalories, Tfat, Tprotein, Tcarb, goal, CreationDate, TrainerID, description) 
                         VALUES ( @id , @PlanName, @Allergens, @DietType, @Duration, @TotalCalories, @Tfat, @Tprotein, @Tcarb, @goal, @CreationDate, @TrainerID, @description)";

            // Sample values for insertion
            DateTime creationDate = DateTime.Now.Date;

            // Create and open connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand with parameters
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@id", NewDietPlanID);
                    cmd.Parameters.AddWithValue("@PlanName", TrianerDietPlan1.DietName );
                    cmd.Parameters.AddWithValue("@Allergens", TrianerDietPlan1.Allergens );
                    cmd.Parameters.AddWithValue("@DietType", TrianerDietPlan1.Type );
                    cmd.Parameters.AddWithValue("@Duration", TrianerDietPlan1.Dur );
                    cmd.Parameters.AddWithValue("@TotalCalories", calories1+ calories2 + calories3 + calories4);
                    cmd.Parameters.AddWithValue("@Tfat", fat1 + fat2 + fat3 + fat4 );
                    cmd.Parameters.AddWithValue("@Tprotein", protein1 + protein2 + protein3 + protein4);
                    cmd.Parameters.AddWithValue("@Tcarb", carb1 + carb2 + carb3 + carb4 );
                    cmd.Parameters.AddWithValue("@goal", TrianerDietPlan1.goal );
                    cmd.Parameters.AddWithValue("@CreationDate", creationDate);
                    cmd.Parameters.AddWithValue("@TrainerID", trainer.TrainerID);
                    cmd.Parameters.AddWithValue("@description", TrianerDietPlan1.Des);

                    // Execute query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if insertion was successful
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Diet Plan Created successfully.");
                    }
                    else
                    {
                      //  Console.WriteLine("Diet Plan creation failed.");
                    }
                }
            }

            Insert4Meals(); 


            //trainer option me jana hai
            Hide();
            using (TrainerOptionscs form2 = new TrainerOptionscs())
                form2.ShowDialog();
            Show();
        }


        private void Insert4Meals () {

            // Connection string
            string connectionString = "Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;";

            // SQL query to insert data
            string query = @"INSERT INTO MealsInDietPlan (MealsID, PlanID) 
                         VALUES (@MealsID, @PlanID)";

            
            // Create and open connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand with parameters
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@MealsID", mealID1 );
                    cmd.Parameters.AddWithValue("@PlanID", NewDietPlanID );

                    // Execute query
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
            }


            query = @"INSERT INTO MealsInDietPlan (MealsID, PlanID) 
                         VALUES (@MealsID, @PlanID)";


            // Create and open connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand with parameters
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@MealsID", mealID2);
                    cmd.Parameters.AddWithValue("@PlanID", NewDietPlanID);

                    // Execute query
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
            }

            query = @"INSERT INTO MealsInDietPlan (MealsID, PlanID) 
                         VALUES (@MealsID, @PlanID)";


            // Create and open connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand with parameters
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@MealsID", mealID3);
                    cmd.Parameters.AddWithValue("@PlanID", NewDietPlanID);

                    // Execute query
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
            }


            query = @"INSERT INTO MealsInDietPlan (MealsID, PlanID) 
                         VALUES (@MealsID, @PlanID)";


            // Create and open connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand with parameters
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@MealsID", mealID4);
                    cmd.Parameters.AddWithValue("@PlanID", NewDietPlanID);

                    // Execute query
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            M1 = comboBox1.Text; 
            // Assuming you've opened the connection
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            // Define the SQL query to retrieve data for the meal named "Sushi"
            string query = "SELECT * FROM Meals WHERE MealName = @MealName";

            // Create a SqlCommand object with the query and connection
            SqlCommand cmd = new SqlCommand(query, conn);

            // Add a parameter for the meal name
            cmd.Parameters.AddWithValue("@MealName", M1 );

            // Execute the query and get the data
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Store data in variables
                     mealID1 = reader.GetInt32(reader.GetOrdinal("MealsID"));
                     calories1 = reader.GetInt32(reader.GetOrdinal("Calories"));
                     fat1 = reader.GetInt32(reader.GetOrdinal("Fat"));
                     protein1 = reader.GetInt32(reader.GetOrdinal("Protien"));
                     carb1 = reader.GetInt32(reader.GetOrdinal("Carb"));
                     mealName1 = reader.GetString(reader.GetOrdinal("MealName"));
                     mealType1 = reader.GetString(reader.GetOrdinal("MealType"));

                    // Now you have all attributes stored in variables, you can use them as needed
                    

                }
                textBox1.Text = calories1.ToString() ; 
                

            }


        }
    }
}
