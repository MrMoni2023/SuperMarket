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
    public partial class NaheedProductForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        public NaheedProductForm()
        {
            InitializeComponent();
        }

        private void NaheedProductForm_Load(object sender, EventArgs e)
        {
            GetCategory();
            GetTable(); 
        }
        private void GetCategory()
        {

            string SelectQuerey = "Select * From NaheedCategory";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            NAHcomboBox_categories.DataSource = table;
            NAHcomboBox_categories.ValueMember = "CategoryName";
            NAHcomboBox_search.DataSource = table;
            NAHcomboBox_search.ValueMember = "CategoryName";
        }
        private void GetTable()
        {
            string SelectQuerey = "Select * From NaheedProduct";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            NAHDataGridView_product.DataSource = table;
        }
        private void Clear()
        {
            TextBox_id.Clear();
            NAHTextBox_name.Clear();
            NAHTextBox_price.Clear();
            NAHTextBox_Qty.Clear();
            NAHcomboBox_categories.SelectedIndex = 0;
        }

        private void NAHbutton_add_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuerey = "INSERT INTO NaheedProduct VALUES ("+TextBox_id.Text+",'" + NAHTextBox_name.Text + "','" + NAHTextBox_price.Text + "','" + NAHTextBox_Qty.Text + "','" + NAHcomboBox_categories.Text + "' )";
                SqlCommand Command = new SqlCommand(InsertQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Product ADDED Successfully", "Added information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetTable();
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void NAHDataGridView_product_Click(object sender, EventArgs e)
        {

            TextBox_id.Text = NAHDataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            NAHTextBox_name.Text = NAHDataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            NAHTextBox_price.Text = NAHDataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            NAHTextBox_Qty.Text = NAHDataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
            NAHcomboBox_categories.SelectedValue = NAHDataGridView_product.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void NAHbutton_update_Click(object sender, EventArgs e)
        {

            try
            {
                if (TextBox_id.Text == "" || NAHTextBox_name.Text == "" || NAHTextBox_price.Text == "" || NAHTextBox_Qty.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string UpdateQuerey = "UPDATE NaheedProduct SET ProductName = '" + NAHTextBox_name.Text + "', ProductPrice = '" + NAHTextBox_price.Text + "',ProductQty = '" + NAHTextBox_Qty.Text + "',ProductCat = '" + NAHcomboBox_categories.Text + "' WHERE ProductId = '" + TextBox_id.Text + "'";
                    SqlCommand Command = new SqlCommand(UpdateQuerey, DBconnect.GetCon());
                    DBconnect.OpenCon();
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void NAHbutton_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string DeleteQuery = "DELETE FROM NaheedProduct WHERE ProductId = " + TextBox_id.Text + "";
                    SqlCommand Command = new SqlCommand(DeleteQuery, DBconnect.GetCon());
                    DBconnect.OpenCon();
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void NAHbutton_refresh_Click(object sender, EventArgs e)
        {
            GetTable();
        }

        private void NAHcomboBox_search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string SelectQuerey = "Select * From NaheedProduct WHERE ProductCat = '" + NAHcomboBox_search.SelectedValue.ToString() + "'";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            NAHDataGridView_product.DataSource = table;
        }

        private void NAHbutton_category_Click(object sender, EventArgs e)
        {
            NaheedCategoryForm form = new NaheedCategoryForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_selling_Click(object sender, EventArgs e)
        {
            NaheedSellingForm form = new NaheedSellingForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_seller_Click(object sender, EventArgs e)
        {
            NaheedSellerForm form = new NaheedSellerForm();
            form.Show();
            this.Hide();
        }

        private void label_exit_imt_MouseEnter(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.AliceBlue;
        }

        private void label_exit_imt_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void label_logout_NAH_MouseEnter(object sender, EventArgs e)
        {
            label_logout_NAH.ForeColor = Color.AliceBlue;
        }

        private void label_logout_NAH_Click(object sender, EventArgs e)
        {
            LoginForm_Naheed_cs loginForm_ = new LoginForm_Naheed_cs();
            loginForm_.Show();
            this.Hide();
        }

        private void label_exit_imt_MouseLeave(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Crimson;
        }

        private void label_logout_NAH_MouseLeave(object sender, EventArgs e)
        {
            label_logout_NAH.ForeColor = Color.Crimson;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
