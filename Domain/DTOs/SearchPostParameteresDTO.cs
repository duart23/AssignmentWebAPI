namespace Domain.DTOs;

public class SearchPostParameteresDTO
{
    public string? UserName { get; }
    public string? TitleContains {get; }
    public string? contentContains { get; }

    public SearchPostParameteresDTO(string? userName, string? titleContains, string? contentContains)
    {
        UserName = userName;
        TitleContains = titleContains;
        this.contentContains = contentContains;
    }
}