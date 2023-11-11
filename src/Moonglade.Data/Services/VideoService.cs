using LanguageEnum = Moonglade.Data.Enum.LanguageEnum;

namespace Moonglade.Data.Services;

public class VideoService
{
	private moongladedb722Context _context;
	public VideoService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteVideo(long id)
	{
		try
		{
			VideoEntity ord = _context.Videos.Find(id);
			_context.Videos.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<VideoEntity> GetVideos()
	{
		try
		{
			LanguageEnum culture = DataHelper.GetLanguage();
			return _context.Videos.Where(l => l.Language == culture).OrderByDescending(d => d.DatePublished).ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertVideo(VideoEntity video)
	{
		try
		{
			_context.Videos.Add(video);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public VideoEntity Video(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateVideo(long id, VideoEntity video)
	{
		try
		{
			var local = _context.Set<VideoEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(video.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(video).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
