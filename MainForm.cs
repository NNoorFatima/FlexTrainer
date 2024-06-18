using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Trainer":
                    Hide();
                    using (Trainer_Reg form2 = new Trainer_Reg())
                        form2.ShowDialog();
                    Show();
                    break;
                case "Member":
                    Hide();
                    using (MemberRegistration1 form2 = new MemberRegistration1())
                        form2.ShowDialog();
                    Show();
                    break;
                case "Admin":
                    Hide();
                    using (adminlogin form2 = new adminlogin())
                        form2.ShowDialog();
                    Show();
                    break;
                case "Owner":
                    Hide();
                    using (Gymregistration form2 = new Gymregistration())
                        form2.ShowDialog();
                    Show();
                    break;
                case "Code Dumped":

                    Hide();
                    using (CodeDumped form2 = new CodeDumped())
                        form2.ShowDialog();
                    Show();
                    break;



            }
        }
    }
}
