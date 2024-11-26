using System.ComponentModel;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/**
 * Johan Ahlqvist
 */
namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private int[,] Board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private int Player = 1;
        private int Computer = 2;
        private int PlayerScore = 0;
        private int ComputerScore = 0;

        public string Score()
        {
            return "Score: You: " + PlayerScore + "  Computer: " + ComputerScore;
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "WpfTicTacToe";
            scoreBoard.Text = Score();
        }

        public void ResetBoard()
        {
            Board = new int[3,3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            btnRow0Col0.Background = Brushes.LightGray;
            btnRow0Col1.Background = Brushes.LightGray;
            btnRow0Col2.Background = Brushes.LightGray;
            btnRow1Col0.Background = Brushes.LightGray;
            btnRow1Col1.Background = Brushes.LightGray;
            btnRow1Col2.Background = Brushes.LightGray;
            btnRow2Col0.Background = Brushes.LightGray;
            btnRow2Col1.Background = Brushes.LightGray;
            btnRow2Col2.Background = Brushes.LightGray;
        }

        private void OnBoard_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = e.Source as Button;
            if (Board[Grid.GetRow(clickedButton),Grid.GetColumn(clickedButton)] == 0)
            {
                clickedButton.Background = Brushes.Blue;
                Board[Grid.GetRow(clickedButton), Grid.GetColumn(clickedButton)] = Player;
                if (CheckBoardWin())
                {
                    scoreBoard.Text = Score();
                    ResetBoard();
                }
                else
                {
                    if (IsBoardMovesLeft())
                    {
                        ComputerMove();
                        if (CheckBoardWin())
                        {
                            scoreBoard.Text = Score();
                            ResetBoard();
                        }
                    }
                    else
                    {
                        ResetBoard();
                    }
                }
            }
        }

        private bool IsBoardMovesLeft()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row, col] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ComputerMove()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row, col] == 0)
                    {
                        Board[row, col] = Computer;
                        if (row == 0 && col == 0)
                            btnRow0Col0.Background = Brushes.Red;
                        if (row == 0 && col == 1)
                            btnRow0Col1.Background = Brushes.Red;
                        if (row == 0 && col == 2)
                            btnRow0Col2.Background = Brushes.Red;
                        if (row == 1 && col == 0)
                            btnRow1Col0.Background = Brushes.Red;
                        if (row == 1 && col == 1)
                            btnRow1Col1.Background = Brushes.Red;
                        if (row == 1 && col == 2)
                            btnRow1Col2.Background = Brushes.Red;
                        if (row == 2 && col == 0)
                            btnRow2Col0.Background = Brushes.Red;
                        if (row == 2 && col == 1)
                            btnRow2Col1.Background = Brushes.Red;
                        if (row == 2 && col == 2)
                            btnRow2Col2.Background = Brushes.Red;
                        return;
                    }
                }
            }
        }

        private bool CheckBoardWin()
        {
            // Checking rows for player or computer win. 
            for (int row = 0; row < 3; row++)
            {
                if (Board[row, 0] == Board[row, 1] &&
                    Board[row, 1] == Board[row, 2])
                {
                    if (Board[row, 0] == Player)
                    {
                        PlayerScore += 1;
                        return true;
                    }
                    else if (Board[row, 0] == Computer)
                    {
                        ComputerScore += 1;
                        return true;
                    }
                }
            }

            // Checking columns for player or computer win. 
            for (int col = 0; col < 3; col++)
            {
                if (Board[0, col] == Board[1, col] &&
                    Board[1, col] == Board[2, col])
                {
                    if (Board[0, col] == Player)
                    {
                        PlayerScore += 1;
                        return true;
                    }
                    else if (Board[0, col] == Computer)
                    {
                        ComputerScore += 1;
                        return true;
                    }
                }
            }

            // Checking diagonals for player or computer win. 
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                if (Board[0, 0] == Player)
                {
                    PlayerScore += 1;
                    return true;
                }
                else if (Board[0, 0] == Computer)
                {
                    ComputerScore += 1;
                    return true;
                }
            }

            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            {
                if (Board[0, 2] == Player)
                {
                    PlayerScore += 1;
                    return true;
                }
                else if (Board[0, 2] == Computer)
                {
                    ComputerScore += 1;
                    return true;
                }
            }
            return false;
        }
    }
}