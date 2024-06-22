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
    
    public partial class ImtiazSellerForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        public ImtiazSellerForm()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void GetTable()
        {
            string SelectQuerey = "Select * From ImtiazSeller";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_seller.DataSource = table;
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
                string InsertQuerey = "INSERT INTO ImtiazSeller VALUES ("+TextBox_id.Text+",'" + TextBox_name.Text + "','" + TextBox_age.Text + "','" + TextBox_phone.Text + "','" + TextBox_pass.Text + "' )";
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

        private void ImtiazSellerForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void label_logout_imt_MouseEnter(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor = Color.Red;
        }

        private void label_logout_imt_MouseLeave(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor = Color.CadetBlue;
        }

        private void label_exit_imt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logout_imt_Click(object sender, EventArgs e)
        {
            UIForm form = new UIForm();
            form.Show();
            this.Hide();
        }

        private void label_exit_imt_MouseEnter(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Red;
        }

        private void label_exit_imt_MouseLeave(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.CadetBlue;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (  TextBox_id.Text == "" ||TextBox_name.Text == "" || TextBox_age.Text == "" || TextBox_phone.Text == "" || TextBox_pass.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string UpdateQuerey = "UPDATE ImtiazSeller SET  SellerName = '" + TextBox_name.Text + "',SellerAge = '" + TextBox_age.Text + "',SellerPhone = '" + TextBox_phone.Text + "',SellerPass = '" + TextBox_pass.Text + "' WHERE SellerId = '" + TextBox_id.Text + "'";
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
        //display the value into the textbox when we click on to the flieds
        private void DataGridView_seller_Click(object sender, EventArgs e)
        {
            TextBox_id.Text = DataGridView_seller.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = DataGridView_seller.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_age.Text= DataGridView_seller.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_phone.Text = DataGridView_seller.SelectedRows[0].Cells[3].Value.ToString();
            TextBox_pass.Text = DataGridView_seller.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void imtaizbutton_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                        string DeleteQuery = "DELETE FROM ImtiazSeller WHERE SellerId = " + TextBox_id.Text + "";
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

        private void imtiazbutton_product_Click(object sender, EventArgs e)
        {
            ImtiazProductForm form = new ImtiazProductForm();
            form.Show();
            this.Hide();
        }

        private void imtiazbutton_category_Click(object sender, EventArgs e)
        {
            ImtiazCategoryForm form = new ImtiazCategoryForm();
            form.Show();
            this.Hide();
        }

        private void imtiazbutton_selling_Click(object sender, EventArgs e)
        {
            ImtiazSellingForm form = new ImtiazSellingForm();
            form.Show();
            this.Hide();
        }
    }
}
