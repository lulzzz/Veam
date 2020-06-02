using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Veam.Application.Core.Notifications;
using Veam.Application.Core.Notifications.Models;

namespace Veam.Base.Application
{
    public class ProductCreated :INotification
    {
        public long productId { get; set; }

      
    }
    public class ProductCreatedHandler : INotificationHandler<ProductCreated>
    {
        private readonly INotificationService _notification;

        public ProductCreatedHandler(INotificationService notification)
        {
            _notification = notification;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail or update or in db
            await _notification.SendAsync(new Message());
        }
    }
}