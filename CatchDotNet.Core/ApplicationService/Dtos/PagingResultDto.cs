namespace CatchDotNet.Core.ApplicationService.Dtos
{
    public record class PagingResultDto<T> where T : class
    {
        public List<T> Items { get; init; }

        

    }
}
