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
    public class FilterController : ControllerBase
    {
        public readonly IFiltering Filtering;
        public FilterController(IFiltering Filtering)
        {
            this.Filtering = Filtering;
        }

        [HttpPost("add-filter")]
        public FilteringResult AddFilter(Filter filter)
        {
            return Filtering.AddFilter(filter);
        }

        [HttpGet("Filter")]
        public FilteringResult GetFilterList()
        {
            return Filtering.ListFilter();
        }
    }
}
