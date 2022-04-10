using System.Threading;
using System.Threading.Tasks;
using FrontDesk.Core.Events;
using MediatR;

namespace FrontDesk.Api.Hubs
{
  public class AppointmentDeleteHandler : INotificationHandler<AppointmentDeletedEvent>
  {
    //TODO: fill with IHubContext

    public Task Handle(AppointmentDeletedEvent notification, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }
  }
}
