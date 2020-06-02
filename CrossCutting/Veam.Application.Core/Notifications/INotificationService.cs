using Veam.Application.Core.Notifications.Models;
using System.Threading.Tasks;

namespace Veam.Application.Core.Notifications
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
