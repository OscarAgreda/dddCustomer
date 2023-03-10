using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DDDCustomer.Infrastructure.Data
{
    public static class IdentityHelpers
    {
        public static Task EnableIdentityInsert<T>(this DbContext context)
        {
            return SetIdentityInsert<T>(context, true);
        }

        public static Task DisableIdentityInsert<T>(this DbContext context)
        {
            return SetIdentityInsert<T>(context, false);
        }

        private static Task SetIdentityInsert<T>(DbContext context, bool enable)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            return context.Database.ExecuteSqlRawAsync(
                $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
        }

        public static async Task SaveChangesWithIdentityInsert<T>(this DbContext context)
        {
            if (!context.IsRealDatabase())
            {
                await context.SaveChangesAsync();
                return;
            }

            using var transaction = context.Database.BeginTransaction();
            await context.EnableIdentityInsert<T>();
            await context.SaveChangesAsync();
            await context.DisableIdentityInsert<T>();
            transaction.Commit();
        }

        public static bool IsRealDatabase(this DbContext context)
        {
            return context.Database.ProviderName.Contains("SqlServer");
        }
    }
}