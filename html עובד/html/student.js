//הוספת תלמידה
function sendRequest() {
  //שליפת השם לשליחה
  let Id = document.querySelector("#id").value;
  let FirstName = document.querySelector("#firstName").value;
  let LastName = document.querySelector("#lastName").value;
  let FatherName = document.querySelector("#fatherName").value;
  let MotherName = document.querySelector("#motherName").value;
  let Sister = document.getElementById("checkmarksister");
  let c = Sister.checked;
  console.log(c)
  let Phone = document.querySelector("#phone").value;
  let Address = document.querySelector("#address").value;
  let Age = document.querySelector("#age").value;
  let ClassNum = document.querySelector("#classn").value;
  let Pharm = document.querySelector("#pharm").value;
  let Email = document.querySelector("#email").value;
  let Password = document.querySelector("#password").value;

  console.log(Pharm);
  //יצירת קריאה חדשה
  let req = new XMLHttpRequest();
  //פתיחת קריאה חדשה - סוג וכתובת
  req.open('get', 'https://localhost:44308/api/user/GetAddNewUser/' + Id + '/' + FirstName + '/' + LastName + '/' +
    FatherName + '/' + MotherName + '/' + c + '/' + Phone + '/' + Address + '/' + Age + '/' + ClassNum + '/' + Pharm + '/' + Email + '/' +
    Password +'/'+"תלמידה",true);
  //שליחת הבקשה
  req.send();
  //קבלת התשובה למשתנה req.responseText
  req.onload = function () {
    //הדפסת התשובה על המסך
    //document.getElementById("res").innerHTML = req.responseText;
    if (req.responseText == "-1")
      alert("התלמידה נמצאת במערכת")
    else {
      alert("נוספה בהצלחה")
      window.location.href = "activities.html"
    }
  }

}
//עדכון פרטים
function updateDetails() {

  let Id = document.querySelector("#id").value;
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/user/GetUser/' + Id, true);
  req.send();
  req.onload = function () {
    request = JSON.parse(req.response);
    console.log(request)
    document.querySelector("#id1").value = request.Id;
    document.querySelector("#firstName").value = request.FirstName
    document.querySelector("#lastName").value = request.LastName
    document.querySelector("#fatherName").value = request.FatherName
    document.querySelector("#motherName").value = request.MotherName
    document.querySelector("#checkmarksister1").checked = request.Sister
    document.querySelector("#phone1").value = request.Phone
    document.querySelector("#address1").value = request.Address
    document.querySelector("#age1").value = request.Age
    document.querySelector("#pharm1").value = request.Pharm
    document.querySelector("#email1").value = request.Password
    document.querySelector("#password1").value = request.Email
    document.querySelector("#classn").value = request.ClassNum

  }
}
//מחיקת תלמידה
function DeleteStudent() {
  let id = document.querySelector("#id").value
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/user/GetDelete/' + id, true);
  req.send();
  req.onload = function () {
    if (req.responseText == "1")
      alert("תלמידה הוסרה מהמערכת");
      if (req.responseText == "2")
      alert("התלמידה רשומה לפעילות, הסירי אותה קודם מהפעילות בטרם המחיקה");
    else if (req.responseText == "0")
      alert("לא נמצאה תלמידה,הקישי שוב");
    // else
    //   alert("תלמידה לא נמחקה, נסי שוב");

  }
}
//התחברות
function connect() {
  window.location.href = "studentDetails.html"
}
//עדכון פרטי התלמידה
function changeStudentDetails() {

  let Id = document.querySelector("#id").value;
  let FirstName = document.querySelector("#firstName").value;
  let LastName = document.querySelector("#lastName").value;
  let FatherName = document.querySelector("#fatherName").value;
  let MotherName = document.querySelector("#motherName").value;
  let Sister = document.getElementById("checkmarksister1");
  let c = Sister.checked;
  let Phone = document.querySelector("#phone1").value;
  let Address = document.querySelector("#address1").value;
  let Age = document.querySelector("#age1").value;
  let ClassNum = document.querySelector("#classn").value;
  let Pharm = document.querySelector("#pharm1").value;
  let Password = document.querySelector("#password1").value;
  let Email = document.querySelector("#email1").value;
  let req4 = new XMLHttpRequest();
  req4.open('get', 'https://localhost:44308/api/user/GetUpdateStudentDetails/' + Id + '/' + FirstName + '/' + LastName + '/' +
    FatherName + '/' + MotherName + '/' + c + '/' + Phone + '/' + Address + '/' + Age + '/' + ClassNum + '/' + Pharm + '/' + Password + '/' +
    Email + '/' + "תלמידה", true);
  req4.send();
  req4.onload = function () {
    document.getElementById("res").innerHTML = req4.responseText;
  }
}
//הוספת תלמידה לטיול-לרשימה
function addStudentToTrip() {

  let Id = document.querySelector("#id").value;
  let FirstName = document.querySelector("#firstName").value;
  let LastName = document.querySelector("#lastName").value;
  let FatherName = document.querySelector("#fatherName").value;
  let MotherName = document.querySelector("#motherName").value;
  let Phone = document.querySelector("#phone").value;
  let Address = document.querySelector("#address").value;
  let Age = document.querySelector("#age").value;
  let Pharm = document.querySelector("#pharm").value;
  let Password = document.querySelector("#password").value;
  let Email = document.querySelector("#email").value;
  let req4 = new XMLHttpRequest();
  req4.open('get', 'https://localhost:44308api/user/GetAddStudentToTrip/' + Id + '/' + FirstName + '/' + LastName + '/' +
    FatherName + '/' + MotherName + '/' + Phone + '/' + Address + '/' + Age + '/' + Pharm + '/' + Password + '/' +
    Email, true);
  req4.send();
  req4.onload = function () {
    document.getElementById("res").innerHTML = req4.responseText;
    // window.location.href = "pay.html"
  }
}
function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}

//הצגה כל התלמידות
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
    d1.innerHTML = "שם אב"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "שם אם"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "אחות"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "טלפון"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = " כתובת"

    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "גיל"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "קופת חולים"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "סיסמא"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "מייל"
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

      //שם אב
      d1 = document.createElement('td');
      d1.innerHTML = users[i].FatherName

      r.appendChild(d1)

      //שם אם
      d1 = document.createElement('td');
      d1.innerHTML = users[i].MotherName

      r.appendChild(d1)

      //אחות
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Sister

      r.appendChild(d1)


      //טלפון
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Phone

      r.appendChild(d1)

      //כתובת 
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Address

      r.appendChild(d1)

      //גיל
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Age

      r.appendChild(d1)

      //קופת חולים
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Pharm

      r.appendChild(d1)

      //סיסמא
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Password

      r.appendChild(d1)

      //מייל
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Email

      r.appendChild(d1)

      // הוספת שורות תוכן
      table.appendChild(r)

    }

    document.getElementById('main').appendChild(table)
  }
  // document.getElementById("message").innerHTML = req.responseText
}
//הצגה כל המורות
function ShowAllTeachers() {
  let req = new XMLHttpRequest()
  //פונקצית שליפה 
  req.open('get', 'https://localhost:44308/api/teacher/GetAllTeachers', true)
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
//שליפה של התלמידות שנרשמו לפעילות מסוימת-מחנה טיול או שבת מחנה
function ShowAllStudentsTrip() {
  let id = document.querySelector("#idCamp").value
  let req = new XMLHttpRequest()
  //פונקצית שליפה 
  req.open('get', 'https://localhost:44308/api/activity/GetStudentsOfActivity/'+ id, true)
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
    d1.innerHTML = "שם אב"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "שם אם"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "אחות"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "טלפון"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = " כתובת"

    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "גיל"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "קופת חולים"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "סיסמא"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "מייל"
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

      //שם אב
      d1 = document.createElement('td');
      d1.innerHTML = users[i].FatherName
      r.appendChild(d1)

      //שם אם
      d1 = document.createElement('td');
      d1.innerHTML = users[i].MotherName
      r.appendChild(d1)

      //אחות
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Sister
      r.appendChild(d1)


      //טלפון
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Phone
      r.appendChild(d1)

      //כתובת 
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Address
      r.appendChild(d1)

      //גיל
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Age
      r.appendChild(d1)

      //קופת חולים
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Pharm
      r.appendChild(d1)

      //סיסמא
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Password
      r.appendChild(d1)

      //מייל
      d1 = document.createElement('td');
      d1.innerHTML = users[i].Email
      r.appendChild(d1)

      // הוספת שורות תוכן
      table.appendChild(r)

    }

    document.getElementById('active').appendChild(table)
  }
  // document.getElementById("message").innerHTML = req.responseText
}



