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
    /// Interaction logic for final.xaml
    /// </summary>
    public partial class final : Window
    {
        private int firstBox;
        private int lastBox;
        private double offerfinal;
       

        public final(int first, int last)
        {
            InitializeComponent();
            firstBox = first;
            lastBox = last;

            // calculates the offer amount
           offerfinal = Math.Round((last + first / 2) * 0.75);
            
            //it displays in the text box
            TxtFinal.Text = "The banker's offer is £" + offerfinal;
        }

        private void BtnSwapBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Congratulations, you won £" + lastBox + ". Do you want to play again?", "Congratulations", MessageBoxButton.YesNo);
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

        private void BtnKeepMyBox_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Congratulations, you won £" + firstBox + ". Do you want to play again?", "Congratulations", MessageBoxButton.YesNo);
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

        private void BtnAcceptOffer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Congratulations, you won £" + offerfinal + ". Do you want to play again?", "Congratulations", MessageBoxButton.YesNo);
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
