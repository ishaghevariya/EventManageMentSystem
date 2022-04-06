using DataAcessLayer;
using DataAcessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IFlowerRepo
    {
        Task<IEnumerable<Flower>> Search(string FlowerType);
        Task<Flower> GetFlower(int id);
        Task<IEnumerable<Flower>> GetFlowers();
        Task<Flower> AddFlower(FlowerViewModel flower);
        Task<Flower> UpdateFlower(FlowerViewModel flower);
        Task<Flower> DeleteFlower(int id);
    }
}
