using Exercicio2.Domain.Enums;
using Exercicio2.Domain.Interfaces;

namespace Exercicio2.Domain.Entities
{
    public abstract class Vehicle : IBaseEntity
    {
        public int Id { get; set;}
        public string Description { get; set; }
        public VehicleTypeEnum VehicleType { get; set; }
        public string LicensePlate { get; set; }
    }
}