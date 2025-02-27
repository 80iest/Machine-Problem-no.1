using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine_Problem_no._1
{
    public partial class Form1: Form
    {

        private decimal balance = 0;
        private int numDeposits = 0, numChecks = 0;
        private decimal totalDeposits = 0, totalChecks = 0;
        private const decimal serviceCharge = 10m;

        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) && amount > 0)
            {
                if (rdoDeposit.Checked)
                {
                    balance += amount;
                    numDeposits++;
                    totalDeposits += amount;
                }
                else if (rdoCheck.Checked)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                        numChecks++;
                        totalChecks += amount; 
                    }
                    else
                    {
                        MessageBox.Show("Insufficient funds!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        balance -= serviceCharge;
                    }
                }
                else if (rdoServiceCharge.Checked)
                {
                    balance -= serviceCharge;
                }
                BalanceLabel.Text = $"{balance:F2}";
                AmountTextBox.Clear();
                AmountTextBox.Focus();
            }else
            {
                MessageBox.Show("Enter valid amount", "Input Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            AmountTextBox.Clear();
            BalanceLabel.Text = "0.00";

            rdoDeposit.Checked = false;
            rdoCheck.Checked = false;
            rdoServiceCharge.Checked = false;
            AmountTextBox.Focus();
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            string summary = $"Total Deposits: {numDeposits}\nTotal Deposit Amount: ${totalDeposits:F2}\n" +
                             $"Total Checks: {numChecks}\nTotal Check Amount: ${totalChecks:F2}";
            MessageBox.Show(summary,"Account Summary", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdoDeposit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BalanceLabel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
