using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleicoes
{
    public class Candidato
    {
        public string Nome;
        public int Votos;

        public Candidato(string nome)
        {
            this.Nome = nome;
            Votos = 0;
        }

        public int AdicionarVoto()
        {
            Votos++;
            return Votos;
        }

        public int RetornarVotos()
        {
            return Votos;
        }
    }
}
