using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileTickets.Web.Models;

namespace Tests.Models
{
    [TestFixture]
    public class EspetaculoTests
    {
        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoes()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(1));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsTrue(ivete.PossuiVagas(5));
        }

        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeExataDeIngressosDentroDeQualquerDasSessoes()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(1));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsTrue(ivete.PossuiVagas(6));
        }

        [Test]
        public void DeveInformarSeNaoEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoes()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(1));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsFalse(ivete.PossuiVagas(15));
        }

        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoesComUmMinimoPorSessao()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(4));

            Assert.IsTrue(ivete.PossuiVagas(5, 3));
        }

        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeExataDeIngressosDentroDeQualquerDasSessoesComUmMinimoPorSessao()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(4));

            Assert.IsTrue(ivete.PossuiVagas(10, 3));
        }

        [Test]
        public void DeveInformarSeNaoEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoesComUmMinimoPorSessao()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsFalse(ivete.PossuiVagas(5, 3));
        }

        #region CriarSessoes

        [Test]
        public void NaoDeveCriarSessoesQuandoDataInicioIgualADataFimEhAPeriodicidadeEhSemanal()
        {
            Espetaculo ironMaiden = new Espetaculo();

            var dateInicioFim = new DateTime();

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicioFim, dateInicioFim, Periodicidade.SEMANAL);

            Assert.AreEqual(1, sessoes.Count());
        }

        [Test]
        public void DeveCriarApenas1SessaoQuandoDataInicioIgualADataFimEhAPeriodicidadeEhDiaria()
        {
            Espetaculo ironMaiden = new Espetaculo();

            var dateInicioFim = new DateTime();

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicioFim, dateInicioFim, Periodicidade.DIARIA);

            Assert.AreEqual(1, sessoes.Count());
        }

        [Test]
        public void DeveCriar3SessoesQuandoDataFimEh2DiasDepoisDeDataInicioEhAPeriodicidadeEhDiaria()
        {
            Espetaculo ironMaiden = new Espetaculo();

            DateTime dateInicio = new DateTime();
            DateTime dataFim = dateInicio.AddDays(2);

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicio, dataFim, Periodicidade.DIARIA);

            Assert.AreEqual(3, sessoes.Count());
        }

        [Test]
        public void DeveCriar2SessoesQuandoDataFimEh8DiasDepoisDeDataInicioEhAPeriodicidadeEhSemanal()
        {
            Espetaculo ironMaiden = new Espetaculo();

            DateTime dateInicio = new DateTime();
            DateTime dataFim = dateInicio.AddDays(8);

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicio, dataFim, Periodicidade.SEMANAL);

            Assert.AreEqual(2, sessoes.Count());
        }

        [Test]
        public void DeveCriar1SessaoQuandoDataFimEh6DiasDepoisDeDataInicioEhAPeriodicidadeEhSemanal()
        {
            Espetaculo ironMaiden = new Espetaculo();

            DateTime dateInicio = new DateTime();
            DateTime dataFim = dateInicio.AddDays(6);

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicio, dataFim, Periodicidade.SEMANAL);

            Assert.AreEqual(1, sessoes.Count());
        }

        [Test]
        public void DevePreencherSessoesComDadosDoEspetaculo()
        {
            Espetaculo ironMaiden = SetUpEstabelecimento();

            DateTime dataInicio = new DateTime();
            DateTime dataFim = dataInicio;

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dataInicio, dataFim, Periodicidade.DIARIA);

            Assert.AreEqual(1, sessoes.Count());

            VerificarEstabelecimento(sessoes[0].Espetaculo);
        }

        private Espetaculo SetUpEstabelecimento()
        {
            Espetaculo ironMaiden = new Espetaculo();
            ironMaiden.Id = 1;
            ironMaiden.Descricao = "Metal!!!";
            ironMaiden.Estabelecimento = new Estabelecimento();
            ironMaiden.Estabelecimento.Id = 1;
            ironMaiden.Estabelecimento.Nome = "Citibank Hall";
            ironMaiden.Estabelecimento.Endereco = "Rua ABCD";
            return ironMaiden;
        }

        private void VerificarEstabelecimento(Espetaculo espetaculo)
        {
            Assert.AreEqual(1, espetaculo.Id);
            Assert.AreEqual("Metal!!!", espetaculo.Descricao);
            Assert.AreEqual(1, espetaculo.Estabelecimento.Id);
            Assert.AreEqual("Citibank Hall", espetaculo.Estabelecimento.Nome);
            Assert.AreEqual("Rua ABCD", espetaculo.Estabelecimento.Endereco);
        }

        #endregion       

        private Sessao SessaoComIngressosSobrando(int quantidade)
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = quantidade * 2;
            sessao.IngressosReservados = quantidade;

            return sessao;
        }
    }
}
