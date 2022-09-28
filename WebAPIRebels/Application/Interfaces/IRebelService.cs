using WebAPIRebels.Application.Rebel;

namespace WebAPIRebels.Application.Interfaces
{
    public interface IRebelService
    {
        Task<RebelResponse> CreateRebelRegister(string rebelName, string planetName);
        Task<bool> ExistRebel(string rebelName, string planetName);
    }
}
