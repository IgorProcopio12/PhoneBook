using Administrador.Data;
using Administrador.Models;

namespace Administrador.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Alterar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) throw new Exception("Erro ao alterar usuario");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;  
            usuarioDB.DataAlteracao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel BuscarLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new Exception("Erro ao alterar usuario");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
