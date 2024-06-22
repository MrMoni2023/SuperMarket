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
using DGVPrinterHelper;

namespace SuperMarket
{
    public partial class NaheedSellingForm : Form
    {
        DBConnection DBconnect = new DBConnection();
        DGVPrinter Printer = new DGVPrinter();

        public NaheedSellingForm()
        {
            InitializeComponent();
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

        }
        private void GetTable()
        {
            string SelectQuerey = "Select ProductName,ProductPrice From NaheedProduct";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_productsNAH.DataSource = table;
        }
        private void GetSellTable()
        {
            string SelectQuerey = "Select *  From NaheedCustomer";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_sells_listNAH.DataSource = table;
        }
        private void NaheedSellingForm_Load(object sender, EventArgs e)
        {
            label_dateNAH.Text = DateTime.Today.ToShortDateString();
            label_sellerNAH.Text = LoginForm_Naheed_cs.NaheedSellerName;
            GetTable();
            GetCategory();
            GetSellTable();
        }

        private void DataGridView_productsNAH_Click(object sender, EventArgs e)
        {
            TextBox_nameNAH.Text = DataGridView_productsNAH.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_priceNAH.Text = DataGridView_productsNAH.SelectedRows[0].Cells[1].Value.ToString();
        }
        int GrandTotal = 0, n = 0;

        private void button_addorderNAH_Click(object sender, EventArgs e)
        {
            if (TextBox_nameNAH.Text == "" || TextBox_QtyNAH.Text == "")
            {
                MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int Total = Convert.ToInt32(TextBox_priceNAH.Text) * Convert.ToInt32(TextBox_QtyNAH.Text);
                DataGridViewRow addrow = new DataGridViewRow();
                addrow.CreateCells(DataGridView_orderNAH);
                addrow.Cells[0].Value = ++n;
                addrow.Cells[1].Value = TextBox_nameNAH.Text;
                addrow.Cells[2].Value = TextBox_priceNAH.Text;
                addrow.Cells[3].Value = TextBox_QtyNAH.Text;
                addrow.Cells[4].Value = Total;
                DataGridView_orderNAH.Rows.Add(addrow);
                GrandTotal += Total;
                label_AmounNAH.Text = " Rs  " + GrandTotal;
            }
        }

        private void imtaizbutton_printNAH_Click(object sender, EventArgs e)
        {
            //Using DGVpirinter Help for Printing with Pdf File
            Printer.Title = "Multi Vender SuperMarket List";
            Printer.SubTitle = String.Format("Date : {0}", DateTime.Now);
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = true;
            Printer.HeaderCellAlignment = StringAlignment.Near;
            Printer.Footer = "PAF KIET";
            Printer.FooterSpacing = 15;
            Printer.printDocument.DefaultPageSettings.Landscape = true;
            Printer.PrintDataGridView(DataGridView_sells_listNAH);
        }

        private void NAHcomboBox_categories_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string SelectQuerey = "Select ProductName,ProductPrice From ImtiazProduct WHERE ProductCat = '" + NAHcomboBox_categories.SelectedValue.ToString() + "'";
            SqlCommand Command = new SqlCommand(SelectQuerey, DBconnect.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_productsNAH.DataSource = table;
        }

        private void button_addNAH_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertQuerey = "INSERT INTO NaheedCustomer VALUES (" + TextBox_idNAH.Text + ",'" + label_sellerNAH.Text + "','" + label_dateNAH.Text + "','" + GrandTotal.ToString() + "' )";
                SqlCommand Command = new SqlCommand(InsertQuerey, DBconnect.GetCon());
                DBconnect.OpenCon();
                Command.ExecuteNonQuery();
                MessageBox.Show("Order ADDED Successfully", " Order information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBconnect.Closecon();
                GetSellTable();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label_exit_NAH_MouseEnter(object sender, EventArgs e)
        {
            label_exit_NAH.ForeColor = Color.AliceBlue;
        }

        private void label_exit_NAH_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logout_imt_MouseEnter(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor = Color.AliceBlue;
        }

        private void label_logout_imt_Click(object sender, EventArgs e)
        {
            LoginForm_Naheed_cs loginForm_ = new LoginForm_Naheed_cs();
            loginForm_.Show();
            this.Hide();
        }

        private void label_exit_NAH_MouseLeave(object sender, EventArgs e)
        {
            label_exit_NAH.ForeColor = Color.Crimson;
        }

        private void label_logout_imt_MouseLeave(object sender, EventArgs e)
        {
            label_logout_imt.ForeColor= Color.Crimson;  
        }

        private void NAHbutton_selling_Click(object sender, EventArgs e)
        {
            NaheedCategoryForm form = new NaheedCategoryForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_product_Click(object sender, EventArgs e)
        {
            NaheedProductForm form = new NaheedProductForm();
            form.Show();
            this.Hide();
        }

        private void NAHbutton_seller_Click(object sender, EventArgs e)
        {
            NaheedSellerForm form = new NaheedSellerForm();
            form.Show();
            this.Hide();

        }

        private void NAHcomboBox_categories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_refreshNAH_Click(object sender, EventArgs e)
        {
            GetTable();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox_nameNAH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
