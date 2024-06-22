using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace SuperMarket
{
    public partial class UIForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        public static string SellerName;
        public UIForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            textBox_imtiaz_password.UseSystemPasswordChar = false;
        }

        private void label_imtiaz_clear_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void label_imtiaz_clear_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            textBox_imtiaz_userName.Clear();
            textBox_imtiaz_password.Clear();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox_imtiaz_userName.BackColor = Color.White;
            panel_userName_imt.BackColor = Color.White;
            panel_password_imt.BackColor = SystemColors.Control;
            textBox_imtiaz_password.BackColor = SystemColors.Control;
        }

        private void textBox_imtiaz_password_TextChanged(object sender, EventArgs e)
        {
            textBox_imtiaz_password.BackColor = Color.White;
            panel_password_imt.BackColor = Color.White;
            panel_userName_imt.BackColor= SystemColors.Control;
            textBox_imtiaz_userName.BackColor = SystemColors.Control;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Red;
        }

        private void label_exit_imt_MouseLeave(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Navy;
        }

        private void label_clear_imt_MouseEnter(object sender, EventArgs e)
        {
            label_clear_imt.ForeColor = Color.Red;
        }

        private void label_clear_imt_MouseLeave(object sender, EventArgs e)
        {
            label_clear_imt.ForeColor= Color.Navy;
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            textBox_imtiaz_password.UseSystemPasswordChar = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox_imtiaz_userName.Text == "" && textBox_imtiaz_password.Text == "")
            {
                MessageBox.Show("Please enter Missing Information", "Misiing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox_role.SelectedIndex > -1)
                {
                    if (comboBox_role.SelectedItem.ToString() == "ADMIN")
                    {
                        if (textBox_imtiaz_userName.Text == "Imtiaz" || textBox_imtiaz_password.Text == "Imtiaz123")
                        {
                            ImtiazProductForm form = new ImtiazProductForm();
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
                        string selectQuery = "SELECT * FROM ImtiazSeller WHERE SellerName = '" + textBox_imtiaz_userName.Text + "' AND SellerPass = '" + textBox_imtiaz_password.Text + "'";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, DBconnect.GetCon());
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            SellerName = textBox_imtiaz_userName.Text;
                            ImtiazSellingForm form = new ImtiazSellingForm();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void UIForm_Load(object sender, EventArgs e)
        {

        }

        private void imtiazbutton_seller_Click(object sender, EventArgs e)
        {
            ImtiazRegisterForm sellingForm = new ImtiazRegisterForm();    
            sellingForm.Show();
            this.Hide();
        }

        private void label_clear_imt_MouseHover(object sender, EventArgs e)
        {
            label_clear_imt.ForeColor = Color.Black;
        }
    }
}
