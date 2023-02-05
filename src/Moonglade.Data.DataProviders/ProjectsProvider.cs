using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
    /// <summary>
    /// Provider for Projects.
    /// </summary>
    /// <seealso cref="DataProvider{T}" />
    public class ProjectsProvider : DataProvider<Project>
    {
        private ILogger<ProjectsProvider> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsProvider"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="validator">The validator.</param>
        public ProjectsProvider(IHostEnvironment env, ILogger<ProjectsProvider> logger)
            : base(env, "projects.json")
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the projects for that target..
        /// </summary>
        /// <returns>Projectlist.</returns>
        public override IEnumerable<Project> Get()
        {
            LanguageEnum culture = Helper.GetLanguage();
            var projects = (base.Get() ?? Array.Empty<Project>()).Where(t => t.Language == culture).ToList();

            return projects;
        }
    }
}
