using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Biblioteca
    {
        private string _nome;
        private string _indirizzo;
        private TimeOnly _orarioApertura, _orarioChiusura;
        private Dictionary<string, Libro> _libri = new();
        private Dictionary<string, List<Libro>> _autori = new();

        public Biblioteca(string nome, string indirizzo, TimeOnly orarioApertura, TimeOnly orarioChiusura)
        {
            _nome = nome;
            _indirizzo = indirizzo;
            _orarioApertura = orarioApertura;
            _orarioChiusura = orarioChiusura;
        }

        public string Nome { get => _nome; set => _nome = value; }
        public string Indirizzo { get => _indirizzo; set => _indirizzo = value; }
        public TimeOnly OrarioApertura { get => _orarioApertura; set => _orarioApertura = value; }
        public TimeOnly OrarioChiusura { get => _orarioChiusura; set => _orarioChiusura = value; }

        public void aggiungiLibro(Libro libro)
        {
            if (_libri.ContainsKey(libro.Titolo)) throw new ArgumentException("Titolo libro duplicato");
            _libri[libro.Titolo] = libro;
            if (!_autori.ContainsKey(libro.Autore)) _autori[libro.Autore] = new();
            _autori[libro.Autore].Add(libro);
        }

        public Libro? cercaLibro(string titolo)
        {
            if (!_libri.ContainsKey(titolo)) return null;
            return _libri[titolo];
        }
    }
}
