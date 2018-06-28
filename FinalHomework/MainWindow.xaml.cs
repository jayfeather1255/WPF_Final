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

namespace FinalHomework
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 抓取目前時間 (星期 日 月 年)
            Date.Text = DateTime.Now.ToString("ddd dd MMM,yyyy");
            Time.Text = DateTime.Now.ToShortTimeString();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 新增事件標籤
            ToDoBall ball = new ToDoBall();
           
            // 放入ToDoThings
            ToDoThings.Children.Add(ball);

            // 根據種類變換標籤顏色
            if (Study.IsChecked == true)
                ball.Background = Brushes.LightBlue;
          
            if (Home.IsChecked == true)
                ball.Background = Brushes.LightCyan;

            if (Club.IsChecked == true)
                ball.Background = Brushes.Khaki;

            if (Work.IsChecked == true)
                ball.Background = Brushes.Pink;

            if (Others.IsChecked == true)
                ball.Background = Brushes.Beige;

            STalk();
        }

        private void S_MouseDown(object sender, MouseButtonEventArgs e)
        {
            STalk();
        }

        // 蜘蛛說話
        public void STalk()
        {
            Random TalkNumber = new Random();
            int TN = TalkNumber.Next(0, 5);

            if (TN == 0)
                TalkText.Text = "我是一隻快樂的小蜘蛛～";

            if (TN == 1)
                TalkText.Text = "做完的事情記得要打勾呦～";

            if (TN == 2)
                TalkText.Text = "蜘蛛累但蜘蛛不說";

            if (TN == 3)
                TalkText.Text = "做完事情會有個成就感～";

            if (TN == 4)
                TalkText.Text = "肚子餓了...";
        }

        private void ToDoBall_MouseDown(object sender, MouseButtonEventArgs e)
        {            

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> data = new List<string>();

            // 轉換項目
            foreach (ToDoBall ball in ToDoThings.Children)
            {
                string line = "";

                // 加入是否勾選記號
                if (ball.Checked)
                    line += "O";
                else
                    line += "X";

                // 加上分隔符號與項目文字
                line += "│" + ball.BallNames;

                // 加入串列
                data.Add(line);

                // 存檔
                System.IO.File.WriteAllLines(@"D:\temp\data.txt", data);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開檔
            string[] lines = System.IO.File.ReadAllLines(@"D:\temp\data.txt");

            // 分析每一行
            foreach (string line in lines)
            {
                // 用│符號拆開
                string[] parts = line.Split('│');

                // 建立ToDoBall
                ToDoBall ball = new ToDoBall();
                ball.BallNames = parts[1];

                // 是否打勾
                if (parts[0] == "O")
                    ball.Checked = true;
                else
                    ball.Checked = false;

                // 放進清單裡
                ToDoThings.Children.Add(ball);
            }
        }
    }
}
