using System;
using System.Text;
using System.Web.Mvc;

namespace MvcShop.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static string PageLinks(this HtmlHelper htmlHelper, int currentPage, int totalPages, Func<int,string> pageUrl)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= totalPages; i++)
            {
                var tag= new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i==currentPage) tag.AddCssClass("selected");
                sb.AppendLine(tag.ToString());
            }
            return sb.ToString();
        }
    }
}