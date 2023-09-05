﻿using Administrador.Models;
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
    }
}