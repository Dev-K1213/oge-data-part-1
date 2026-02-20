using System;
using System.Collections.Generic;
using System.IO;

namespace oge_data_part_1
{
    struct StudentEvent
    {
        public string Date { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Event { get; set; }
    }

    class Program
    {
        static void Main()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "Attendence.csv";
            string filePath = Path.Combine(baseDir, fileName);

           
            Dictionary<int, List<StudentEvent>> studentData = new Dictionary<int, List<StudentEvent>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool headerSkipped = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!headerSkipped)
                    {
                        headerSkipped = true;
                        continue;
                    }

                    string[] parts = line.Split(',');

                    string date = parts[0];
                    int id = int.Parse(parts[1]);
                    string name = parts[2];
                    string course = parts[3];
                    string ev = parts[4];

                    StudentEvent record = new StudentEvent
                    {
                        Date = date,
                        StudentID = id,
                        Name = name,
                        Course = course,
                        Event = ev
                    };

                    
                    if (!studentData.ContainsKey(id))
                    {
                        studentData[id] = new List<StudentEvent>();
                    }

                    
                    List<StudentEvent> events = studentData[id];
                    int index = events.FindIndex(e => string.Compare(e.Date, record.Date) > 0);
                    if (index == -1)
                        events.Add(record);
                    else
                        events.Insert(index, record);
                }
            }

           
            foreach (var kvp in studentData)
            {
                int id = kvp.Key;
                var events = kvp.Value;
                string name = events[0].Name;

                Console.WriteLine($"Student ID: {id}");
                Console.WriteLine($"Student Name: {name}");
                Console.WriteLine("Date\tCourse\tEvent");

                foreach (var e in events)
                {
                    Console.WriteLine($"{e.Date}\t{e.Course}\t{e.Event}");
                }

                Console.WriteLine();
            }

            
            Console.WriteLine(" Summary Report \n");
            Console.WriteLine($"{"Student ID"} {"Name"} {"# Absent"} {"# Tardy"}");

            foreach (var kvp in studentData)
            {
                int id = kvp.Key;
                var events = kvp.Value;
                string name = events[0].Name;

                int absCount = 0;
                int tardyCount = 0;

                foreach (var e in events)
                {
                    if (e.Event.Equals("Absent"))
                        absCount++;
                    else if (e.Event.Equals("Tardy"))
                        tardyCount++;
                }

                Console.WriteLine($"{id} {name} {absCount} {tardyCount}");
            }
        }
    }
}
