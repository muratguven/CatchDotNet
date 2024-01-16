using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.Core.ApplicationService.Dtos
{
    public record class PagingResultDto<T> where T : class
    {
        public List<T> Items { get; init; }

        

    }
}
