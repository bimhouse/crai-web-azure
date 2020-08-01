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
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            string offset = null;
            var list = new List<AirtableRecord<PortfolioDTO>>();
            var clients = new List<AirtableRecord<ClientDTO>>();
            do
            {
                using (AirtableBase airtableBase = new AirtableBase("keyadwZtJKvZqY2fc", "appO5FAiLicd4LKkT"))
                {
                    Task<AirtableListRecordsResponse<ClientDTO>> taskClient = airtableBase.ListRecords<ClientDTO>("Client", offset);
                    Task<AirtableListRecordsResponse<PortfolioDTO>> task = airtableBase.ListRecords<PortfolioDTO>("Portfolio", offset);
                    AirtableListRecordsResponse<ClientDTO> response2 = await taskClient;
                    AirtableListRecordsResponse<PortfolioDTO> response = await task;

                    if (response2.Success)
                    {
                        clients.AddRange(response2.Records.ToList());
                    }

                    if (response.Success)
                    {

                        list.AddRange(response.Records.ToList());
                        offset = response.Offset;
                    }

                    foreach (var item in list)
                    {
                        if(item.Fields.Client.Count == 1)
                        {
                            var match = clients.Find(c => c.Id == item.Fields.Client[0]);
                            if (match != null)
                            {
                                item.Fields.ClientName = match.Fields.Name;
                            }
                        }
                    }
                }
            } while (offset != null);

            return Ok(list.Where(x => x.Fields.Active));
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(string id)
        {

            string offset = null;
            var list = new List<AirtableRecord<PortfolioDTO>>();
            var clients = new List<AirtableRecord<ClientDTO>>();
            do
            {
                //string filter = "{id}='" + id + "'";
                using (AirtableBase airtableBase = new AirtableBase("keyadwZtJKvZqY2fc", "appO5FAiLicd4LKkT"))
                {
                    Task<AirtableListRecordsResponse<ClientDTO>> taskClient = airtableBase.ListRecords<ClientDTO>("Client", offset);
                    Task<AirtableListRecordsResponse<PortfolioDTO>> task = airtableBase.ListRecords<PortfolioDTO>("Portfolio", offset);
                    AirtableListRecordsResponse<PortfolioDTO> response = await task;
                    AirtableListRecordsResponse<ClientDTO> response2 = await taskClient;

                    if (response2.Success)
                    {
                        clients.AddRange(response2.Records.ToList());
                    }

                    if (response.Success)
                    {

                        list.AddRange(response.Records.Where(x => x.Id == id).ToList());
                        offset = response.Offset;
                    }

                    foreach (var item in list)
                    {
                        if (item.Fields.Client.Count == 1)
                        {
                            var match = clients.Find(c => c.Id == item.Fields.Client[0]);
                            if (match != null)
                            {
                                item.Fields.ClientName = match.Fields.Name;
                            }
                        }
                    }
                }
            } while (offset != null);

            return Ok(list.FirstOrDefault());
        }
    }
}