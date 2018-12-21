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
    public partial class CustomerInfo : Form
    {
        private const string con = "Data Source=HUNAIN-PC;Initial Catalog=DBproject;Integrated Security=True";

        private const string qrygetname = "select name from customers where idcustomers = '{0}'";
        private const string qrygetmobile = "select mobile#  from customers where idcustomers = '{0}'";
        private const string qrygetsales = "select* from sale s where s.customers_idcustomers = '{0}' and s.amount > s.paid";
        private const string qrygetpurchases = "select * from purchase p where p.customers_idcustomers = '{0}' and p.amount > p.paid";

        private const string qrygetAmountYouOwe = "select sum(amount - paid) from sale where customers_idcustomers = '{0}'";
        private const string qrygetAmountTheyOwe = " select sum(amount - paid)from purchase where customers_idcustomers = '{0}'";
        customer _current = new customer();
        public CustomerInfo(customer _data)
        {
            InitializeComponent();
            _current = _data;
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            int custid = _current.id;
            textBox1.Text = custid.ToString();

            SqlConnection conn = new SqlConnection(con);
            SqlCommand commandqrygetname = new SqlCommand(string.Format(qrygetname, custid), conn);
            SqlCommand commandqrygetmobile = new SqlCommand(string.Format(qrygetmobile, custid), conn);
            SqlCommand commandqrygetsales = new SqlCommand(string.Format(qrygetsales, custid), conn);
            SqlCommand commandqrygetpurchases = new SqlCommand(string.Format(qrygetpurchases, custid), conn);
            SqlCommand commandqrygetAmountYouOwe = new SqlCommand(string.Format(qrygetAmountYouOwe, custid), conn);
            SqlCommand commandqrygetAmountTheyOwe = new SqlCommand(string.Format(qrygetAmountTheyOwe, custid), conn);



            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = commandqrygetsales;
            DataSet ds = new DataSet();
            sda.Fill(ds, "[Donation]");
            dataGridView3.DataSource = ds.Tables[0];

            SqlDataAdapter sda1 = new SqlDataAdapter();
            sda1.SelectCommand = commandqrygetpurchases;

            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "[Donation]");
            dataGridView1.DataSource = ds1.Tables[0];

            using (SqlConnection conn1 = new SqlConnection(con))
            {
                conn1.Open();
                SqlCommand cmd = new SqlCommand(
                    string.Format(qrygetname, custid), conn);
                object result5 = cmd.ExecuteScalar();
                string name1 = result5.ToString();
                textBox2.Text = name1;

                conn.Close();
            }
            /*
            object result = commandqrygetname.ExecuteScalar();

            string name = result.ToString();
            textBox2.Text = name;
            textBox2.Refresh();
            */
            object result1 = commandqrygetmobile.ExecuteScalar();
            string mobile = result1.ToString();
            textBox3.Text = mobile;

            object result2 = commandqrygetAmountTheyOwe.ExecuteScalar();
            string amountCustomerOwe = result2.ToString();
            textBox4.Text = amountCustomerOwe;

            object result3 = commandqrygetAmountYouOwe.ExecuteScalar();
            string amountYouOwe = result3.ToString();
            textBox5.Text = amountYouOwe;

            int balance = Convert.ToInt32(amountCustomerOwe) - Convert.ToInt32(amountYouOwe);
            textBox6.Text = balance.ToString();





        }
    }
}
