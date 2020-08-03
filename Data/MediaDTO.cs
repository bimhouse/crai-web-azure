using System;
using System.Collections.Generic;
using AirtableApiClient;

namespace crai.Data
{
    public class MediaDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<AirtableAttachment> Attachment { get; set; }

        public List<string> Project { get; set; }

        public bool Downloadable { get; set; }

        public string MediaType { get; set; }

        public string Link { get; set; }
    }
}