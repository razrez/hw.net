using System;
using System.Linq;
using System.Reflection;
using System.Text;
using hw7.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hw7.wwwroot
{
    public static class MyHtmlHelperEditorExtensions
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }
            //var typeModel = htmlHelper.ViewData.Model.GetType();
            IHtmlContentBuilder htmlRes = new HtmlContentBuilder();
            //var model = htmlHelper.ViewData.Model;
            //foreach (var property in typeModel.GetProperties())
                //htmlRes.AppendHtml(AddHtmlContent(property, model));
                //model нужна для сравнения и определения типа инпута
            return htmlRes.AppendHtml(AddHtmlContent());
        }

        private static string AddHtmlContent()//PropertyInfo property, object model
        {
            var page = new StringBuilder("<div class='col-md-6'><label for='inputEmail4' class='form-label'>Эл. адрес</label><input type='email' class='form-control' id='inputEmail4' placeholder='email'></div>");
            return page.ToString();
        }

        public static IHtmlContent CreateSubmit(this IHtmlHelper helper, string name, string value)
        {
            var btn = new StringBuilder("<div class='col-12'><input type='submit' class='btn btn-primary' name='" + name + "' value='" + value + "'/></div>") ;
            return new HtmlString(btn.ToString());
        }
    }
}