using Moonglade.Data.Enum;

namespace Moonglade.Data.Services;

public class HonoraryPositionService
{
	private moongladedb722Context _context;
	public HonoraryPositionService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteHonoraryPosition(long id)
	{
		try
		{
			HonoraryPositonEntity ord = _context.HonoraryPositons.Find(id);
			_context.HonoraryPositons.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<HonoraryPositonEntity> GetHonoraryPositions()
	{
		try
		{
			LanguageEnum culture = DataHelper.GetLanguage();
			return _context.HonoraryPositons.Where(c => c.Language == culture).ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertPosition(HonoraryPositonEntity position)
	{
		try
		{
			_context.HonoraryPositons.Add(position);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public CertificateEntity SinglePosition(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateHonoraryPosition(long id, HonoraryPositonEntity position)
	{
		try
		{
			var local = _context.Set<HonoraryPositonEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(position.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(position).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
