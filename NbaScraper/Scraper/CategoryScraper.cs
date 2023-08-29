using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace NbaScraper.Scraper
{
    internal class CategoryScraper : ScraperBase
    {
        private HtmlNode GetTableNode(HtmlDocument doc)
        {
            try
            {
                // Get this node: <thead class="Table__header-group Table__THEAD">
                return doc.DocumentNode.SelectSingleNode("//thead[@class='Table__header-group Table__THEAD']");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private HtmlNode GetTableTr(HtmlNode node)
        {
            try
            {
                // Get this node: <tr class="Table__TR Table__even">
                return node.SelectSingleNode("tr[@class='Table__TR Table__even']");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private HtmlNode GetTableTh(HtmlNode node)
        {
            try
            {
                // Get this node: <th class="Table__TH">GP</th>
                return node.SelectSingleNode("th[@class='Table__TH']");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private HtmlNode GetTableSpan(HtmlNode node)
        {
            try
            {
                // Get this node: <span class="fw-medium w-100 dib underline tar stats-cell" title="Games Played">GP</span>
                Console.WriteLine($"node-null {node is null}");
                return node.SelectSingleNode("span[@class=\"fw-medium w-100 dib underline tar stats-cell\"]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private HtmlNode GetTableAnchor(HtmlNode node)
        {
            try
            {
                Console.WriteLine($"node-null: {node is null}");
                // Get this node: <a class="AnchorLink clr-gray-01">GP</a>
                return node.SelectSingleNode("a");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private string GetAnchorInnerText(HtmlNode node)
        {
            try
            {
                return node.InnerText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private int GetTableTrCount(HtmlNode node)
        {
            try
            {
                return node.SelectNodes("tr").Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        // Create a main function that calls all of the above functions
        public List<string> GetCategoryNames(string url)
        {
            HtmlDocument doc = GetHtmlDocument(url);
            HtmlNode tableNode = GetTableNode(doc);
            int trCount = GetTableTrCount(tableNode);
            List<string> categories = new();

            for (var i = 0; i < trCount; i++)
            {
                var trNode = tableNode.SelectSingleNode($"tr[{i + 1}]");
                var thNode = GetTableTh(trNode);
                var spanNode = GetTableSpan(thNode);
                var anchorNode = GetTableAnchor(spanNode);
                var name = GetAnchorInnerText(anchorNode);
                // Console.WriteLine($"[{i}] {name}");
                categories.Add(name);
            }
            return categories;
        }
    }
}
