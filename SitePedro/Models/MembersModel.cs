using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace SitePedro.Models
{
    public class MembersModel
    {
        public string NameandSurname { get; set; }

        public IPublishedContent Avatar { get; set; }

        public string ImagemUrl { get; set; }
    }
}