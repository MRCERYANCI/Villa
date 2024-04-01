using Microsoft.AspNetCore.SignalR;
using Villa.BusniessLayer.Abstract;

namespace Villa.WebUI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IMessageService _messageService;

        public SignalRHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendNotification()
        {
            var NotificationCountByStatusValue = _messageService.TGetAllAsync();
            await Clients.All.SendAsync("ReceiverNotificationCountByStatus", NotificationCountByStatusValue);
        }
    }
}
