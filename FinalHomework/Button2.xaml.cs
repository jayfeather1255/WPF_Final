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
    /// Button2.xaml 的互動邏輯
    /// </summary>
    public partial class Button2 : UserControl
    {
        // 外部控制文字
        public string ButtonText
        {
            get
            {
                return BtnText.Text;
            }

            set
            {
                BtnText.Text = value;
            }
        }

        public Button2()
        {
            InitializeComponent();
        }
        
    }
}
