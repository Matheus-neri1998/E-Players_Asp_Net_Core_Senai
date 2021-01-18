using System;
using E_Players_Asp_Net_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_Asp_Net_Core_Senai.Controllers
{
        [Route("Jogador")]
    public class JogadorController : Controller
    {

        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Jogadores   = jogadorModel.ReadAll(); // passando informações do jogador
            ViewBag.Equipes     = equipeModel.ReadAll(); // passando informações de equipe
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador      = new Jogador();
            novoJogador.Idjogador    = Int32.Parse(form["Idjogador"]);
            novoJogador.Nome         = form["Nome"];
            novoJogador.Email        = form["Email"];
            novoJogador.Senha        = form["Senha"]; 

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            
            return LocalRedirect("~/Jogador");
        }
    } // fim de JogadorController

    

    
}