using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using TeamProject.Clients.WebUI.Common.Pagination.Models;

namespace TeamProject.Clients.WebUI.Common.Pagination
{
    //public class PagingTagHelper : TagHelper
    //{
    //    PagingInfo info;
    //    public PagingTagHelper(PagingInfo _info)
    //    {
    //        info = _info;
    //    }
    //    public override  void Process(TagHelperContext context,TagHelperOutput output)
    //    {
    //        for (int i = 1; i <= info.TotalPages; i++)
    //        {
    //            output.TagName = "div";
    //            output.Attributes.SetAttribute("class", "btn btn-primary switchPage");
    //            output.Attributes.SetAttribute("page-id", i.ToString());
    //            output.Content.SetContent(i.ToString());
    //            if (i == info.CurrentPage)
    //            {
    //                output.Attributes.SetAttribute("selected", null);
    //            }
    //        }               

    //    }
    public static class PagingTagHelper
    {
        public static IHtmlContent PagingButtons(this IHtmlHelper html, PagingInfo info)
        {
            //string tmp = null;
            string result = null;
            for (int i = 1; i <= info.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("div");
                tag.MergeAttribute("class", "btn btn-primary switchPage");
                tag.MergeAttribute("page-id", i.ToString());
                tag.InnerHtml.Append(i.ToString());
                if (i == info.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                result += GetString(tag);
            }
            return new HtmlString(result);

        }

        private static string GetString(IHtmlContent content)
        {
            using var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}

