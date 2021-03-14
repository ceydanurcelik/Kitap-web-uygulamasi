using System;
using System.Collections.Generic;
using System.Text;
using WebBook.Data;

namespace WebBook.Business
{
    public interface IFiltering
    {
        FilteringResult AddFilter(Filter filter);
        FilteringResult ListFilter();
    }
}
