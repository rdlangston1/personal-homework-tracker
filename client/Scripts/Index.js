const apiUrl = "http://localhost:5094/api/Assignments"
var AssignmentData;
var assignmentCount;
var NextWeek
var nextWeekDates = [];
const dates = [];


async function HandleOnLoad(){
    await FetchAssignments();
    await ConvertToNormalDate();
    await PopulateTable();
    await CheckIfAssignmentsDue();
    await CheckForExams()
  }


//Fetching Data


  async function FetchAssignments(){
    await FetchData(apiUrl).then(apiResponse => {
      AssignmentData = apiResponse;
      console.log(AssignmentData);
    })
    .catch(error => console.error('Error fetching data:', error));
}

async function FetchData(url) {
    return fetch(url)
        .then(response => response.json())
        .catch(error => {
            console.error('Error fetching data:', error);
        });
  }



// convert date to mm-dd-yy

  async function ConvertToNormalDate(){
    AssignmentData.forEach(item => {
        const date = new Date(item.assignmentDueDate);
        item.assignmentDueDate = date.toLocaleDateString('en');
        
    });
  }



  // Populate the table

  async function PopulateTable(){
    AssignmentData.forEach(item => {
        const row = document.createElement('tr');
 
      row.innerHTML = `
        <td>${item.assignmentClass}</td>
        <td>${item.assignmentName}</td>
        <td>${item.assignmentDueDate}</td>
        <td>${item.assignmentCompleted}</td>
      `;
 
      tableBody.appendChild(row);
    });
  }


// Log in console if I have an assignment

async function CheckIfAssignmentsDue(){
    var assignmentsDueList = await GetAssignmentsDueToday();
    const currentDate = new Date().toLocaleDateString()
    await CountAssignments();
    AssignmentData.forEach(item => {
        if (item.assignmentDueDate = currentDate){
            console.log(`You have ${assignmentCount} assignments due today: ${JSON.stringify(assignmentsDueList, null, 2)}`);
        }
        
    });
}

async function GetAssignmentsDueToday(){
    const currentDate = new Date().toLocaleDateString()
    var assignmentsDueList = [];
    AssignmentData.forEach((item) => {
        if(item.assignmentDueDate === currentDate){
            assignmentsDueList.push({ assignmentClass: item.assignmentClass, assignmentName: item.assignmentName });
        }
    });
    return assignmentsDueList;
}

async function CountAssignments(){
    var assignmentsDueList = await GetAssignmentsDueToday();
    assignmentCount = 0;
    await GetAssignmentsDueToday();
    assignmentsDueList.forEach(item => {
        assignmentCount++;
    });
}


async function CheckForExams(){
    nextWeekDates = await getDatesForNextWeek();
    AssignmentData.forEach(item => {
        dates.forEach(date => {
            if(item.assignmentDueDate === date){
                console.log(`Assignment "${item.assignmentName}" is due on ${date}`);
            }
        });
    });
}


// get next week dates for exams

async function getDatesForNextWeek() {
    const currentDate = new Date();
  
    for (let i = 7; i < 14; i++) {
      const nextDate = new Date(currentDate);
      nextDate.setDate(currentDate.getDate() + i + 1);
      dates.push(nextDate.toLocaleDateString('en'));
    }
  
return dates
  }

