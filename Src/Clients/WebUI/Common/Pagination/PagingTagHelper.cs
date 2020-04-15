using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamProject.Clients.WebUI.Common.Pagination.Models;

namespace TeamProject.Clients.WebUI.Common.Pagination
{
    public static class PagingTagHelper
    {
        public static IHtmlContent PagingButtons(this IHtmlHelper html, PagingInfo info)
        {
            string result = null;
            for (var i = 1; i <= info.TotalPages; i++)
            {
                var tag = new TagBuilder("div");
                tag.MergeAttribute("class", "btn btn-primary switchPage");
                tag.MergeAttribute("page-id", i.ToString());
                tag.InnerHtml.Append(i.ToString());
                if (i == info.CurrentPage) tag.AddCssClass("selected");

                result += GetString(tag);
            }

            return new HtmlString(result);
        }

        private static string GetString(IHtmlContent content)
        {
            using var writer = new StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}