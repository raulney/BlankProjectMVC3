using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Web.Mvc;
using NUnit.Framework;

namespace Blank.Tests.Helpers.MVC
{
    public static class Support
    {
        public static TModel Model<TModel>(this ActionResult result)
        {
            Assert.IsInstanceOf<ViewResultBase>(result, "The action result is not a view result type");
            ViewResultBase viewResult = (ViewResultBase)result;
            Assert.IsNotNull(viewResult.ViewData.Model, "The action result does not contain a model");
            Assert.IsInstanceOf<TModel>(viewResult.ViewData.Model, "The model in the action result is not of the right type");
            return (TModel)viewResult.ViewData.Model;
        }

        public static string JsonResult(this ActionResult result)
        {
            Assert.IsInstanceOf<JsonResult>(result, "The action result is not a view result type");
            JsonResult jsonResult = (JsonResult)result;
            return jsonResult.Data.ToString();
        }

        public static dynamic ViewBag(this ActionResult result)
        {
            Assert.IsInstanceOf<ViewResultBase>(result, "The action result is not a view result type");
            ViewResultBase viewResult = (ViewResultBase)result;
            Assert.IsNotNull(viewResult.ViewBag);
            return viewResult.ViewBag;
        }

    }
}
