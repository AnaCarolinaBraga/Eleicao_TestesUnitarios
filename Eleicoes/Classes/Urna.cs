using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleicoes
{
    public class Urna
    {
        public string? VencedorEleicao { get; set; }
        public int VotosVencedor { get; set; }
        public List<Candidato>? Candidatos { get; set; }
        public bool EleicaoAtiva { get; set; }

        public Urna()
        {
            VencedorEleicao = "";
            VotosVencedor = 0;
            Candidatos = new List<Candidato>();
            EleicaoAtiva = false;
        }

        public void IniciarEleicao()
        {
            EleicaoAtiva = true;
        }

        public void EncerrarEleicao()
        {
            EleicaoAtiva = false;
        }

        public bool CadastrarCandidato(string nome)
        {
            if (!string.IsNullOrEmpty(nome) && !EleicaoAtiva)
            {
                Candidato candidato = new Candidato(nome);
                Candidatos.Add(candidato);
                return true;
            }

            return false;
        }

        public bool Votar(string nome)
        {
            var candidatoEscolhido = Candidatos.Where(c => c.Nome.ToUpper() == nome.ToUpper()).FirstOrDefault();

            if (candidatoEscolhido is not null && EleicaoAtiva)
            {
                candidatoEscolhido.AdicionarVoto();
                return true;
            }

            return false;
        }

        public string MostrarResultadoEleicao()
        {
            if(!EleicaoAtiva)
            {
                return "Eleição não foi iniciada";
            }
            var vencedor = Candidatos.OrderByDescending(c => c.RetornarVotos()).ThenBy(c => c.Nome).FirstOrDefault();

            return $"Nome vencedor: {vencedor.Nome}. Votos: {vencedor.Votos}";
        }
    }
}
