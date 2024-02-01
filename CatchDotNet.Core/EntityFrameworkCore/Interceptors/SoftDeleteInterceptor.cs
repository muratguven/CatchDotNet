using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CatchDotNet.Core.EntityFrameworkCore.Interceptors
{
    public sealed class SoftDeleteInterceptor : DbCommandInterceptor
    {


        //public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        //{

        //    var entities = eventData.Context.Model.GetEntityTypes();

        //    if (entities.Any(x => x.GetProperty("IsDeleted") != null && command.CommandText.Contains("SELECT")))
        //    {
        //        command.CommandText = command.CommandText.Contains("WHERE") ? command.CommandText + " AND c.\"IsDelete\"=false" : command.CommandText + " WHERE c.\"IsDeleted\"=false";
        //    }

        //    return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        //}

    }
}
