using Veam.Application.Core.Interfaces;
using Veam.Application.Core.Notifications.Models;
using System.Threading.Tasks;

namespace Veam.Application.Core.Notifications
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
