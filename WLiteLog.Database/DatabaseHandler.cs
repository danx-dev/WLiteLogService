using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLiteLog.Database
{
    public class DatabaseHandler
    {
        private static DatabaseHandler _instance;
        private static readonly object PadLock = new object();
        private string _connectionString = @"Data Source='C:\SQL\logging.db'";
        private DatabaseHandler() { }

        public static DatabaseHandler Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _instance ?? (_instance = new DatabaseHandler());
                }
            }
        }

        public void AddLog(LogEntry log)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                var query = @"INSERT INTO LOGTABLE (Timestamp,Loglevel,Application,Session,Callsite,Message) 
                            VALUES('@Timestamp','@Loglevel','@Application','@Session','@Callsite','@Message')";
                query = query.Replace("@Timestamp", DateTime.Now.ToString());
                query = query.Replace("@Loglevel", log.LogLevel);
                query = query.Replace("@Application", log.Application);
                query = query.Replace("@Session", log.Session);
                query = query.Replace("@Callsite", log.Callsite);
                query = query.Replace("@Message",log.Message);
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<LogEntry> GetDefault()
        {
            var list = new List<LogEntry>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                var query = @"SELECT * FROM LOGTABLE WHERE Timestamp > '@DATE'";
                query = query.Replace("@DATE", DateTime.Now.AddHours(-2).ToString());
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                var log = new LogEntry();
                                log.Id = reader.GetString(0);
                                log.LogDateTime = DateTime.Parse(reader.GetString(1));
                                log.LogLevel = reader.GetString(2);
                                log.Application = reader.GetString(3);
                                log.Session = reader.GetString(4);
                                log.Callsite = reader.GetString(5);
                                log.Message = reader.GetString(6);
                                list.Add(log);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }
            }
            return list;
        }

        public List<string> GetApps(DateTime date)
        {
            var response = new List<string>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                var query = @"SELECT Application FROM LOGTABLE WHERE Timestamp > '@DATE'";
                query = query.Replace("@DATE", date.ToString());
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                response.Add(reader.GetString(0));
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }

                return response;
            }
        }

        public LogEntry GetLogEntry(string id)
        {
            LogEntry entry = null;
            using (var conn = new SQLiteConnection(_connectionString))
            {
                var query = @"SELECT * FROM LOGTABLE WHERE Id = '@ID'";
                query = query.Replace("@ID", id);
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                entry = new LogEntry();
                                entry.Id = id;
                                entry.LogDateTime = DateTime.Parse(reader.GetString(1));
                                entry.LogLevel = reader.GetString(2);
                                entry.Application = reader.GetString(3);
                                entry.Session = reader.GetString(4);
                                entry.Callsite = reader.GetString(5);
                                entry.Message = reader.GetString(6);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }

                return entry;
            }
        }

    }
}
