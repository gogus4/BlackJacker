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
        public Joueur joueur { get; set; }
        public Croupier croupier { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
