using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
	public class MandatesProvider : DataProvider<Mandates>
	{
		private ILogger<MandatesProvider> _logger;

		public MandatesProvider(IHostEnvironment env, ILogger<MandatesProvider> logger)
			: base(env, "mandates.json")
		{
			_logger = logger;
		}

		public override IEnumerable<Mandates> Get()
		{
			LanguageEnum culture = Helper.GetLanguage();
			var mandates = (base.Get() ?? Array.Empty<Mandates>()).Where(t => t.Language == culture).OrderByDescending(m => m.Years).ToList();

			return mandates;
		}
	}
}
