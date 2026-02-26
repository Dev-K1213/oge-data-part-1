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
        Program p = new Program();
        p.ReadCSV("Francis Tuttle Identities_Basic.csv");

    }

    void ReadCSV(string path)
    {
        
    }
}

