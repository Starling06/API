using System.Net.Http;
using System.Net.Http.Json;
using PokemonExamen.Models;
using PokemonExamen.Services;

namespace PokemonExamen.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        private const string PokemonName = "eevee"; // Cambia esto a tu pokemon favorito

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetFavoritePokemonAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<JObject>($"https://pokeapi.co/api/v2/pokemon/{PokemonName}");
            if (response == null) return null;

            var pokemon = new Pokemon
            {
                Name = response["name"]?.ToString(),
                Types = response["types"]?.Select(t => t["type"]?["name"]?.ToString()).ToList(),
                SpriteUrl = response["sprites"]?["front_default"]?.ToString(),
                Moves = response["moves"]?.Select(m => m["move"]?["name"]?.ToString()).ToList()
            };

            return pokemon;
        }
    }
}