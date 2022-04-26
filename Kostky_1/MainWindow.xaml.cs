using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kostky_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Kostka[] kostky = new Kostka[6];
        Kostka[] kostky = new Kostka[]
        {
            new Kostka(),
            new Kostka(),
            new Kostka(),
            new Kostka(),
            new Kostka(),
            new Kostka()
        };

        public MainWindow()
        {
            InitializeComponent();
            ZobrazKostky();
            k1.Fill = new ImageBrush(GetImage(Properties.Resources.dice_one));
            Grid.SetRow(k1, 1);
            Grid.SetColumn(k1, 1);
        }
        private ImageSource GetImage(byte[] resouce)
        {
            MemoryStream memoryStream = new MemoryStream(resouce);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }

        private void ZobrazKostky()
        {
            ZobrazKostku(k1, kostky[0].Hodnota);
            kostka2.Content = kostky[1].Hodnota;
            kostka3.Content = kostky[2].Hodnota;
            kostka4.Content = kostky[3].Hodnota;
            kostka5.Content = kostky[4].Hodnota;
            kostka6.Content = kostky[5].Hodnota;


        }
        private void ZobrazKostku(Rectangle rectangle, int cislo)
        {
            if(cislo == 1)
            {
             rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_one));
            }
            else if (cislo == 2)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_two));
            }
            else if (cislo == 3)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_three));
            }
            else if (cislo == 4)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_four));
            }
            else if (cislo == 5)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_five));
            }
            else if (cislo == 6)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_six));
            }



        }

        private void btnHod_Click(object sender, RoutedEventArgs e)
        {
            foreach (var kostka in kostky)
            {
                kostka.Hod();
            }
            ZobrazKostky();
        }
        private int SpocitejBody()
        {
            int body = 0;
            Dictionary<int, int> pocty = new Dictionary<int, int>();
            pocty.Add(1, 0);
            pocty.Add(2, 0);
            pocty.Add(3, 0);
            pocty.Add(4, 0);
            pocty.Add(5, 0);
            pocty.Add(6, 0);

            foreach (var kostka in kostky)
            {
                pocty[kostka.Hodnota]++;
            }
            return body;
        }
    }
}
