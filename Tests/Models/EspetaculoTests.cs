﻿using System;
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

        [Test]
        public void NaoDeveCriarSessoesQuandoDataInicioIgualADataFimEhAPeriodicidadeEhSemanal()
        {
            Espetaculo ironMaiden = new Espetaculo();

            var dateInicioFim = new DateTime();

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicioFim, dateInicioFim, Periodicidade.SEMANAL);

            Assert.AreEqual(0, sessoes.Count());
        }

        [Test]
        public void DeveCriarApenas1SessaoQuandoDataInicioIgualADataFimEhAPeriodicidadeEhSemanal()
        {
            Espetaculo ironMaiden = new Espetaculo();

            var dateInicioFim = new DateTime();

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicioFim, dateInicioFim, Periodicidade.SEMANAL);

            Assert.AreEqual(0, sessoes.Count());
        }

        [Test]
        public void DeveCriarApenas1SessaoQuandoDataInicioIgualADataFimEhAPeriodicidadeEhDiaria()
        {
            Espetaculo ironMaiden = new Espetaculo();

            var dateInicioFim = new DateTime();

            IList<Sessao> sessoes = ironMaiden.CriaSessoes(dateInicioFim, dateInicioFim, Periodicidade.DIARIA);

            Assert.AreEqual(1, sessoes.Count());
        }

        //[Test]
        //public void DeveCriar2Sess

        private Sessao SessaoComIngressosSobrando(int quantidade)
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = quantidade * 2;
            sessao.IngressosReservados = quantidade;

            return sessao;
        }
    }
}
