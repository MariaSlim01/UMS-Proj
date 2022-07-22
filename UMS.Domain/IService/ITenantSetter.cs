using UMS.Domain.Tenant;

namespace UMS.Application1.IService;

public interface ITenantSetter
{
    void SetTenant(Tenant tenant);
}