let mySchedulesButton;    //My schedules button
let accordionMySchedules;     //My schedules div

//Execute when window loaded
window.addEventListener("load", function () {
    mySchedulesButton = document.getElementById("mySchedulesButton");
    accordionMySchedules = document.getElementById("accordionMySchedules");

    mySchedulesButton.addEventListener("click", toggleMySchedules);

    //loadSchedulesFromDB();
    getMySchedules();
});

function toggleMySchedules() {
    const ele = mySchedulesButton.querySelector("i");
    //ele.classList.toggle("spin");

    toggleAccordion(accordionMySchedules);
}

function toggleAccordion(HTMLElement) {
    if (HTMLElement.style.maxHeight) {
        HTMLElement.style.maxHeight = null;
        mySchedulesButton.blur();   //remove focus
    } else {
        HTMLElement.style.maxHeight = HTMLElement.scrollHeight + "px";
    }
}

/*
function loadSchedulesFromDB() {
    //load items from db
    const xhr = new XMLHttpRequest();
    xhr.addEventListener("load", onLoadSchedulesFromDB);
    xhr.open("GET", "Data/GetSchedules?userid=" + currentUser.id);
    xhr.send();
}
*/

//function onLoadSchedulesFromDB() {
function getMySchedules() {
    userSchedules.forEach(schedule => {
        const item = document.createElement("button");

        item.innerText = schedule.title;
        item.classList.add("sm-btn-nav");

        item.addEventListener("click", function () {
            //scheduleDiv.dataset.currentSchedule = schedule.title;
            //console.log("clicked on " + schedule.title);
            currSchedule = schedule;
            refreshSchedule(schedule);
        });

        accordionMySchedules.appendChild(item);
    });
}

//fill with const items
function loadTestSchedules() {
    for (let i = 0; i < 5; i++) {
        const ele = document.createElement("button");
        ele.innerText = "Item " + i;
        ele.classList.add("sm-btn-nav");
        accordionMySchedules.appendChild(ele);
    }
}