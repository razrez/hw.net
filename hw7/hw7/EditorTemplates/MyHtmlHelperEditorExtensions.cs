using System;
using System.ComponentModel;
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
                htmlRes.AppendHtml(AddHtmlContent(property, model));
            return htmlRes;
        }

        private static string AddHtmlContent(PropertyInfo property, object model)
        {
            var div1 = new TagBuilder("div");
            div1.MergeAttribute("class","col-12-");
            div1.InnerHtml.AppendHtml(CreateLabel(property));//для Label нужно толкьо название свойства
            div1.InnerHtml.AppendHtml(CreateInput(property, model));// но для правильного input нужна искомая модель
            var page = new StringBuilder("<div class='col-12'><label for='inputEmail4' class='form-label'>Эл. адрес</label><input type='email' class='form-control' id='inputEmail4' placeholder='email'></div>");
            return page.ToString();
        }

        

        private static IHtmlContent CreateLabel(PropertyInfo property)
        {
            var label = new TagBuilder("label")
            {
                Attributes =
                {
                    {"for", property.Name},
                    {"class", "form-label"}
                }
                
            };
            label.InnerHtml.AppendLine(DisplayName(property));
            return label;
        }

        private static string DisplayName(MemberInfo prop)
        {
            var displayName = prop.GetCustomAttribute<DisplayNameAttribute>();
            return displayName is null ? SplitByCamelCase(prop.Name) : displayName.DisplayName;
        }
        
        private static string SplitByCamelCase(string str)
        {
            return str
                .Skip(1)
                .Aggregate($"{str.FirstOrDefault()}",
                    (current, symbol) => current + (char.IsUpper(symbol) ? $" {symbol}" : symbol));
        }

        private static IHtmlContent CreateInput(PropertyInfo property, object model)
        {
            throw new NotImplementedException();
        }
        
        public static IHtmlContent CreateSubmit(this IHtmlHelper helper, string name, string value)
        {
            var btn = new StringBuilder("<div class='col-12'><input type='submit' class='btn btn-primary' name='"
                                        + name + "' value='" + value + "'/></div>") ;
            return new HtmlString(btn.ToString());
        }
    }
}