﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Infrastructure.Feed.DataSurrogates;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Feed
{
    [XmlRoot("XmlSports")]
    public class SportsFeed
    {
        [XmlElement("Sport")]
        public List<SportSurrogated> Sports { get; set; }

        [XmlAttribute("CreateDate")]
        public DateTime CreateDate { get; set; }

        public SportsFeed()
        {
            this.Sports = new List<SportSurrogated>();
        }
    }


}
