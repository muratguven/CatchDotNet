namespace CatchDotNet.Core.Pagination
{
    public abstract class PagedQuery
    {
        //[QueryParam, BindFrom("currentPage")]
        public int CurrentPage { get; init; }
        //public int TotalPages { get; init; }
        //[QueryParam, BindFrom("pageSize")]
        public int PageSize { get; init; }

        public int Skip
        {
            get
            {
                return (CurrentPage - 1) * PageSize;
            }
        }
    }
}
