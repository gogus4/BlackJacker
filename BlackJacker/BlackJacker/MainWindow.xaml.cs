﻿using BlackJacker.Model;
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
        public Boolean isDoubled { get; set; }
        public Boolean isDouble { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            joueur = new Joueur();
            croupier = new Croupier();

            Restart.IsEnabled = false;

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

            DoubleNoSplit.IsEnabled = true;
            SplitNoSplit.IsEnabled = true;

            CarteSplit.Visibility = Visibility.Visible;

            if (Slider.Value > 0 && joueur.jeton >= int.Parse(ValueSlider.Text.ToString()))
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

                if (joueur.listSimple[0].nom != joueur.listSimple[1].nom)
                    SplitNoSplit.IsEnabled = false;

                if (joueur.jeton < joueur.mise)
                    DoubleNoSplit.IsEnabled = false;
            }

            else
            {
                SplitNoSplit.Visibility = Visibility.Collapsed;
                ResteNoSplit.Visibility = Visibility.Collapsed;

                if (int.Parse(ValueSlider.Text.ToString()) > joueur.jeton)
                {
                    MessageBox.Show("Vous n'avez pas assez d'argent");
                }

                else
                    MessageBox.Show("Le montant de votre pari doit être supérieur à 0 €");
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void CarteNoSplit_Click(object sender, RoutedEventArgs e)
        {
            SplitNoSplit.Visibility = Visibility.Collapsed;
            DoubleNoSplit.Visibility = Visibility.Collapsed;

            if (isDoubled && isDouble)
            {
                MessageBox.Show("Vous ne pouvez pas demander de cartes car vous avez doublé.");
                return;
            }

            isDoubled = true;

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
                if (!joueur.isSplit)
                {
                    Reste();
                }

                else
                    MessageBox.Show("Vous avez perdu cette partie.");

                CarteNoSplit.Visibility = Visibility.Collapsed;
            }
        }

        private void Reste()
        {
            SplitNoSplit.Visibility = Visibility.Collapsed;
            ResteNoSplit.Visibility = Visibility.Collapsed;

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
                message = "Felicitation, vous avez gagné la partie";
            }

            else
            {
                message = "Vous avez perdu la partie";
            }

            if (MessageBox.Show(message + Environment.NewLine + "Voulez-vous recommencer la partie ?", "Recommencer", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
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

            if (joueur.jeton < 2)
            {
                Restart.IsEnabled = true;
            }
        }

        private void ResteNoSplit_Click(object sender, RoutedEventArgs e)
        {
            Reste();
        }

        private void SplitNoSplit_Click(object sender, RoutedEventArgs e)
        {
            if (joueur.Split() == 0)
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

                if (joueur.jeton < joueur.mise)
                    DoubleNoSplit.IsEnabled = false;
            }

            else if (joueur.Split() == 1)
            {
                MessageBox.Show("Les deux cartes ne sont pas identiques.");
            }

            else
            {
                MessageBox.Show("Vous n'avez pas assez d'argent.");
            }
        }

        private void DoubleNoSplit_Click(object sender, RoutedEventArgs e)
        {
            if (joueur.jeton >= int.Parse(ValueSlider.Text.ToString()))
            {
                joueur.mise += int.Parse(ValueSlider.Text.ToString());
                joueur.jeton -= int.Parse(ValueSlider.Text.ToString());
                BetNoSplit.Text = (int.Parse(BetNoSplit.Text.ToString()) * 2).ToString();

                MontantTotal.Text = joueur.jeton.ToString();

                DoubleNoSplit.Visibility = Visibility.Collapsed;

                croupier.Distribuer(joueur, false);
                Image Img = new Image();
                Img.Source = new BitmapImage(new Uri("pack://application:,,,/BlackJacker;component/" + joueur.listSimple[joueur.listSimple.Count - 1].pathImage));
                Img.Width = 100;
                Img.Height = 100;
                JoueurNoSplit.Children.Add(Img);

                ScoreNoSplit.Text = Utils.Instance.GetScore(joueur.listSimple).ToString();

                Reste();
            }

            else
            {
                MessageBox.Show("Vous n'avez pas assez de jeton pour pouvoir doubler.");
            }
        }

        private void CarteSplit_Click(object sender, RoutedEventArgs e)
        {
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

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            if (joueur.jeton < 2)
            {
                joueur.jeton = 100;
                MontantTotal.Text = joueur.jeton.ToString();
            }

            else
                MessageBox.Show("Vous avez assez d'argent pour faire au moins une partie.");
        }
    }
}
