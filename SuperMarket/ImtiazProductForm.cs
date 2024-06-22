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
    public partial class ImtiazProductForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        public ImtiazProductForm()
        {
            InitializeComponent();
        }

        private void Imtaiz_ProductPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imtiazTextBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void imtiazTextBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void imtiazTextBox_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void imtiazTextBox_quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_exit_imt_MouseLeave(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.CadetBlue;
        }

        private void label_exit_imt_MouseEnter(object sender, EventArgs e)
        {
            label_exit_imt.ForeColor = Color.Red;
        }

        private void label_exit_imt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logout_imt_MouseEnter(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor= Color.Red;  
        }

        private void label_logout_imt_MouseLeave(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor = Color.CadetBlue;
        }

        private void label_logout_imt_Click(object sender, EventArgs e)
        {
            UIForm Ui = new UIForm();
            Ui.Show();
            this.Hide();

        }

        private void imtiazbutton_category_Click(object sender, EventArgs e)
        {
            ImtiazCategoryForm category = new ImtiazCategoryForm();
            category.Show();
            this.Hide();
        }
        private void GetCategory()
        {

            string SelectQuerey = "Select * From ImtiazCategory";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
           ImtiazcomboBox_categories.DataSource = table;
            ImtiazcomboBox_categories.ValueMember = "CategoryName"; //name
            ImtiazcomboBox_search.DataSource = table;
            ImtiazcomboBox_search.ValueMember = "CategoryName"; //name
        }

        private void ImtiazProductForm_Load(object sender, EventArgs e)
        {
            GetCategory();
            GetTable();
        }
        private void GetTable()
        {
            string SelectQuerey = "Select * From ImtiazProduct";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }
        private void Clear()
        {
           TextBox_id.Clear();
            TextBox_name.Clear();
            TextBox_price.Clear();
            TextBox_Qty.Clear();
            ImtiazcomboBox_categories.SelectedIndex = 0;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuerey = "INSERT INTO ImtiazProduct VALUES ("+TextBox_id.Text+",'" + TextBox_name.Text + "','" + TextBox_price.Text + "','" + TextBox_Qty.Text + "','" + ImtiazcomboBox_categories.Text + "' )";
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

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "" || TextBox_name.Text == "" || TextBox_price.Text == "" || TextBox_Qty.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string UpdateQuerey = "UPDATE ImtiazProduct SET ProductName = '"+TextBox_name.Text+"', ProductPrice = '" + TextBox_price.Text + "',ProductQty = '" + TextBox_Qty.Text + "',ProductCat = '" + ImtiazcomboBox_categories.Text + "' WHERE ProductId = '" + TextBox_id.Text + "'";
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

        private void DataGridView_product_Click(object sender, EventArgs e)
        {
           TextBox_id.Text = DataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = DataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_price.Text = DataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_Qty.Text = DataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
            ImtiazcomboBox_categories.SelectedValue = DataGridView_product.SelectedRows[0].Cells[4].Value.ToString();
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
                    string DeleteQuery = "DELETE FROM ImtiazProduct WHERE ProductId = " + TextBox_id.Text + "";
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

        private void imtiazbutton_refresh_Click(object sender, EventArgs e)
        {
            //view whole table data
            GetTable();
        }

        private void ImtiazcomboBox_search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string SelectQuerey = "Select * From ImtiazProduct WHERE ProductCat = '"+ImtiazcomboBox_search.SelectedValue.ToString()+"'";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }

        private void imtiazbutton_seller_Click(object sender, EventArgs e)
        {
            ImtiazSellerForm sellerForm = new ImtiazSellerForm();
            sellerForm.Show();
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
