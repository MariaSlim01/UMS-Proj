// using UMS.Application1.IService;
// using UMS.Domain.Tenant;
//
// namespace UMS.WebAPI1;
//
// using Microsoft.Extensions.Options;
// public class MultiTenantServiceMiddleware : IMiddleware
// {
//     private readonly ITenantSetter setter;
//     private List<Tenant> _tenant;
//     private readonly ILogger<MultiTenantServiceMiddleware> logger;
//     
//     public MultiTenantServiceMiddleware(
//         ITenantSetter setter, 
//         ILogger<MultiTenantServiceMiddleware> logger,List<Tenant> tenant)
//     {
//         this.setter = setter;
//         this.logger = logger;
//         _tenant = tenant;
//     }
//     
//     public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//     {
//         var tenant =_tenant.FirstOrDefault() ;
//
//         foreach (var Tenant in _tenant)
//         {
//             if (context.Request.Headers["Tenant"]==Tenant.Name)
//             {
//                 setter.SetTenant(Tenant);
//                 logger.LogInformation("Using the tenant {Tenant}", Tenant.Name);
//             }
//         }
//         
//         await next(context);
//     }
// }