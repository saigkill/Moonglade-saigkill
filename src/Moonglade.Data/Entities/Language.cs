#nullable disable
using System.Globalization;

namespace Moonglade.Data.Entities
{
  [System.ComponentModel.Description("Specified Language Enum")]
  public enum Language
  {
    Unknown,
    English,
    German
  }

  public static class LanguageExtensions
  {
    public static string ToFriendlyString(this Language me)
    {
      return me switch
      {
        Language.English => "English",
        Language.German => "German",
        _ => Language.English.ToString(),
      };
    }

    public static Language FromStringToLanguage(this string language)
    {
      return language switch
      {
        "English" => Language.English,
        "German" => Language.German,
        _ => Language.English
      };
    }

    public static Language FromLangCodeToLang()
    {
      var culture = CultureInfo.CurrentCulture.Name;
      switch (culture)
      {
        case "en-US":
          return Language.English;
        case "de-DE":
          return Language.German;
        default:
          return Language.English;
      }
    }

    public static string ToLangCode(this Language me)
    {
      return me switch
      {
        Language.English => "en-US",
        Language.German => "de-DE",
        _ => Language.English.ToString(),
      };
    }

  }
}

