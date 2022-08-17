using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TagHelpersSamples.TagHelpers
{

    //HTML.AnyMethode -> Sind Erweiterungsmethoden 
    //Erweiterungsmethoden werden in einer static class und in einer static Methode implementiert
    public static class MyHTMLHelper
    {
        public static IHtmlContent HelloWorldHTMLString (this IHtmlHelper htmlHelper)
        {
            return new HtmlString("<strong>Hello World</strong>");
        }

        public static string HelloWorldString(this IHtmlHelper htmlHelper)
        {
            return "<strong>Hello World</strong>";
        }

        public static IHtmlContent HelloWorld(this IHtmlHelper htmlHelper, string name)
        {
            TagBuilder span = new TagBuilder(tagName: "span");
            span.InnerHtml.Append("Hello " + name);

            TagBuilder br = new TagBuilder("br") { TagRenderMode = TagRenderMode.SelfClosing }; // <br/>

            string result;

            using (var writer = new StringWriter())
            {
                span.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

                result = writer.ToString();
            } //writer.Dispose() -> Objekt wird danach abgeräumt


            return new HtmlString(result);
        }

    }
}
