using NCalc;

namespace NothingCalculator
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = "";

        public MainPage()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            currentInput += button.Text;
            UpdateDisplay();
        }

        private void OnOperationClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (string.IsNullOrEmpty(currentInput))
                return;

            string operation = button.Text;

            currentInput += operation;

            UpdateDisplay();
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            currentInput += ".";

            UpdateDisplay();
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
                return;

            try
            {
                string expression = currentInput;

                var evaluator = new Expression(expression);
                var result = evaluator.Evaluate();

                ExpressionLabel.Text = currentInput;
                currentInput = result.ToString();
                ResultLabel.Text = currentInput;
            }
            catch (Exception)
            {
                ResultLabel.Text = "Error";
                currentInput = "";
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentInput = "";

            ExpressionLabel.Text = "";
            UpdateDisplay();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput[..^1];
            }

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                ResultLabel.Text = "0";
            }
            else
            {
                ResultLabel.Text = currentInput;
            }
        }
    }
}
