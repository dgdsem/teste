using testeSelecao.Models;
using testeSelecao.Operations;

namespace unittest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Operacoes operacoes = new Operacoes();
            Conta novaConta = new Conta();
            novaConta.idConta = 0;
            novaConta.nome = "ContaUnitTest";
            novaConta.descricao = "Conta Unit Test";
            var aux = operacoes.InserirNovaConta(novaConta);
            Assert.AreEqual(true, aux.Result);
        }
    }
}