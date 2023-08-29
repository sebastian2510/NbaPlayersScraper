using HtmlAgilityPack;
using NbaScraper.PlayerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NbaScraper.Scraper;

internal class PointScraper : ScraperBase
{

    // Create an overall function that will return a list of stats

    public List<Stats> GetStats(string url)
    {
        HtmlDocument doc = GetHtmlDocument(url);
        HtmlNodeCollection trtags = GetTrTags(GetNode(doc));
        List<Stats> stats = new();
        // add every 13 stats to the stats list
        for (int i = 0; i < trtags.Count; i++)
        {
            HtmlNodeCollection tdtags = GetTdTags(trtags[i]);
            for (int j = 0; j < tdtags.Count - 1; j += 12)
            {
                Stats stat = new()
                {
                    GP = GetInnerText(GetSpanTags(tdtags[j])),
                    GS = GetInnerText(GetSpanTags(tdtags[j + 1])),
                    MIN = GetInnerText(GetSpanTags(tdtags[j + 2])),
                    PTS = GetInnerText(GetSpanTags(tdtags[j + 3])),
                    OR = GetInnerText(GetSpanTags(tdtags[j + 4])),
                    DR = GetInnerText(GetSpanTags(tdtags[j + 5])),
                    REB = GetInnerText(GetSpanTags(tdtags[j + 6])),
                    AST = GetInnerText(GetSpanTags(tdtags[j + 7])),
                    STL = GetInnerText(GetSpanTags(tdtags[j + 8])),
                    BLK = GetInnerText(GetSpanTags(tdtags[j + 9])),
                    TO = GetInnerText(GetSpanTags(tdtags[j + 10])),
                    PF = GetInnerText(GetSpanTags(tdtags[j + 11])),
                    ASTTO = GetInnerText(GetSpanTags(tdtags[j + 12]))
                };
                stats.Add(stat);

            }
        }

        return stats;

    }

    private HtmlNode GetNode(HtmlDocument doc)
    {
        // get this node: /html/body/div[1]/div/div/div/main/div[2]/div[5]/div/div/section/div/div[5]/div[2]/div/div[2]/table/tbody
        try
        {
            return doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div/main/div[2]/div[5]/div/div/section/div/div[5]/div[2]/div/div[2]/table/tbody");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private HtmlNodeCollection GetTrTags(HtmlNode node)
    {
        try
        {
            return node.SelectNodes("tr");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private HtmlNodeCollection GetTdTags(HtmlNode node)
    {
        try
        {
            return node.SelectNodes("td");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private HtmlNode GetSpanTags(HtmlNode node)
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

    private string GetInnerText(HtmlNode node)
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
}