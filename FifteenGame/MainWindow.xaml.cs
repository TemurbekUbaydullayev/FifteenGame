using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FifteenGame
{
    public partial class MainWindow : Window
    {
        private int[] arr = new int[16];
        private short count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button);

            foreach(var item in BtnGridUi.Children)
            {
                Button btn = (Button)item;
                if(btn.Content is "")
                {
                    var rowEmpty = Grid.GetRow(btn);
                    var columnEmpty = Grid.GetColumn(btn);

                    var r = Math.Abs(row - rowEmpty);
                    var c = Math.Abs(column - columnEmpty);

                    if (r + c == 1)
                    {
                        btn.Content = button.Content;
                        button.Content = "";
                        count++;
                        TimeLabel.Content = $"Move: {count}";
                        break;
                    }
                }
            }
            
        }

        private void Restart_Button(object sender, RoutedEventArgs e)
        {
            count *= 0;
            TimeLabel.Content = $"Move: {count}";

            var arr = Enumerable.Range(1, 16).ToArray();
            var rnd = new Random();

            for (int i = 0; i < arr.Length; ++i)
            {
                int randomIndex = rnd.Next(arr.Length);
                int temp = arr[randomIndex];
                arr[randomIndex] = arr[i];
                arr[i] = temp;
            }

            int j = 0;
            foreach (var item in BtnGridUi.Children)
            {
                Button btn = (Button)item;
                btn.Content = arr[j];
                if (arr[j] == 16)
                    btn.Content = "";

                j++;
            }
        }

        //private void Timer()
        //{
        //    DispatcherTimer dt = new DispatcherTimer();
        //    dt.Interval = TimeSpan.FromSeconds(1);
        //    dt.Tick += dtTicker;
        //    dt.Start();          
        //}

        //private void dtTicker(object sender, EventArgs e)
        //{
        //    i++;
        //    TimeLabel.Content = $"Time   Move\n" +
        //                        $" {i}   {count}";
        //}
    }
}
