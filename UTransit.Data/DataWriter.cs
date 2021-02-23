using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UTransit.Data
{
    public class QueueData
    {
        public string FileName { get; set; }
        public dynamic Data { get; set; }
    }
    public class DataWriter
    {
        static readonly ConcurrentQueue<QueueData> queune = new ConcurrentQueue<QueueData>();
        static System.Timers.Timer aTimer;
        public static void Add<T>(T data, string fileName)
        {
            queune.Enqueue(new QueueData { FileName = fileName, Data = data });
        }

        public static void WriterCsv()
        {
            if (queune.IsEmpty) return;

            aTimer.Enabled = false;
            var list = queune.ToList();
            queune.Clear();
            Parallel.ForEach(list.GroupBy(x => x.FileName).ToList(), (l) =>
            {
                var directoryName = Path.Combine(WebRoot.WWWRoot, "Data");
                
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);
                var path = Path.Combine(directoryName, $"{l.Key}.csv");

                if (!File.Exists(path))
                {
                    using FileStream fs = File.Create(path);
                    fs.Close();
                    using var writer = new StreamWriter(path);
                    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    var data = new ConcurrentBag<dynamic>();
                    Parallel.ForEach(l, (j) => { data.Add(j.Data); });
                    csv.WriteRecords(data);
                }

                else
                {
                    // Append to the file.
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        // Don't write the header again.
                        HasHeaderRecord = false,
                    };

                    using var stream = File.Open(path, FileMode.Append);
                    using var writer = new StreamWriter(stream);
                    using var csv = new CsvWriter(writer, config);
                    var data = new ConcurrentBag<dynamic>();
                    Parallel.ForEach(l, (j) => { data.Add(j.Data); });
                    csv.WriteRecords(data);
                }
            });
            aTimer.Enabled = true;
        }

        public static void Start(int seconds)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(seconds * 1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            WriterCsv();
        }


        private static string PathSetup(string fileName)
        {
            var path = Path.Combine(WebRoot.WWWRoot, $"Data/{fileName}.txt");

            if (!Directory.Exists(WebRoot.WWWRoot))
                Directory.CreateDirectory(WebRoot.WWWRoot);

            if (!File.Exists(path)) { File.Create(path); }

            return path;
        }
    }
}
