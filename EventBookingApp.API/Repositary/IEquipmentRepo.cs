using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IEquipmentRepo
    {
        Task<IEnumerable<Equipment>> Search(string EquipmentType);
        Task<Equipment> GetEquipment(int id);
        Task<IEnumerable<Equipment>> GetEquipments();
        Task<Equipment> AddEquipment(Equipment equipment);
        Task<Equipment> UpdateEquipment(Equipment equipment);
        Task<Equipment> DeleteEquipment(int id);
    }
}
