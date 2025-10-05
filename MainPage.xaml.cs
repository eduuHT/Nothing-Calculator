using NCalc;

namespace NothingCalculator
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
        }
    }

}
