using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using System.Text;

namespace System.Web.Mvc.Html
{
    public static class ScriptRenderHelp
    {
        private const string SCRIPTBLOCK_BUILDER = "ScriptBlockBuilder";


        public static MvcHtmlString ScriptBlock(this HtmlHelper htmlHelper, Func<dynamic, HelperResult> template)
        {
            var context = htmlHelper.ViewContext.HttpContext;

            if (!context.Request.IsAjaxRequest())
            {
                var scriptBuilder = context.Items[SCRIPTBLOCK_BUILDER] as StringBuilder ?? new StringBuilder();

                scriptBuilder.Append(template(null).ToHtmlString());
                context.Items[SCRIPTBLOCK_BUILDER] = scriptBuilder;

                return new MvcHtmlString(string.Empty);
            }

            return new MvcHtmlString(template(null).ToHtmlString());
        }

        public static MvcHtmlString ScriptBlock(this HtmlHelper htmlHelper, string template)
        {
            var context = htmlHelper.ViewContext.HttpContext;

            if (!context.Request.IsAjaxRequest())
            {
                var scriptBuilder = context.Items[SCRIPTBLOCK_BUILDER] as StringBuilder ?? new StringBuilder();

                scriptBuilder.Append(new MvcHtmlString(template).ToHtmlString());
                context.Items[SCRIPTBLOCK_BUILDER] = scriptBuilder;

                return new MvcHtmlString(string.Empty);
            }

            return new MvcHtmlString(new MvcHtmlString(template).ToHtmlString());
        }

        public static MvcHtmlString WriteScriptBlocks(this HtmlHelper htmlHelper)
        {
            var scriptBuilder = htmlHelper.ViewContext.HttpContext.Items[SCRIPTBLOCK_BUILDER] as StringBuilder ?? new StringBuilder();

            return new MvcHtmlString(scriptBuilder.ToString());
        }

        public static string Script(this UrlHelper instance, string scriptFileName)
        {
            const string Path = "~/Scripts/";
            return instance.Content(Path + scriptFileName + ".js");
        }

    }
}