using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrossCutting;

namespace DataAccess
{
    public class RssChannelDataReader
    {
        public RssChannel RssChannelSelect(int id)
        {
            RssChannel channel = new RssChannel();

            //tukaj pride branje enega zapisa selektanega po idju

            return channel;
        }

        public List<RssChannel> RssChannelSelectAll()
        {
            List<RssChannel> channelList = new List<RssChannel>();

            //tukaj pride branje vseh zaapisov iz tabele rss_channels

            return channelList;
        }
    }
}
