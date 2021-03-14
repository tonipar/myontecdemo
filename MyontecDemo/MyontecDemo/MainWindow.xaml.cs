using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace MyontecDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double time;
        private double distance;
        private double weight;
        private double speed;
        private double met;
        private double calories;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void From_submitButton_Click(object sender, RoutedEventArgs e)
        {
            
            /// Check that none of the textbox are empty and that they are double type
            if (formTime.Text.Length == 0){
                errormessageTime.Text = "Enter value";
                formTime.Focus();
            }
            else if(!double.TryParse(formTime.Text, out time)){
                errormessageTime.Text = "Must enter a number";
            }else{
                errormessageTime.Text = "";
                time = double.Parse(formTime.Text);
            }

            if (formDistance.Text.Length == 0){
                errormessageDistance.Text = "Enter value";
                formDistance.Focus();
            }else if (!double.TryParse(formDistance.Text, out distance)){
                errormessageDistance.Text = "Must enter a number";
            }else{
                errormessageDistance.Text = "";
                distance = double.Parse(formDistance.Text);
            }

            if (formWeight.Text.Length == 0){
                errormessageWeight.Text = "Enter value";
                formWeight.Focus();
            }else if (!double.TryParse(formWeight.Text, out weight)){
                errormessageWeight.Text = "Must enter a number";
            }else{
                errormessageWeight.Text = "";
                weight = double.Parse(formWeight.Text);
            }

            /// Calculate calories/kcals = activity (MET) x 3.5 x (your body weight in kilograms) / 200 = calories burned per minute
            /// Met table used in this demo http://mariemurphyhealthfitness.com/wp-content/uploads/2013/12/Calculating-your-weekly-METs-km-hour.pdf
            speed = distance / time;
            if (speed < 6) { met = 7; }
            else if (speed >= 6 && speed < 7) { met = 7.5; }
            else if (speed >= 7 && speed < 8) { met = 8.5; }
            else if (speed >= 8 && speed < 9) { met = 9.5; }
            else if (speed >= 9 && speed < 10) { met = 10.5; }
            else if (speed >= 10 && speed < 11) { met = 11.5; }
            else if (speed >= 11 && speed < 12) { met = 12.5; }
            else if (speed >= 12 && speed < 13) { met = 13.5; }
            else { met = 14.5; }

            calories = met * 3.5 * weight / 200 * (time*60);

            resulttext.Text = "You have burned " + calories + " calories!";
            
        }
    }
}
