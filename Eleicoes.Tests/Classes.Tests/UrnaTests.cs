using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Eleicoes.Tests
{
    public class UrnaTests
    {

        [Fact]
        public void Construtor_ValidarInformaçoes_RetornarValoresPadrao()
        {
            var urna = new Urna();
            var urnaEsperada = new Urna()
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false
            };

            Assert.Equal(urnaEsperada.VencedorEleicao, urna.VencedorEleicao);
            Assert.Equal(urnaEsperada.VotosVencedor, urna.VotosVencedor);
            Assert.Equal(urnaEsperada.Candidatos.Count, urna.Candidatos.Count);
            Assert.Equal(urnaEsperada.EleicaoAtiva, urna.EleicaoAtiva);
        }

        [Fact]
        public void IniciarEleicao_ValidarFuncionamento_RetornaEleicaoAtivaTrue()
        {
            var eleicaoAtiva = new Urna();
            eleicaoAtiva.IniciarEleicao();
            Assert.Equal(true, eleicaoAtiva.EleicaoAtiva);
        }

        [Fact]
        public void EncerrarEleicao_ValidarFuncionamento_RetornaEleicaoAtivaFalse()
        {
            var eleicaoAtiva = new Urna();
            eleicaoAtiva.IniciarEleicao();
            eleicaoAtiva.EncerrarEleicao();
            Assert.Equal(false, eleicaoAtiva.EleicaoAtiva);
        }

        [Theory]
        [InlineData("Ana")]
        [InlineData("Carolina")]
        public void CadastrarCandidato_Nome_RetornaMesmoNomeComoUltimoCadastrado(string nome)
        {
            var urna = new Urna();
            urna.CadastrarCandidato(nome);
            Assert.Equal(nome, urna.Candidatos.Last().Nome);
        }

        [Theory]
        [InlineData("Ana", "Carolina")]
        public void CadastrarCandidato_AdicionarNomes_RetornaUltimoNomeCadastrado(string nome, string nomeEsperado)
        {
            var urna = new Urna();
            urna.CadastrarCandidato(nome);
            urna.CadastrarCandidato(nomeEsperado);
            Assert.Equal(nomeEsperado, urna.Candidatos.Last().Nome);
        }

        [Fact]
        public void CadastrarCandidato_EleicaoAtivaTrue_RetornaFalse()
        {
            var urna = new Urna();
            urna.IniciarEleicao();
            var resultado = urna.CadastrarCandidato("Ana");
            Assert.False(resultado);
        }

        [Fact]
        public void Votar_EleicaoAtivaTrue_RetornaTrue()
        {
            var urna = new Urna();
            urna.CadastrarCandidato("Ana");
            urna.IniciarEleicao();
            var resultado = urna.Votar("Ana");
            Assert.True(resultado);
        }

        [Fact]
        public void Votar_EleicaoAtivaFalse_RetornaFalse()
        {
            var urna = new Urna();
            urna.CadastrarCandidato("Ana");
            var resultado = urna.Votar("Ana");
            Assert.False(resultado);
        }

        [Fact]
        public void Votar_EleicaoAtivaTrueAoCadastrarCandidato_RetornaFalse()
        {
            var urna = new Urna();
            urna.IniciarEleicao();
            urna.CadastrarCandidato("Ana");
            var resultado = urna.Votar("Ana");
            Assert.False(resultado);
        }

        [Fact]
        public void Votar_CandidatoInexistente_RetornaFalse()
        {
            var urna = new Urna();
            urna.IniciarEleicao();
            var resultado = urna.Votar("Roberto");
            Assert.False(resultado);
        }

        [Fact]
        public void Votar_CandidatoInexistenteEEleicaoNaoIniciada_RetornaFalse()
        {
            var urna = new Urna();
            var resultado = urna.Votar("Roberto");
            Assert.False(resultado);
        }

        [Fact]
        public void MostrarResultadoEleicao_CandidatosComvotosDiferentes_RetornaOGanhador()
        {
            var urna = new Urna();
            urna.CadastrarCandidato("Ana");
            urna.CadastrarCandidato("Julia");
            urna.IniciarEleicao();

            for(int i =0; i<3; i++)
            {
                urna.Votar("Ana");
            }
            for (int i = 0; i < 2; i++)
            {
                urna.Votar("Julia");
            }

            string resultadoEsperado = "Nome vencedor: Ana. Votos: 3";
            var resultado = urna.MostrarResultadoEleicao();
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void MostrarResultadoEleicao_EleicaoNaoIniciada_RetornaAvisoQueNaoEstavaEmEleicao()
        {
            var urna = new Urna();
            string resultadoEsperado = "Eleição não foi iniciada";
            var resultado = urna.MostrarResultadoEleicao();
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}