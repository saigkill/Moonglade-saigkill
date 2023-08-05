using System.ComponentModel.DataAnnotations;

using Moonglade.Utils;

namespace Moonglade.Data.DataProviders.Models
{
	public class HonoraryPositions
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Link { get; set; }

		[Required]
		public string Org { get; set; }

		public string Blurp { get; set; }

		[Required]
		public bool Active { get; set; }

		[Required]
		public LanguageEnum Language { get; set; }
	}
}
