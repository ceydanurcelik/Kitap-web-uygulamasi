using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBook.Business;
using WebBook.Data;

namespace WebBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        public readonly IReadOperation ReadOperation;
        public ReadController(IReadOperation ReadOperation)
        {
            this.ReadOperation = ReadOperation;
        }

        [HttpPost("add-read")]
        public ReadResult AddRead(Read read)
        {
            return ReadOperation.AddRead(read);
        }

        [HttpGet("Read")]
        public List<ReadResult> GetReadList()
        {
            return ReadOperation.ListRead();
        }
    }
}
