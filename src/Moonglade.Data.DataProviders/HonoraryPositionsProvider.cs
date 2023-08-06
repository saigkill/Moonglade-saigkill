using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
	public class HonoraryPositionsProvider : DataProvider<HonoraryPositions>
	{
		private ILogger<HonoraryPositionsProvider> _logger;

		public HonoraryPositionsProvider(IHostEnvironment env, ILogger<HonoraryPositionsProvider> logger)
			: base(env, "honorary-positions.json")
		{
			_logger = logger;
		}

		public override IEnumerable<HonoraryPositions> Get()
		{
			LanguageEnum culture = Helper.GetLanguage();
			var hpos = (base.Get() ?? Array.Empty<HonoraryPositions>()).Where(t => t.Language == culture).ToList();

			return hpos;
		}
	}
}
