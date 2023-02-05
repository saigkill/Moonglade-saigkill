using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

namespace Moonglade.Data.DataProviders
{
    /// <summary>
    /// Data Provider Base class.
    /// </summary>
    /// <typeparam name="T">DataType.</typeparam>
    public abstract class DataProvider<T>
    {
        private readonly string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider{T}"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="path">The path.</param>
        protected DataProvider(IHostEnvironment env, string path)
        {
            _path = Path.Combine(env.ContentRootPath, $@"Data{Path.DirectorySeparatorChar}{path}");
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Deserialized JSON object.</returns>
        public virtual IEnumerable<T> Get()
        {
            var json = File.ReadAllText(_path);
            var deserializedJson = JsonConvert.DeserializeObject<List<T>>(json);
            return deserializedJson;
        }
    }
}