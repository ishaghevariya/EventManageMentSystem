using DataAcessLayer;
using EventBookingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public class EquipmentRepo : IEquipmentRepo
    {
        private readonly ApplicationDbContext _context;
        public EquipmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Equipment> AddEquipment(Equipment equipment)
        {
            var result = await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Equipment> DeleteEquipment(int id)
        {
            var result = await _context.Equipments.FirstOrDefaultAsync(x => x.EquipmentId == id);
            if (result != null)
            {
                _context.Equipments.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Equipment> GetEquipment(int id)
        {
            return await _context.Equipments.FirstOrDefaultAsync(x => x.EquipmentId == id);    
        }

        public async Task<IEnumerable<Equipment>> GetEquipments()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment> UpdateEquipment(Equipment equipment)
        {
            var result = await _context.Equipments.FirstOrDefaultAsync(x => x.EquipmentId == equipment.EquipmentId);
            if (result != null)
            {
                result.EquipmentType = equipment.EquipmentType;
                result.EquipmentCost = equipment.EquipmentCost;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
