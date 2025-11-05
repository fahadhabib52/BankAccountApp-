using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAcountApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> AllAccounts = new List<BankAccount>();
        public Form1()
        {

            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            BankAccount bankAccount = new BankAccount(textBox1.Text);

            AllAccounts.Add(bankAccount);
            RefreshGrid();
            MessageBox.Show("Account Create Succesfully");
        }

        public void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AllAccounts;
            textBox1.Text = "";
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an account first.");
                return;
            }
            BankAccount SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            SelectAccount.Balance += numericUpDown1.Value;
            RefreshGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an account first.");
                return;
            }

            BankAccount SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            if (numericUpDown1.Value > SelectAccount.Balance)
            {
                MessageBox.Show("Insufficient balance!");
                return;
            }

            SelectAccount.Balance -= numericUpDown1.Value;
            RefreshGrid();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
