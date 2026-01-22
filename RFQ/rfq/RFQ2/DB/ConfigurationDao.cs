using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RFQ2.DB
{
    /// <summary>
    /// Data Access Object for reading configuration from Tbl_Configuration in separate database
    /// </summary>
    public class ConfigurationDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Cache for configuration values
        private static Dictionary<string, ConfigItem> _configCache = null;
        private static readonly object _lock = new object();

        /// <summary>
        /// Configuration item model
        /// </summary>
        public class ConfigItem
        {
            public int ID { get; set; }
            public string Key { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string ModifiedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
        }

        /// <summary>
        /// Get the configuration database connection string
        /// </summary>
        private static string GetConfigConnectionString()
        {
            return ConfigurationManager.AppSettings["ConfigConnection"]?.ToString()
                ?? "Server=(local);Database=DIM_RECORDING_USR;Integrated Security=true;";
        }

        /// <summary>
        /// Load all configuration from database into cache
        /// </summary>
        public static void LoadConfiguration()
        {
            lock (_lock)
            {
                if (_configCache == null)
                {
                    _configCache = new Dictionary<string, ConfigItem>(StringComparer.OrdinalIgnoreCase);
                }
                else
                {
                    _configCache.Clear();
                }

                try
                {
                    string connectionString = GetConfigConnectionString();
                    log.Info("Loading configuration from DIM_RECORDING_USR database...");

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT [ID], [Key], [Type], [Value], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate] FROM [dbo].[Tbl_Configuration]";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var item = new ConfigItem
                                    {
                                        ID = reader.GetInt32(0),
                                        Key = reader.IsDBNull(1) ? null : reader.GetString(1),
                                        Type = reader.IsDBNull(2) ? null : reader.GetString(2),
                                        Value = reader.IsDBNull(3) ? null : reader.GetString(3),
                                        CreatedBy = reader.IsDBNull(4) ? null : reader.GetString(4),
                                        CreatedDate = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                        ModifiedBy = reader.IsDBNull(6) ? null : reader.GetString(6),
                                        ModifiedDate = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                                    };

                                    if (!string.IsNullOrEmpty(item.Key))
                                    {
                                        _configCache[item.Key] = item;
                                        log.Debug($"Loaded config: {item.Key} = {item.Value}");
                                    }
                                }
                            }
                        }
                    }

                    log.Info($"Configuration loaded successfully. Total items: {_configCache.Count}");
                }
                catch (Exception ex)
                {
                    log.Error("Error loading configuration from database: " + ex.Message, ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get configuration value by key
        /// </summary>
        public static string GetValue(string key)
        {
            if (_configCache == null)
            {
                LoadConfiguration();
            }

            if (_configCache != null && _configCache.TryGetValue(key, out ConfigItem item))
            {
                return item.Value;
            }

            log.Warn($"Configuration key not found: {key}");
            return null;
        }

        /// <summary>
        /// Get configuration value by key with default value
        /// </summary>
        public static string GetValue(string key, string defaultValue)
        {
            return GetValue(key) ?? defaultValue;
        }

        /// <summary>
        /// Get configuration item by key
        /// </summary>
        public static ConfigItem GetConfigItem(string key)
        {
            if (_configCache == null)
            {
                LoadConfiguration();
            }

            if (_configCache != null && _configCache.TryGetValue(key, out ConfigItem item))
            {
                return item;
            }

            return null;
        }

        /// <summary>
        /// Get all configuration items of a specific type
        /// </summary>
        public static List<ConfigItem> GetByType(string type)
        {
            if (_configCache == null)
            {
                LoadConfiguration();
            }

            var result = new List<ConfigItem>();
            if (_configCache != null)
            {
                foreach (var item in _configCache.Values)
                {
                    if (string.Equals(item.Type, type, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get all folder configurations
        /// </summary>
        public static List<ConfigItem> GetFolders()
        {
            return GetByType("Folder");
        }

        /// <summary>
        /// Get all settings configurations
        /// </summary>
        public static List<ConfigItem> GetSettings()
        {
            return GetByType("Settings");
        }

        /// <summary>
        /// Get all query configurations
        /// </summary>
        public static List<ConfigItem> GetQueries()
        {
            return GetByType("Query");
        }

        /// <summary>
        /// Reload configuration from database
        /// </summary>
        public static void ReloadConfiguration()
        {
            lock (_lock)
            {
                _configCache = null;
                LoadConfiguration();
            }
        }

        /// <summary>
        /// Check if configuration is loaded
        /// </summary>
        public static bool IsConfigurationLoaded()
        {
            return _configCache != null && _configCache.Count > 0;
        }
    }
}
