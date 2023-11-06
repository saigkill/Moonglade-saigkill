using Moonglade.Data.Entities;

namespace Moonglade.Data.Services;

public class ProjectService
{
	private moongladedb722Context _context;
	public ProjectService(moongladedb722Context context)
	{
		_context = context;
	}

	public void DeleteProject(long id)
	{
		try
		{
			ProjectEntity ord = _context.Projects.Find(id);
			_context.Projects.Remove(ord);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public IEnumerable<ProjectEntity> GetProjects()
	{
		try
		{
			return _context.Projects.ToList();
		}
		catch
		{
			throw;
		}
	}

	public void InsertProject(ProjectEntity project)
	{
		try
		{
			_context.Projects.Add(project);
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}

	public ProjectEntity SingleProject(long id)
	{
		throw new NotImplementedException();
	}

	public void UpdateProject(long id, ProjectEntity project)
	{
		try
		{
			var local = _context.Set<ProjectEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(project.Id));
			// check if local is not null
			if (local != null)
			{
				// detach
				_context.Entry(local).State = EntityState.Detached;
			}
			_context.Entry(project).State = EntityState.Modified;
			_context.SaveChanges();
		}
		catch
		{
			throw;
		}
	}
}
