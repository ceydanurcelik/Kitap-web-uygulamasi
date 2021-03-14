using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business


{
    public interface ILikeOperation 
    {
        LikeResult AddLike(Like like);
        List<LikeResult> ListLike();
        LikeResult LikeWriteToFile(Like like);
        Like LikeReadFromFile(string title);
        List<LikeResult> LikeAllReadFromFile();
    }
}
