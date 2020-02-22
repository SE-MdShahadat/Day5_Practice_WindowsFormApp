using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInformation
{
    public partial class CustomerInformationUi : Form
    {
        List<string> userNames = new List<string>();
        List<string> firstNames = new List<string>();
        List<string> lastNames = new List<string>();
        List<string> contactNos = new List<string>();
        List<string> emails = new List<string>();
        List<string> addresses = new List<string>();
        List<string> accountNos = new List<string>();
        List<double> balances = new List<double>();
        public CustomerInformationUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            userNameLabel.Text = "";
            contactLabel.Text = "";
            emailLabel.Text = "";
            accountNoLabel.Text = "";
            int emptyCheckStatus = 0;
            try
            {
                if (!String.IsNullOrWhiteSpace(userNameTextBox.Text))
                {
                    emptyCheckStatus ++;
                }
                else
                {
                    userNameLabel.Text = "User name can't be empty!";
                }
                if (!String.IsNullOrWhiteSpace(contactNoTextBox.Text))
                {
                    emptyCheckStatus ++;
                }
                else
                {
                    contactLabel.Text = "Contact can't be empty!";
                }
                if (!String.IsNullOrWhiteSpace(emailTextBox.Text))
                {
                    emptyCheckStatus ++;
                }
                else
                {
                    emailLabel.Text = "Email can't be empty!";
                }
                if (!String.IsNullOrWhiteSpace(accountNoTextBox.Text))
                {
                    emptyCheckStatus ++;
                }
                else
                {
                    accountNoLabel.Text = "Account number can't be empty!";
                }
                if (emptyCheckStatus ==4)
                {
                    AddDataToList();
                    MessageBox.Show("Customer Information Saved Successfully!!!");
                    ClearTextBox();

                }
            }
            catch( Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void ClearTextBox()
        {
            userNameTextBox.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            contactNoTextBox.Clear();
            emailTextBox.Clear();
            addressTextBox.Clear();
            accountNoTextBox.Clear();
        }
        private void AddDataToList()
        {
            userNames.Add(userNameTextBox.Text);
            firstNames.Add(firstNameTextBox.Text);
            lastNames.Add(lastNameTextBox.Text);
            contactNos.Add(contactNoTextBox.Text);
            emails.Add(emailTextBox.Text);
            addresses.Add(addressTextBox.Text);
            accountNos.Add(accountNoTextBox.Text);
            balances.Add(0);
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            string displayMessage = "SL  ||  Username       ||    Frist Name     ||    Last Name      ||    Contact No  ||   Email       ||   Address        ||    Account No     ||   Balance     \n\n\n";
            int i = 0;
            foreach(string username in userNames)
            {
                displayMessage = displayMessage + (i + 1)+ "    ||" + " " + username + "    ||   " + firstNames[i] + "  ||   " + lastNames[i] + "   ||   " + contactNos[i] + " || " + emails[i] + "     ||   " + addresses[i] + "   ||   " + accountNos[i] + "   ||    " + balances[i]+"\n";
                i++;
            }
            displayRichTextBox.Text = displayMessage;
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            //double blance = 0;
            amountTextBox.Clear();
            int i = 0;
            foreach(string accountNo in accountNos)
            {
                if (accountNo == accountNumberTextBox.Text)
                {
                    amountTextBox.Text = balances[i].ToString();
                }
                i++;
            }
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            accountActionInfoLabel.Text = "";
            int i = 0;
            foreach (string accountNo in accountNos)
            {
                if (accountNo == accountNumberTextBox.Text)
                {
                    balances[i]=balances[i]+Convert.ToDouble(amountTextBox.Text);
                    amountTextBox.Clear();
                    accountActionInfoLabel.Text = "Diposite Complete.";
                }
                i++;
            }
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            accountActionInfoLabel.Text = "";
            int i = 0;
            foreach (string accountNo in accountNos)
            {
                if (accountNo == accountNumberTextBox.Text)
                {
                    balances[i] = balances[i] - Convert.ToDouble(amountTextBox.Text);
                    amountTextBox.Clear();
                    accountActionInfoLabel.Text = "Withdraw Complete.";
                }
                i++;
            }
        }
    }
}
