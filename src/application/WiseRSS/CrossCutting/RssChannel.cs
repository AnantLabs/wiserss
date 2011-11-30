using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossCutting
{
    public class RssChannel
    {
        int id { get; set; }
        string title { get; set; }
        string description { get; set; }
        string link { get; set; }
        DateTime published_date { get; set; }
        bool favorite { get; set; }
    }
}
