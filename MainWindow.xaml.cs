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

namespace BibliotecaScuola
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Biblioteca> _biblioteche = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAggiungiBiblioteca_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca b = new(txtNomeBiblioteca.Text, txtIndirizzoBiblioteca.Text, TimeOnly.Parse(txtAperturaBiblioteca.Text), TimeOnly.Parse(txtChiusuraBiblioteca.Text));
            _biblioteche[b.Nome] = b;
            lstBiblioteche.Items.Add(b.Nome);
        }

        private bool checkSelection()
        {
            if (lstBiblioteche.SelectedItem == null)
            {
                MessageBox.Show("Selezionare una biblioteca!");
                return false;
            }
            return true;
        }

        private void btnAggiungiLibro_Click(object sender, RoutedEventArgs e)
        {
            if (!checkSelection()) return;
            Libro l = new(txtEditoreLibroIns.Text, txtAutoreLibroIns.Text, txtTitoloLibroIns.Text, int.Parse(txtAnnoLibroIns.Text), int.Parse(txtPagineLibroIns.Text));
            _biblioteche[(string)lstBiblioteche.SelectedItem].aggiungiLibro(l);
        }

        private void btnCercaTitolo_Click(object sender, RoutedEventArgs e)
        {
            if (!checkSelection()) return;
            MessageBox.Show(_biblioteche[(string)lstBiblioteche.SelectedItem].cercaLibro(txtTitoloLibroCerca.Text).toString());
        }

        private void btnCercaAutore_Click(object sender, RoutedEventArgs e)
        {
            if (!checkSelection()) return;
            foreach (Libro l in _biblioteche[(string)lstBiblioteche.SelectedItem].trovaLibriAutore(txtAutoreLibroCerca.Text))
            {
                MessageBox.Show(l.toString());
            }
        }

        private void btnNumeroLibri_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_biblioteche[(string)lstBiblioteche.SelectedItem].NumeroLibri.ToString());
        }
    }
}
