namespace PokemonExamen.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<string> Types { get; set; }
        public string SpriteUrl { get; set; }
        public List<string> Moves { get; set; }
    }
}