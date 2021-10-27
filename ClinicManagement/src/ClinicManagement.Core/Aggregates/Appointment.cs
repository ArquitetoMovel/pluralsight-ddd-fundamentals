using System;
using System.Collections.Generic;
using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Aggregates
{
  public class Appointement : BaseEntity<Guid>, IAggregateRoot
  {
    public int ClientId { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartEndTime { get; set; }

    public Appointement(Guid id, int clientId, int doctorId,
                        int patientId, int roomId, DateTime startEndTime)
    {
      Id = id;
      ClientId = clientId;
      DoctorId = doctorId;
      PatientId = patientId;
      RoomId = roomId;
      StartEndTime = startEndTime;
    }
    
    //TODO: Adicionar comportamento
    /* *
     * + Retrieve
     * + Track
     * + Edit
     * + Requires Unique ID
     */
  }
}
