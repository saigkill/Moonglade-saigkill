
using System.ComponentModel.DataAnnotations;

using Moonglade.Utils;

namespace Moonglade.Data.DataProviders.Models;

/// <summary>
/// Testimonial Model.
/// </summary>
public class Testimonial
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
	/// Gets or sets the recommender.
	/// </summary>
	/// <value>
	/// The recommender.
	/// </value>
	[Required]
	public string Recommender { get; set; }

	/// <summary>
	/// Gets or sets the recommender job.
	/// </summary>
	/// <value>
	/// The recommender job.
	/// </value>
	public string RecommenderJob { get; set; }

	/// <summary>
	/// Gets or sets the recommender location.
	/// </summary>
	/// <value>
	/// The recommender location.
	/// </value>
	public string RecommenderLocation { get; set; }

	/// <summary>
	/// Gets or sets the relationship.
	/// </summary>
	/// <value>
	/// The relationship.
	/// </value>
	[Required]
	public string Relationship { get; set; }

	/// <summary>
	/// Gets or sets the image path.
	/// </summary>
	/// <value>
	/// The image path.
	/// </value>
	[Required]
	public string ImagePath { get; set; }

	/// <summary>
	/// Gets or sets the date.
	/// </summary>
	/// <value>
	/// The date.
	/// </value>
	[Required]
	public DateTime Date { get; set; }

	/// <summary>
	/// Gets or sets the language.
	/// </summary>
	/// <value>
	/// The language.
	/// </value>
	[Required]
	public LanguageEnum Language { get; set; }
}
