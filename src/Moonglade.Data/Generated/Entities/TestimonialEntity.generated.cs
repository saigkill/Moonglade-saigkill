//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.2.7.3
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

#nullable disable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Moonglade.Data
{
   /// <summary>
   /// My Testimonials
   /// </summary>
   [System.ComponentModel.Description("My Testimonials")]
   public partial class TestimonialEntity
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected TestimonialEntity()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static TestimonialEntity CreateTestimonialEntityUnsafe()
      {
         return new TestimonialEntity();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="link"></param>
      /// <param name="summary"></param>
      /// <param name="recommender"></param>
      /// <param name="recommenderjob"></param>
      /// <param name="recommenderlocation"></param>
      /// <param name="relationship"></param>
      /// <param name="imagepath"></param>
      /// <param name="date"></param>
      public TestimonialEntity(string link, string summary, string recommender, string recommenderjob, string recommenderlocation, string relationship, string imagepath, DateTime date)
      {
         if (string.IsNullOrEmpty(link)) throw new ArgumentNullException(nameof(link));
         this.Link = link;

         if (string.IsNullOrEmpty(summary)) throw new ArgumentNullException(nameof(summary));
         this.Summary = summary;

         if (string.IsNullOrEmpty(recommender)) throw new ArgumentNullException(nameof(recommender));
         this.Recommender = recommender;

         if (string.IsNullOrEmpty(recommenderjob)) throw new ArgumentNullException(nameof(recommenderjob));
         this.RecommenderJob = recommenderjob;

         if (string.IsNullOrEmpty(recommenderlocation)) throw new ArgumentNullException(nameof(recommenderlocation));
         this.RecommenderLocation = recommenderlocation;

         if (string.IsNullOrEmpty(relationship)) throw new ArgumentNullException(nameof(relationship));
         this.Relationship = relationship;

         if (string.IsNullOrEmpty(imagepath)) throw new ArgumentNullException(nameof(imagepath));
         this.ImagePath = imagepath;

         this.Date = date;

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="link"></param>
      /// <param name="summary"></param>
      /// <param name="recommender"></param>
      /// <param name="recommenderjob"></param>
      /// <param name="recommenderlocation"></param>
      /// <param name="relationship"></param>
      /// <param name="imagepath"></param>
      /// <param name="date"></param>
      public static TestimonialEntity Create(string link, string summary, string recommender, string recommenderjob, string recommenderlocation, string relationship, string imagepath, DateTime date)
      {
         return new TestimonialEntity(link, summary, recommender, recommenderjob, recommenderlocation, relationship, imagepath, date);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public DateTime Date { get; set; }

      /// <summary>
      /// Identity, Required
      /// </summary>
      [Key]
      [Required]
      public int Id { get; set; }

      /// <summary>
      /// Required, Max length = 150
      /// </summary>
      [Required]
      [MaxLength(150)]
      [StringLength(150)]
      public string ImagePath { get; set; }

      public global::Moonglade.Data.Enum.LanguageEnum? Language { get; set; }

      /// <summary>
      /// Required, Max length = 150
      /// </summary>
      [Required]
      [MaxLength(150)]
      [StringLength(150)]
      public string Link { get; set; }

      /// <summary>
      /// Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      public string Recommender { get; set; }

      /// <summary>
      /// Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      public string RecommenderJob { get; set; }

      /// <summary>
      /// Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      public string RecommenderLocation { get; set; }

      /// <summary>
      /// Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      public string Relationship { get; set; }

      /// <summary>
      /// Required, Max length = 600
      /// </summary>
      [Required]
      [MaxLength(600)]
      [StringLength(600)]
      public string Summary { get; set; }

   }
}

