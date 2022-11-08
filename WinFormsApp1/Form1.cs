using System.Runtime.CompilerServices;

namespace WinFormsApp1
{

    public interface IForm
    {
        public void DisplayMessage(string message);

    }

    public partial class Form2 : IForm
    {
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
    }


    public partial class Form1 : Form
    {

        IForm dependency;

        public string errorMessage { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IForm form, string message)
        {
            InitializeComponent();
            //this.errorMessage = message;
            this.dependency = form;

            form.DisplayMessage(message);
            //dependency.DisplayMessage(message);



        }

        public void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("You have to enter a name");
                return;
            }

            if (numBalance.Value < 10_000 || numBalance.Value > 1_000_000)
            {
                MessageBox.Show("Must be between 10k and 1MM");
                return;
            }

            if (File.Exists("authkey.txt") is false)
            {
                MessageBox.Show("Missing authorization key");
                return;
            }

            lblResults.Text = (numBalance.Value * numInterestRate.Value).ToString("c");
        }
    }
}