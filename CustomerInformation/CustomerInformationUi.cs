using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                //Username validation :exists, empty
                if (!String.IsNullOrWhiteSpace(userNameTextBox.Text))
                {
                    if (userNames.Contains(userNameTextBox.Text)==true)
                    {
                        userNameLabel.Text = "Username already exists!";                        
                    }
                    else emptyCheckStatus++;                   
                }
                else userNameLabel.Text = "Username can't be empty!";
                
                //Contact no valiadation :exists, empty, length, numeric
                if (!String.IsNullOrWhiteSpace(contactNoTextBox.Text))
                {
                    if (contactNoTextBox.Text.Length == 11)
                    {
                        if (contactNos.Contains(contactNoTextBox.Text) == true)
                        {
                            contactLabel.Text = "Contact already exists!";
                        }
                        else emptyCheckStatus++;
                    }
                    else contactLabel.Text = "Contact no should be 11 digit!";
                    
                }
                else contactLabel.Text = "Contact can't be empty!";

                //Email valiadation :exists, empty, format
                if (!String.IsNullOrWhiteSpace(emailTextBox.Text))
                {
                    string email = emailTextBox.Text;
                    if (IsValidEmail(email) == true)
                    {
                        if (emails.Contains(emailTextBox.Text))
                        {
                            emailLabel.Text = "Email already exists!";
                        }
                        else emptyCheckStatus++;
                    }
                    else emailLabel.Text = "Email format is not valid!";

                }
                else emailLabel.Text = "Email can't be empty!";

                //Account no valiadation :exists, empty, length, numeric
                if (!String.IsNullOrWhiteSpace(accountNoTextBox.Text))
                {
                    if (accountNoTextBox.Text.Length == 9)
                    {
                        if (accountNos.Contains(accountNoTextBox.Text) == true)
                        {
                            accountNoLabel.Text = "Account number already exists!";
                        }
                        else emptyCheckStatus++;
                    } else accountNoLabel.Text = "Account no should be 9 digit!";
                    
                }
                else accountNoLabel.Text = "Account number can't be empty!";


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
            try
            {
                string displayMessage = "SL  ||  Username       ||    Frist Name     ||    Last Name      ||    Contact No  ||   Email       ||   Address        ||    Account No     ||   Balance     \n\n\n";
                int i = 0;
                foreach (string username in userNames)
                {
                    displayMessage = displayMessage + (i + 1) + "    ||" + " " + username + "    ||   " + firstNames[i] + "  ||   " + lastNames[i] + "   ||   " + contactNos[i] + " || " + emails[i] + "     ||   " + addresses[i] + "   ||   " + accountNos[i] + "   ||    " + balances[i] + "\n";
                    i++;
                }
                displayRichTextBox.Text = displayMessage;
            }
            catch(Exception excaption)
            {
                MessageBox.Show(excaption.Message);
            }
            
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            
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

        private void contactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if(!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                contactLabel.Text = "Contact no should be numeric!";
            }
        }

        private void accountNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if(!Char.IsDigit(chr)&& chr != 8)
            {
                e.Handled = true;
                accountNoLabel.Text = "Account no should be numeric!";
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
