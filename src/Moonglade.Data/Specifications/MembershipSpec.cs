using System.Globalization;

using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class MembershipByIdSpec : SingleResultSpecification<MembershipEntity>
{
  public MembershipByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class MembershipByLanguage : Specification<MembershipEntity>
{
  public MembershipByLanguage()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == language && p.Active);
  }
}
