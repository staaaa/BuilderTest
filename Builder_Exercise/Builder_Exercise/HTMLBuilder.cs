using System;
namespace Builder_Exercise
{
    public class HTMLBuilder
    {
        private readonly HTML _html = new HTML();

        public HTMLBuilder Boilerplate()
        {
            _html.code = @"
<!DOCTYPE html>\n
<html lang = ""pl"">
    <head>
        <meta charset = ""UTF-8"">";
            return this;
        }

        public HTMLBuilder Title(string tagContent)
        {
            _html.code += GetWholeTag("title", tagContent, "");
            return this;
        }

        public HTMLBuilder CloseHeadOpenBody()
        {
            _html.code += 
    @"
    </head>
    <body>";
            return this;
        }

        public HTMLBuilder Append(string tagName, string tagContent, string tagAttr)
        {
            _html.code += GetWholeTag(tagName, tagContent, tagAttr);
            return this;
        }

        public HTMLBuilder AppendWithChildrens(string tagName, params string[] Tags)
        {
            _html.code += GetBeginingOfTag(tagName);
            foreach(string p in Tags)
            {
                _html.code += p;
            }
            _html.code += GetEndOfTag(tagName);
            return this;
        }

        public HTMLBuilder CloseHtml()
        {
            _html.code += @"
    </body>
</html>";
            return this;
        }

        public string GetWholeTag(string tagName, string tagContent, string tagAttr)
        {
            
            return "\n\t"+$" <{tagName}{tagAttr}>{tagContent}</{tagName}>";
        }

        private string GetBeginingOfTag(string tagName)
        {
            return "\n\t" + $"<{tagName}>";
        }

        private string GetEndOfTag(string tagName)
        {
            return "\n\t" + $"</{tagName}>";
        }

        public string ShowCode()
        {
            return _html.code;
        }
    }
}
