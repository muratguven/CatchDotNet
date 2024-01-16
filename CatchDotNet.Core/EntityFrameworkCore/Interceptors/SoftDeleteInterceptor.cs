using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CatchDotNet.Core.EntityFrameworkCore.Interceptors
{
    public sealed class SoftDeleteInterceptor : DbCommandInterceptor
    {
        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            var entities = eventData.Context.Model.GetEntityTypes();

            if (entities.Any(x => x.GetProperty("IsDeleted") != null))
            {
                command.CommandText = command.CommandText.Contains("WHERE") ? command.CommandText + " AND IsDelete=0" : command.CommandText + " WHERE IsDeleted=0";
            }
            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
           
            var entities = eventData.Context.Model.GetEntityTypes();

            if (entities.Any(x => x.GetProperty("IsDeleted") != null))
            {
                command.CommandText = command.CommandText.Contains("WHERE") ? command.CommandText + " AND IsDelete=0" : command.CommandText + " WHERE IsDeleted=0";
            }
           
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

    }
}
