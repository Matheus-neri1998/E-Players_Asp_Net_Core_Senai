using System.Collections.Generic;
using E_Players_Asp_Net_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_Asp_Net_Core_Senai.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {

        [TempData]
        public string Mensagem { get; set; }
        
        
        Jogador jogadorModel = new Jogador();
        public IActionResult Index()
        {
            return View();        
        }

    [Route("Logar")]

            public IActionResult Logar(IFormCollection form)
        {
            // Lemos todos os arquivos do CSV
            List<string> csv = jogadorModel.ReadAllLinesCSV("Database/Jogador.csv");

            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[2] == form["Email"] && // verifica  se o email do csv é igual ao do form 
                x.Split(";")[3] == form["Senha"] // verifica se a senha do csv é igual ao do form
            );


            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                // Salvar a informação do nome na sessão
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/"); // caso encontre, será direcionado para home
            }

            Mensagem = "Dados incorretos, tente novamente!";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
            public IActionResult Logout()
            {
                HttpContext.Session.Remove("_UserName");
                return LocalRedirect("~/");
            }

    } // fim de LoginController
} 