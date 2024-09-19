using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class CertificateByIdSpec : SingleResultSpecification<CertificateEntity>
{
  public CertificateByIdSpec(int id)
  {
	Query.Where(p => p.Id == id);
  }
}

public sealed class CertificateAllSpec : Specification<CertificateEntity>
{
  public CertificateAllSpec()
  {
	Query.AsNoTracking();
  }
}

public sealed class CertificateByLanguageSpec : Specification<CertificateEntity>
{
  public CertificateByLanguageSpec()
  {
	var culture = LanguageExtensions.FromLangCodeToLang();
	Query.Where(p => p.Language == culture).OrderByDescending(y => y.Year);
  }
}
