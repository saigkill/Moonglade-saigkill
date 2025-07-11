#nullable disable
using System.ComponentModel;

using Moonglade.Data.Specifications;

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("My Testimonials")]
public class TestimonialEntity
{
  [Description("Date of the Testimonial.")]
  public DateTime Date { get; set; }

  public int Id { get; set; }

  [Description("Image path of the recommender")]
  public string ImagePath { get; set; }

  [Description("Language of the Testimonial.")]
  public Language? Language { get; set; }

  [Description("Link to the Testimonial.")]
  public string Link { get; set; }

  [Description("Name of the recommender")]
  public string Recommender { get; set; }

  [Description("Job of the recommender")]
  public string RecommenderJob { get; set; }

  [Description("Location of the recommender")]
  public string RecommenderLocation { get; set; }

  [Description("Relationship to me")]
  public string Relationship { get; set; }

  [Description("Summary of the Testimonial")]
  public string Summary { get; set; }

  [Description("Audience of the Testimonial")]
  public Audience Audience { get; set; }
}
