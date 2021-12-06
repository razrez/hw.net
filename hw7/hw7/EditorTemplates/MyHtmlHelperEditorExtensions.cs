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
            var typeModel = htmlHelper.ViewData.Model.GetType();
            IHtmlContentBuilder htmlRes = new HtmlContentBuilder();
            var model = htmlHelper.ViewData.Model;
            foreach (var property in typeModel.GetProperties())
                AddHtmlContent(htmlRes, property, model);
                //model нужна для сравнения и определения типа инпута
            return htmlRes;
        }

        private static void AddHtmlContent(IHtmlContentBuilder htmlRes, PropertyInfo property, object model)
        {
            throw new NotImplementedException();
        }

        public static IHtmlContent CreateSubmit(this IHtmlHelper helper, string name, string value)
        {
            var btn = new StringBuilder("<input type='submit' class='btn btn-primary' name='" + name + "' value='" + value + "'/>") ;
            return new HtmlContentBuilder();
        }
    }
}