﻿using Moonglade.Data.Entities;

namespace Moonglade.Data
{
    public static class PostModelExtensions
    {
        /// <summary>
        /// Gets the time to read.
        /// </summary>
        /// <param name="story">The story.</param>
        /// <returns>TimeToRead object with calculated reading time.</returns>
        public static TimeToRead GetTimeToRead(this PostEntity story)
        {
            string wordCount = story.PostContent; // Get all content of the story
            int counts = wordCount.Count(ch => ch == ' ') + 1;
            int minutes = counts / 200; // Calculate Minutes
            int seconds = counts % 200 / (200 / 60); // Calculate Seconds
            string strMinutes = (minutes == 1) ? "Minute" : "Minutes";
            string strSeconds = (seconds == 1) ? "Second" : "Seconds";
            TimeToRead timeToRead = new()
            {
                Minutes = minutes,
                Seconds = seconds,
                StrMinutes = strMinutes,
                StrSeconds = strSeconds,
            };
            return timeToRead;
        }
    }
}