// MIT License
//
// Copyright (c) 2022 Sascha Manns
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
    /// <summary>
    /// Provider for Videos.
    /// </summary>
    /// <seealso cref="Video" />
    public class VideosProvider : DataProvider<Video>
    {
        private ILogger<VideosProvider> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideosProvider"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="validator">The validator</param>
        public VideosProvider(IHostEnvironment env, ILogger<VideosProvider> logger)
            : base(env, "videos.json")
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the videos..
        /// </summary>
        /// <returns>Video List.</returns>
        public override IEnumerable<Video> Get()
        {
            LanguageEnum culture = Helper.GetLanguage();
            var videos = base.Get().Where(t => t.Language == culture).OrderByDescending(p => p.DatePublished).ToList();

            return videos;
        }
    }
}
