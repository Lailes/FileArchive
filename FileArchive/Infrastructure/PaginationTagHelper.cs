using System;
using FileArchive.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FileArchive.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        [ViewContext] [HtmlAttributeNotBound] public ViewContext ViewContext { get; set; }

        public string SelectedButtonClass { get; set; }

        public string UnselectedButtonClass { get; set; }

        public PaginationInfo PageModel { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

        public string DivClass { get; set; }
        public string ButtonStartClass { get; set; }
        public string ButtonEndClass { get; set; }

        public string ButtonStyle { get; set; }
        public string ButtonStartStyle { get; set; }
        public string ButtonEndStyle { get; set; }

        public override void Process (TagHelperContext context, TagHelperOutput output)
        {
            var builder = new TagBuilder("div");
            var buttonTagBuilder = new TagBuilder("div");

            var page = PageModel.PageNumber;
            var pageCount = Math.Ceiling((double) PageModel.TotalItems / PageModel.ItemsPerPage);
            if (pageCount < 5)
            {
                for (var i = 1; i <= pageCount; i++)
                {
                    var tag = new TagBuilder("a");
                    tag.AddCssClass(i == page ? SelectedButtonClass : UnselectedButtonClass);
                    tag.Attributes["href"] = $"/{Controller}/{Action}/{i}";
                    tag.Attributes["style"] = ButtonStyle;
                    tag.InnerHtml.Append(i.ToString());
                    buttonTagBuilder.InnerHtml.AppendHtml(tag);
                }
            }
            else
            {
                var tagFirst = new TagBuilder("a");
                tagFirst.AddCssClass(1 == page ? SelectedButtonClass : ButtonStartClass);
                tagFirst.Attributes["href"] = $"/{Controller}/{Action}/1";
                tagFirst.Attributes["style"] = ButtonStartStyle;
                tagFirst.InnerHtml.AppendHtml("1");
                buttonTagBuilder.InnerHtml.AppendHtml(tagFirst);

                var tempStart = PageModel.PageNumber - 3;
                var tempEnd = PageModel.PageNumber + 3;
                var start = tempStart <= 1 ? 2 : tempStart;
                var end = tempEnd >= pageCount ? pageCount - 1 : tempEnd;

                for (var i = start; i <= end; i++)
                {
                    var tag = new TagBuilder("a");
                    tag.AddCssClass(i == page ? SelectedButtonClass : UnselectedButtonClass);
                    tag.Attributes["href"] = $"/{Controller}/{Action}/{i}";
                    tag.Attributes["style"] = ButtonStyle;
                    tag.InnerHtml.Append(i.ToString());
                    buttonTagBuilder.InnerHtml.AppendHtml(tag);
                }

                var lastTag = new TagBuilder("a");
                lastTag.AddCssClass(pageCount == page ? SelectedButtonClass : ButtonEndClass);
                lastTag.Attributes["href"] = $"/{Controller}/{Action}/{pageCount}";
                lastTag.Attributes["style"] = ButtonEndStyle;
                lastTag.InnerHtml.AppendHtml(pageCount.ToString());
                buttonTagBuilder.InnerHtml.AppendHtml(lastTag);
            }

            buttonTagBuilder.Attributes["style"] = "text-align:center;";
            builder.InnerHtml.AppendHtml(buttonTagBuilder);
            output.Content.AppendHtml(builder.InnerHtml);
        }
    }
}