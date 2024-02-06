using MySql.Data.MySqlClient;
namespace api.Models

{
    public class AssignmentUtility
    {
        private readonly string cs;
        public AssignmentUtility(){
        cs = new ConnectionString().cs;
    }
    public List<Assignment> assignmentsList = new List<Assignment>();
    DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
    



//  Get all assignments

// get assignments due on current system date
// 	If assignment date = to current system date put in temp array
// 	Return temp array to user
// Get all assignments

// get assignments due on current system date
// 	If assignment date = to current system date put in temp array
// 	Return temp array to user




    public List<Assignment> GetAllAssignments(){
            using (MySqlConnection connection = new MySqlConnection(cs))
            {
                connection.Open();
 
                
 
                using (MySqlCommand command = new MySqlCommand("select* from assignment", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assignmentsList.Add(new Assignment
                            {
                                assignmentID = Convert.ToInt32(reader["assignmentID"]),
                                assignmentClass = reader["assignmentClass"].ToString(),
                                assignmentDueDate = (DateTime)reader["assignmentDueDate"],
                                assignmentCompleted = Convert.ToByte(reader["assignmentCompleted"]),
                                assignmentType = reader["assignmentType"].ToString(),
                                assignmentName = reader["assignmentName"].ToString(),
                            });
                        }
                    }
                }
                connection.Close();
                return assignmentsList;
            }
        }


        // public void CheckIfAssignments(){
        //     GetAllAssignments();
        //     CheckIfDueDate();

        // }

        // public void CheckIfDueDate(){
        //         foreach (Assignment Assignment in assignmentsList)
        //         {
        //             if(Assignment.assignmentDueDate == currentDate){
        //                     System.Console.WriteLine(Assignment.assignmentName);
        //             }
        //         }

        // }
}
}