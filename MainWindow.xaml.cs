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

namespace TicTacToe
{
  
  public partial class MainWindow : Window
  {
    bool turn = true; /// If turn is true, set an "X", if turn is false, set an "O". An X is set first.
    int turn_count = 0; /// Param for counting the turns you've made. In the beginning it's set to 0
    public MainWindow()
    {
      InitializeComponent();
    }
 
    private void btn_click(object sender, RoutedEventArgs e)
    {
      Button b = (Button)sender;
      if (turn)
        b.Content = "X"; /// If turn == true, fill the button with an X
      else
        b.Content = "O";  /// If turn == false, fill the button with an X
      turn = !turn; 

      b.IsEnabled = false; /// If a button already has content, the button will be disabled, therefore you cannot click it again
      turn_count++; /// Counts the turns, if a button is clicked a turn is added
      Winner(); /// Jumps to the "Winner" subprogram
     
    } // End of btn_click

    private void Winner()
    {  /// This subprogram identifies wether there is a winner or not
      /// First we check the horizontal lines, then vertical, then diagonally
      /// We also have to make sure, that there is content in the buttons,
      /// if we wouldn't check that, you'd always have a winner
      /// To avoid that we added btn.Content != null, so the Content should NOT be zero
      
      bool winner = false; /// At first there's no winner

      /// Horizontal win
      if ((btn0_0.Content != null) && (btn0_0.Content == btn1_0.Content) && (btn1_0.Content == btn2_0.Content))
        winner = true;

      else if ((btn0_1.Content != null) && (btn0_1.Content == btn1_1.Content) && (btn1_1.Content == btn2_1.Content))
        winner = true;

      else if ((btn0_2.Content != null) && (btn0_2.Content == btn1_2.Content) && (btn1_2.Content == btn2_2.Content))
        winner = true;
      
      /// Vertical win
      else if ((btn0_0.Content != null) && (btn0_0.Content == btn0_1.Content) && (btn0_1.Content == btn0_2.Content))
        winner = true;
      else if ((btn1_0.Content != null) && (btn1_0.Content == btn1_1.Content) && (btn1_1.Content == btn1_2.Content))
        winner = true;
      else if ((btn2_0.Content != null) && (btn2_0.Content == btn2_1.Content) && (btn2_1.Content == btn2_2.Content))
        winner = true;

      /// Diagonal win
      else if ((btn0_0.Content != null)  && (btn0_0.Content == btn1_1.Content) && (btn1_1.Content == btn2_2.Content))
        winner = true;
      else if ((btn0_2.Content != null) && (btn0_2.Content == btn1_1.Content) && (btn1_1.Content == btn2_0.Content))
        winner = true;
      
      /// Determines  wether X or O has won the game
      if (winner == true)
      {
        string endgame = "";
        if (turn) endgame = "O";
        else endgame = "X";
        MessageBox.Show(endgame + " has won the game! Click 'New Game' to start a new round");
      } // End of Determination of Winner
      else
      {
        if (turn_count == 9) MessageBox.Show("A tie! Click 'New Game' to start a new round"); /// If there's no winner and 9 rounds have been played, show message "Try again"
      }
    } // End Winner subprogram

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      turn_count = 0; /// Set rounds at 0 again
     
      btn0_0.Content = null; /// Clears the buttons
      //btn0_0.Content = String.Empty; would be another way to clear the buttons 
      btn0_0.IsEnabled = true; /// Buttons can be clicked again

      btn0_1.Content = null;
      btn0_1.IsEnabled = true;

      btn0_2.Content = null;
      btn0_2.IsEnabled = true;

      btn1_0.Content = null;
      btn1_0.IsEnabled = true;

      btn1_1.Content = null;
      btn1_1.IsEnabled = true;

      btn1_2.Content = null;
      btn1_2.IsEnabled = true;

      btn2_0.Content = null;
      btn2_0.IsEnabled = true;

      btn2_1.Content = null;
      btn2_1.IsEnabled = true;

      btn2_2.Content = null;
      btn2_2.IsEnabled = true;



    } // End btnReset_Click subprogram
  }


  }



