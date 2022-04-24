namespace CoinR.Models;

public class CryptoCurrency
{
    public CryptoCurrency(string name, Image logo, Rating rating, string symbol, List<String> chart,String detailslink,string chartname)
    {
        this.name = name;
        this.logo = logo;
        this.rating = rating;
        this.symbol = symbol;
        this.chart = chart;
        this.detailslink = detailslink;
        this.chartname = chartname;
        
    }

    public CryptoCurrency()
    {
            
    }

    public String name { get; set; }

    public Image logo { get; set; }

    public Rating rating { get; set; }

    public String symbol { get; set; }

    public List<string> chart { get; set; }

    public string labels
    {
        get
        {
            return generateLabels();
        }
        set
        {
        }
    }

    public string detailslink { get; set; }

    public string chartname { get; set; }

    public String getChartsStringPreview()
    {
        String chartvals = "";

        for (int i = 0; i < chart.Count; i++)
        {
            if (i == 0)
            {
                if (chart[i].Length >= 3)
                {
                    chartvals += "["+chart[i].Substring(0,3)+",";
                }
                else
                {
                    chartvals += "["+chart[i]+",";

                }
            }

            if (i == chart.Count-1)
            {
                if (chart[i].Length >= 3)
                {
                    chartvals += ""+ chart[i].Substring(0,3) + "]";
                }
                else
                {
                    chartvals += ""+ chart[i] + "]";
                }
            }
            else if(i != 0 && i != chart.Count-1)
            {
                if (chart[i].Length >= 3)
                {
                    chartvals += chart[i].Substring(0,3) + ",";
                }
                else
                {
                    chartvals += chart[i] + ",";
                }
            }
        }

        return chartvals;
    }
    
    public String getChartString()
    {
        String chartvals = "";
        
        for (int i = 0; i < chart.Count; i++)
        {
            if (i == 0)
            {
                chartvals += "["+chart[i]+",";
            }

            if (i == chart.Count-1)
            {
                chartvals += ""+ chart[i] + "]";
            }
            else if(i != 0 && i != chart.Count-1)
            {
                chartvals += chart[i] + ",";
            }
        }

        return chartvals;
    }

    public String generateLabels()
    {
        string labels = "";
        for (int i = 0; i < chart.Count; i++)
        {
            if (i == 0)
            {
                labels += "["+i+",";
            }

            if (i == chart.Count-1)
            {
                labels += ""+ i + "]";
            }
            else if(i != 0 && i != chart.Count-1)
            {
                labels += i + ",";
            }
        }

        return labels;
    }
}