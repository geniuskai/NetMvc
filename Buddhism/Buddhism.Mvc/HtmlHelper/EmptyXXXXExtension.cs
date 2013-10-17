using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Html
{
    public static class EmptyXXXXExtension
    {
        public static MvcHtmlString EmptyTFootIf(this HtmlHelper htmlHelper, int colspan, bool b)
        {
            if (!b)
            {
                return MvcHtmlString.Empty;
            }
            string format = "<tfoot>\r\n    <tr>\r\n        <td colspan=\"{0}\" class=\"empty\">无</td>\r\n    </tr>\r\n</tfoot>";
            return MvcHtmlString.Create(string.Format(format, colspan));
        }
        public static MvcHtmlString EmptyTrIf(this HtmlHelper htmlHelper, int colspan, bool b)
        {
            if (!b)
            {
                return MvcHtmlString.Empty;
            }
            string format = "<tr>\r\n    <td colspan=\"{0}\" class=\"empty\">无</td>\r\n</tr>";
            return MvcHtmlString.Create(string.Format(format, colspan));
        }
    }
}
