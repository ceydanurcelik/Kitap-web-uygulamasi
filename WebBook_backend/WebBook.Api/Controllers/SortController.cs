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
    public class SortController : ControllerBase
    {
        public readonly ISorting Sorting;
        public SortController(ISorting Sorting)
        {
            this.Sorting = Sorting;
        }

        [HttpPost("add-sort")]
        public SortResult AddSort(Sort sort)
        {
            return Sorting.AddSort(sort);
        }

        [HttpGet("Sort")]
        public SortResult GetSortList()
        {
            return Sorting.ListSort();
        }
    }
}
