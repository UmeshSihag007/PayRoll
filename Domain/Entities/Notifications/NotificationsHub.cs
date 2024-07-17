using Microsoft.AspNetCore.SignalR;

namespace ApwPayroll_Domain.Entities.Notifications
{
    public class NotificationsHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task SendNotificationWithDocumentToUser(string connectionId, string message, string? documentUrl)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveNotificationWithDocument", message, documentUrl);
        }
    }
}
