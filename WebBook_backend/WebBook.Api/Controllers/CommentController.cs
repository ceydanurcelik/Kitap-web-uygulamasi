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
    public class CommentController : ControllerBase
    {
        public readonly ICommentOperation CommentOperation;
        public CommentController(ICommentOperation CommentOperation)
        {
            this.CommentOperation = CommentOperation;
        }

        [HttpPost("add-comment")]
        public CommentResult AddComment(Comment comment)
        {
            return CommentOperation.AddComment(comment);
        }

        [HttpGet("GetCommentList")]
        public List<CommentResult> GetCommentList()
        {
            return CommentOperation.ListComment();
        }
    }
}

