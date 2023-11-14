using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Views.Helpers
{
    public static class FileHelper
    {
        public static MvcHtmlString File(this HtmlHelper htmlHelper, string cssClassName)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("id", "Image");
            tag.MergeAttribute("name", "Photo");
            tag.MergeAttribute("class", cssClassName);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}