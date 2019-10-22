using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Common
{
    public class ContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppContext> builder = new DbContextOptionsBuilder<AppContext>();
            
            string connection = "Server=LAPTOP-A11S67KC\\SQLEXPRESS;Database=Webir;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connection);

            return new AppContext(builder.Options);
        }

    }
}
