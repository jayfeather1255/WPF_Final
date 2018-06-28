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
    /// ToDoBall.xaml 的互動邏輯
    /// </summary>
    public partial class ToDoBall : UserControl
    {
        public ToDoBall()
        {
            InitializeComponent();

            // 生成時不打勾
            Check.Visibility = Visibility.Collapsed;
        }

        // 封裝事件名稱
        public string BallNames
        {
            get
            {
                return BallName.Text;
            }

            set
            {
                BallName.Text = value;
            }
        }

        // 封裝屬性: 是否打勾
        public bool Checked
        {
            get
            {
                // 若勾選符號未顯示，回傳false
                if (Check.Visibility == Visibility.Collapsed)
                    return false;
                else
                    return true;                         
            }

            set
            {
                if (value)
                    Check.Visibility = Visibility.Visible;
                else
                    Check.Visibility = Visibility.Collapsed;
            }
        }

        // 勾選事件
        private void CheckBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Check.Visibility == Visibility.Collapsed)
                Check.Visibility = Visibility.Visible;
            else
                Check.Visibility = Visibility.Collapsed;

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }        
    }
}
