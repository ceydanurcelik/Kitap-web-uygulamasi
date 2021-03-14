using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public interface ISorting
    {
        SortResult AddSort(Sort sort);
        SortResult ListSort();
    }
}
