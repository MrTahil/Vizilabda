namespace Vizilabda.Models
{
    public record CreatePlayerDto(string Name, sbyte? Age, int? Height, int? Weight);
    public record UpdatePlayerDto(string Name, sbyte? Age, int? Height, int? Weight);
}
