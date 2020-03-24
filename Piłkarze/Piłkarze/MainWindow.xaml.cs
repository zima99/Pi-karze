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


namespace Piłkarze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Piłkarz> listaPiłkarzy = new List<Piłkarz>();
        


        public MainWindow()
        {
           
            InitializeComponent();
            WiekPetla();
            ListaPiłkarzy();
            
        }
        private void WiekPetla()
        {
            for (int i = 16; i <=50; i++)
            {
                wiek_cb.Items.Add(i.ToString());
            }
            wiek_cb.Text = "16";
            wiek_cb.SelectedItem = 16;
        }

        private void ListaPiłkarzy()
        {
            List<string> piłkarze = File.ReadAllLines("piłkarze.txt", Encoding.Default).ToList();
            foreach (string piłkarz in piłkarze)
            {
                string[] tmp = piłkarz.Split(',');
                listaPiłkarzy.Add(new Piłkarz(tmp[0], tmp[1], Int32.Parse(tmp[2]), Int32.Parse(tmp[3])));

            }
            listapilkarzy_lb.ItemsSource = listaPiłkarzy;
        }

        private void waga_sl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            if (waga_wyswietlana != null)
            {
                waga_wyswietlana.Content = waga_sl.Value;
            }
        }

        private bool gf1 = false;
        private bool gf2 = false;

        private void Reset()
        {
            listapilkarzy_lb.Items.Refresh();
            imie_tb.Text = "Wpisz imię: ";
            nazwisko_tb.Text = "Wpisz nazwisko: ";
            imie_tb.BorderThickness = new Thickness(1);
            nazwisko_tb.BorderThickness = new Thickness(1);
            imie_tb.Foreground = Brushes.Gray;
            nazwisko_tb.Foreground = Brushes.Gray;
            imie_tb.BorderBrush = Brushes.Gray;
            nazwisko_tb.BorderBrush = Brushes.Gray;
            wiek_cb.SelectedItem = 16;
            wiek_cb.Text = "16";
            waga_sl.Value = 50;
            gf1 = false;
            gf2 = false;
            listapilkarzy_lb.UnselectAll();
        }

        private void dodaj_btn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(imie_tb.Text) == false && String.IsNullOrEmpty(nazwisko_tb.Text) == false && gf1 == true && gf2 == true)
            {
                listaPiłkarzy.Add(new Piłkarz(imie_tb.Text, nazwisko_tb.Text, Int32.Parse(wiek_cb.Text), (int)waga_sl.Value));
                Reset();
            }
        }

        private void usun_btn_Click(object sender, RoutedEventArgs e)
        {
            if(listapilkarzy_lb.SelectedItem!=null)
            {
                listaPiłkarzy.RemoveAt(listapilkarzy_lb.SelectedIndex);
                Reset();
            }
        }

        private void modyfikuj_btn_Click(object sender, RoutedEventArgs e)
        {
            if(listapilkarzy_lb.SelectedItem != null)
            {
                listaPiłkarzy[listapilkarzy_lb.SelectedIndex].Imie = imie_tb.Text;
                listaPiłkarzy[listapilkarzy_lb.SelectedIndex].Nazwisko = nazwisko_tb.Text;
                listaPiłkarzy[listapilkarzy_lb.SelectedIndex].Wiek = Int32.Parse(wiek_cb.Text);
                listaPiłkarzy[listapilkarzy_lb.SelectedIndex].Waga = (int)waga_sl.Value;
                Reset();
            }
        }

        private void imie_tb_gf(object sender, RoutedEventArgs e)
        {
            if (gf1== false)
            {
                imie_tb.Clear();
                imie_tb.Foreground = Brushes.Black; gf1 = true;
               
            }
            imie_tb.BorderBrush = Brushes.Black;
            imie_tb.BorderThickness = new Thickness(1.5);
        }

        private void imie_tb_lf(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(imie_tb.Text) == false)
            {
                imie_tb.BorderBrush = Brushes.Gray;
                imie_tb.BorderThickness = new Thickness(1);
                imie_tb.ClearValue(ToolTipProperty);
            }
            else
            {
                imie_tb.ToolTip = "Należy wpisać imię";
                imie_tb.BorderBrush = Brushes.Red;
                imie_tb.BorderThickness = new Thickness(1.5);
            }
        }

        private void nazwisko_tb_gf(object sender, RoutedEventArgs e)
        {
          if (gf2 == false)
          {
                nazwisko_tb.Clear();
                nazwisko_tb.Foreground = Brushes.Black; gf2 = true;

          }
            nazwisko_tb.BorderBrush = Brushes.Black;
            nazwisko_tb.BorderThickness = new Thickness(1.5);
        }
        private void nazwisko_tb_lf(object sender, RoutedEventArgs e)
        { 
            if (String.IsNullOrEmpty(nazwisko_tb.Text)==false)
            {
                nazwisko_tb.BorderBrush = Brushes.Gray;
                nazwisko_tb.BorderThickness = new Thickness(1);
                nazwisko_tb.ClearValue(ToolTipProperty);
            }
            else
            {
                nazwisko_tb.BorderBrush = Brushes.Red;
                nazwisko_tb.BorderThickness = new Thickness(1.5);
                nazwisko_tb.ToolTip = "Należy wpisać nazwisko";

            }
        }

        private void listapilkarzy_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedItem != null)
            {
                imie_tb.Text = listaPiłkarzy[lb.SelectedIndex].Imie;
                nazwisko_tb.Text = listaPiłkarzy[lb.SelectedIndex].Nazwisko;
                wiek_cb.Text = listaPiłkarzy[lb.SelectedIndex].Wiek.ToString();
                wiek_cb.SelectedItem = listaPiłkarzy[lb.SelectedIndex].Wiek;
                waga_sl.Value = listaPiłkarzy[lb.SelectedIndex].Waga;

                imie_tb.BorderBrush = Brushes.Gray;
                nazwisko_tb.BorderBrush = Brushes.Gray;
                imie_tb.Foreground = Brushes.Black;
                nazwisko_tb.Foreground = Brushes.Black;
                imie_tb.BorderThickness = new Thickness(1);
                nazwisko_tb.BorderThickness = new Thickness(1);
                gf1 = true;
                gf2 = true;
            }
        }
        

        private void zamkniecieProgramu(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using(StreamWriter wr = new StreamWriter("piłkarze.txt"))
            {
                foreach (Piłkarz piłkarz in listaPiłkarzy)
                {
                    wr.WriteLine($"{piłkarz.Imie},{piłkarz.Nazwisko},{piłkarz.Wiek},{piłkarz.Waga}");
                }
            }
        }
    } }


