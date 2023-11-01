function aa() {
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/activity/GetCheckActivityById/' + localStorage.getItem("id"), true);
  req.send();
  req.onload = function () {
    let price = JSON.parse(req.response)
    document.querySelector("#p").value = price.Price;


  }
}



//הוספת פעילות
function addActivity() {
  // let Id = document.querySelector("#id").value;
  let ActivitiesName = document.querySelector("#activitiesName").value;
  let ActivitiesPlace = document.querySelector("#activitiesPlace").value;
  let ActivitiesDate = document.querySelector("#activitiesDate").value;
  let Price = document.querySelector("#price").value;

  let req2 = new XMLHttpRequest();
  req2.open('get', 'https://localhost:44308/api/activity/GetAddNewActivities/' +
    ActivitiesName + '/' + ActivitiesPlace + '/' + ActivitiesDate + '/' + Price, true);
  req2.send();
  req2.onload = function () {
    //הדפסת התשובה על המסך
    if (req2.responseText == "-1")
      alert("הפעילות קיימת במערכת")
    else {
      alert("הפעילות נוספה בהצלחה")
      // window.location.href = "activities.html"
      // document.getElementById("add").innerHTML = req2.responseText;
    }
  }
}
//עדכון פרטים
function updateActivitiesDetails() {

  let Id = document.querySelector("#id").value;
  localStorage.setItem("id", "" + Id);
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/activity/GetActivitiesById/' + Id, true);
  req.send();
  req.onload = function () {
    request = JSON.parse(req.response);
    console.log(request)

    document.querySelector("#activitiesName").value = request.ActivitiesName;
    document.querySelector("#activitiesPlace").value = request.ActivitiesPlace;
    document.querySelector("#activitiesDate").value = request.ActivitiesDate;
    document.querySelector("#price").value = request.Price;

  }
}

//עדכון פעילויות
function changeActivitiesDetails() {
  // let Id = document.querySelector("#id").value;

  let ActivitiesName = document.querySelector("#activitiesName").value;
  let ActivitiesPlace = document.querySelector("#activitiesPlace").value;
  let ActivitiesDate = document.querySelector("#activitiesDate").value;
  let Price = document.querySelector("#price").value;
  let req5 = new XMLHttpRequest();
  req5.open('get', 'https://localhost:44308/api/activity/GetUpdateActivity/' +
    localStorage.getItem("id") + '/' + ActivitiesName + '/' + ActivitiesPlace + '/' + ActivitiesDate + '/' + Price, true);
  req5.send();
  req5.onload = function () {
    //הדפסת התשובה על המסך
    document.getElementById("add").innerHTML = req5.responseText;
  }
}

//זיהוי פעילות לפי מספר פעילות
function checkActivityById() {
  let a = document.querySelector('#activity')
  var value = a.value;
  console.log(value)
  DeleteActivity();

  // switch (a) {
  //   case 1: a.value == "תוכנית אדר"; break;
  // }
  // let id = document.querySelector("#id").value;
  // localStorage.setItem("id", "" + id);

  // let req = new XMLHttpRequest();
  // req.open('get', 'https://localhost:44308/api/activity/GetCheckActivityById/' + localStorage.getItem("id"), true);
  // req.send();
  // req.onload = function () {
  //   if (req.responseText == "1")
  //     DeleteActivity();

  //   else
  //     alert("לא קיים מספר פעילות זה");
  // }
}
//מחיקת פעילות
function DeleteActivity() {
  // let id = document.querySelector("#id").value
  let id = document.querySelector('#activity').value;
  // var value = a.value;
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/activity/GetDelete/' + id, true);
  req.send();
  req.onload = function () {
    if (req.responseText == "0")
      alert("פעילות הוסרה מהמערכת");
    if (req.responseText == "2")
      alert("מורה רשומה לפעילות, הסירי אותה קודם מהפעילות בטרם המחיקה");
    if (req.responseText == "3")
      alert("תלמידה רשומה לפעילות, הסירי אותה קודם מהפעילות בטרם המחיקה");
    else if (req.responseText == "1")
      alert("לא נמצאה פעילות,הקישי שוב");

  }
}

function allActivities() {
  let req = new XMLHttpRequest();
  let op;
  req.open('get', 'https://localhost:44308/api/activity/GetAllActivities/', true);
  req.send();
  req.onload = function () {
    activities = JSON.parse(req.response);
    console.log(activities);
    for (let i = 0; i < activities.length; i++) {
      console.log(activities.Id);
      op = document.createElement('option')
      op.value = activities[i].Id
      op.innerHTML = activities[i].ActivitiesName
      document.querySelector('#activity').appendChild(op)

    }

  }
}



//בניית פעילות עם התמונות מהDB
function buildActivity() {
  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/activity/GetAllActivities', true);
  req.send();
  req.onload = function () {
    request = JSON.parse(req.response);
    console.log(request);

    for (let i = 0; i < request.length; i++) {
      let new_div = document.createElement('div')

      let button = document.createElement('button')
      button.appendChild(new_div)
      button.type = "button"
      if (localStorage.getItem('role') == "מורה") {
        button.onclick = function () { addEtnachta(request[i].Id) }
        // button.style.cursor="pointer"
      }
      switch (request[i].ActivitiesName) {
        case "טיול":
          button.id = 'trip'
          new_div.innerHTML = "טיול"
          button.title = "טיול"
          break;
        case "יריד":
          button.id = 'Fair'
          button.title = "יריד"

          break;
        case "קארטינג":
          button.id = 'carting'
          button.title = "קארטינג"

          break;
        case "הרקדה":
          button.id = 'dance'
          button.title = "הרקדה"

          break;
        case "שירה על הים":
          button.id = 'sing'
          button.title = "שירה על הים"
          break;
        case "חפץ חיים":
          button.id = 'waterPark'
          button.title = "חפץ חיים"

          break;
        case "נסיעה לירושלים":
          button.id = 'hakotel'
          button.title = "נסיעה לירושלים"

          break;
        case "סרט":
          button.id = 'movie'
          button.title = "סרט"

          break;
        default:
          button.id = 'other'
          button.title = request[i].ActivitiesName

          break;

      }

      document.querySelector('#box').appendChild(button)

    }

  }

}
//שליפת טיול מהDB 
function trip() {
  //ת מחנה ושבת לקרוא לשתי הפונקציו 
  camp();
  shabbat();
  let year = new Date().getFullYear();

  let req = new XMLHttpRequest();
  console.log(year)
  req.open('get', 'https://localhost:44308/api/activity/GetTrip/' + year, true);
  req.send();
  req.onload = function () {
    request = JSON.parse(req.response);
    localStorage.setItem('year', request.Year)
    localStorage.setItem("activityid",request.Id)
    console.log(request);
    let div = document.createElement('div')
    div.id = "a";
    let tag_a = document.createElement('a')
    localStorage.getItem("")
    tag_a.href = "pay.html"
    tag_a.innerHTML = "טיול"
    tag_a.id = "trip"
    localStorage.getItem("trip", trip)
    div.appendChild(tag_a)
    document.querySelector("#box").appendChild(div)

  }
}
//הוספת תלמידה לטיול
function addStudentToTrip() {
  // let classTrip=document.querySelector('drop-header1')

  console.log(classTrip)
  let year = new Date().getFullYear();
  let req = new XMLHttpRequest();
  console.log(year)
  req.open('get', 'https://localhost:44308/api/activity/GetChooseTrip/' + localStorage.getItem("Id") + '/' + year, true);
  req.send();
  req.onload = function () {
    alert("נוספת בהצלחה!!")
  }
}
//שליפת מחנה מהDB 
function camp() {
  //ת מחנה ושבת לקרוא לשתי הפונקציו 
  let year = new Date().getFullYear();

  let req = new XMLHttpRequest();
  console.log(year)
  req.open('get', 'https://localhost:44308/api/activity/GetCamp/' + year, true);
  req.send();
  req.onload = function () {
    request = JSON.parse(req.response);
    localStorage.setItem('year', request.Year)
    console.log(request);
    let div = document.createElement('div')
    div.id = "a";
    let tag_a = document.createElement('a')
    tag_a.className = "drop-header"
    tag_a.href = "payCamp.html"
    tag_a.innerHTML = "מחנה"
    div.appendChild(tag_a)
    document.querySelector("#box").appendChild(div)

  }
}
//הוספת תלמידה למחנה
function addStudentToCamp() {
  // let classCamp=document.querySelector('drop-header2')
  let year = new Date().getFullYear();
  let req = new XMLHttpRequest();
  console.log(year)
  req.open('get', 'https://localhost:44308/api/activity/GetChooseCamp/' + localStorage.getItem("Id") + '/' + year, true);
  req.send();
  req.onload = function () {
    alert("נוספת בהצלחה!!")
  }
}
//שליפת שבת מחנה מהDB 
function shabbat() {
  //ת מחנה ושבת לקרוא לשתי הפונקציו 
  let year = new Date().getFullYear();

  let req = new XMLHttpRequest();
  console.log(year)
  req.open('get', 'https://localhost:44308/api/activity/GetShabbatCamp/' + year, true);
  req.send();
  req.onload = function () {
    request = JSON.parse(req.response);
    localStorage.setItem('year', request.Year)
    console.log(request);
    let div = document.createElement('div')
    div.id = "a";
    let tag_a = document.createElement('a')
    tag_a.className = "drop-header"
    tag_a.href = "payShabbat.html"
    tag_a.innerHTML = "שבת מחנה"
    div.appendChild(tag_a)
    document.querySelector("#box").appendChild(div)


  }
}
//הוספת תלמידה לשבת מחנה
function addStudentToShabbat() {
  // let classShabbatCamp=document.querySelector('drop-header3')
  let year = new Date().getFullYear();
  let req = new XMLHttpRequest();
  console.log(year)
  req.open('get', 'https://localhost:44308/api/activity/GetChooseShabbatCamp/' + localStorage.getItem("Id") + '/' + year, true);
  req.send();
  req.onload = function () {
    alert("נוספת בהצלחה!!")
  }
}


function idActivity(){
  // לשלוח לדט בייס ולקבל את האובייקט
  // let id = document.querySelector("#id").value;
  //  localStorage.setItem("id", id);

  let req = new XMLHttpRequest();
  req.open('get', 'https://localhost:44308/api/activity/GetActivitiesById/' + localStorage.getItem("activityid"), true);
  req.send();
  req.onload = function () {
    let p = JSON.parse(req.response)
    document.getElementById('price').value = p.Price
    console.log(p.Price)
  }
}


//הצגה כל הפעילויות
function ShowAllActivities() {
  let req = new XMLHttpRequest()
  //פונקצית שליפה 
  req.open('get', 'https://localhost:44308/api/activity/GetAllActivities', true)
  req.send();
  req.onload = function () {

    activities = JSON.parse(req.response);
    console.log(activities);

    let table = document.createElement('table')
    table.setAttribute('class', 'table table-primary table-bordered table-hover')

    //שורת כותרת
    let r = document.createElement('tr');
    //עמודות כותרת
    let d1 = document.createElement('th');
    d1.innerHTML = "מספר פעילות"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "שם פעילות"

    r.appendChild(d1)
   
    d1 = document.createElement('th');
    d1.innerHTML = "מקום הפעילות"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "תאריך הפעילות"
    r.appendChild(d1)

    d1 = document.createElement('th');
    d1.innerHTML = "מחיר"
    r.appendChild(d1)

    // הוספת שורת כותרת
    table.appendChild(r)

    //שורות תוכן
    for (let i = 0; i < activities.length; i++) {
      let r = document.createElement('tr');
      //עמודות תוכן
    //מספר פעילות
      let d1 = document.createElement('td');
      d1.innerHTML = activities[i].Id
      r.appendChild(d1)
     
        //שם פעילות
      d1 = document.createElement('td');
      d1.innerHTML = activities[i]. ActivitiesName

      r.appendChild(d1)

    
        //מקום הפעילות
      d1 = document.createElement('td');
      d1.innerHTML = activities[i].ActivitiesPlace

      r.appendChild(d1)

    
          //תאריך הפעילות
      d1 = document.createElement('td');
      d1.innerHTML = activities[i].ActivitiesDate

      r.appendChild(d1)

  
      //מחיר
      d1 = document.createElement('td');
      d1.innerHTML = activities[i].Price

      r.appendChild(d1)


      // הוספת שורות תוכן
      table.appendChild(r)

    }

    document.getElementById('main').appendChild(table)
  }
  // document.getElementById("message").innerHTML = req.responseText
}



