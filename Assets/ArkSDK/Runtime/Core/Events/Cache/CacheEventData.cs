namespace ARK.SDK.Core.Events.Cache
{
    /// <summary>
    /// Event fired when data is cached
    /// </summary>
    public class DataCachedEventData : BaseEventData
    {
        /// <summary>
        /// Type of data that was cached
        /// </summary>
        public string DataType { get; }

        /// <summary>
        /// Key or identifier for the cached data
        /// </summary>
        public string DataKey { get; }

        public DataCachedEventData(string dataType, string dataKey)
        {
            DataType = dataType;
            DataKey = dataKey;
        }
    }

    /// <summary>
    /// Event fired when cache is cleared
    /// </summary>
    public class CacheClearedEventData : BaseEventData
    {
        /// <summary>
        /// Type of data that was cleared (null for all data)
        /// </summary>
        public string DataType { get; }

        /// <summary>
        /// Whether all cache was cleared or specific type
        /// </summary>
        public bool IsFullClear { get; }

        public CacheClearedEventData(string dataType = null)
        {
            DataType = dataType;
            IsFullClear = string.IsNullOrEmpty(dataType);
        }
    }
} 