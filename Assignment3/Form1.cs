using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace Assignment3
{
    //Francis Mc Nabola
    //22210289
    //Creating a application for Mad4Road employees to process client transactions for there product.

    public partial class Mad4Road : Form
    {
        public Mad4Road()
        {
            InitializeComponent();
        }

        //Setting constant values for programme.

        const string PASSWORD = "2Fast4U#", FILENAME = "TransactionRecords.txt";

        string NAME, POSTCODE, TELEPHONE, EMAIL, TRANSACTIONID, SEARCHID, SEARCHEMAIL, Readlines;
       
        int PASSWORDATTEMPTS, TERM, Year;


        decimal BORROWAMOUNT, InterestRate, MONTHLYINTEREST, TOTALINTEREST, TOTALREPAYMENT,
        TOTALBORROWED, OVERALLINTEREST, AVGBORROWAMOUNT, AVGLENTGHOFLOAN;

        const int TERM1 = 1, TERM2 = 3, TERM3 = 5, TERM4 = 7, MONTHS = 12, RecordsPerLine = 9;

        const decimal LOWERRATE1 = 6.00m, LOWERRATE2 = 6.50M, LOWERRATE3 = 7.00M, LOWERRATE4 = 7.50M, MIDDLERATE1 = 8.00M,
        MIDDLERATE2 = 8.50M, MIDDLERATE3 = 9.00M, MIDDLERATE4 = 9.50M, HIGHERRATE1 = 8.50M, HIGHERRATE2 = 8.57M,
        HIGHERRATE3 = 9.10M, HIGHERRATE4 = 9.25M, MonthlyInt = 0;


        private void EnterButton_Click(object sender, EventArgs e)
        {

            //declaring what the password is and notifying user of invalid input.
            if (PasswordTxtBox.Text == PASSWORD)
            {

                ButtonPanel.Visible = true;
                LoginGroupBox.Visible = false;
                LogoPictureBox.Visible = false;
                BorrowTextBox.Focus();
                SummaryButton.Enabled = false;

            }
            else
            {
                PASSWORDATTEMPTS++;
                MessageBox.Show("Please enter the correct password, you have 1 attempt left.", "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                PasswordTxtBox.Text = "";
                PasswordTxtBox.Focus();
                PasswordTxtBox.SelectAll();

            }
             
            if (PASSWORDATTEMPTS >= 2)

                {
                    MessageBox.Show("Password limit expired, this program will now close.", "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.Close();

                }
        }


        private void DisplayButton_Click(object sender, EventArgs e)
        {
            //setting local variables.

            decimal InvestAmount = 0, InterestRate = 0, LoanInterest = 0, LoanAmount = 0, FinalValueOfLoan1, FinalValueOfLoan2,
            FinalValueOfLoan3, FinalValueOfLoan4, MiddleLoanValue1, MiddleLoanValue2, MiddleLoanValue3, MiddleLoanValue4,
            HigherLoanValue1, HigherLoanValue2, HigherLoanValue3, HigherLoanValue4;

            int LoanIndex = 0;

        
         

            if (decimal.TryParse(BorrowTextBox.Text, out BORROWAMOUNT))
            {

                if (BORROWAMOUNT < 400000)
                {
                    LoanIndex = RepaymentsListBox.SelectedIndex;


                    //Calling the Calcualte Loan method to work out loan details.

                    InterestRate = LOWERRATE1;
                    TERM = TERM1;
                    LoanAmount = CalLoanInterest(TERM1, BORROWAMOUNT, LOWERRATE1);

                    FinalValueOfLoan1 = BORROWAMOUNT + LoanInterest;
                    RepaymentsListBox.Items.Add(TERM1 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (FinalValueOfLoan1/(TERM1*MONTHS)).ToString("C")+"\t"+"\t"+
                    (FinalValueOfLoan1 - LoanInterest).ToString("C") + "\t" + FinalValueOfLoan1.ToString("C2"));

                    InterestRate = LOWERRATE2;
                    TERM = TERM2;
                    LoanAmount = CalLoanInterest(TERM2, BORROWAMOUNT, LOWERRATE2);
                    FinalValueOfLoan2 = BORROWAMOUNT+LoanInterest;


                    RepaymentsListBox.Items.Add(TERM2 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (FinalValueOfLoan1 / (TERM2* MONTHS)).ToString("C") + "\t" + "\t" +
                    (FinalValueOfLoan2 - LoanInterest).ToString("C") + "\t" + FinalValueOfLoan2.ToString("C2"));



                    InterestRate = LOWERRATE3;
                    TERM = TERM3;
                    LoanAmount = CalLoanInterest(TERM3, BORROWAMOUNT, LOWERRATE3);
                    FinalValueOfLoan3 = BORROWAMOUNT = LoanInterest;


                    RepaymentsListBox.Items.Add(TERM3 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (FinalValueOfLoan1 / (TERM3 * MONTHS)).ToString("C") + "\t" + "\t" +
                    (FinalValueOfLoan3 - LoanInterest).ToString("C") + "\t" + FinalValueOfLoan3.ToString("C2"));



                    InterestRate = LOWERRATE4;
                    TERM = TERM4;
                    LoanAmount = CalLoanInterest(TERM4, BORROWAMOUNT, LOWERRATE4);
                    FinalValueOfLoan4 = BORROWAMOUNT + LoanInterest;


                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (FinalValueOfLoan1 / (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
                    (FinalValueOfLoan4 - LoanInterest).ToString("C") + "\t" + FinalValueOfLoan4.ToString("C2"));




                    switch (LoanIndex)

                    {
                        case 0: Year = TERM1; InterestRate = LOWERRATE1; MONTHLYINTEREST = MonthlyInt;
                            break;
                        case 1: Year = TERM2; InterestRate = LOWERRATE2;
                            break;
                        case 2: Year = TERM3; InterestRate = LOWERRATE3;
                            break;
                        case 3: Year = TERM4; InterestRate = LOWERRATE4;
                            break;
                    }

                    

                }

                else if (BORROWAMOUNT >= 40000)
                {
                    InterestRate = MIDDLERATE1;

                    LoanAmount = CalLoanInterest(TERM1, BORROWAMOUNT, MIDDLERATE1);
                    MiddleLoanValue1 = BORROWAMOUNT;

                    RepaymentsListBox.Items.Add(TERM1 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (MiddleLoanValue1 / (TERM1 * MONTHS)).ToString("C") + "\t" + "\t" +
                 (MiddleLoanValue1 - LoanInterest).ToString("C") + "\t" + MiddleLoanValue1.ToString("C2"));
    

                    InterestRate = MIDDLERATE2;

                    LoanAmount = CalLoanInterest(TERM2, BORROWAMOUNT, MIDDLERATE2);
                    MiddleLoanValue2 = BORROWAMOUNT;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (MiddleLoanValue2/ (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
               (MiddleLoanValue2- LoanInterest).ToString("C") + "\t" + MiddleLoanValue2.ToString("C2"));

                    InterestRate = MIDDLERATE3;

                    LoanAmount = CalLoanInterest(TERM3, BORROWAMOUNT, MIDDLERATE3);
                    MiddleLoanValue3 = BORROWAMOUNT;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (MiddleLoanValue3 / (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
               (MiddleLoanValue3 - LoanInterest).ToString("C") + "\t" + MiddleLoanValue3.ToString("C2"));


                    InterestRate = MIDDLERATE4;

                    LoanAmount = CalLoanInterest(TERM4, BORROWAMOUNT, MIDDLERATE4);
                    MiddleLoanValue4 = BORROWAMOUNT;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (MiddleLoanValue4/ (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
               (MiddleLoanValue4 - LoanInterest).ToString("C") + "\t" + MiddleLoanValue4.ToString("C2"));

                }

                switch (LoanIndex)

                {
                    case 0:
                        Year = TERM1; InterestRate = MIDDLERATE1;
                        break;
                    case 1:
                        Year = TERM2; InterestRate = MIDDLERATE2;
                        break;
                    case 2:
                        Year = TERM3; InterestRate = MIDDLERATE3;
                        break;
                    case 3:
                        Year = TERM4; InterestRate = MIDDLERATE4;
                        break;
                }


                if (BORROWAMOUNT > 80000)
                {
                    InterestRate = HIGHERRATE1;

                    LoanAmount = CalLoanInterest(TERM1, BORROWAMOUNT, HIGHERRATE1);

                    HigherLoanValue1 = BORROWAMOUNT + LoanInterest;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (HigherLoanValue1/ (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
             (HigherLoanValue1 - LoanInterest).ToString("C") + "\t" + HigherLoanValue1.ToString("C2"));

                    InterestRate = HIGHERRATE2;

                    LoanAmount = CalLoanInterest(TERM2, BORROWAMOUNT, HIGHERRATE2);
                    HigherLoanValue2 = BORROWAMOUNT + LoanInterest;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (HigherLoanValue2 / (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
               (HigherLoanValue2 - LoanInterest).ToString("C") + "\t" + HigherLoanValue2.ToString("C2"));

                    InterestRate = HIGHERRATE3;

                    LoanAmount = CalLoanInterest(TERM3, BORROWAMOUNT, HIGHERRATE3);
                    HigherLoanValue3 = BORROWAMOUNT + LoanInterest;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (HigherLoanValue3 / (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
               (HigherLoanValue3 - LoanInterest).ToString("C") + "\t" + HigherLoanValue3.ToString("C2"));

                    InterestRate = HIGHERRATE4;

                    LoanAmount = CalLoanInterest(TERM4, BORROWAMOUNT, HIGHERRATE4);
                    HigherLoanValue4 = BORROWAMOUNT + LoanInterest;

                    RepaymentsListBox.Items.Add(TERM4 + "Years\t" + "\t" + InterestRate + "%\t" + "\t" + (HigherLoanValue4 / (TERM4 * MONTHS)).ToString("C") + "\t" + "\t" +
                (HigherLoanValue4 - LoanInterest).ToString("C") + "\t" + HigherLoanValue4.ToString("C2"));;


                }


                switch (LoanIndex)

                {
                    case 0:
                        Year = TERM1; InterestRate = HIGHERRATE1; 
                        break;
                    case 1:
                        Year = TERM2; InterestRate = HIGHERRATE2;
                        break;
                    case 2:
                        Year = TERM3; InterestRate = HIGHERRATE3;
                        break;
                    case 3:
                        Year = TERM4; InterestRate = HIGHERRATE4;
                        break;
                }

                PeriodOutputLabel.Text = TERM.ToString();

                try
                {
                    BORROWAMOUNT = int.Parse(BorrowTextBox.Text);
                }

                catch
                {
                    MessageBox.Show("Please enter a numerical value for borrow amount.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BorrowTextBox.Focus();
                    BorrowTextBox.SelectAll();
                }

                //Calculations for Summary Table.

                TOTALBORROWED = BORROWAMOUNT + 1;
                OVERALLINTEREST = TOTALINTEREST + 1;
                AVGBORROWAMOUNT = TOTALBORROWED / TERM;
                AVGLENTGHOFLOAN = Year * MONTHS;
                

                LoanGroupBox.Visible = true;
                RepaymentsListBox.Visible = true;

            }

        }
        private void ProceedButton_Click(object sender, EventArgs e)

        {
            //Helping user by notifying them that they must select an option.

            if ((RepaymentsListBox.SelectedIndex != -1))
            {
                DetailsGroupBox.Visible = true;
            }

            else
            {
                MessageBox.Show("Please selecet 1 out of the 4 options", "Option Needed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                RepaymentsListBox.Focus();

            }

            //Toggling with view so relevant boxs appear.


            TransactionIDTextBox.Text = TransactionID();
            NameTextBox.Focus();
            
        } 

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //Outputting information to the final view before customer chooses to purchsase or not.

            DetailsGroupBox.Visible = false;
            FullDetailsGroupBox.Visible = true;
            SummaryButton.Enabled = true;

            
            NAME = NameTextBox.Text;
            POSTCODE = PostcodeTextBox.Text;
            EMAIL = EmailTextBox.Text;
            TELEPHONE = TelephoneTextBox.Text;
            TRANSACTIONID = TransactionIDTextBox.Text;

            
            NameOutputLabel.Text = NAME.ToString();
            PostcodeOutputLabel.Text = POSTCODE.ToString();
            EmailOutputLabel.Text = EMAIL.ToString();
            PhoneOutputLabel.Text = TELEPHONE.ToString();
            IDOutputLabel.Text = TRANSACTIONID;
            IntRateOutputLabel.Text = InterestRate.ToString();
            MonthIntOutputLabel.Text = MonthlyInt.ToString("C2");
            TotalIntOutputLabel.Text = TOTALINTEREST.ToString("C2");
            TotalRepaymentsOutputLabel.Text = TOTALREPAYMENT.ToString("C2");
            
        }
        
        private void SummaryButton_Click(object sender, EventArgs e)
        {

            TotalAmountOutputLabel.Text = TOTALBORROWED.ToString("C2");
            TotalInterestOutputLabel.Text = OVERALLINTEREST.ToString("C2");
            AverageAmountOutputLabel.Text = AVGBORROWAMOUNT.ToString("C2");
            AverageDurationOutputLabel.Text = AVGLENTGHOFLOAN.ToString(); 


            //Toggling view for user while showing summary of payments.

            SummaryPanel.Visible = true;
            DetailsGroupBox.Visible = false;
            OkButton.Focus();
        

        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            StreamWriter outputFile;

            try
            {
                //Saving transaction to file.
                
                {
                    outputFile = File.AppendText(FILENAME);
                    outputFile.WriteLine(TRANSACTIONID);
                    outputFile.WriteLine(EMAIL);
                    outputFile.WriteLine(NAME);
                    outputFile.WriteLine(TELEPHONE);
                    outputFile.WriteLine(POSTCODE);
                    outputFile.WriteLine(BORROWAMOUNT);
                    outputFile.WriteLine(InterestRate);
                    outputFile.WriteLine(TERM);
                    outputFile.WriteLine(TOTALINTEREST);
                    outputFile.Close();

                    MessageBox.Show("Transaction has been processed.", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
            }


            catch
            {

            }
            //Clearing the programme by resetting all the variables to zero for thr next user.

            RepaymentsListBox = null;
            FullDetailsGroupBox.Visible = false;
            BorrowTextBox.Text = null;
            TransactionIDLabel.Text = "0";
            NameOutputLabel.Text = "0";
            PostcodeTextBox.Text = null;
            NameTextBox = null;
            EmailTextBox = null;
            TelephoneTextBox = null;
            PeriodOutputLabel.Text = "0";
            TotalInterestOutputLabel.Text = "0";
            MonthIntOutputLabel.Text = "0";
            TotalRepaymentsOutputLabel.Text = "0";
            EmailOutputLabel.Text = "0";
            PostcodeOutputLabel.Text = "0";
            
            SearchPanel.Visible = true;

        }
        private void EmailSearchButton_Click(object sender, EventArgs e)
        {
            SEARCHEMAIL = SearchEmailTxtBox.Text;

            StreamReader eyes = new StreamReader(FILENAME);

            using (eyes)
            {
                for( int i = 0; i < 10; i++)
                {
                    Readlines = eyes.ReadLine();
                    eyes.ReadLine();

                }
            }
          
            
                SearchResultsListBox.Visible = true;
                

        }
        private void IDSearchButton_Click(object sender, EventArgs e)
        {


            string path ="TransactionRecords.txt";
           

            //Searching for previous transactions with the same ID number.

            SEARCHID = IDSearchTxtBox.Text;
            SearchResultsListBox.Visible = true;
       

        }
        private void OkButton_Click(object sender, EventArgs e)
                {
                    //Allowing user to close summary table view.

                    SummaryPanel.Visible = false;

                }
        private decimal CalLoanInterest(int Term, decimal Loan, decimal InterestRate)

        {
            //Calcualting the interest on the loan amount.

            decimal LoanInterest, MonthlyLoanAmount, MonthlyInt,  Exponent = 1;

            int MonthlyTerm;

            MonthlyInt = ((InterestRate / MONTHS) / 100);

            MonthlyTerm = TERM * MONTHS;

            for (int i = 0; i < MonthlyTerm; i++)

            {
                Exponent *= (1 + MonthlyInt);
            }

            MonthlyLoanAmount = Loan * ((MonthlyInt * Exponent) / (Exponent - 1));

            LoanInterest = MonthlyLoanAmount * MonthlyTerm;

            return LoanInterest;

           
        }
        private string TransactionID()
        {
            //Generating a random 5 digit ID number for users.
            
                Random Random = new Random();

                return Random.Next(10000, 100000).ToString();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //closing the programme.

            this.Close();


        }
        
        private bool CalIDNumber()
        {
            //Searching previous transactions by ID number method.


            SEARCHID = IDSearchTxtBox.Text;

            try
            {
               StreamReader FILENAME = new StreamReader("TransactionRecords.txt");
               SEARCHID = FILENAME.ReadLine();

                while (SEARCHID ==TRANSACTIONID) ;

                for ( int i = 0; i <10; i++)
                        
                {
                    SEARCHID = FILENAME.ReadLine();
                }
            }

            catch
            {
                MessageBox.Show("Can't find ID number");
            }
            bool found = false;

            return found;
        }
        private void CalEmail()
        {
            SEARCHEMAIL = SearchEmailTxtBox.Text;
            try
            {
                StreamReader FILENAME = new StreamReader("TransactionRecords.txt");
                SEARCHEMAIL = FILENAME.ReadLine();

                while (SEARCHEMAIL ==EMAIL) ;

                for (int i = 0; i < 10; i++)

                {
                    SEARCHEMAIL = FILENAME.ReadLine();
                }
            }

            catch
            {
                MessageBox.Show("Can't find ID number");
            }

            bool found = false;

        }

    }
}



