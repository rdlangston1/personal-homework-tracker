using System.Data.SqlTypes;

namespace api.Models
{
    public class Assignment
    {
        public int assignmentID {get; set;}
        public string assignmentClass {get; set;}
        public DateTime assignmentDueDate {get; set;}
        public byte assignmentCompleted {get; set;}
        public string assignmentType {get; set;}
        public string assignmentName {get; set;}
    }
}