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
using System.Threading.Tasks;

namespace Take_it_or_Leave_it
{
    /// <summary>
    /// Interaction logic for Play.xaml
    /// </summary>
    public partial class Play : Window
    {
        private List<int> prizes = new List<int>(){
            1, 5, 25, 50, 75, 100, 250, 500, 700, 900, 1000, 5000, 10000, 15000, 25000, 50000, 75000, 100000, 150000, 250000};
        private int noleft = 21; //iterator, subtracting 1 every time a box is opened.... so, = number of boxes left
        private int total; // the total amount of all prizes added up. the values of the boxes being revealed are being removed from List, so the new sum equals to the current total of adding up the values from the unopened boxes
        private int firstBox; //the money value in the first chosen box
        private int lastBox; // the money value in the never chosen box
       

        public Play()
        {
            InitializeComponent();
            startGame();
            enableNumbers();
        }

        public void startGame()
        {
            // Randomly Order it by Guid.
            prizes = prizes.OrderBy(i => Guid.NewGuid()).ToList();
            // It's now shuffled

            //here it is allocating each int from the list to each box which are buttons
            btn1.Tag = prizes[0];
            btn2.Tag = prizes[1];
            btn3.Tag = prizes[2];
            btn4.Tag = prizes[3];
            btn5.Tag = prizes[4];
            btn6.Tag = prizes[5];
            btn7.Tag = prizes[6];
            btn8.Tag = prizes[7];
            btn9.Tag = prizes[8];
            btn10.Tag = prizes[9];
            btn11.Tag = prizes[10];
            btn12.Tag = prizes[11];
            btn13.Tag = prizes[12];
            btn14.Tag = prizes[13];
            btn15.Tag = prizes[14];
            btn16.Tag = prizes[15];
            btn17.Tag = prizes[16];
            btn18.Tag = prizes[17];
            btn19.Tag = prizes[18];
            btn20.Tag = prizes[19];

            total = prizes.Sum(); //calculate the total prize money
            
        }

        public void disableNumbers()
        {
            //you cannot see the content
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;
            btn8.IsEnabled = false;
            btn9.IsEnabled = false;
            btn10.IsEnabled = false;
            btn11.IsEnabled = false;
            btn12.IsEnabled = false;
            btn12.IsEnabled = false;
            btn13.IsEnabled = false;
            btn14.IsEnabled = false;
            btn15.IsEnabled = false;
            btn16.IsEnabled = false;
            btn17.IsEnabled = false;
            btn18.IsEnabled = false;
            btn19.IsEnabled = false;
            btn20.IsEnabled = false;
        }

        public void enableNumbers()
        {
            //to see the content of the box
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
            btn6.IsEnabled = true;
            btn7.IsEnabled = true;
            btn8.IsEnabled = true;
            btn9.IsEnabled = true;
            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;
            btn12.IsEnabled = true;
            btn13.IsEnabled = true;
            btn14.IsEnabled = true;
            btn15.IsEnabled = true;
            btn16.IsEnabled = true;
            btn17.IsEnabled = true;
            btn18.IsEnabled = true;
            btn19.IsEnabled = true;
            btn20.IsEnabled = true;
        }

        public void Boxes_Click(object sender, RoutedEventArgs e)
        {
            //one method used by all the boxes / buttons.
            //this happens every time a box is clicked
            Button shuffledButton = (Button)sender;

            noleft--;// the not yet selected boxes will decrease in one

            string number = shuffledButton.Tag.ToString(); //get the money value in the box as a string
            int money = int.Parse(number); //convert it to an integer

            // then depending of the number of times a box has been clicked
            // we will be in one of the following scenarios

            if (noleft == 20)// user is starting the game, is choosing first box ever
            {
                firstBox = money; //store what is in there as first prize
                shuffledButton.IsEnabled = false;
                shuffledButton.Foreground = Brushes.Black;
                shuffledButton.Content = "This is your box";
                final finalwindow = new final(firstBox, lastBox);
               
            }
         
                else if (noleft == 1)
                // it means we are close to the end of the game, 2 boxes unopened left
                // the first chosen and the never chosen we need to call method final offer
            {
                lastBox = money; //store what is in there as last prize
                shuffledButton.IsEnabled = false;
                final finalwindow = new final(firstBox, lastBox);
                remove(money);
                //give it the first box money and the last box money so player can choose between them
                finalwindow.Show();
            }


            else if (noleft == 17 || noleft == 14 || noleft == 11 || noleft == 8 || noleft == 5)
            // it means we are in a regular round of having opened 3 boxes
            {
                remove(money);//the prize of each box is going to be removed from the list of possible prizes
                shuffledButton.IsEnabled = false;
                Task.Delay(2000); // enter a 2 second delay, so the player can see clearly which was the last prize value 
                offer offerwindow = new offer(total, noleft);
                offerwindow.Show();
            }
            else
            {
               remove(money);
               shuffledButton.IsEnabled = false;
                //the prize of each box is going to be removed from the list of possible prizes
                // keep opening boxes whereas you are selecting your 2nd, 3rd or 4th box 
                // or opening boxes after refusing a banker's offer
            }

        }

        private void remove(int money)
        {
            total = total - money; //keep a total of how much money is in the prize pot
           

            //to clear the content of the labels as they are clicked, so disappears from both sides columns
            
          if ((noleft == 1))
           {
                   switch (money)
                {
               case 1: lblShow1.Content = "£1"; break;
               case 5: lblShow2.Content = "£5"; break;
               case 25: lblShow3.Content = "£25"; break;
               case 50: lblShow4.Content = "£50"; break;
               case 75: lblShow5.Content = "£75"; break;
               case 100: lblShow6.Content = "£100"; break;
               case 250: lblShow7.Content = "£250"; break;
               case 500: lblShow8.Content = "£500"; break;
               case 700: lblShow9.Content = "£700"; break;
               case 900: lblShow10.Content = "£900"; break;
               case 1000: lblShow11.Content = "£1,000"; break;
               case 5000: lblShow12.Content = "£5,000"; break;
               case 10000: lblShow13.Content = "£10,000"; break;
               case 15000: lblShow14.Content = "£15,000"; break;
               case 25000: lblShow15.Content = "£25,000"; break;
               case 50000: lblShow16.Content = "£50,000"; break;
               case 75000: lblShow17.Content = "£75,000"; break;
               case 100000: lblShow18.Content = "£100,000"; break;
               case 150000: lblShow19.Content = "£150,000"; break;
               case 250000: lblShow20.Content = "£250,000"; break;
                }
            }
           else

               switch (money)

               {
                   case 1: lblShow1.Content = ""; break;
                   case 5: lblShow2.Content = ""; break;
                   case 25: lblShow3.Content = ""; break;
                   case 50: lblShow4.Content = ""; break;
                   case 75: lblShow5.Content = ""; break;
                   case 100: lblShow6.Content = ""; break;
                   case 250: lblShow7.Content = ""; break;
                   case 500: lblShow8.Content = ""; break;
                   case 700: lblShow9.Content = ""; break;
                   case 900: lblShow10.Content = ""; break;
                   case 1000: lblShow11.Content = ""; break;
                   case 5000: lblShow12.Content = ""; break;
                   case 10000: lblShow13.Content = ""; break;
                   case 15000: lblShow14.Content = ""; break;
                   case 25000: lblShow15.Content = ""; break;
                   case 50000: lblShow16.Content = ""; break;
                   case 75000: lblShow17.Content = ""; break;
                   case 100000: lblShow18.Content = ""; break;
                   case 150000: lblShow19.Content = ""; break;
                   case 250000: lblShow20.Content = ""; break;
               }
        }
    }
}
