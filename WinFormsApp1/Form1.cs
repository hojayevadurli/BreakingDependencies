using System.Runtime.CompilerServices;

namespace WinFormsApp1
{

    public interface IForm
    {
        public void DisplayMessage(string message);

    }

    public class Form2 : IForm
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

        public Form1(IForm form)
        {
            this.dependency = form;
            InitializeComponent();

        }

        public Form1(IForm form, string message)
        {
            this.dependency = form;
            InitializeComponent();
            txtName.Text = message;

        }

        public void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {

                dependency.DisplayMessage("You have to enter a name");
                return;
            }

            if (numBalance.Value < 10_000 || numBalance.Value > 1_000_000)
            {
                dependency.DisplayMessage("Must be between 10k and 1MM");
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