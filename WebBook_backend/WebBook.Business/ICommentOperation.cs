using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business



{
    public interface ICommentOperation 
    {
        CommentResult AddComment(Comment comment);
        List<CommentResult> ListComment();
        CommentResult CommentWriteToFile(Comment comment);
        Comment CommentReadFromFile(string title);
        List<CommentResult> CommentAllReadFromFile();
    }
}
