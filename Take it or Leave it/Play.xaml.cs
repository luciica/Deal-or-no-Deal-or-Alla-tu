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
using System.Windows.Threading;
using System.Linq;
using System.Windows.Ink;
using System.Xml.Schema;


namespace Take_it_or_Leave_it
{
    /// <summary>
    /// Interaction logic for Play.xaml
    /// </summary>
    public partial class Play : Window

    {
        int prize;
        List<int> prizes = new List<int>()
        {
            1, 5, 25, 50, 75, 100, 250, 500, 700, 900,
            1000, 5000, 10000, 15000, 25000, 50000, 75000, 100000, 150000, 250000
        };
        
        int notYetSelected = 20; //iterator, subtracting 1 every time a box is opened.... so, = number of boxes left
        int total; // the total amount of all prizes added up
        int currentTotal; // set as total, but it is a temp and the values of the boxes being revealed are being removed from List, so the new sum equals to the current total of adding up the values from the unopened boxes

        


    public Play()
            {
                InitializeComponent();
                startGame();
               
            }



    private void startGame()

        {


            // Randomly Order it by Guid..
            int listPrizes = listPrizes.OrderBy(i => Guid.NewGuid()).ToList();
            // It's now shuffled.


            // to obtain the total sum of 1, 5, 25, .... which is 683606 
            int total = 0;
            foreach (int prize in prizes)
            {
                total = total + prize;
            }


            //it is allocating each int from the array to each box which is a btn
            //int[] shuffled = FisherYates(boxes);

            btn1.Tag = shuffled[0];
            btn2.Tag = shuffled[1];
            btn3.Tag = shuffled[2];
            btn4.Tag = shuffled[3];
            btn5.Tag = shuffled[4];
            btn6.Tag = shuffled[5];
            btn7.Tag = shuffled[6];
            btn8.Tag = shuffled[7];
            btn9.Tag = shuffled[8];
            btn10.Tag = shuffled[9];
            btn11.Tag = shuffled[10];
            btn12.Tag = shuffled[11];
            btn13.Tag = shuffled[12];
            btn14.Tag = shuffled[13];
            btn15.Tag = shuffled[14];
            btn16.Tag = shuffled[15];
            btn17.Tag = shuffled[16];
            btn18.Tag = shuffled[17];
            btn19.Tag = shuffled[18];
            btn20.Tag = shuffled[19];
        }

        /// private void enableNumbers()
        {
            //to see the content 
            btn1.IsEnabled = true;

            btn20.IsEnabled = true;
        }

        public void disableNumbers()
        {
            //you cannot see the content
            btn1.IsEnabled = false;

        }


        public void Boxes_Click(object sender, RoutedEventArgs e)
        {
            //one method used by all the boxes / buttons.  //this happens every time a box is clicked


            //the prize of each box is going to be removed from the list
            prize.Remove(shuffledButton.Content);

            //and then the contents of the list added up
            foreach (int prize in prizes)
            {
                total = total + prize;
            }

            // and then the not yet selected boxes will decrease in one
            for (int notYetSelected = 20; notYetSelected > 0; notYetSelected--)
                
          
        }

            // then depending of the number of times a box has been clicked
            // we will be in one of the following scenarios
            {

                if notYetSelected == 20;
                // user is starting the game, is choosing first box ever
                {
                    Button shuffledButton = (Button) sender;
                    string number = shuffledButton.Tag.ToString(); //to DO NOT display the content of the box
                    shuffledButton.IsEnabled = false;
                }

                else if notYetSelected == 1;
                // it means we are close to the end of the game, 2 boxes unopened left
                // the first chosen and the never chosen we need to call method final offer
                {
                    final finalwindow = new final();
                    finalwindow.Show();
                }


                else if notYetSelected == 16 || == 13 || 10 || 7 || 4;
                // it means we are in a regular round of having opened 3 boxes
                {
                    int currentTotal(int total)
                    {
                        prize--;
                        return currentTotal;
                    }

                    Offer();

                    offer offerwindow = new offer();
                    offerwindow.Show();
        

                else
                {

                    // keep opening boxes whereas you are selecting your 2nd, 3rd or 4th box 
                    // or opening boxes after refusing a banker's offer

                    Button shuffledButton = (Button) sender;
                    string number = shuffledButton.Tag.ToString(); //to display the content of the box
                    shuffledButton.IsEnabled = true;

                }
            }



        }

        public Offer()
            // make an offer... (sum remaining values of array / (notYetSelected) + 1 ) *0.8
            // pop up message :  accept or playing
            // need to use float as the result of the calculation might have decimals
        {
            float offer;
            float offer(total / notYetSelected)
            *0.8;
            return offer();
        
       



        }

        public Final()
            //make final offer (sum remaining values of array / 2 ) * 0.7
            // need to use float as the result of the calculation might have decimals
        {
            float final(total / 2) *0.7;
            return final();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
