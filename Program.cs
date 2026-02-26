namespace CSharpAssignments;
using System;
using System.Text.RegularExpressions;

public struct ColumnData
    {
        public string Display_Name;
        public string First_Name;
        public string Last_Name;
        public string Work_Email;
        public string cloud_Life_cycle_State;
        public string Identity_Id;
        public string Is_Manager;
        public string Department;
        public string Job_Title;
        public string Uid;
        public string Access_Type;
        public string Access_Source_Name;
        public string Access_Display_Name;
        public string Access_Description;

        public ColumnData(
            string displayName, string firstName, string lastName, string workEmail, string cloudLifecycleState, string identityId, string isManager,
            string department, string jobTitle, string uid, string accessType, string accessSourceName, string accessDisplayName, string accessDescription)
        {
            Display_Name = displayName;
            First_Name = firstName;
            Last_Name = lastName;
            Work_Email = workEmail;
            this.cloud_Life_cycle_State = cloudLifecycleState;
            Identity_Id = identityId;
            Is_Manager = isManager;
            Department = department;
            Job_Title = jobTitle;
            Uid = uid;
            Access_Type = accessType;
            Access_Source_Name = accessSourceName;
            Access_Display_Name = accessDisplayName;
            Access_Description = accessDescription;
        }
    }

class Program
{
    private List<ColumnData> oge_data = new List<ColumnData>();
    static void Main(string[] args)
    {
        Program program = new Program();
        program.ReadCSV("Francis Tuttle Identities_Basic.csv");
        Console.WriteLine(program.oge_data.Count);
    }

    void ReadCSV(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string header = reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 14)
                {
                    Console.WriteLine("Skipping invalid line: " + line);
                    continue;
                }

                ColumnData data_line = new ColumnData(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    parts[5],
                    parts[6],
                    parts[7],
                    parts[8],
                    parts[9],
                    parts[10],
                    parts[11],
                    parts[12],
                    parts[13]
                );

                oge_data.Add(data_line);
            }
        }
    }
}

