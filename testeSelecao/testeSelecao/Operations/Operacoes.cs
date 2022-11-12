using testeSelecao.Models;

namespace testeSelecao.Operations
{
    public class Operacoes
    {
        public async Task<bool> InserirNovaConta(Conta novaConta)
        {
            try
            {
                using (var db = new ContaContext())
                {
                    db.Contas.Add(novaConta);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Conta>> SelecionarConta(string conta)
        {
            try
            {
                using (var db = new ContaContext())
                {
                    var contas = db.Contas.Where(w => w.nome.ToLower().Contains(conta)).ToList();
                    return contas;
                }
            }
            catch
            {
                return new List<Conta>();
            }
        }

        public async Task<bool> AtualizarConta(Conta conta)
        {
            try
            {
                using (var db = new ContaContext())
                {
                    var contaAtualizada = db.Contas.First(f => f.idConta == conta.idConta);
                    contaAtualizada.nome = conta.nome;
                    contaAtualizada.descricao = conta.descricao;
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<Conta> DeletarConta(Conta conta)
        {
            try
            {
                using (var db = new ContaContext())
                {
                    var contaApagada = db.Contas.First(f => f.idConta == conta.idConta);
                    db.Contas.Remove(contaApagada);
                    await db.SaveChangesAsync();
                    return contaApagada;
                }
            }
            catch
            {
                return new Conta();
            }
        }
    }
}
