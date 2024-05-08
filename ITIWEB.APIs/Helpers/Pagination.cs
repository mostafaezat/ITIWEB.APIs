using Core.Entities;
using ITIWEB.APIs.DTOs;

namespace ITIWEB.APIs.Helpers
{
    public class Pagination<T> where T:class
    {
        public int? pageIndex { get; set; }
        public int? pageSize { get; set; }
        public int? count { get; set; }
        public IEnumerable<T> Data { get; set; }

        public Pagination(int? PageIndex, int? PageSize, IEnumerable<T> data)
        {
            pageIndex =  PageIndex;
            pageSize =  PageSize;
            Data = data;
        }

     
    }
}
