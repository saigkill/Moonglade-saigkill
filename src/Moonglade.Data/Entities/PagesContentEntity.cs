namespace Moonglade.Data.Entities;

public class PagesContentEntity
{
    public int Id { get; set; }
    public Language Language { get; set; }
    public string RootPage { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}