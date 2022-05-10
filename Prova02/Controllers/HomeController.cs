using Microsoft.AspNetCore.Mvc;
using Prova02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(StringReverseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var texto = model.Texto;
                    var textoReverso = new string(texto.Reverse().ToArray());

                    TempData["texto"] = textoReverso;

                    if(texto.ToLower() == textoReverso.ToLower())
                    {
                        TempData["MensagemSucesso"] = "É um palíndromo!";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }
    }
}
