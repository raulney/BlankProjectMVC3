using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blank.Domain.Security.Models;
using Blank.Domain.Security.Repositories.Abstract;
using Blank.Infrastructure.Validation.Abstract;
using Blank.Infrastructure.Messages;
using MvcContrib;
using MvcContrib.Filters;
using Blank.Domain.Security.Attributes;

namespace Blank.Application.Controllers
{
    [ControleProtegido("Grupos", "Grupos de acesso")]
    public class GruposController : Controller
    {

        private IGrupos grupos;
        private IValidator validator;

        public GruposController(IGrupos grupos, IValidator validator)
        {
            this.grupos = grupos;
            this.validator = validator;
        }
        
        [HttpGet]
        [MetodoProtegido("Index", "Página inicial")]
        public ActionResult Index(Grupo grupo = null)
        {
            
            if (grupo == null || grupo.EstaVazio())
            {
                return View();
            }
            else
            {
                return View("_Resultado", this.grupos.ListaPorNomePorDescricaoInatividade(grupo));
            }
            
        }

        [HttpGet]
        [MetodoProtegido("Novo", "Botão 'Novo'")]
        public ActionResult Novo()
        {
             return View();
        }

        [HttpGet]
        [MetodoProtegido("Edita", "Link de edição de um determinado grupo de acesso")]
        public ActionResult Edita(short id)
        {
            return View(this.grupos.BuscaPorIdentificador(id));
        }

        [HttpPost]
        [MetodoProtegido("Insere", "Botão para cadastrar um novo grupo de acesso")]
        public ActionResult Insere(Grupo grupo) {

            this.validator.Validates(grupo);
            this.validator.OnValidationErrorRedirectTo<GruposController>(g => g.Novo());
            
            try
            {
                this.grupos.Insere(grupo);
                TempData["mensagem"] = new Message().Of(MessageType.SUCCESS).Containing("Grupo cadastrado com sucesso");
                return this.RedirectToAction(c => c.Index(null));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                TempData["mensagem"] = new Message().Of(MessageType.ERROR).Containing("Grupo não pode ser cadatrado verifique se já existe outro grupo com este nome");
                return this.RedirectToAction(c => c.Novo());
            }

        }

        [HttpPost]
        [MetodoProtegido("Atualiza", "Botão para atualizar um determinado grupo de acesso")]
        public ActionResult Atualiza(Grupo grupo)
        {
            this.validator.Validates(grupo);
            this.validator.OnValidationErrorRedirectTo<GruposController>(g => g.Edita(grupo.Id));
            try
            {
                this.grupos.Atualiza(grupo);
                TempData["mensagem"] = new Message().Of(MessageType.SUCCESS).Containing("Grupo atualizado com sucesso");
                return this.RedirectToAction(c => c.Index(null));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                TempData["mensagem"] = new Message().Of(MessageType.ERROR).Containing("Grupo não pode ser atualizado verifique se já existe outro grupo com este nome");
                return this.RedirectToAction(c => c.Edita(grupo.Id));

            }
        }


        [HttpPost]
        [MetodoProtegido("Ativa", "Link para ativar determinado grupo de acesso")]
        public ActionResult Ativa(short id)
        {
            try
            {
                this.grupos.Reativa(this.grupos.BuscaPorIdentificador(id));
                return Json(new { status = "OK", mensagem = "Grupo reativado com sucesso" });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return Json(new { status = "ERRO", mensagem = "Não foi possível reativar este grupo"});
            }

        }

        [HttpPost]
        [MetodoProtegido("Inativa", "Link para inativar determinado grupo de acesso")]
        public ActionResult Inativa(short id)
        {
            try
            {
                this.grupos.Inativa(this.grupos.BuscaPorIdentificador(id));
                return Json(new { status = "OK", mensagem = "Grupo inativado com sucesso" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return Json(new { status = "ERRO", mensagem = "Não foi possível inativar este grupo" });
            }

        }

    }
}
