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

namespace Shooting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const double minSizeFactor = 2.5;
        public class Radius
        {
            private int? radiusInner;
            private int? radiusOuter;
            public int? RadiusInner 
            { 
                get => radiusInner;
                set
                {
                    if (value < 10)
                    {
                        throw new ArgumentException();
                    }
                    radiusInner = value;
                }
            }
                
            public int? RadiusOuter
            {
                get => radiusOuter;
                set
                {
                    if (value < 10 || value < radiusInner)
                    {
                        throw new ArgumentException();
                    }
                    radiusOuter = value;
                }
            }
        }

        public Radius radius = new Radius();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = radius;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (radius.RadiusInner > 10 && radius.RadiusOuter > 10 && radius.RadiusOuter > radius.RadiusInner)
            {
                //radius.RadiusInner = 60;
                //radius.RadiusOuter = 120;
                this.Content = new ShootingPage((int)radius.RadiusInner, (int)radius.RadiusOuter);
                this.MinHeight = (int) radius.RadiusOuter * minSizeFactor;
                this.MinWidth = (int) radius.RadiusOuter * minSizeFactor + 200;
            }
            else 
            {
                MessageBox.Show("Radius must be greater than 10 and RadiusOuter greater than RadiusInner");
            }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            //MessageBox.Show(e.Error.ErrorContent.ToString());
        }

        private void tbxHinted1_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHint1.Visibility = Visibility.Visible;
            if (tbxEnterInnerRadius.Text.Length > 0)
            {
                txtHint1.Visibility = Visibility.Hidden;
            }
        }

        private void tbxHinted2_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHint2.Visibility = Visibility.Visible;
            if (tbxEnterOuterRadius.Text.Length > 0)
            {
                txtHint2.Visibility = Visibility.Hidden;
            }
        }
    }
}
