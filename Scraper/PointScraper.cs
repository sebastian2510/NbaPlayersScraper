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

    public List<Stats> PrintAllStats(string url)
    {
        HtmlDocument doc = GetHtmlDocument(url);
        HtmlNodeCollection trtags = GetTrTags(GetNode(doc));
        List<Stats> stats = new();
        // add every 13 stats to the stats list
        for (int i = 0; i < trtags.Count - 1; i++)
        {
            HtmlNodeCollection tdtags = GetTdTags(trtags[i]);
            for (int j = 0; j < tdtags.Count; j += 12)
            {
                Stats stat = new();
                stat.GP = GetInnerText(GetSpanTags(tdtags[j]));
                stat.GS = GetInnerText(GetSpanTags(tdtags[j + 1]));
                stat.MIN = GetInnerText(GetSpanTags(tdtags[j + 2]));
                stat.PTS = GetInnerText(GetSpanTags(tdtags[j + 3]));
                stat.OR = GetInnerText(GetSpanTags(tdtags[j + 4]));
                stat.DR = GetInnerText(GetSpanTags(tdtags[j + 5]));
                stat.REB = GetInnerText(GetSpanTags(tdtags[j + 6]));
                stat.AST = GetInnerText(GetSpanTags(tdtags[j + 7]));
                stat.STL = GetInnerText(GetSpanTags(tdtags[j + 8]));
                stat.BLK = GetInnerText(GetSpanTags(tdtags[j + 9]));
                stat.TO = GetInnerText(GetSpanTags(tdtags[j + 10]));
                stat.PF = GetInnerText(GetSpanTags(tdtags[j + 11]));
                stat.ASTTO = GetInnerText(GetSpanTags(tdtags[j + 12]));
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