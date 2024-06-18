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
    public partial class MemberTrainerFeedback : Form
    {
        public static string MemberID = "";
        public static string TrainerID = "";

        public MemberTrainerFeedback()
        {
            InitializeComponent();
        }

        private void MemberTrainerFeedback_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(1);
            comboBox1.Items.Add(2);
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.Items.Add(5);

            // combo box 2 = show trainers. 
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;"))
            {
                conn.Open();

                // MessageBox.Show(gymID); 
                MemberID = MembernewLogin.MemberID;

                // Create SqlCommand
                using (SqlCommand cm = new SqlCommand("SELECT TrainerID FROM appointments WHERE MemberID = @id", conn))
                {
                    // Add parameter for GymID
                    cm.Parameters.AddWithValue("@id", MemberID);

                    // Execute the query and retrieve TrainerID
                    using (SqlDataReader da = cm.ExecuteReader())
                    {
                        // Loop through the SqlDataReader to populate the comboBox
                        while (da.Read())
                        {
                            // Add TrainerID to the comboBox
                            comboBox2.Items.Add(da["TrainerID"].ToString());
                        }
                    }
                }




            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;
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

            query = "select Max (FeedbackID) from Feedback ";

            cm = new SqlCommand(query, conn);
            int NewId = 0; 

            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    NewId= da.GetInt32(0);
                    break;
                }
            }
            NewId += 1; 


            if ( comboBox3.Text != "" && comboBox2.Text != "" && comboBox1.Text != "") {

                // insert the data.
                // 2 is the id , 1 is the rating(int) , 3 is the comment 

                query = "insert into feedback values (@fdID , @MemID , @TrID , @rate , @date , @comm )";
                cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@fdID" , NewId);
                cm.Parameters.AddWithValue("@MemID", MembernewLogin.MemberID  );
                cm.Parameters.AddWithValue("@TrID",  comboBox2.Text  );
                cm.Parameters.AddWithValue("@rate", comboBox1.Text );
                cm.Parameters.AddWithValue("@date", Today );
                cm.Parameters.AddWithValue("@comm", comboBox3.Text );



                cm.ExecuteNonQuery();
                conn.Close(); 

                Hide();
                using ( MemberOptions form2 = new MemberOptions())
                    form2.ShowDialog();
                Show();

                

            }
            else {
                MessageBox.Show("Fill all the boxes."); 
            } 
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rt = int.Parse(comboBox1.Text);
            comboBox3.Items.Clear(); // Clear existing items

            if (rt > 3  ) {
                // good
                // Nice , Excellent
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Nice");
                comboBox3.Items.Add("Excellent");

            }
            else if (rt == 3) {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Average");  
            }
            else if (rt <3 )
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Strongly Dissatisfied");
                comboBox3.Items.Add("Bad");
                

            }




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            /// label 7 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            TrainerID = comboBox2.Text;



            SqlCommand cm;
            string query;


            query = "select UserName from Trainer where TrainerId = @id";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@id", TrainerID);
            SqlDataReader da2 = cm.ExecuteReader();

            while (da2.Read())
            {
                // MessageBox.Show(da2.GetValue(0).ToString() );
                label7.Text = da2.GetValue(0).ToString();
                break;
            }

            conn.Close();


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
