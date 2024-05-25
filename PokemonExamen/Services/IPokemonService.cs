using PokemonExamen.Models;
namespace PokemonExamen.Services;
    public interface IPokemonService
    {
        Task<Pokemon> GetFavoritePokemonAsync();
    }

