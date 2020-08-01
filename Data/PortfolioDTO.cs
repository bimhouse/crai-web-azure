using System;
using System.Collections.Generic;
using AirtableApiClient;

namespace crai.Data
{
    public class PortfolioDTO
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Location { get; set; }

        public List<string> Client { get; set; }

        public string Size { get; set; }

        public string Project { get; set; }

        public int? Sf { get; set; }

        public List<AirtableAttachment> Thumb { get; set; }

        public List<string> Role { get; set; }

        public List<string> Media { get; set; }

        public string WriteUp { get; set; }

        public bool Active { get; set; }

        public bool ConstructionStatus { get; set; }

        public string ClientName { get; set; }
    }
}