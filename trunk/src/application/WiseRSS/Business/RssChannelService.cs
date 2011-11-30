using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrossCutting;
using DataAccess;

namespace Business
{
    public class RssChannelService
    {

        public RssChannel RssChannelSelect(int id)
        {

            //tukaj bo logika pri nekaterih 

            return new RssChannelDataReader().RssChannelSelect(id);
        }

    }
}
