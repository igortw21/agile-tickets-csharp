using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileTickets.Web.Models;

namespace Tests.Models
{
    [TestFixture]
    public class SessaoTest
    {
        [Test]
        public void DeveVender1IngressoSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsTrue(sessao.PodeReservar(1));
        }

        [Test]
        public void NaodeveVender3IngressoSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsFalse(sessao.PodeReservar(3));
        }

        [Test]
        public void ReservarIngressosDeveDiminuirONumeroDeIngressosDisponiveis()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 5;

            sessao.Reserva(3);
            Assert.AreEqual(2, sessao.IngressosDisponiveis);
        }

        [Test]
        public void DeveVender2IngressosSeHa2Vagas() 
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsTrue(sessao.PodeReservar(2));
        }

        [Test]
        public void DeveVender10IngressosSeHa10Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 10;

            Assert.IsTrue(sessao.PodeReservar(10));
        }

        [Test]
        public void DeveVender200IngressosSeHa200Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 200;

            Assert.IsTrue(sessao.PodeReservar(200));
        }

        [Test]
        public void DeveVender10IngressosSeHa100Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 100;

            Assert.IsTrue(sessao.PodeReservar(10));
        }

        [Test]
        public void DeveVender1IngressoSeHa10Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 10;

            Assert.IsTrue(sessao.PodeReservar(1));
        }

        [Test]
        public void NaoDeveVender10IngressosSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsFalse(sessao.PodeReservar(10));
        }

        [Test]
        public void NaoDeveVender500IngressosSeHa200Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 200;

            Assert.IsFalse(sessao.PodeReservar(500));
        }
    }
}
