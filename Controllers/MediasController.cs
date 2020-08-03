using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirtableApiClient;
using crai.Data;

namespace crai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMedias()
        {
            string offset = null;
            var media = new List<AirtableRecord<MediaDTO>>();
            do
            {
                using (AirtableBase airtableBase = new AirtableBase("keyadwZtJKvZqY2fc", "appO5FAiLicd4LKkT"))
                {
                    Task<AirtableListRecordsResponse<MediaDTO>> taskMedia = airtableBase.ListRecords<MediaDTO>("Media", offset);
                    AirtableListRecordsResponse<MediaDTO> response = await taskMedia;

                    if (response.Success)
                    {

                        media.AddRange(response.Records.ToList());
                        offset = response.Offset;
                    }

                }
            } while (offset != null);

            return Ok(media);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedia(string id)
        {

            string offset = null;
            var media = new List<AirtableRecord<MediaDTO>>();
            do
            {
                using (AirtableBase airtableBase = new AirtableBase("keyadwZtJKvZqY2fc", "appO5FAiLicd4LKkT"))
                {
                    Task<AirtableListRecordsResponse<MediaDTO>> taskMedia = airtableBase.ListRecords<MediaDTO>("Media", offset);
                    AirtableListRecordsResponse<MediaDTO> response = await taskMedia;

                    if (response.Success)
                    {

                        media.AddRange(response.Records.Where(x => x.Fields.Project[0] == id).ToList());
                        offset = response.Offset;
                    }
                }
            } while (offset != null);

            return Ok(media);
        }
    }
}