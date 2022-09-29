using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eleicoes.Tests
{
    public class CandidatoTests
    {

            [Fact]
        public void Construtor_InstancializandoCandidatoComNome_RetornaMesmoNome()
        {
            var nomeCandidato = "Juliana";
            var candidato = new Candidato(nomeCandidato);
            Assert.Equal(nomeCandidato, candidato.Nome);
        }

        [Fact]
        public void Construtor_VotosQuandoInstanciaAClasse_RetornaVotoZerado()
        {
            var candidato = new Candidato("Robson");
            var votoEsperado = 0;
            Assert.Equal(votoEsperado, candidato.Votos);
        }


        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        public void AdcionarVoto_AdicionandoVotoParaCandidato_RetornaNumeroDeVezesQueAdicionouVoto(int quantidadeVotos)
        {
            var candidato = new Candidato("Robson");
            for(int i =0; i < quantidadeVotos; i++)
            {
                candidato.AdicionarVoto();
            }

            Assert.Equal(quantidadeVotos, candidato.Votos);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        public void RetornarVotos_VotosQueCandidatoRecebeu_RetornarVotosTotais(int quantidadeVotos)
        {
            var candidato = new Candidato("Robson");
            for (int i = 0; i < quantidadeVotos; i++)
            {
                candidato.AdicionarVoto();
            }

            Assert.Equal(quantidadeVotos, candidato.RetornarVotos());
        }
    }
}
