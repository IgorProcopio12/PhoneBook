using Administrador.Models;

namespace Administrador.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Alterar(UsuarioModel usuario);
        bool Deletar(int id);
    }
}
