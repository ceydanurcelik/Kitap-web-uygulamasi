using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBook.Data;
using WebBook.Business;


namespace WebBook.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        public readonly ILikeOperation LikeOperation;
        public LikeController(ILikeOperation LikeOperation)
        {
            this.LikeOperation = LikeOperation;
        }

        [HttpPost("add-like")]
        public LikeResult AddLike(Like like)
        {
            return LikeOperation.AddLike(like);
        }

        [HttpGet("Like")]
        public List<LikeResult> GetLikeList()
        {
            return LikeOperation.ListLike();
        }
    }
}

