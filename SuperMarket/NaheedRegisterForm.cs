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
    public partial class NaheedRegisterForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        public NaheedRegisterForm()
        {
            InitializeComponent();
        }
        private void GetTable()
        {
            string SelectQuerey = "Select * From NaheedSeller";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
           
        }
        private void Clear()
        {
            TextBox_id.Clear();
            TextBox_name.Clear();
            TextBox_age.Clear();
            TextBox_phone.Clear();
            TextBox_pass.Clear();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuerey = "INSERT INTO NaheedSeller VALUES (" + TextBox_id.Text + ",'" + TextBox_name.Text + "','" + TextBox_age.Text + "','" + TextBox_phone.Text + "','" + TextBox_pass.Text + "' )";
                SqlCommand Command = new SqlCommand(InsertQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Seller ADDED Successfully", "Added information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable();
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "" || TextBox_name.Text == "" || TextBox_age.Text == "" || TextBox_phone.Text == "" || TextBox_pass.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string UpdateQuerey = "UPDATE NaheedSeller SET SellerName = '" + TextBox_name.Text + "',SellerAge = '" + TextBox_age.Text + "',SellerPhone = '" + TextBox_phone.Text + "',SellerPass = '" + TextBox_pass.Text + "' WHERE SellerId = '" + TextBox_id.Text + "'";
                    SqlCommand Command = new SqlCommand(UpdateQuerey, DBconnect.GetCon());
                    DBconnect.OpenCon();
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Seller  Updated Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBconnect.Closecon();
                    GetTable();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string DeleteQuery = "DELETE FROM NaheedSeller WHERE SellerId = " + TextBox_id.Text + "";
                    SqlCommand Command = new SqlCommand(DeleteQuery, DBconnect.GetCon());
                    DBconnect.OpenCon();
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBconnect.Closecon();
                    GetTable();
                    Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


    
    

        private void DataGridView_seller_Click(object sender, EventArgs e)
        {

           
        }

        private void label_exit_Imtiaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_back_imt_Click(object sender, EventArgs e)
        {
            LoginForm_Naheed_cs loginForm = new LoginForm_Naheed_cs();
            loginForm.Show();
            this.Hide();
        }

        private void NaheedRegisterForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void label_exit_Imtiaz_MouseEnter(object sender, EventArgs e)
        {
            label_exit_Imtiaz.ForeColor = Color.AliceBlue;
        }

        private void label_exit_Imtiaz_MouseLeave(object sender, EventArgs e)
        {
            label_exit_Imtiaz.ForeColor = Color.Crimson;
        }

        private void label_back_imt_MouseEnter(object sender, EventArgs e)
        {
            label_back_imt.ForeColor = Color.AliceBlue;
        }

        private void label_back_imt_MouseLeave(object sender, EventArgs e)
        {
            label_back_imt.ForeColor = Color.Crimson;
        }
    }
}
