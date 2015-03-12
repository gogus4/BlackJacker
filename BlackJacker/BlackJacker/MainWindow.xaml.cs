using BlackJacker.Model;
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

namespace BlackJacker
{
    public partial class MainWindow : Window
    {
        private MainWindow _instance { get; set; }
        public MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();

                return _instance;
            }
        }

        public Joueur joueur { get; set; }
        public Croupier croupier { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            joueur = new Joueur();
            croupier = new Croupier();

            MontantTotal.Text = joueur.jeton.ToString();

            _instance = this;
        }

        public void Init()
        {
            
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (Slider.Value > 0)
            {
                StackNoSplit.Visibility = Visibility.Visible;
                StackCroupier.Visibility = Visibility.Visible;

                croupier.Distribuer(joueur, false);
                Image Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + joueur.listSimple[0].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                JoueurNoSplit.Children.Add(Img);

                croupier.Distribuer(joueur, false);
                Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + joueur.listSimple[1].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                JoueurNoSplit.Children.Add(Img);

                JoueurNoSplit.UpdateLayout();

                croupier.Distribuer(croupier, false);
                Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + croupier.listSimple[0].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                Banque.Children.Add(Img);
                
                croupier.Distribuer(croupier, false);
                Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/data/img/cartes/back-blue-75-1.png"));
                Img.Width = 100;
                Img.Height = 100;
                Banque.Children.Add(Img);   
            }

            else MessageBox.Show("Le montant de votre pari doit être supérieur à 0 €");
        }
    }
}
