

using Microsoft.Extensions.Configuration;

namespace UMS.Infrastructure.Abstraction.Mail;

public class MailSettings
{
    private readonly IConfiguration Configuration;

    public string Mail { get; set; } 
    public string DisplayName { get; set; } 
    public string Password { get; set; } 
    public string Host { get; set; } 
    public int Port { get; set; }

   /* public MailSettings()
    {
        var mailSettings= new MailSettings();
        Configuration.GetSection("MailSettings").Bind(mailSettings);

    }*/
    
}