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
    public partial class MemberRegistration2 : Form
    {

        // from reg form1 
        public static string userName;
        public static string em;
        public static int MemType;
        public static string password;

        // its own 
        public static string healthCond ;
        public static string goal ;
        public static string gymid;
        public static string startDate ;




        public MemberRegistration2()
        {
            InitializeComponent();
        }

        private void MemberRegistration2_Load(object sender, EventArgs e)
        {
            // adding all the avaliable gym ids in the drop down box ( combo box )
            /*comboBox1.Items.Add("Noor is i dont know ");
            comboBox1.Items.Add("Sara is saba ");
             */

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm; 
            string query;


            query = "select count(*) from Gym";
            cm = new SqlCommand(query, conn);
            int count = (int)cm.ExecuteScalar();
            


            query = "select GymID from Gym";
            cm = new SqlCommand(query, conn);


            // ExecuteReader reads data forward-only from the query
            using (SqlDataReader da = cm.ExecuteReader())
            {
                // Loop through the SqlDataReader to populate the comboBox
                while (da.Read())
                {
                    // Add GymID to the comboBox
                    comboBox1.Items.Add(da["GymID"].ToString());
                }
            }

            conn.Close();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = MemberRegistration1.userName;
            password = MemberRegistration1.password;
            em = MemberRegistration1.em;
            MemType = MemberRegistration1.MemType;

         // its own 
         healthCond = textBox1.Text ;
         goal = textBox2.Text;
         gymid= comboBox1.Text;
         startDate = textBox6.Text ;


            if (healthCond != "" && goal != "" && gymid != "" && startDate != "") {


                // genernate id and first show it to him 
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
                conn.Open();


                SqlCommand cm;
                string query;
                query = "SELECT  MAX(CAST(RIGHT(MemberID, 3) AS INT)) + 1 FROM Members WHERE MemberID LIKE '%-%'";


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

                query = "SELECT CONCAT('22m-', RIGHT('00' + CAST(@NextID AS NVARCHAR(3)), 3))";
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

                MessageBox.Show("Your Login ID is : " + Insertid);


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

                // MessageBox.Show(Today);

                query = "insert into Members values ( @MemID , @GymID , @Goal , @Type , @cond , @Status , @name , @pass , @email , @RegDate , @startDate )";
                cm = new SqlCommand(query, conn);

                cm.Parameters.AddWithValue("@MemID", Insertid);
                cm.Parameters.AddWithValue("@GymID", gymid);
                cm.Parameters.AddWithValue("@Goal", goal);
                cm.Parameters.AddWithValue("@Type", MemType);
                cm.Parameters.AddWithValue("@cond", healthCond);

                cm.Parameters.AddWithValue("@Status", "Approved");
                cm.Parameters.AddWithValue("@name", userName);
                cm.Parameters.AddWithValue("@pass", password);
                cm.Parameters.AddWithValue("@email", em);
                cm.Parameters.AddWithValue("@RegDate", Today);
                cm.Parameters.AddWithValue("@startDate", startDate);


                MessageBox.Show("Registration Succcesfull, you will now move to Login Page");
                cm.ExecuteNonQuery();
                conn.Dispose();
                conn.Close();

                // member created now login kro. 

                Hide(); 
                using (MembernewLogin form2 = new MembernewLogin())
                    form2.ShowDialog();
                Show();

            }
            else
            {

                MessageBox.Show("Fill all Boxes");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }
    }
}
