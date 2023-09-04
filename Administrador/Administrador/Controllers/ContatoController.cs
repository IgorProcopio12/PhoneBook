using Administrador.Models;
using Administrador.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Administrador.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Cadastrar Contato! " + err.Message;
                return RedirectToAction("Index");
            }

        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Alterar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Alterar Contato! " + err.Message;
                return RedirectToAction("Index");

            }
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                if (_contatoRepositorio.Deletar(id))
                {
                    TempData["MensagemSucesso"] = "Contato Excluído com Sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao Excluir Contato! ";
                }

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = "Erro ao Alterar Contato! " + err.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
