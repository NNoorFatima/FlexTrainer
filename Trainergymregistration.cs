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
    public partial class Trainergymregistration : Form
    {

        public static string gym;
        public static string MainTrainer; 
        public Trainergymregistration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gym = comboBox1.Text;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();

            SqlCommand cm;
            string query;
            query = "select username , Email ,Location  from owners o Join Gym g on g.OwnerId = o.Ownerid where g.GymId = @id ";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@id", gym);

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader reader = cm.ExecuteReader())
            {
                if (reader.Read()) // Check if there's data to read
                {
                    // Read values from the reader and set them to text boxes
                    textBox2.Text = reader.GetString(0); // Assuming username is a string
                    textBox4.Text = reader.GetString(1); // Assuming Email is a string
                    textBox1.Text = reader.GetString(2); // Assuming Location is a string
                }
            }

            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Trainergymregistration_Load(object sender, EventArgs e)
        {
            MainTrainer = trainer.TrainerID;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;
            query = "select distinct(g.gymid) from gym g join worksin w on g.gymid = w.gymid and w.trainerid <> @MainTrainer; ";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@MainTrainer", trainer.TrainerID);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["gymid"].ToString());
                }
            }

            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();



            SqlCommand cm;
            string query = "";
            string OwnID = ""; 
            query = " Select OwnerId from Gym where GymId = @gymid ";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@gymid  ", gym );

            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                     OwnID = da.GetValue (0).ToString () ;
                    break; 
                }
            }




            query = "insert into Approval values  (@TrID , @OwnID  , @gID ) ";

            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@TrID", trainer.TrainerID);
            cm.Parameters.AddWithValue("@OwnID", OwnID);
            cm.Parameters.AddWithValue("@gID"  , gym );



            cm.ExecuteNonQuery();

            conn.Dispose(); conn.Close(); 



            MessageBox.Show("Insertion");
            Hide();
            using ( TrainerOptionscs form2 = new TrainerOptionscs())
                form2.ShowDialog();
            Show();
        }
    }
}
