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

namespace project
{
    public partial class Main : Form
    {

        //private const string CONNSTRING = "Data Source=HUNAIN-PC\\MSSQLSERVER;Initial Catalog = DBproject; Integrated Security = True;";
        private const string con = "Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True";


            private const string qryGetAllstock = "select * from stock Where Lot# = '{0}' and name = '{1}'";
        private const string qryGetAllstock1 = "select * from stock Where Lot# = '{0}'";
        private const string qryGetAllstock2 = "select * from stock Where name = '{0}'";
        private const string qryGetAllstock3 = "select * from stock";
        private const string qryGetAllCustomers = "Select * From Customers";
        private const string qryGetAllCustomers1 = "Select * From Customers Where idcustomers = '{0}'";
        private const string qryGetAllCustomers2 = "Select * From Customers Where name = '{0}'";

        private const string qryGetAllCustomers3 = "select distinct cu.idcustomers from customers cu, purchase p where cu.idcustomers = p.customers_idcustomers and amount > paid";
        //private const string qryGetAllCustomers4 = "select distinct cu.idcustomers from customers cu, purchase p where cu.idcustomers = '{0}' and cu.idcustomers = p.customers_idcustomers and amount > paid";
        //private const string qryGetAllCustomers5 = "select distinct cu.idcustomers from customers cu, purchase p where cu.Name = '{0}' and cu.idcustomers = p.customers_idcustomers and amount > paid";

        private const string qryGetAllCustomers6 = "select distinct cu.idcustomers from customers cu, sale s where cu.idcustomers = s.customers_idcustomers and amount > paid";
        //private const string qryGetAllCustomers7 = "select distinct cu.idcustomers from customers cu, sale s where cu.idcustomers = '{0}' and cu.idcustomers = s.customers_idcustomers and amount > paid";
        //private const string qryGetAllCustomers8 = "select distinct cu.idcustomers from customers cu, sale s where cu.Name = '{0}' and cu.idcustomers = s.customers_idcustomers and amount > paid";
        
        //sale not paid
        private const string qryAllSaleNotPaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c where amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers";


        private const string qryCustomerSaleNotPaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c where amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and c.Name like '{2}'";


        private const string qryCustomerLotIDSaleNotPaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c, saleLines sl where s.amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}'and s.customers_idcustomers = c.idcustomers and s.idsale = sl.sale_idsale and c.Name like '{2}' and sl.stock_Lot# = '{3}'";

        private const string qryCustomerLotNameSaleNotPaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c, saleLines sl, stock sc where s.amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.idsale = sl.sale_idsale and sc.Lot# = sl.stock_Lot#  and c.Name like '{2}' and sc.name like '{3}'";


        private const string qryLotNameSaleNotPaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, saleLines sl, stock sc, customers c where s.amount > paid and s.DueDate<GETDATE() and s.customers_idcustomers = c.idcustomers and [date] between '{0}' and '{1}' and s.idsale = sl.sale_idsale and sc.Lot# = sl.stock_Lot# and sc.name like '{2}'";


        private const string qryLotIDSaleNotPaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, saleLines sl, customers c where s.amount > paid and s.DueDate<GETDATE() and s.customers_idcustomers = c.idcustomers and [date] between '{0}' and '{1}' and s.idsale = sl.sale_idsale and sl.stock_Lot# = '{2}'";


        //sale paid

        private const string qryAllSalePaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers";



        private const string qryCustomerSalePaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers  and c.Name like '{2}'";


        private const string qryCustomerLotIDSalePaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c, saleLines sl where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.idsale = sl.sale_idsale and c.Name like '{2}' and sl.stock_Lot# = '{3}'";

        private const string qryCustomerLotNameSalePaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, customers c, saleLines sl, stock sc where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.idsale = sl.sale_idsale and sc.Lot# = sl.stock_Lot# and c.Name like '{2}' and sc.name like '{3}'";

        private const string qryLotNameSalePaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, saleLines sl, stock sc, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.idsale = sl.sale_idsale and sc.Lot# = sl.stock_Lot# and sc.name like '{2}'";


        private const string qryLotIDSalePaid = "select s.idsale, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from sale s, saleLines sl, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.idsale = sl.sale_idsale and sl.stock_Lot# = '{2}'";


        //purchase not paid

        private const string qryAllPurchaseNotPaid = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c where amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers";

        private const string qryCustomerPurchaseNotPaid = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c where amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and c.Name like '{2}'";


        private const string qryCustomerLotIDPurchaseNotPaid = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c, purchaseLines sl where s.amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.purchaseID = sl.purchase_purchaseID and c.Name like '{2}' and sl.stock_Lot# = '{3}'";

        private const string qryCustomerLotNamePurchaseNotPaid = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c, purchaseLines sl, stock sc where s.amount > paid and s.DueDate<GETDATE() and[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.purchaseID = sl.purchase_purchaseID and sc.Lot# = sl.stock_Lot# and c.Name like '{2}' and sc.name like '{3}'";

        private const string qryLotNamePurchaseNotPaid = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, purchaseLines sl, stock sc, customers c where s.amount > paid and s.DueDate<GETDATE() and s.customers_idcustomers = c.idcustomers and [date] between '{0}' and '{1}' and s.purchaseID = sl.purchase_purchaseID and sc.Lot# = sl.stock_Lot# and sc.name like '{2}'";


        private const string qryLotIDPurchaseNotPaid = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, purchaseLines sl, customers c where s.amount > s.paid and s.DueDate<GETDATE() and s.customers_idcustomers = c.idcustomers and s.[date] between '{0}' and '{1}' and s.purchaseID = sl.purchase_purchaseID and sl.stock_Lot# = '{2}'";

        //purchaseAll

        private const string qrypurchaseAll = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers";

        private const string qryCustomerpurchaseAll = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and c.Name like '{2}'";

        private const string qryCustomerLotIDpurchaseAll = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c, purchaseLines sl where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.purchaseID = sl.purchase_purchaseID and c.Name like '{2}' and sl.stock_Lot# = '{3}'";

        private const string qryCustomerLotNamepurchaseAll = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, customers c, purchaseLines sl, stock sc where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.purchaseID = sl.purchase_purchaseID and sc.Lot# = sl.stock_Lot# and c.Name like '{2}' and sc.name like '{3}'";

        private const string qryLotNamepurchaseAll = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, purchaseLines sl, stock sc, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.purchaseID = sl.purchase_purchaseID and sc.Lot# = sl.stock_Lot# and sc.name like '{2}'";

        private const string qryLotIDpurchaseAll = "select s.purchaseID, c.idcustomers, c.Name, s.date, s.DueDate, s.amount, s.paid from purchase s, purchaseLines sl, customers c where[date] between '{0}' and '{1}' and s.customers_idcustomers = c.idcustomers and s.purchaseID = sl.purchase_purchaseID and sl.stock_Lot# = '{2}'";

        private const string saleviewall = "select * from [viewAll]";
        private const string purchaseviewall = "select * from [PurchaseviewAll]";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBprojectDataSet.stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.dBprojectDataSet.stock);
            // TODO: This line of code loads data into the 'dBprojectDataSet1.customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter.FillBy(this.dBprojectDataSet1.customers);
            // TODO: This line of code loads data into the 'dBprojectDataSet.customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter.FillBy(this.dBprojectDataSet.customers);
            // TODO: This line of code loads data into the 'dBprojectDataSet.purchase' table. You can move, or remove it, as needed.
            this.purchaseTableAdapter.Fill(this.dBprojectDataSet.purchase);
            // TODO: This line of code loads data into the 'dBprojectDataSet.customers' table. You can move, or remove it, as needed.
           // this.customersTableAdapter.FillBy(this.dBprojectDataSet.customers);
            /*SqlConnection conn = new SqlConnection(@"Data Source=HUNAIN-PC;Initial Catalog=DBproject;Persist Security Info=True;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(qryGetAllCustomers, conn);


            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            */
            /*
            SqlConnection conn = new SqlConnection(@"Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(qryGetAllCustomers, conn);
            //DataTable dt = new DataTable();
            sda.Fill(dt);
            DataSet ds = new DataSet();
            sda.Fill(ds, "[Donation]");
            dataGridView1.DataSource = ds.Tables[0];
            */
            /*
            SqlConnection conn = new SqlConnection(@"Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(qryGetAllCustomers, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataSet ds = new DataSet();
            sda.Fill(ds, "[Donation]");
            dataGridView2.DataSource = ds.Tables[0];//customersBindingSource1;
            //dataGridView1.DataSource = stockBindingSource;
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var c = new SqlConnection(CONNSTRING); // Your Connection String here


            SqlConnection conn = new SqlConnection(con/*@"Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True"*/);
            SqlCommand command = new SqlCommand(string.Format(qryGetAllCustomers), conn);
            SqlCommand command1 = new SqlCommand(string.Format(qryGetAllCustomers1, textBox3.Text), conn);
            SqlCommand command2 = new SqlCommand(string.Format(qryGetAllCustomers2, textBox4.Text), conn);
            SqlCommand command3 = new SqlCommand(string.Format(qryGetAllCustomers3), conn);
            SqlCommand command4 = new SqlCommand(string.Format(qryGetAllCustomers6), conn);
            //SqlDataAdapter sda = new SqlDataAdapter(qryGetAllCustomers, conn);
            SqlDataAdapter sda = new SqlDataAdapter();

            if (textBox3.Text.Length == 0 && textBox4.Text.Length == 0 && radioButton6.Checked == true)
            {
                sda.SelectCommand = command;
            }
            else if (textBox3.Text.Length == 0 && radioButton6.Checked == true)
            {

                sda.SelectCommand = command2;
            }

            else if (textBox4.Text.Length == 0 && radioButton6.Checked == true)
            {

                sda.SelectCommand = command1;
            }
            else if (radioButton4.Checked == true)
            {
                sda.SelectCommand = command3;
            }

            else if (radioButton5.Checked == true)
            {
                sda.SelectCommand = command4;
            }

            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            DataSet ds = new DataSet();
            sda.Fill(ds, "[Donation]");
            dataGridView2.DataSource = ds.Tables[0];

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.FillBy(this.dBprojectDataSet.customers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.FillBy1(this.dBprojectDataSet.customers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con/*@"Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True"*/);
            SqlCommand command = new SqlCommand(string.Format(qryGetAllstock, textBox1.Text, textBox2.Text), conn);
            SqlCommand command1 = new SqlCommand(string.Format(qryGetAllstock1, textBox1.Text), conn);
            SqlCommand command2 = new SqlCommand(string.Format(qryGetAllstock2, textBox2.Text), conn);
            SqlCommand command3 = new SqlCommand(string.Format(qryGetAllstock3), conn);

            /*
            command.Parameters.Add("@lot#", SqlDbType.Int);
            command.Parameters.Add("@name", SqlDbType.Text);
            command.Parameters["@lot#"].Value = Convert.ToInt32(textBox1.Text);
            command.Parameters["@name"].Value = textBox2.Text;
            */

            SqlDataAdapter sda = new SqlDataAdapter();
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                sda.SelectCommand = command3;
            }
            else if (textBox1.Text.Length == 0)
            {

                sda.SelectCommand = command2;
            }

            else if (textBox2.Text.Length == 0)
            {

                sda.SelectCommand = command1;
            }
            else
            {
                sda.SelectCommand = command;
            }

            
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            DataSet ds = new DataSet();
            sda.Fill(ds, "[Donation]");
            dataGridView1.DataSource = ds.Tables[0];

            
            


        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con/*"Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True"*/);
            SqlCommand commandqryAllSaleNotPaid = new SqlCommand(string.Format(qryAllSaleNotPaid, SPdateTimePickerFrom.Value.Date.ToString(),SPdateTimePickerTo.Value.Date.ToString()), conn);
            SqlCommand commandqryCustomerSaleNotPaid = new SqlCommand(string.Format(qryCustomerSaleNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text), conn);
            SqlCommand commandqryCustomerLotIDSaleNotPaid = new SqlCommand(string.Format(qryCustomerLotIDSaleNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text,SPLotNumtextBox.Text), conn);
            SqlCommand commandqryCustomerLotNameSaleNotPaid = new SqlCommand(string.Format(qryCustomerLotNameSaleNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text, SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotNameSaleNotPaid = new SqlCommand(string.Format(qryLotNameSaleNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotIDSaleNotPaid = new SqlCommand(string.Format(qryLotIDSaleNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPLotNumtextBox.Text), conn);

            SqlCommand commandqryAllSalePaid = new SqlCommand(string.Format(qryAllSalePaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString()), conn);
            SqlCommand commandqryCustomerSalePaid = new SqlCommand(string.Format(qryCustomerSalePaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text), conn);
            SqlCommand commandqryCustomerLotIDSalePaid = new SqlCommand(string.Format(qryCustomerLotIDSalePaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text, SPLotNumtextBox.Text), conn);
            SqlCommand commandqryCustomerLotNameSalePaid = new SqlCommand(string.Format(qryCustomerLotNameSalePaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text, SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotNameSalePaid = new SqlCommand(string.Format(qryLotNameSalePaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotIDSalePaid = new SqlCommand(string.Format(qryLotIDSalePaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPLotNumtextBox.Text), conn);


            SqlCommand commandqryAllPurchaseNotPaid = new SqlCommand(string.Format(qryAllPurchaseNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString()), conn);
            SqlCommand commandqryCustomerPurchaseNotPaid = new SqlCommand(string.Format(qryCustomerPurchaseNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text), conn);
            SqlCommand commandqryCustomerLotIDpurchaseNotPaid = new SqlCommand(string.Format(qryCustomerLotIDPurchaseNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text, SPLotNumtextBox.Text), conn);
            SqlCommand commandqryCustomerLotNamepurchaseNotPaid = new SqlCommand(string.Format(qryCustomerLotNamePurchaseNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPcustomertextBox.Text, SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotNamepurchaseNotPaid = new SqlCommand(string.Format(qryLotNamePurchaseNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(),  SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotIDPurchaseNotPaid = new SqlCommand(string.Format(qryLotIDPurchaseNotPaid, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(),  SPLotNumtextBox.Text), conn);

            SqlCommand commandqryAllPurchaseAll = new SqlCommand(string.Format(qrypurchaseAll, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString()), conn);
            SqlCommand commandqryCustomerPurchaseAll = new SqlCommand(string.Format(qryCustomerpurchaseAll, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(),  SPcustomertextBox.Text), conn);
            SqlCommand commandqryCustomerLotIDpurchaseAll = new SqlCommand(string.Format(qryCustomerLotIDpurchaseAll, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(),  SPcustomertextBox.Text, SPLotNumtextBox.Text), conn);
            SqlCommand commandqryCustomerLotNamepurchaseAll = new SqlCommand(string.Format(qryCustomerLotNamepurchaseAll, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(),  SPcustomertextBox.Text, SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotNamepurchaseAll = new SqlCommand(string.Format(qryLotNamepurchaseAll, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(),  SPLotNametextBox.Text), conn);
            SqlCommand commandqryLotIDPurchaseAll = new SqlCommand(string.Format(qryLotIDpurchaseAll, SPdateTimePickerFrom.Value.Date.ToString(), SPdateTimePickerTo.Value.Date.ToString(), SPLotNumtextBox.Text), conn);

            //SqlDataAdapter sda = new SqlDataAdapter(qryGetAllCustomers, conn);
            SqlDataAdapter sda = new SqlDataAdapter();

            if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength == 0 && SPsaleradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryAllSalePaid;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength != 0 && SPsaleradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerSalePaid;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength != 0 && SPsaleradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerLotIDSalePaid;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength != 0 && SPsaleradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryCustomerLotNameSalePaid;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength == 0 && SPsaleradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryLotIDSalePaid; ;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength == 0 && SPsaleradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryLotNameSalePaid; ;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength == 0 && SPsaleradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryAllSaleNotPaid;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength != 0 && SPsaleradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerSaleNotPaid;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength != 0 && SPsaleradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerLotIDSaleNotPaid;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength != 0 && SPsaleradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryCustomerLotNameSaleNotPaid;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength == 0 && SPsaleradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryLotIDSaleNotPaid; ;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength == 0 && SPsaleradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryLotNameSaleNotPaid; ;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength == 0 && SPPurchaseradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryAllPurchaseAll;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength != 0 && SPPurchaseradioButton.Checked == true  && SPradioButtonAll.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerPurchaseAll;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength != 0 && SPPurchaseradioButton.Checked == true == true && SPradioButtonAll.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerLotIDpurchaseAll;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength != 0 && SPPurchaseradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryCustomerLotNamepurchaseAll;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength == 0 && SPPurchaseradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryLotIDPurchaseAll;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength == 0 && SPPurchaseradioButton.Checked == true && SPradioButtonAll.Checked == true)
            {
                sda.SelectCommand = commandqryLotNamepurchaseAll;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength == 0 && SPPurchaseradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryAllPurchaseNotPaid;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength == 0 && SPcustomertextBox.TextLength != 0 && SPPurchaseradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerPurchaseNotPaid;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength != 0 && SPPurchaseradioButton.Checked == true == true && SPradioButtonPay.Checked == true)
            {

                sda.SelectCommand = commandqryCustomerLotIDpurchaseNotPaid;
            }
            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength != 0 && SPPurchaseradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryCustomerLotNamepurchaseNotPaid;
            }

            else if (SPLotNumtextBox.TextLength != 0 && (SPLotNametextBox.TextLength == 0 || SPLotNametextBox.TextLength != 0) && SPcustomertextBox.TextLength == 0 && SPPurchaseradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryLotIDPurchaseNotPaid;
            }

            else if (SPLotNumtextBox.TextLength == 0 && SPLotNametextBox.TextLength != 0 && SPcustomertextBox.TextLength == 0 && SPPurchaseradioButton.Checked == true && SPradioButtonPay.Checked == true)
            {
                sda.SelectCommand = commandqryLotNamepurchaseNotPaid;
            }

            DataSet ds3 = new DataSet();
            sda.Fill(ds3, "[Donation]");
            dataGridView3.DataSource = ds3.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count > 0)
            {
                customer cust = new customer();
                cust.id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                CustomerInfo custinfo = new CustomerInfo(cust);
                custinfo.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            customer sel = new customer();
            if (SPsaleradioButton.Checked == true)
            {
                sel.id = 1;
            }
            else
            {
                sel.id = 2;
            }
            New_Sale_Purchase newSalePurchase = new New_Sale_Purchase(sel);
            newSalePurchase.Show();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con);

            SqlCommand commandsaleviewall = new SqlCommand(string.Format(saleviewall), conn);
            SqlCommand commandpurchaseviewall = new SqlCommand(string.Format(purchaseviewall), conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            if (radioButton1.Checked == true)
            {
                sda.SelectCommand = commandsaleviewall;
                
            }
            else
            {
                sda.SelectCommand = commandpurchaseviewall;
            }

            DataSet ds3 = new DataSet();
            sda.Fill(ds3, "[Donation]");
            dataGridView4.DataSource = ds3.Tables[0];
        }
    }

    public class customer
    {
        public int id;
        public string name;
        

        public override string ToString()
        {
            return name ;
        }

    }
}
