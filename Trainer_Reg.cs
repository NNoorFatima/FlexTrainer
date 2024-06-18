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
    public partial class Trainer_Reg : Form
    {
        public static string username;
        public static string Password;
        public static string email;
        public static string certi;
        public static string speci;
        public static string regiss_date;
        public static string exp;
        public Trainer_Reg()
        {
            InitializeComponent();
        }

        private void Trainer_Reg_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();
            using (TrainerOptionscs form2 = new TrainerOptionscs())
                form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (trainer form2 = new trainer())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;
            string query;
            query = "SELECT  MAX(CAST(RIGHT(TrainerID, 3) AS INT)) + 1 FROM Trainer WHERE TrainerID LIKE '%-%'";


            string tempid = "";
            cm = new SqlCommand(query, conn);



            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    tempid = da.GetValue(0).ToString();
                    break;
                }
            }

            // MessageBox.Show(tempid);

            query = "SELECT CONCAT('22t-', RIGHT('00' + CAST(@NextID AS NVARCHAR(3)), 3))";
            string Insertid = "";
            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@Nextid", tempid);

            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    Insertid = da.GetValue(0).ToString();
                    break;
                }
            }

            // this is intentional ( Donot remove it )
            MessageBox.Show( "Your Id is : "+ Insertid);
            // phele add data in database 
            username = textBox1.Text;
            Password = textBox2.Text;
            email = textBox3.Text;
            certi = textBox4.Text;
            speci = textBox5.Text;
            DateTime creationDate = DateTime.Now.Date;

            regiss_date = "";
            exp = textBox7.Text;
            string insertQuery = "INSERT INTO trainer (TrainerID, Username, Trainer_Password, Email, Reg_date, Certification, Specialization, Experience) " +
                              "VALUES (@TrainerID, @Username, @Password, @Email, @Reg_date, @Certification, @Specilization, @Experience)";
            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
            insertCmd.Parameters.AddWithValue("@TrainerID", Insertid);
            insertCmd.Parameters.AddWithValue("@Username", textBox1.Text);
            insertCmd.Parameters.AddWithValue("@Password", textBox2.Text);
            insertCmd.Parameters.AddWithValue("@Email", textBox3.Text);
            insertCmd.Parameters.AddWithValue("@Certification", textBox4.Text);
            insertCmd.Parameters.AddWithValue("@Specilization", textBox5.Text);
            insertCmd.Parameters.AddWithValue("@Reg_date", creationDate); 
            insertCmd.Parameters.AddWithValue("@Experience", textBox7.Text);
            insertCmd.ExecuteNonQuery();
            insertCmd.Dispose();

            conn.Close();
            Hide();
            using (TrainerOptionscs form2 = new TrainerOptionscs())
                form2.ShowDialog();
            Show();
        }
    }
}
