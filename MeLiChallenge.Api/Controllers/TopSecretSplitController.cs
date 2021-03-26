using MeLiChallenge.Business.Interface;
using MeLiChallenge.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeLiChallenge.Api.Controllers
{
    [Route("[controller]/{name?}")]
    [ApiController]
    public class TopSecretSplitController : ControllerBase
    {
        IMessageService _service;
        public TopSecretSplitController(IMessageService service)
        {
            _service = service;
        }


        [HttpPost]
 
        public void PostTopSecretSplit([FromRoute(Name = "name")]string name,[FromBody] TopSecretSplitRequestDTO dto)
        {
            _service.AddMessageBySatellite(dto, name);
        }


        [HttpGet]
        public TopSecretResponseDTO GetTopSecretSplit()
        {
            var result = _service.GetLastMessage();
            return result;
        }
    }
}
