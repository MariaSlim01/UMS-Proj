
using Microsoft.EntityFrameworkCore;
using PCP.Persistence.Infrastructure;
using UMS.Application1.IService;
using WebApplication4.Models;

namespace UMS.Persistence
{
    public class PcpDbContextFactory 
        : DesignTimeDbContextFactoryBase<postgresContext>
    {
        protected override postgresContext CreateNewInstance(DbContextOptions<postgresContext> options){ 
            return new postgresContext(options);
        }
    }
}
