using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllCertificatesQuery() : IRequest<List<CertificateEntity>>;

public class GetAllCertificatesQueryHandler(MoongladeRepository<CertificateEntity> repo) : IRequestHandler<GetAllCertificatesQuery, List<CertificateEntity>>
{
  public Task<List<CertificateEntity>> Handle(GetAllCertificatesQuery request, CancellationToken ct)
  {
	var spec = new CertificateAllSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}

public record GetCertficateByIdQuery(int id) : IRequest<CertificateEntity>;

public class GetCertficateByIdQueryHandler(MoongladeRepository<CertificateEntity> repo) : IRequestHandler<GetCertficateByIdQuery, CertificateEntity>
{
  public Task<CertificateEntity> Handle(GetCertficateByIdQuery request, CancellationToken ct)
  {
	var spec = new CertificateByIdSpec(request.id);
	var entity = repo.SingleOrDefaultAsync(spec, ct);
	return entity;
  }
}

public record GetCertficateByLanguageQuery() : IRequest<List<CertificateEntity>>;

public class GetCertficateByLanguageQueryHandler(MoongladeRepository<CertificateEntity> repo) : IRequestHandler<GetCertficateByLanguageQuery, List<CertificateEntity>>
{
  public Task<List<CertificateEntity>> Handle(GetCertficateByLanguageQuery request, CancellationToken ct)
  {
	var spec = new CertificateByLanguageSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}
