using System.ComponentModel.DataAnnotations;

using Moonglade.Utils;

namespace Moonglade.Data.DataProviders.Models
{
	public class Memberships
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
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
