
//הוספת פעילות למורות
function addEtnachta(id) {
  //let Id = document.querySelector("#id").value;
  let Id = id
  let teacher = localStorage.getItem("Id");
  //בפונקציה שמורה נכנסת
  //localStorage.setItem("idTeacher",""+idTeacher)

  // let ActivitiesPlace = document.querySelector("#activitiesPlace").value;
  // let ActivitiesDate = document.querySelector("#activitiesDate").value;
  // let Price = document.querySelector("#price").value;

  let req7 = new XMLHttpRequest();
  //req7.open('get', 'https://localhost:44308/api/activity/GetAddNewActivitiesTeacher/' +
  req7.open('get', 'https://localhost:44308/api/teacher/GetChooseActivities/' +
    teacher + '/' + Id, true);
  req7.send();
  req7.onload = function () {
    //הדפסת התשובה על המסך
    alert(req7.responseText);
  }
}
//עובד
//הוספת מורה
function addTeacher() {
  let Id = document.querySelector("#id").value;
  let FirstName = document.querySelector("#firstName").value;
  let LastName = document.querySelector("#lastName").value;
  let Educator = document.getElementById("checkmarksister");
  let c = Educator.checked;
  let Phone = document.querySelector("#phone").value;
  let Address = document.querySelector("#address").value;
  let Email = document.querySelector("#email").value;
  let Password = document.querySelector("#password").value;

  let req = new XMLHttpRequest();
  //פתיחת קריאה חדשה - סוג וכתובת
  req.open('get', 'https://localhost:44308/api/teacher/GetAddNewTeacher/' + Id + '/' + FirstName + '/' + LastName + '/' +
    Phone + '/' + Address + '/' + Password + '/' + c + '/' + Email + '/' + 'מורה', true);
  req.send();
  req.onload = function () {
    if (req.responseText == "-1")
      alert("המורה נמצאת במערכת")
    else {
      alert("נוספה בהצלחה")
      window.location.href = "managerUpdates.html"

    }

  }

}
//עובד
//עדכון פרטי מורה
function changeTeacherDetails() {

  let Id = document.querySelector("#id").value;
  let FirstName = document.querySelector("#firstName").value;
  let LastName = document.querySelector("#lastName").value;
  let Educator = document.getElementById("checkmarksister");
  let c = Educator.checked;
  let Phone = document.querySelector("#phone").value;
  let Address = document.querySelector("#address").value;
  let Email = document.querySelector("#email").value;
  let Password = document.querySelector("#password").value;
  let req = new XMLHttpRequest();

  req.open('get', 'https://localhost:44308/api/teacher/GetUpdateTeacherDetails/' + Id + '/' + FirstName + '/' + LastName + '/' +
    Phone + '/' + Address + '/' + Password + '/' + c + '/' + Email + '/' + 'מורה', true);
  req.send();
  req.onload = function () {
    alert("הפרטים עודכנו בהצלחה");
  }
}
//הוספת אתנחתות לבנות יב
function addEtnachtastudent() {
  let Id = document.querySelector("#id").value;
  let ActivitiesName = document.querySelector("#activitiesName").value;
  let ActivitiesPlace = document.querySelector("#activitiesPlace").value;
  let ActivitiesDate = document.querySelector("#activitiesDate").value;
  // let Price = document.querySelector("#price").value;

  let req7 = new XMLHttpRequest();
  req7.open('get', 'https://localhost:44308/api/activity/GetAddNewActivities/' +
    Id + '/' + ActivitiesName + '/' + ActivitiesPlace + '/' + ActivitiesDate, true);
  req7.send();
  req7.onload = function () {
    //הדפסת התשובה על המסך
    document.getElementById("student was added").innerHTML = req7.responseText;
  }
}
//שליחה לבדיקת הסיסמה  
function checkPassword() {
  let id = document.querySelector("#id").value;
  let password = document.querySelector("#pass").value;
  let req3 = new XMLHttpRequest();
  req3.open('get', 'https://localhost:44308/api/user/GetCheckPassword/' + id + '/' + password, true);
  req3.send();
  req3.onload = function () {

    // console.log(req);
    // document.getElementById("res").innerHTML ="hello"+ req.responseText;
    //   document.getElementById("res").innerHTML = 
    let ans = JSON.parse(req3.response);
    if (ans != null) {
      // let ans = JSON.parse(req3.response);
      localStorage.clear();
      localStorage.setItem("Phone", ans.Phone);
      localStorage.setItem("Password", ans.Password);
      localStorage.setItem("LastName", ans.LastName);
      localStorage.setItem("Id", ans.Id);
      localStorage.setItem("FirstName", ans.FirstName);
      localStorage.setItem("Email", ans.Email);
      localStorage.setItem("Address", ans.Address);
      localStorage.setItem("role", ans.Role);
      // localStorage.setItem("idTeacher", "" + password);
      if (ans.Role == "תלמידה")
        window.location.href = "activities.html";
      else if (ans.Role == "מורה")
        window.location.href = "teacher.html";
      else if (ans.Role == "   רכזת")
        window.location.href = "managerUpdates.html";
    }
    else
      alert("הנך לא קיימת במערכת")
  }
}
//הצגה בטבלאות
function ShowAllStudents() {
  let req = new XMLHttpRequest()
  //פונקצית שליפה 
  req.open('get', 'https://localhost:44308/api/user/GetAllUsers', true)
  req.send();
  req.onload = function () {

    users = JSON.parse(req.response);
    console.log(users);

    let table = document.createElement('table')
    table.setAttribute('class', 'table table-primary table-bordered table-hover')

    //שורת כותרת
    let r = document.createElement('tr');
    //עמודות כותרת
    let d1 = document.createElement('th');
    d1.innerHTML = "תעודת זהות"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "שם פרטי"

    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "שם משפחה"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "טלפון"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = " כתובת"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "סיסמא"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "מייל"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "מחנכת"
    r.appendChild(d1)


    // הוספת שורת כותרת
    table.appendChild(r)

    //שורות תוכן
    for (let i = 0; i < users.length; i++) {
      let r = document.createElement('tr');
      //עמודות תוכן
      //תעודת זהות
      let d1 = document.createElement('td');
      d1.innerHTML = users[i].Id
      r.appendChild(d1)

      //שם פרטי
      d1 = document.createElement('td');
      d1.innerHTML = users[i].FirstName

      r.appendChild(d1)

      //שם משפחה
      d1 = document.createElement('td');
      d1.innerHTML = users[i].LastName

      r.appendChild(d1)

      //טלפון
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Phone

      r.appendChild(d1)

      //כתובת 
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Address

      r.appendChild(d1)

      //סיסמא
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Password

      r.appendChild(d1)

      //מייל
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Email

      r.appendChild(d1)

      //מחנכת
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Educator

      r.appendChild(d1)


      // הוספת שורות תוכן
      table.appendChild(r)

    }

    document.getElementById('main').appendChild(table)
  }
  // document.getElementById("message").innerHTML = req.responseText
}
function helloTeacher() {
  let a = document.createElement('div');
  a.innerHTML = localStorage.getItem("FirstName") + " יקרה בחרי פעילויות שברצונך להשתבץ בהם ";
  document.getElementById('sayHello').appendChild(a);
}
//לשנות תאריך בפעילויות...
//מחנה
function updateDate() {
  let Campdate = document.getElementById("etnachtaDate").value;
  localStorage.setItem("date", Campdate);
  // globalVariable.Gdate = Campdate;
  window.location.href = "camp.html";
}
function getcampDate() {
  document.getElementById("dDate").innerHTML += localStorage.getItem("date");

}
//טיול
function updateDate() {
  let Tripdate = document.getElementById("etnachtaDate").value;
  localStorage.setItem("date", Tripdate);
  // globalVariable.Gdate = Campdate;
  window.location.href = "trip.html";
}
function gettripDate() {
  document.getElementById("dDate").innerHTML += localStorage.getItem("date");

}
//שבת מחנה
function updateDate() {
  let Shabbatdate = document.getElementById("etnachtaDate").value;
  localStorage.setItem("date", Shabbatdate);
  // globalVariable.Gdate = Campdate;
  window.location.href = "shabbat.html";
}
function getshabbatDate() {
  document.getElementById("dDate").innerHTML += localStorage.getItem("date");

}
//אתנחתא
function updateDate() {
  let Etnachtadate = document.getElementById("etnachtaDate").value;
  localStorage.setItem("date", Etnachtadate);
  // globalVariable.Gdate = Campdate;
  window.location.href = "etnachta.html";
}
function getetnachtaDate() {
  document.getElementById("dDate").innerHTML += localStorage.getItem("date");

}
//מחיקת מורה
function DeleteTeacher() {
  let id = document.querySelector("#id").value
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/teacher/GetDelete/' + id, true);
  req.send();
  req.onload = function () {
    if (req.responseText == "1")
      alert("מורה הוסרה מהמערכת");
      if (req.responseText == "2")
      alert("המורה רשומה לפעילות, הסירי אותה קודם מהפעילות בטרם המחיקה");
      else if (req.responseText == "0")
      alert("לא נמצאה מורה,הקישי שוב");

  }
}

//מחיקת מורה מפעילות
function DeleteTeacherFromActivity() {
  let id = document.querySelector("#id").value
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/teacher/GetDeleteTeacherFromActivity/' + id+'/'+localStorage.getItem("Id"), true);
  req.send();
  req.onload = function () {
    if (req.responseText == "1")
      alert("מורה הוסרה מהפעילות");  
      else if (req.responseText == "0")
      alert("לא נמצאה מורה,הקישי שוב");

  }
}

//בדיקת משתמש לפי תעודת זהות
function checkUserById() {
  let id = document.querySelector("#id").value;
  localStorage.setItem("id", "" + id);

  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/user/GetCheckPersonById/' + localStorage.getItem("id"), true);
  req.send();
  req.onload = function () {
    if (req.responseText == "1")
      DeleteStudent();
    else if (req.responseText == "2")
      DeleteTeacher();

    else
      alert("לא קיים מספר זהות זה");
  }
}
//התנתקות
function out() {
  // document.querySelector('#out').display="flex"
  localStorage.clear()
}
// function DeleteTeacherFromActivity() {
//   let id = document.querySelector("#idActivity").value
//   let req = new XMLHttpRequest();
//   req.open('get', 'https://localhost:44308/api/teacher/GetDelete/' + id, true);
//   req.send();
//   req.onload = function () {
//     if (req.responseText == "1")
//       alert("מורה הוסרה מהמערכת");
//       else if (req.responseText == "0")
//       alert("לא נמצאה מורה,הקישי שוב");

//   }
// }

// let student=document.querySelector('#border').children
// let info
// for(let i=0;i<student.length;i++){
//     info+=student[i].children[1].value
//     info+='/'
// }





function aaa() {
  console.log(document.getElementById('excel_file').files[0]);
}


// Create a "close" button and append it to each list item
var myNodelist = document.getElementsByTagName("LI");
var i;
for (i = 0; i < myNodelist.length; i++) {
  var span = document.createElement("SPAN");
  var txt = document.createTextNode("\u00D7");
  span.className = "close";
  span.appendChild(txt);
  myNodelist[i].appendChild(span);
}

// Click on a close button to hide the current list item
var close = document.getElementsByClassName("close");
var i;
for (i = 0; i < close.length; i++) {
  close[i].onclick = function () {
    var div = this.parentElement;
    div.style.display = "none";
  }
}

// Add a "checked" symbol when clicking on a list item

var list = document.querySelectorAll('.t');
for (let i = 0; i < list.length; i++) {
  list[i].addEventListener('click', function (ev) {
    ev.target.classList.toggle('checked');
  }, false);
}


// Create a new list item when clicking on the "Add" button
function newElement() {
  var li = document.createElement("li");
  var inputValue = document.getElementById("myInput").value;
  var t = document.createTextNode(inputValue);
  li.appendChild(t);
  if (inputValue === '') {
    alert("You must write something!");
  } else {
    document.getElementById("myUL").appendChild(li);
  }
  document.getElementById("myInput").value = "";

  var span = document.createElement("SPAN");
  var txt = document.createTextNode("\u00D7");
  span.className = "close";
  span.appendChild(txt);
  li.appendChild(span);

  for (i = 0; i < close.length; i++) {
    close[i].onclick = function () {
      var div = this.parentElement;
      div.style.display = "none";
    }
  }
}


//שייך למידע

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function () {

    /* החלף בין הוספה והסרה של המחלקה "פעילה",
    כדי לסמן את הלחצן ששולט בלוח */
    this.classList.toggle("active");

    /* מעבר בין הסתרה והצגה של החלונית הפעילה */
    var panel = this.nextElementSibling;
    if (panel.style.display === "block") {
      panel.style.display = "none";
    } else {
      panel.style.display = "block";
    }
  });
}


var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function () {
    this.classList.toggle("active");
    var panel = this.nextElementSibling;
    if (panel.style.maxHeight) {
      panel.style.maxHeight = null;
    } else {
      panel.style.maxHeight = panel.scrollHeight + "px";
    }
  });
}




// like
function myFunction(x) {
  x.classList.toggle("fa-thumbs-down");
}



//בחירת אתנחתות למורה
// function teacherSelectActivities() {


//   //  let Id = document.querySelector("#id").value;
//   //  let ActivitiesName = document.querySelector("#activitiesName").value;
//   //  let ActivitiesPlace = document.querySelector("#activitiesPlace").value;
//   //  let ActivitiesDate = document.querySelector("#activitiesDate").value;
//   //  let Price = document.querySelector("#price").value;

//   // let password = document.querySelector("#pass").value;

//   // localStorage.setItem("password", "" + password);
//   let req6 = new XMLHttpRequest();
//   req6.open('get', 'https://localhost:44308/api/activity/GetAddNewActivities/' +
//     Id + '/' + ActivitiesName + '/' + ActivitiesPlace + '/' + ActivitiesDate, true);
//   req6.send();
//   req6.onload = function () {

//     if (req6.responseText == "true")
//       window.location.href = "etnachta.html";
//     else
//       document.getElementById("res").innerHTML = "sorry,Try again...";
//   }


//   // window.location.href="etnachta.html"
//   // let select = document.querySelector("#selectAct").value
// }


//שליחה לבדיקת הסיסמה של התלמידה
// function sendRequestStudent() {
//   let password = document.querySelector("#pass").value;

//   localStorage.setItem("password", "" + password);
//   let req6 = new XMLHttpRequest();
//   req6.open('get', 'https://localhost:44308/api/user/GetCheckStudentPassword/' + password, true);
//   req6.send();
//   req6.onload = function () {
//     // console.log(req);
//     // document.getElementById("res").innerHTML ="hello"+ req.responseText;
//     //   document.getElementById("res").innerHTML = 
//     if (req6.responseText == "true")
//       window.location.href = "activities.html";
//     else
//       alert('sorry,The password is incorrect')
//     // document.getElementById("res").innerHTML = "sorry,The password is incorrect";
//   }
// }


//קובץ excel 
// function sendFile() {
//   let f = document.getElementById("csvFile");
//   console.log(f.value);
//   let fileToUpload = f.files[0];
//   const formData = new FormData();
//   formData.append('file', fileToUpload, fileToUpload.name);
//   let req = new XMLHttpRequest();
//   //פתיחת קריאה חדשה - סוג וכתובת
//   req.open('POST', 'https://localhost:44308/api/ReadCsv/postExcel', true);
//   // req.setRequestHeader('.csv', formData);
//   //שליחת הבקשה
//   req.send(formData);
//   //קבלת התשובה למשתנה req.responseText
//   req.onload = function () {

//     //הדפסת התשובה על המסך
//     //document.getElementById("res").innerHTML = req.responseText;
//     // const formData = new FormData();
//     // formData.append('file', fileToUpload, fileToUpload.name);
//     // this.http.post<any>(`${this.url}/PostExcel`, formData)

//   }
//   // this.excelService.postExcel(f.files)
//   //     .subscribe(function (ans) {
//   //         console.log(ans);
//   //     });
//   // }
// }

//פונקציה לכניסת מנהל/משתמש לאתר לפי הניתוב המתאים
// function Login() {
//   // let email = document.querySelector("#fname").value;
//   let password = document.querySelector("#lname").value
//   let req = new XMLHttpRequest();
//   req.open('get', 'https://localhost:44331/api/Person/GetLogin/' + password, true);
//   req.send();
//   req.onload = function () {
//     request = JSON.parse(req.response);
//     console.log(req.response);
//     //הדפסת התשובה על המסך
//     let password = request.Person.password;

//     // let email = request.Person.Email;
//     // FindIdByEmail(email)
//     localStorage.setItem("key", request.userType)
//     localStorage.setItem("id", request.Person.Id);
//     // localStorage.setItem("gmail", email);
//     if (request.userType == 1) {
//       window.location.href = "manager.html"
//     }
//     else if (request.userType == 2) {
//       window.location.href = "teacher.html"
//     }
//     else if (request.userType == 3) {
//       window.location.href = "student.html"
//     }
//     else
//       alert("הנך לא קים במערכת")
//   }
// }


//שליחה לבדיקת הסיסמה של המורה
// function sendRequestTeacher() {
//   let password = document.querySelector("#pass").value;
//   let req6 = new XMLHttpRequest();
//   req6.open('get', 'https://localhost:44308/api/teacher/GetCheckTeacherPassword/' + password, true);
//   req6.send();
//   req6.onload = function () {
//     // console.log(req);
//     // document.getElementById("res").innerHTML ="hello"+ req.responseText;
//     //   document.getElementById("res").innerHTML = 
//     if (req6.response != null) {
//       let ans = JSON.parse(req6.response);
//       localStorage.clear();
//       localStorage.setItem("Phone", ans.Phone);
//       localStorage.setItem("Password", ans.Password);
//       localStorage.setItem("LastName", ans.LastName);
//       localStorage.setItem("Id", ans.Id);
//       localStorage.setItem("FirstName", ans.FirstName);
//       localStorage.setItem("Email", ans.Email);
//       localStorage.setItem("Address", ans.Address);
//       // localStorage.setItem("idTeacher", "" + password);
//       window.location.href = "teacher.html";
//     }
//     else
//       alert("sorry,The password is incorrect")
//   }
// }


//בדיקה אם זה מנהל או מורה
// function teacherOrManager() {
//   let Id = document.querySelector("#id").value;
//   let req6 = new XMLHttpRequest();
//   req6.open('get', 'https://localhost:44308/api/user/GetCheckStudentPassword/' + password, true);
//   req6.send();
//   req6.onload = function () {
//     // console.log(req);
//     // document.getElementById("res").innerHTML ="hello"+ req.responseText;
//     //   document.getElementById("res").innerHTML = 
//     if (req6.responseText == "true")
//       alert('teacher');
//     else
//       alert('manager')
//     // document.getElementById("res").innerHTML = "sorry,The password is incorrect";
//   }
// }