#nullable disable
namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("Specified Language Enum")]
public enum Language
{
  Unknown,
  English,
  German
}

public static class LanguageExtensions
{
  public static Language FromStringToLanguage(this string language)
  {
    return language switch
    {
      "English" => Language.English,
      "German" => Language.German,
      _ => Language.English
    };
  }

  public static Language FromLangCodeToLang(string culture)
  {
    switch (culture)
    {
      case "en-us":
      case "en-gb":
        return Language.English;
      case "de-de":
        return Language.German;
      default:
        return Language.English;
    }
  }

  public static string CheckLanguage(string culture)
  {
    switch (culture)
    {
      case "de-de":
        return "de-de";
      default:
        return "en-us";
    }
  }
}
