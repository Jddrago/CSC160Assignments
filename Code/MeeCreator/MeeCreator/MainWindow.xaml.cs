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

namespace MeeCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboItemRed_Selected(object sender, RoutedEventArgs e)
        {
            RightEye.Fill = ComboItemRed.Background;
            LeftEye.Fill = ComboItemRed.Background;
        }

        private void ComboItemBlue_Selected(object sender, RoutedEventArgs e)
        {
            RightEye.Fill = ComboItemBlue.Background;
            LeftEye.Fill = ComboItemBlue.Background;
        }

        private void ComboItemPurple_Selected(object sender, RoutedEventArgs e)
        {
            RightEye.Fill = ComboItemPurple.Background;
            LeftEye.Fill = ComboItemPurple.Background;
        }

 
    }
    public class InvertValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                double temp = (double)value;
                temp *= -1;
                value = temp;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                double temp = (double)value;
                temp *= -1;
                value = temp;
            }
            return value;
        }
    }
}
