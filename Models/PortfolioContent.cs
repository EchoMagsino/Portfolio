namespace Portfolio.Models;

public record Project(
    string Number,
    string Title,
    string Stack,
    string Description,
    IReadOnlyList<string> Tags,
    string Year);

public record Skill(string Name, int Level);

public record SkillGroup(string Title, string Caption, IReadOnlyList<Skill> Skills);

public record Fact(string Label, string Value);

public class PortfolioViewModel
{
    public string Name { get; init; } = "Jericho Magsino";
    public string ShortName { get; init; } = "JM Portfolio";
    public string Role { get; init; } = "3rd Year College Student";
    public string Tagline { get; init; } = "Developing scalable web applications with ASP.NET Core, C#, and SQL.";
    public string Email { get; init; } = "jericho.magsino@example.com";
    public string GitHubUrl { get; init; } = "#";
    public string LinkedInUrl { get; init; } = "#";

    public IReadOnlyList<Project> Projects { get; init; } = [];
    public IReadOnlyList<SkillGroup> SkillGroups { get; init; } = [];
    public IReadOnlyList<Fact> Facts { get; init; } = [];
}
