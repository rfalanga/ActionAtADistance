using Microsoft.EntityFrameworkCore;

namespace ActionAtaDistance1.Common
{
    /*
     * NOTE: This class represents what is done with the WPF app at work. i.e.: this represents
     * the Action at a Distance anti-pattern! So, do NOT do it this way!!!
     */
    internal class MainDbContext
    {
        public MainDbContext(DbContext dbContext)
        {
            GlobalDbContext = dbContext;
        }

        public DbContext GlobalDbContext { get; }
    }
}
