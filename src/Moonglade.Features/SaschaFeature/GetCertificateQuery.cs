using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllCertificatesQuery() : IQuery<List<CertificateEntity>>;

public class GetAllCertificatesQueryHandler(MoongladeRepository<CertificateEntity> repo) : IQueryHandler<GetAllCertificatesQuery, List<CertificateEntity>>
{
  public Task<List<CertificateEntity>> HandleAsync(GetAllCertificatesQuery request, CancellationToken ct)
  {
	var spec = new CertificateAllSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}

public record GetCertficateByIdQuery(int id) : IQuery<CertificateEntity>;

public class GetCertficateByIdQueryHandler(MoongladeRepository<CertificateEntity> repo) : IQueryHandler<GetCertficateByIdQuery, CertificateEntity>
{
  public Task<CertificateEntity> HandleAsync(GetCertficateByIdQuery request, CancellationToken ct)
  {
	var spec = new CertificateByIdSpec(request.id);
	var entity = repo.SingleOrDefaultAsync(spec, ct);
	return entity;
  }
}

public record GetCertficateByLanguageQuery() : IQuery<List<CertificateEntity>>;

public class GetCertficateByLanguageQueryHandler(MoongladeRepository<CertificateEntity> repo) : IQueryHandler<GetCertficateByLanguageQuery, List<CertificateEntity>>
{
  public Task<List<CertificateEntity>> HandleAsync(GetCertficateByLanguageQuery request, CancellationToken ct)
  {
	var spec = new CertificateByLanguageSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}
