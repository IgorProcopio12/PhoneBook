using Administrador.Models;

namespace Administrador.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Alterar(ContatoModel contato);
        bool Deletar(int id);
    }
}
