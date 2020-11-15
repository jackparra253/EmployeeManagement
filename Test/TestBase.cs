using Data;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public abstract class TestBase 
    {
        private bool _useSqlite;

        public EmployeeContext GetDbContext()
        {
            DbContextOptionsBuilder<EmployeeContext> builder = new DbContextOptionsBuilder<EmployeeContext>();

            if (_useSqlite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }


            var dbContext = new EmployeeContext(builder.Options);
            if (_useSqlite)
            {
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        public void UseSqlite()
        {
            _useSqlite = true;
        }
    }
}
