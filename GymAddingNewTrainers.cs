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

    public partial class GymAddingNewTrainers : Form
    {
        public static string TrainerID = "";
        public static string GymID = "";


        public GymAddingNewTrainers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add into Worksin table plus delete from Approval table.

            // get from approval table gym id 
           // GymID = Trainergymregistration.gym ;





            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;


            query = "select GymId from Approval where trainerID = @Tid and  OwnerID = @oID  ";

            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@Tid", TrainerID);
            cm.Parameters.AddWithValue("@oID", GymLogin.OwnerId);

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {


                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    GymID = da.GetValue(0).ToString(); 
                    break;

                }
            }






            query = "insert into Worksin values ( @Tid , @gID , @oID ) ";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@Tid", TrainerID);
            cm.Parameters.AddWithValue("@gID", GymID );
            cm.Parameters.AddWithValue("@oID", GymLogin.OwnerId );
            cm.ExecuteNonQuery();

            // now delete


            query = "delete from Approval where trainerID =  @Tid and GymID =  @gID and OwnerID =  @oID  ";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@Tid", TrainerID);
            cm.Parameters.AddWithValue("@gID", GymID);
            cm.Parameters.AddWithValue("@oID", GymLogin.OwnerId);
            cm.ExecuteNonQuery();




            Hide();
            using (GymOwner form2 = new GymOwner())
                form2.ShowDialog();
            Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // just delete from Approval table. 

           // GymID = Trainergymregistration.gym;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;

            query = "select GymId from Approval where trainerID = @Tid and  OwnerID = @oID  ";

            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@Tid", TrainerID);
            cm.Parameters.AddWithValue("@oID", GymLogin.OwnerId);

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {


                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    GymID = da.GetValue(0).ToString();
                    break;

                }
            }


            // now delete


            query = "delete from Approval where trainerID =  @Tid and GymID =  @gID and OwnerID =  @oID  ";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@Tid", TrainerID);
            cm.Parameters.AddWithValue("@gID", GymID);
            cm.Parameters.AddWithValue("@oID", GymLogin.OwnerId);
            cm.ExecuteNonQuery();



            Hide();
            using (GymOwner form2 = new GymOwner())
                form2.ShowDialog();
            Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrainerID = comboBox1.Text ;




            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;


            query = "select userName , Specialization , Experience from trainer where TrainerId = @id ";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@id", TrainerID );



            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                

                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    textBox1.Text = da.GetValue(0).ToString();
                    textBox3.Text = da.GetValue(1).ToString();
                    textBox2.Text = da.GetValue(2).ToString();

                    break; 

                }
            }



        }

        private void GymAddingNewTrainers_Load(object sender, EventArgs e)
        {
            // load options of trainer which has send requests 


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;


            query = "select distinct(TrainerID) from Approval where OwnerID = @id ";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue( "@id"  , GymLogin.OwnerId  ); 



            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["TrainerID"].ToString());



                }

            }


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
    }
}
