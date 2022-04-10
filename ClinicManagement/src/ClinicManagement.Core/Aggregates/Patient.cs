using ClinicManagement.Core.ValueObjects;
using PluralsightDdd.SharedKernel;

namespace ClinicManagement.Core.Aggregates
{
  // CRUD SIMPLES, não está sendo utilizado DDD /
  // não foi modelado utilizando DDD
  public class Patient : BaseEntity<int>
  {
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public AnimalType AnimalType { get; set; }
    public int? PreferredDoctorId { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
