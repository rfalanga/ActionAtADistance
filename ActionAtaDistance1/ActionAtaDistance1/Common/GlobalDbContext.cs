using Microsoft.EntityFrameworkCore;

namespace ActionAtaDistance1.Common
{
    /*
     * NOTE: This class represents what is done with the WPF app at work. i.e.: this represents
     * the Action at a Distance anti-pattern! So, do NOT do it this way!!!
     * 
     * NOTE 2: This class might not even be necessary
     */
    internal class GlobalDbContext
    {
        public GlobalDbContext(DbContext dbContext)
        {
            MainDataContext = dbContext;
        }

        public DbContext MainDataContext { get; private set; }
    }
}
