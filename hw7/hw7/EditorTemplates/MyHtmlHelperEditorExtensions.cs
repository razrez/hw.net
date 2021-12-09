using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            var modelProperties = helper.ViewData.ModelMetadata.ModelType.GetProperties();
            var model = helper.ViewData.Model;
            
            IHtmlContentBuilder htmlRes = new HtmlContentBuilder();

            foreach (var property in modelProperties)
            {
                htmlRes.AppendHtml(AddHtmlContent(property, model));
            }
                
            return htmlRes;
        }

        private static IHtmlContent AddHtmlContent(this PropertyInfo property, object model)
        {
            var div1 = new TagBuilder("div");
            div1.MergeAttribute("class","col-12-");
            div1.InnerHtml.AppendHtml(CreateLabel(property));
            div1.InnerHtml.AppendHtml(CreateInput(property, model));
            // эта хуйня нужна, если данные не валидны, тогда появляется [2] inner
            div1.InnerHtml.AppendHtml(Validate(property, model));
            //var page = new StringBuilder("<div class='col-12'><label for='inputEmail4' class='form-label'>Эл. адрес</label><input type='email' class='form-control' id='inputEmail4' placeholder='email'></div>");
            return div1;
        }


        private static IHtmlContent CreateLabel(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
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
            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    {"class", "form-control"},
                    {"id", property.Name},
                    {"name", property.Name},
                    {"type", property.PropertyType.IsNumeric() ? "number" : "text"},
                    {"value", model is not null ? property.GetValue(model)?.ToString() ?? "" : ""}
                }
            };
            
            return input;
        }
        
        public static IHtmlContent CreateSubmit(this IHtmlHelper helper, string name, string value)
        {
            var btn = new StringBuilder("<div class='col-12'><input type='submit' class='btn btn-primary' name='"
                                        + name + "' value='" + value + "'/></div>") ;
            return new HtmlString(btn.ToString());
        }
        
        public static IHtmlContent Validate(PropertyInfo propertyInfo, object model)
        {
            if (model is null) return null;
            
            var attributes = propertyInfo.GetCustomAttributes<ValidationAttribute>();
            return (from attr in attributes let value = propertyInfo.GetValue(model) 
                where !attr.IsValid(value) let span = new TagBuilder("span")
                {
                    Attributes =
                    {
                        { "class", "field-validation-error" }, { "data-replace", "true" }, { "data-for", "propertyInfo.Name" }
                    }
                } 
                select span.InnerHtml.Append(attr.ErrorMessage ?? attr.FormatErrorMessage(propertyInfo.Name)!)).FirstOrDefault();
        }
    }

    public static class SupportedTypes
    {
        public static readonly Type[] IntegerT =
        {
            typeof(int), typeof(long)
        };

        public static readonly Type[] NullIntegerT =
        {
            typeof(int?), typeof(long?)
        };
        public static readonly Type[] DoubleDecimal =
        {
            typeof(double), typeof(decimal)
        };
        public static readonly Type[] NullDoubleDecimal =
        {
            typeof(double?), typeof(decimal?)
        };
        public static readonly Type[] Integers =
        {
            typeof(int), typeof(long)
        };

        public static bool IsNumeric(this Type mytype)
        {
            return IntegerT.Concat(DoubleDecimal).Contains(mytype) ||
                   NullIntegerT.Concat(NullDoubleDecimal).Contains(mytype)
        ;
        }
    }
}