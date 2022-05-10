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
        //Kostka[] kostky = new Kostka[6]; - taky moznost udelat kostky
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
            ZobrazKostku(k2, kostky[1].Hodnota);
            ZobrazKostku(k3, kostky[2].Hodnota);
            ZobrazKostku(k4, kostky[3].Hodnota);
            ZobrazKostku(k5, kostky[4].Hodnota);
            ZobrazKostku(k6, kostky[5].Hodnota);
            //kostka2.Content = kostky[1].Hodnota;
            //kostka3.Content = kostky[2].Hodnota;
            //kostka4.Content = kostky[3].Hodnota;
            //kostka5.Content = kostky[4].Hodnota;
            //kostka6.Content = kostky[5].Hodnota;


        }
        private void ZobrazKostku(Rectangle rectangle, int cislo)
        {
            if (cislo == 1)
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
            lbl_body.Content = $"Body: {SpocitejBody(kostky)}";
        }
        private int SpocitejBody(Kostka[] kostky)
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
            if (pocty.ContainsValue(6)) //neceho je 6
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 6).Key;
                if (kostka == 1)
                {
                    body = 8000;
                }
                else
                {
                    body = kostka * 800;
                }
            }
            else if (pocty.ContainsValue(5)) //neceho je 5
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 5).Key;
                if (kostka == 1)
                {
                    body = 4000;
                    body += 50 * pocty[5];

                }
                else
                {
                    body = kostka * 400;
                    body += 100 * pocty[1];
                    body += 50 * pocty[5];


                }
            }
            else if (pocty.ContainsValue(4)) //neceho je 4
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 4).Key;
                if (kostka == 1) //pokud jsou 4 jednicky
                {
                    body = 2000;
                    body += 50 * pocty[5];

                }
                else
                {
                    body = kostka * 200;
                    body += 100 * pocty[1];
                    body += 50 * pocty[5];


                }
            }
            else if (pocty.ContainsValue(3)) //neceho je 3
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 3).Key;
                if (kostka == 1)//jsou 3 jednicky
                {
                    body = 1000;

                }
                else
                {
                    body = kostka * 100;
                }
                int pocetTrojic = 0;
                foreach(var pocet in pocty)
                {
                    pocetTrojic++;   
                }
            }
            return body;
        }
        public int Po
    }

