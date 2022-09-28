using Microsoft.EntityFrameworkCore;
using WebAPIRebels.Application.Interfaces;
using WebAPIRebels.Domain.Entities;
using WebAPIRebels.Infraestructure;

namespace WebAPIRebels.Application.Rebel
{
    public class RebelService : IRebelService
    {
        private readonly ApplicationDBContext context;
        private readonly ILogger<RebelService> logger;

        public RebelService(ApplicationDBContext context, ILogger<RebelService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Inserta un Rebelde en la BD
        /// </summary>
        /// <param name="rebelName">Nombre del Rebelde</param>
        /// <param name="planetName">Planeta del Rebelde</param>
        /// <returns>RebelResponse</returns>
        public async Task<RebelResponse> CreateRebelRegister(string rebelName, string planetName)
        {
            var rebelDB = new RebelEntity() { RebelName = rebelName, PlanetName = planetName, Created = DateTime.Now };

            context.Rebels.Add(rebelDB);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }

            var response = new RebelResponse { Message = $"El rebelde {rebelName} identificado en {planetName} a las {rebelDB.Created}" };

            return response;
        }

        /// <summary>
        /// Comprueba si el Rebelde dado existe en la BD.
        /// </summary>
        /// <param name="rebelName">Nombre del Rebelde</param>
        /// <param name="planetName">Planeta del Rebelde</param>
        /// <returns>bool</returns>
        public async Task<bool> ExistRebel(string rebelName, string planetName)
        {
            //Comprobamos que no existe el rebelde indicado en la BD
            var existRebel = await context.Rebels.AnyAsync(r => r.RebelName == rebelName && r.PlanetName == planetName);

            return existRebel;
        }

    }

}
