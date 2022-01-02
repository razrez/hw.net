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
            var div1 = new TagBuilder("div")
            {
                Attributes =
                {
                    {"class", "col"}
                }
            };
            div1.InnerHtml.AppendHtml(CreateLabel(property));
            
            var div2 = new TagBuilder("div");
            div2.InnerHtml
                .AppendHtml
                (
                    property.PropertyType.IsEnum ?
                    CreateDropDown(property, model) : CreateInput(property, model)
                );
            div1.InnerHtml.AppendHtml(div2);
            
            var validationRes = Validate(property, model);
            if (validationRes != null)
            {
                div1.InnerHtml.AppendHtml(validationRes);
                div1.InnerHtml.AppendHtml("<br/>");
            }
                
            return div1;
        }
        /// ////////////////

        private static IHtmlContent CreateDropDown(PropertyInfo property, object model)
        {
            var select = new TagBuilder("select")
            {
                Attributes =
                {
                    {"id", property.Name},
                    {"name", property.Name}
                }
            };

            var value = model is not null ? property.GetValue(model) : 0;
            var fieldInfos = property
                .PropertyType
                .GetFields(BindingFlags.Public | BindingFlags.Static);
            
            foreach (var fieldInfo in fieldInfos)
            {
                var option = CreateVariation(fieldInfo, value);
                select.InnerHtml.AppendHtml(option);
            }

            return select;
        }

        private static IHtmlContent CreateVariation(FieldInfo fieldInfo, object value)
        {
            //enum
            var declaringType = fieldInfo.DeclaringType;
            var option = new TagBuilder("option")
            {
                Attributes =
                {
                    {"value", fieldInfo.Name}
                }
            };
            
            if (fieldInfo.GetValue(declaringType)?.Equals(value) ?? false)
                option.MergeAttribute("selected", "true");
            
            option.InnerHtml.AppendHtmlLine(DisplayName(fieldInfo));
            return option;
        }

        /// ///////////////////
 
        private static IHtmlContent CreateLabel(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            var label = new TagBuilder("label")
            {
                Attributes =
                {
                    {"for", property.Name},
                    {"class", "col-lg-1 col-sm-2 col-form-label"}
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
        

        private static IHtmlContent Validate(PropertyInfo propertyInfo, object model)
        {
            if (model is null) return null;
            
            var attributes = propertyInfo.GetCustomAttributes<ValidationAttribute>();
            return (from attr in attributes let value = propertyInfo.GetValue(model) 
                where !attr.IsValid(value) let span = new TagBuilder("span")
                {
                    Attributes =
                    {
                        { "class", "invalid-feedback" }, { "data-replace", "true" }, { "data-for", "propertyInfo.Name" }
                    }
                } 
                select span.InnerHtml.Append(attr.ErrorMessage ?? attr.FormatErrorMessage(propertyInfo.Name)!)).FirstOrDefault();
        }
    }

    public static class SupportedTypes
    {
        private static readonly Type[] IntegerT =
        {
            typeof(int), typeof(long)
        };

        private static readonly Type[] NullIntegerT =
        {
            typeof(int?), typeof(long?)
        };

        private static readonly Type[] DoubleDecimal =
        {
            typeof(double), typeof(decimal)
        };

        private static readonly Type[] NullDoubleDecimal =
        {
            typeof(double?), typeof(decimal?)
        };

        public static bool IsNumeric(this Type mytype)
        {
            return IntegerT.Concat(DoubleDecimal).Contains(mytype) ||
                   NullIntegerT.Concat(NullDoubleDecimal).Contains(mytype)
        ;
        }
    }
}