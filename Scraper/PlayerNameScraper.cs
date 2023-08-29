using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;
using NbaScraper.Scraper;

namespace NbaScraper
{
    internal class PlayerNameScraper : ScraperBase
    {

        public List<string> GetPLayerNames(string url)
        {
            HtmlDocument doc = GetHtmlDocument(url);
            HtmlNode tableNode = GetTableNode(doc);
            int trCount = GetTableTrCount(tableNode);

            var players = new List<string>();

            for (var i = 0; i < trCount; i++)
            {
                HtmlNode trNode = tableNode.SelectSingleNode($"tr[{i + 1}]");
                HtmlNode tdNode = GetTableTd(trNode);
                HtmlNode spanNode = GetTableSpan(tdNode);
                HtmlNode anchorNode = GetTableAnchor(spanNode);
                players.Add(GetAnchorInnerText(anchorNode));
            }
            return players;
        }

        private HtmlNode GetTableNode(HtmlDocument doc)
        {
            try
            {
                return doc.DocumentNode.SelectSingleNode("//tbody[@class='Table__TBODY']"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private HtmlNode GetTableTd(HtmlNode node)
        {
            try
            {
                return node.SelectSingleNode("td[@class='Table__TD']");
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
                return node.SelectSingleNode("span");
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
                return node.InnerHtml;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        private int GetTableTrCount(HtmlNode node)
        {
            return node.SelectNodes("tr").Count - 1; // -1 because last tr is total
        }
    }
}

