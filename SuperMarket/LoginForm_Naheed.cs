using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SuperMarket
{
    public partial class LoginForm_Naheed_cs : Form
    {
        DBConnection DBconnect = new DBConnection();
        public static string NaheedSellerName;
        public LoginForm_Naheed_cs()
        {
            InitializeComponent();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.AliceBlue;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DarkRed;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
        }

        private void textBox_userName_TextChanged(object sender, EventArgs e)
        {
            textBox_userName.BackColor = Color.White;
            panel_userName_imt.BackColor = Color.White;
            panel_password_imt.BackColor = SystemColors.Control;
            textBox_password.BackColor = SystemColors.Control;
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            textBox_password.BackColor = Color.White;
            panel_password_imt.BackColor = Color.White;
            panel_userName_imt.BackColor = SystemColors.Control;
            textBox_userName.BackColor = SystemColors.Control;
        }

        private void Button_home_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox_userName.Text == "" && textBox_password.Text == "")
            {
                MessageBox.Show("Please enter Missing Information", "Misiing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox_role_naheed.SelectedIndex > -1)
                {
                    if (comboBox_role_naheed.SelectedItem.ToString() == "ADMIN")
                    {
                        if (textBox_userName.Text == "Naheed" || textBox_password.Text == "Naheed123")
                        {
                            NaheedProductForm form = new NaheedProductForm();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are Admin enter correct ID and Password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string selectQuery = "SELECT * FROM NaheedSeller WHERE SellerName = '" + textBox_userName.Text + "' AND SellerPass = '" + textBox_password.Text + "'";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, DBconnect.GetCon());
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            NaheedSellerName = textBox_userName.Text;
                            NaheedSellingForm form = new NaheedSellingForm();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username Or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Slect Role", "Wrong information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void imtiazbutton_seller_Click(object sender, EventArgs e)
        {
            NaheedRegisterForm form = new NaheedRegisterForm();
            form.Show();
            this.Hide();
        }

        private void LoginForm_Naheed_cs_Load(object sender, EventArgs e)
        {

        }

        private void label_clear_Click(object sender, EventArgs e)
        {
            textBox_userName.Clear();
            textBox_password.Clear();
        }

        private void label_clear_MouseHover(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Black;
        }
    }
}
