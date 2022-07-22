using UMS.Domain.Tenant;

namespace UMS.Application1.IService;

public interface ITenantGetter 
{
    Tenant Tenant { get; }
}