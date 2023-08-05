using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
	public class MembershipProvider : DataProvider<Memberships>
	{
		private ILogger<MembershipProvider> _logger;

		public MembershipProvider(IHostEnvironment env, ILogger<MembershipProvider> logger)
			: base(env, "memberships.json")
		{
			_logger = logger;
		}

		public override IEnumerable<Memberships> Get()
		{
			LanguageEnum culture = Helper.GetLanguage();
			var memberships = (base.Get() ?? Array.Empty<Memberships>()).Where(t => t.Language == culture).ToList();

			return memberships;
		}
	}
}
