using System.Collections;

namespace CatchDotNet.Core.Pagination
{
    [Serializable]
    public class PagedResults<TValue> 
    {
  
        public int TotalCount { get; init; }

        public int CurrentPage { get; init; }
        //public int TotalPages { get; init; }
        public int PageSize {  get; init; }
        //public bool HasPreviousPage
        //{
        //    get
        //    {
        //        return CurrentPage > 1;
        //    }
        //}

        //public bool HasNextPage
        //{
        //    get
        //    {
        //        return CurrentPage < TotalPages;
        //    }
        //}


      

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(TotalCount / (double)PageSize);
            }
        }


        public List<TValue> Items { get; init; }

      

        public PagedResults(List<TValue> items, int totalCount, int currentPage, int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Items = new List<TValue>(items);

        }

    }
}
