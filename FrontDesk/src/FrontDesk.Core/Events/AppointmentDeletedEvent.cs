using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontDesk.Core.ScheduleAggregate;
using PluralsightDdd.SharedKernel;

namespace FrontDesk.Core.Events;

public class AppointmentDeletedEvent : BaseDomainEvent
{
  // recebe o apontamento apagado 
  public AppointmentDeletedEvent(Appointment appointment)
  {
    AppointmentDeleted = appointment;
  }

  public Guid Guid { get; } = Guid.NewGuid();

  public Appointment AppointmentDeleted { get; }
}
