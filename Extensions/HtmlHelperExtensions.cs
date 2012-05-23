using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Illumination.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Renders a partial view to the response output for each item in an generic IEnumerable with additional HTML Formatting around each partial view.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="partialViewName">Name or location of the partial view</param>
        /// <param name="models">IEnumerable collection of models to be injected into the partial view</param>
        /// <param name="htmlFormat">String to determine the formatting of partial views around other HTML. The default {0} placeholder is to be used to reference the partial view. This allows you to wrap the result of each partial view with your own markup"</param>
        public static void RenderPartials<T>(this HtmlHelper helper, string partialViewName, IEnumerable<T> models, string htmlFormat)
        {
            if (models == null)
                return;

            foreach (var result in models.Select(item => helper.Partial(partialViewName, item)))
            {
                helper.ViewContext.Writer.Write(htmlFormat, result);
            }
        }

        public static void RenderPartials<T>(this HtmlHelper helper, string partialViewName, IEnumerable<T> models)
        {
            helper.RenderPartials(partialViewName, models, "{0}");
        }
    }
}
