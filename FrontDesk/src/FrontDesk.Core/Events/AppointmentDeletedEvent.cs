<<<<<<< HEAD
using System;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 38e562d43da9756528f7e09d1265a0c6648ed72b
using FrontDesk.Core.ScheduleAggregate;
using PluralsightDdd.SharedKernel;

namespace FrontDesk.Core.Events
{
<<<<<<< HEAD
    public class AppointmentDeletedEvent : BaseDomainEvent
    {
       public AppointmentDeletedEvent(Appointment appointment)
       {
          AppointmentDeleted = appointment; 
       }    

    public Guid Id { get; private set; } = Guid.NewGuid();
    public Appointment AppointmentDeleted { get; private set; }

    }
}
=======
  //
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
}
>>>>>>> 38e562d43da9756528f7e09d1265a0c6648ed72b
