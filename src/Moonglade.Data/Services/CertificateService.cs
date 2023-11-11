using Moonglade.Data.Enum;

namespace Moonglade.Data.Services;

/// <summary>
/// Job Certification Service.
/// </summary>
/// <seealso cref="CertificateEntity" />
public class CertificateService
{
	private moongladedb722Context _context;

	/// <summary>
	/// Initializes a new instance of the <see cref="CertificateService"/> class.
	/// </summary>
	/// <param name="context">The context.</param>
	public CertificateService(moongladedb722Context context)
	{
		_context = context;
	}

	/// <summary>
	/// Deletes the certificate.
	/// </summary>
	/// <param name="id">The identifier.</param>
	public void DeleteCertificate(long id)
	{
		try
		{
			CertificateEntity ord = _context.Certificates.Find(id);
			_context.Certificates.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// Gets the certificates.
	/// </summary>
	/// <returns></returns>
	public IEnumerable<CertificateEntity> GetCertificates()
	{
		try
		{
			LanguageEnum culture = DataHelper.GetLanguage();
			return _context.Certificates.Where(c => c.Language == culture).OrderByDescending(p => p.Year).ToList();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// Inserts the book.
	/// </summary>
	/// <param name="certificate">The certificate.</param>
	public void InsertBook(CertificateEntity certificate)
	{
		try
		{
			_context.Certificates.Add(certificate);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// Singles the certificate.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns></returns>
	/// <exception cref="System.NotImplementedException"></exception>
	public CertificateEntity SingleCertificate(long id)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Updates the certificate.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <param name="certificate">The certificate.</param>
	public void UpdateCertificate(long id, CertificateEntity certificate)
	{
		try
		{
			var local = _context.Set<CertificateEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(certificate.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(certificate).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
