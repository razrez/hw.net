using System;
using System.Linq;
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
            
            var type = htmlHelper.ViewData.ModelMetadata.ModelType;
            var tagbuilder = new TagBuilder("li");
            //tagbuilder.Attributes.Ad
            return null;
        }
        public static IHtmlContent CreateSubmit(this IHtmlHelper helper, string name, string value)
        {
            var btn = new StringBuilder("<input type='submit' class='btn btn-primary' name='" + name + "' value='" + value + "'/>") ;
            return new HtmlString(btn.ToString());
        }
    }
}