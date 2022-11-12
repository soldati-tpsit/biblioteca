using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Libro
    {
        private string _editore;
        private string _autore;
        private string _titolo;
        private int _annoPubblicazione;
        private int _numeroPagine;

        public Libro(string editore, string autore, string titolo, int annoPubblicazione, int numeroPagine)
        {
            _editore = editore;
            _autore = autore;
            _titolo = titolo;
            _annoPubblicazione = annoPubblicazione;
            _numeroPagine = numeroPagine;
        }

        public string Editore { get => _editore; set => _editore = value; }
        public string Autore { get => _autore; set => _autore = value; }
        public string Titolo { get => _titolo; set => _titolo = value; }
        public int AnnoPubblicazione { get => _annoPubblicazione; set => _annoPubblicazione = value; }
        public int NumeroPagine { get => _numeroPagine; set => _numeroPagine = value; }

        public int readingTime() => NumeroPagine / 100 + 1;

        public string toString() => string.Format("Editore: {1}{0}Autore: {2}{0}Titolo: {3}{0}Anno di pubblicazione: {4}{0}Numero di pagine: {5}{0}",
            Environment.NewLine, Editore, Titolo, AnnoPubblicazione, NumeroPagine);
    }
}
