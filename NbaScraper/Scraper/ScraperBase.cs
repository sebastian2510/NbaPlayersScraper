using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaScraper.Scraper
{
    internal abstract class ScraperBase
    {
        public HtmlDocument GetHtmlDocument(string url)
        {
            try
            {
                return new HtmlWeb().Load(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
