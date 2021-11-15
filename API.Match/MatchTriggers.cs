using API.Match.v1.Models;
using API.Match.v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API.Match
{
    public class MatchTriggers
    {
        private readonly IClass1Service _Class1Service;

        public MatchTriggers(IClass1Service Class1Service)
        {
            _Class1Service = Class1Service;
        }

        [FunctionName("PostAsync")]
        public async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Match")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var addModel = JsonConvert.DeserializeObject<MatchAddModel>(requestBody);
            var responseModel = await _Class1Service.AddAsync(addModel);
            return new OkObjectResult(responseModel);
        }

        [FunctionName("GetByIDAsync")]
        public async Task<IActionResult> GetByIDAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Match/{id:Guid}")]
            HttpRequest req, Guid id, ILogger log)
        {
            var response = await _Class1Service.GetByIDAsync(id);
            return new OkObjectResult(response);
        }

        [FunctionName("PutAsync")]
        public async Task<IActionResult> PutAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Match/{id:Guid}")] HttpRequest req, Guid id, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateModel = JsonConvert.DeserializeObject<MatchUpdateModel>(requestBody);
            updateModel.ID = id;
            var responseModel = await _Class1Service.UpdateAsync(updateModel);
            return new OkObjectResult(responseModel);
        }

        [FunctionName("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Match/{id:Guid}")] HttpRequest req, Guid id, ILogger log)
        {
            await _Class1Service.DeleteAsync(id);
            return new NoContentResult();
        }
    }
}
