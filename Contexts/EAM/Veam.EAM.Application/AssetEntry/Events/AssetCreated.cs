using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Notifications;
using Veam.Application.Core.Notifications.Models;

namespace Veam.EAM.Application
{
    public class AssetCreated: INotification
    {
        public long AssetId { get; set; }
    }

    public class AssetCreatedHandler : INotificationHandler<AssetCreated>
    {
        private readonly INotificationService _notification;

        public AssetCreatedHandler(INotificationService notification)
        {
            _notification = notification;
        }

        public async Task Handle(AssetCreated notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail or update or in db
            await _notification.SendAsync(new Message());
        }
    }
}