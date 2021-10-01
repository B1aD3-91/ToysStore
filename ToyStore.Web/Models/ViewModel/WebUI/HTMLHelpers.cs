using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace ToysStore.Web.Models.WebUI
{
    public static class HTMLHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            int i = 1;

            TagBuilder pagger = new TagBuilder("ul");
            pagger.AddCssClass("pagination");
            pagger.MergeAttribute("id", "PageUI");

            for (; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                if (i == pagingInfo.CurrentPage)
                {
                    li.AddCssClass("active");
                }

                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");
                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml.SetContent(i.ToString());

                li.InnerHtml.Append(a.ToString());
                pagger.InnerHtml.Append(li.ToString());
            }
            return new HtmlString(pagger.ToString());
        }

    }
}