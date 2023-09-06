using Administrador.Models;
using Administrador.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Administrador.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Cadastrar Usuário! " + err.Message;
                return RedirectToAction("Index");
            }

        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel? usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil,

                    };

                    _usuarioRepositorio.Alterar(usuario);
                    TempData["MensagemSucesso"] = "Usuário Alterado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Alterar Usuário! " + err.Message;
                return RedirectToAction("Index");

            }
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);  
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                if (_usuarioRepositorio.Deletar(id))
                {
                    TempData["MensagemSucesso"] = "Usuário Excluído com Sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao Excluir Usuário! ";
                }

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Alterar Usuário! " + err.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
