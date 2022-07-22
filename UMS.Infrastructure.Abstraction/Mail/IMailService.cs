


namespace UMS.Infrastructure.Abstraction.Mail;

public interface IMailService
{
    public Task SendEmailAsync(MailRequest mailRequest);

}