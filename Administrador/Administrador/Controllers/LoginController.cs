using Administrador.Models;
using Administrador.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Administrador.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarLogin(model.Login);

                    if (usuario != null && usuario.ValidaSenha(model.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["MensagemErro"] = "Usuário ou Senha incorretos!";
                }
                TempData["MensagemErro"] = "Usuário ou Senha incorretos!";
                return View("Index");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Efetuar Login! " + err.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
