using Microsoft.AspNetCore.SignalR;

namespace UMS.Application1.Hubs;

public class NotificationHub : Hub
{
    public string Activate()
    {
        return "Monitor Activated";
    } 
    public void SendNotifications(long userId, string message)
    {
        
            Clients.User(userId.ToString()).SendAsync("ReceiveNotification",message);

        
    }
}