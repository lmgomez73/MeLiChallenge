using MeLiChallenge.Business.Interface;
using MeLiChallenge.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeLiChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopSecretController : Controller
    {

        private readonly IMessageService _service;

        public TopSecretController( IMessageService service)
        {
            this._service = service;
        }


        [HttpPost]
        public TopSecretResponseDTO PostTopSecret(TopSecretRequestDTO dto)
        {
            var response = _service.AddMessage(dto);
            return response;
        }
    }
}
