using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Take_it_or_Leave_it
{
    /// <summary>
    /// Interaction logic for offer.xaml
    /// </summary>
    public partial class offer : Window
    {
        private int totalPrizeMoney;
        private int noOfBoxes;
        private double offeramount;

        public offer(int total, int noleft)
        {
            InitializeComponent();
            totalPrizeMoney = total;
            noOfBoxes = noleft;

            // calculates the offer amount
            offeramount = Math.Round((total / noOfBoxes) * 0.8);

            //it displays in the text box
            TxtOffer.Text = "The banker's offer is £" + offeramount;

        }
        

        private void BtnKeepPlaying_Click(object sender, RoutedEventArgs e)
        {
            //to return to the play game, but not to the beginning, to the point the player keeps opening boxes by just closing this window
            this.Close();
        }

        private void BtnAcceptOffer_Click(object sender, RoutedEventArgs e)
        {
            
            
            MessageBoxResult result = MessageBox.Show("Congratulations, you won £" + offeramount + ". Do you want to play again?", "Congratulations", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //opens a new game, without showing the rules, as you just played

                Play play = new Play();
                play.Show();
                
            }
            else
            {
                Application.Current.Shutdown(); //Exits the application
            }
            
        }
    }
    
}
