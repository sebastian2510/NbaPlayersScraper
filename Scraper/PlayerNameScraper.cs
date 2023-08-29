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
                // Console.WriteLine($"[{i}] {name}");
                players.Add(GetAnchorInnerText(anchorNode));
            }
            return players;
        }

        private HtmlNode GetTableNode(HtmlDocument doc)
        {
            try
            {
                // Console.WriteLine("Finding tbody");
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
                // Console.WriteLine($"Finding td | {node == null}");

                // Get the td with class name 'Table__TD'
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
                // Console.WriteLine($"Finding span | {node == null}");

                // Get the span without a class inside of the td with class name 'Table__TD'
                
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
                // Console.WriteLine($"Finding anchor | {node == null}");

                // Get the anchor tag inside of the span without a class
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
                // Console.WriteLine($"Getting anchor inner text | {node == null}");

                // Get the inner text of node
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

