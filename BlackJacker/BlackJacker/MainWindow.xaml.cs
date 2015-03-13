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

        public Boolean IsLoose { get; set; }

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
            JoueurNoSplit.Children.Clear();
            JoueurSplit.Children.Clear();
            Banque.Children.Clear();
            croupier.paquet.Initialiser();

            joueur.listSimple.Clear();
            joueur.listSplit.Clear();
            croupier.listSimple.Clear();

            CarteNoSplit.Visibility = Visibility.Visible;
            ResteNoSplit.Visibility = Visibility.Visible;
            SplitNoSplit.Visibility = Visibility.Visible;
            DoubleNoSplit.Visibility = Visibility.Visible;

            CarteSplit.Visibility = Visibility.Visible;
            DoubleSplit.Visibility = Visibility.Visible;

            if (Slider.Value > 0 && joueur.jeton > Slider.Value)
            {
                StackNoSplit.Visibility = Visibility.Visible;
                StackCroupier.Visibility = Visibility.Visible;
                Paquet.Visibility = Visibility.Visible;

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

                croupier.Distribuer(croupier, false);
                Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + croupier.listSimple[0].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                Banque.Children.Add(Img);

                ScoreBanqueSplit.Text = Utils.Instance.GetScore(croupier.listSimple).ToString();

                croupier.Distribuer(croupier, false);
                Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/data/img/cartes/back-blue-75-1.png"));
                Img.Width = 100;
                Img.Height = 100;
                Banque.Children.Add(Img);

                joueur.jeton -= int.Parse(ValueSlider.Text.ToString());
                MontantTotal.Text = joueur.jeton.ToString();

                ScoreNoSplit.Text = Utils.Instance.GetScore(joueur.listSimple).ToString();
                joueur.mise = int.Parse(ValueSlider.Text.ToString());
                BetNoSplit.Text = ValueSlider.Text.ToString();

                Start.Visibility = Visibility.Collapsed;
            }

            else MessageBox.Show("Le montant de votre pari doit être supérieur à 0 €");
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void CarteNoSplit_Click(object sender, RoutedEventArgs e)
        {
            SplitNoSplit.Visibility = Visibility.Collapsed;
            DoubleNoSplit.Visibility = Visibility.Collapsed;

            croupier.Distribuer(joueur, false);

            Image Img = new Image();
            Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + joueur.listSimple[joueur.listSimple.Count - 1].pathImage));
            Img.Width = 100;
            Img.Height = 100;
            JoueurNoSplit.Children.Add(Img);

            int newScore = Utils.Instance.GetScore(joueur.listSimple);

            ScoreNoSplit.Text = newScore.ToString();

            if (newScore > 21) // fin de partie
            {
                MessageBox.Show("Vous avez perdu cette partie.");

                CarteNoSplit.Visibility = Visibility.Collapsed;
            }
        }

        private void Reste()
        {
            Banque.Children.RemoveAt(Banque.Children.Count - 1);

            Image Img = new Image();
            Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + croupier.listSimple[1].pathImage));
            Img.Width = 100;
            Img.Height = 100;
            Banque.Children.Add(Img);

            while (Utils.Instance.GetScore(croupier.listSimple) < 17)
            {
                croupier.Distribuer(croupier, false);
                Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + croupier.listSimple[croupier.listSimple.Count - 1].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                Banque.Children.Add(Img);
            }

            ScoreBanqueSplit.Text = Utils.Instance.GetScore(croupier.listSimple).ToString();
            String message = "";
            if (Utils.Instance.PlayerWin(croupier, joueur) > 0)
            {
                message = "Felicitation, vous avez gagner la partie";
            }

            else
            {
                message = "Vous avez perdu la partie";
            }


            if (MessageBox.Show(message + Environment.NewLine + "Voulez-vous recommencer la partie ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Utils.Instance.UpdatePartie(croupier, joueur);
                StackNoSplit.Visibility = Visibility.Collapsed;
                StackSplit.Visibility = Visibility.Collapsed;
                StackCroupier.Visibility = Visibility.Collapsed;
                Paquet.Visibility = Visibility.Collapsed;

                Start.Visibility = Visibility.Visible;

                MontantTotal.Text = joueur.jeton.ToString();
            }

            else
            {
                Application.Current.Shutdown();
            }
        }

        private void ResteNoSplit_Click(object sender, RoutedEventArgs e)
        {
            Reste();
        }

        private void SplitNoSplit_Click(object sender, RoutedEventArgs e)
        {
            if (joueur.Split())
            {
                StackSplit.Visibility = Visibility.Visible;

                joueur.jeton -= int.Parse(ValueSlider.Text.ToString());
                MontantTotal.Text = joueur.jeton.ToString();

                ScoreSplit.Text = Utils.Instance.GetScore(joueur.listSimple).ToString();
                ScoreNoSplit.Text = Utils.Instance.GetScore(joueur.listSplit).ToString();

                BetSplit.Text = BetNoSplit.Text;

                JoueurNoSplit.Children.RemoveAt(JoueurNoSplit.Children.Count - 1);

                Image Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + joueur.listSplit[0].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                JoueurSplit.Children.Add(Img);

                SplitNoSplit.Visibility = Visibility.Collapsed;
            }

            else
            {
                MessageBox.Show("Les deux cartes ne sont pas identiques");
            }
        }

        private void DoubleNoSplit_Click(object sender, RoutedEventArgs e)
        {
            if (joueur.jeton > int.Parse(ValueSlider.Text.ToString()))
            {
                joueur.mise += int.Parse(ValueSlider.Text.ToString());
                joueur.jeton -= int.Parse(ValueSlider.Text.ToString());
                BetNoSplit.Text = (int.Parse(BetNoSplit.Text.ToString()) * 2).ToString();

                MontantTotal.Text = joueur.jeton.ToString();

                DoubleNoSplit.Visibility = Visibility.Collapsed;
            }

            else
            {
                MessageBox.Show("Vous n'avez pas assez de jeton pour pouvoir doubler.");
            }
        }

        private void CarteSplit_Click(object sender, RoutedEventArgs e)
        {
            DoubleSplit.Visibility = Visibility.Collapsed;

            croupier.Distribuer(joueur, true);

            Image Img = new Image();
            Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + joueur.listSplit[joueur.listSplit.Count - 1].pathImage));
            Img.Width = 100;
            Img.Height = 100;
            JoueurSplit.Children.Add(Img);

            int newScore = Utils.Instance.GetScore(joueur.listSplit);

            ScoreSplit.Text = newScore.ToString();

            if (newScore > 21) // fin de partie
            {
                MessageBox.Show("Vous avez perdu cette partie.");
                CarteSplit.Visibility = Visibility.Collapsed;
            }
        }

        private void DoubleSplit_Click(object sender, RoutedEventArgs e)
        {
            if (joueur.jeton > int.Parse(ValueSlider.Text.ToString()))
            {
                joueur.mise += int.Parse(ValueSlider.Text.ToString());
                joueur.jeton -= int.Parse(ValueSlider.Text.ToString());
                BetSplit.Text = (int.Parse(BetSplit.Text.ToString()) * 2).ToString();

                MontantTotal.Text = joueur.jeton.ToString();

                DoubleSplit.Visibility = Visibility.Collapsed;
            }

            else
            {
                MessageBox.Show("Vous n'avez pas assez de jeton pour pouvoir doubler.");
            }
        }
    }
}
