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
using _21._05._2026.Yadro;

namespace _21._05._2026
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        private Border[,] _cells;
        private Border[,] _border;
        public MainWindow()
        {
            InitializeComponent();

            _game = new Game();

            _cells = new Border[_game.Rows, _game.Cols];
            CreateGameGrid();
        }

        private void CreateGameGrid()
        {
            gameGrid.Children.Clear();
            gameGrid.Rows = _game.Rows;
            gameGrid.Columns = _game.Cols;
            for (int i = 0; i < _game.Rows; i++)
            {
                for (int j = 0; j < _game.Cols; j++)
                {
                    Border border = new Border()
                    {
                        Background = Brushes.Black,
                        BorderBrush = Brushes.DimGray,
                        BorderThickness = new Thickness(0.3)
                    };

                    int iCaptured = i, jCaptured = j;
                    border.MouseLeftButtonDown += (sender, e) => CellClick(iCaptured, jCaptured);
                }
            }
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("start clicked");
        }
        private void StopClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("stop clicked");
        }
    }
}
