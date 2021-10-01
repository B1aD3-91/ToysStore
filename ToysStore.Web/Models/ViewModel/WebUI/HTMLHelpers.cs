using System;
using System.Web.Mvc;

namespace ToysStore.Web.Models.WebUI
{
    public static class HTMLHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
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
                a.InnerHtml = i.ToString();

                li.InnerHtml += a.ToString();
                pagger.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(pagger.ToString());
        }

    }
}