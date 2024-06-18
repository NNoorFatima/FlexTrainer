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
    public partial class MemberRegistration1 : Form
    {

        public static string userName ; 
        public static string em ; 
        public static int MemType =0; 
        public static string password ; 
                        

        public MemberRegistration1()
        {
            InitializeComponent();
        }

        private void MemberRegistration_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                    }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (MembernewLogin form2 = new MembernewLogin())
                form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C55UT4H\\SQLEXPRESS;Initial Catalog=ProjectData;Integrated Security=True;");
            conn.Open();


            SqlCommand cm;

            em = textBox3.Text;
            userName = textBox1.Text;
            password = textBox2.Text;
            em = textBox3.Text;
            if (textBox5.Text != "")
            MemType = int .Parse (textBox5.Text) ;

            if (em != "" && userName != "" && password != "" && MemType != 0)
            {

                string query;
                query = "select count (*) from Members where Email = @email";
                cm = new SqlCommand(query, conn);

                cm.Parameters.AddWithValue("@email", em);

                int count = (int)cm.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Email already in use.");

                }


                else
                {

                    Hide();
                    using (MemberRegistration2 form2 = new MemberRegistration2())
                        form2.ShowDialog();
                    Show();

                }
            }
            else {

                MessageBox.Show("Fill all Boxes"); 
            }


            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
