using Moonglade.Data.Entities;
using Moonglade.Utils;

namespace Moonglade.Data.Services;

public class TestimonialService
{
	private moongladedb722Context _context;
	public TestimonialService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteTestimonial(long id)
	{
		try
		{
			TestimonialEntity ord = _context.Testimonials.Find(id);
			_context.Testimonials.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<TestimonialEntity> GetTestimonials()
	{
		try
		{
			LanguageEnum culture = Helper.GetLanguage();
			return _context.Testimonials.Where(c => c.Language == culture).OrderByDescending(d => d.Date).ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertTestimonial(TestimonialEntity testimonial)
	{
		try
		{
			_context.Testimonials.Add(testimonial);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public TestimonialEntity SingleTestimonial(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateTestimonial(long id, TestimonialEntity testimonial)
	{
		try
		{
			var local = _context.Set<TestimonialEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(testimonial.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(testimonial).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
