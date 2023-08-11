
using System.ComponentModel.DataAnnotations;

using Moonglade.Utils;

namespace Moonglade.Data.DataProviders.Models
{
	/// <summary>
	/// Talks model.
	/// </summary>
	public class Talk
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Required]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the where.
		/// </summary>
		/// <value>
		/// The where.
		/// </value>
		[Required]
		public string Where { get; set; }

		/// <summary>
		/// Gets or sets the link.
		/// </summary>
		/// <value>
		/// The link.
		/// </value>
		public string Link { get; set; }

		/// <summary>
		/// Gets or sets the blurp.
		/// </summary>
		/// <value>
		/// The blurp.
		/// </value>
		[Required]
		public string Blurp { get; set; }

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		[Required]
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the type of the talk.
		/// </summary>
		/// <value>
		/// The type of the talk.
		/// </value>
		[Required]
		public TalkType TalkType { get; set; }

		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>
		/// The language.
		/// </value>
		[Required]
		public LanguageEnum Language { get; set; }
	}
}
