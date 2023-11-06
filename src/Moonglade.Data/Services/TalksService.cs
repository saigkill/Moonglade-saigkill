using Moonglade.Data.Entities;
using Moonglade.Utils;

namespace Moonglade.Data.Services;

public class TalksService
{
	private moongladedb722Context _context;
	public TalksService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteTalk(long id)
	{
		try
		{
			TalkEntity ord = _context.Talks.Find(id);
			_context.Talks.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<TalkEntity> GetTalks()
	{
		try
		{
			LanguageEnum culture = Helper.GetLanguage();
			return _context.Talks.Where(t => t.Language == culture).OrderByDescending(p => p.Date).ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertTalk(TalkEntity talk)
	{
		try
		{
			_context.Talks.Add(talk);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public TalkEntity SingleTalk(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateTalk(long id, TalkEntity talk)
	{
		try
		{
			var local = _context.Set<TalkEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(talk.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(talk).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
