using System;
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
            // кароче мне нужно получить все поля и в зависимости от типа данных, правильно их преобразовать
            // привет, рефлексия
            
            return null;
        }
    }
}