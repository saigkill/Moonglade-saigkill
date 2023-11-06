using Moonglade.Data.Entities;
using Moonglade.Utils;

namespace Moonglade.Data.Services;

public class MandateService
{
	private moongladedb722Context _context;
	public MandateService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteMandate(long id)
	{
		try
		{
			MandateEntity ord = _context.Mandates.Find(id);
			_context.Mandates.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<MandateEntity> GetMandates()
	{
		try
		{
			LanguageEnum culture = Helper.GetLanguage();
			return _context.Mandates.Where(c => c.Language == culture).OrderByDescending(d => d.Years).ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertMandate(MandateEntity mandate)
	{
		try
		{
			_context.Mandates.Add(mandate);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public MandateEntity SingleMandate(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateMandate(long id, MandateEntity mandate)
	{
		try
		{
			var local = _context.Set<MandateEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(mandate.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(mandate).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
