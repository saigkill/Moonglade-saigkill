using System.ComponentModel.DataAnnotations;

using Moonglade.Utils;
namespace Moonglade.Data.DataProviders.Models
{
    /// <summary>
    /// Video Model.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the video code.
        /// </summary>
        /// <value>
        /// The video code. Let me say, you want to embed that Youtube Video: https://www.youtube.com/watch?v=gooI9E4KY4Q
        /// then "gooI9E4KY4Q" is your video code.
        /// </value>
        [Required]
        public string VideoCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the video.
        /// </summary>
        /// <value>
        /// The type of the video.
        /// </value>
        [Required]
        public VideoType VideoType { get; set; }

        /// <summary>
        /// Gets or sets the date published.
        /// </summary>
        /// <value>
        /// The date published.
        /// </value>
        [Required]
        public DateTime DatePublished { get; set; }

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
