
using System.ComponentModel.DataAnnotations;

using Moonglade.Utils;

namespace Moonglade.Data.DataProviders.Models
{
    /// <summary>
    /// Project Model.
    /// </summary>
    public class Project
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
        /// Gets or sets the portfolio link.
        /// </summary>
        /// <value>
        /// The portfolio link.
        /// </value>
        [Required]
        public string PortfolioLink { get; set; }

        /// <summary>
        /// Gets or sets the project link.
        /// </summary>
        /// <value>
        /// The project link.
        /// </value>
        public string ProjectLink { get; set; }

        /// <summary>
        /// Gets or sets the projectname.
        /// </summary>
        /// <value>
        /// The projectname.
        /// </value>
        [Required]
        public string Projectname { get; set; }

        /// <summary>
        /// Gets or sets the project blurp.
        /// </summary>
        /// <value>
        /// The project blurp.
        /// </value>
        [Required]
        public string ProjectBlurp { get; set; }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public string Clients { get; set; }

        /// <summary>
        /// Gets or sets the completion.
        /// </summary>
        /// <value>
        /// The completion.
        /// </value>
        [Required]
        public string Completion { get; set; }

        /// <summary>
        /// Gets or sets the type of the project.
        /// </summary>
        /// <value>
        /// The type of the project.
        /// </value>
        [Required]
        public string ProjectType { get; set; }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        [Required]
        public string Authors { get; set; }

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
