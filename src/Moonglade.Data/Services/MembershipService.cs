using Moonglade.Data.Enum;

namespace Moonglade.Data.Services;

public class MembershipService
{
	private moongladedb722Context _context;
	public MembershipService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteMembership(long id)
	{
		try
		{
			MembershipEntity ord = _context.Memberships.Find(id);
			_context.Memberships.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<MembershipEntity> GetMemberships()
	{
		try
		{
			LanguageEnum culture = DataHelper.GetLanguage();
			return _context.Memberships.Where(c => c.Language == culture).ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertMemberships(MembershipEntity membership)
	{
		try
		{
			_context.Memberships.Add(membership);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public MembershipEntity SingleMeMembership(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateMembership(long id, MembershipEntity membership)
	{
		try
		{
			var local = _context.Set<MembershipEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(membership.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(membership).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
