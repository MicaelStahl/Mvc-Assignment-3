function StartTimer() {
    const timer = new Date();

    let year = timer.getFullYear();
    let month = timer.getMonth() + 1;
    let day = timer.getDate();
    let hours = timer.getHours();
    let minutes = timer.getMinutes();
    let seconds = timer.getSeconds();

    month = AddingZero(month);
    day = AddingZero(day);
    hours = AddingZero(hours);
    minutes = AddingZero(minutes);
    seconds = AddingZero(seconds);

    var footer = year + "-" + month + "-" + day + "  " + hours + ":" + minutes + ":" + seconds +
        " Micael Ståhl " + "&copy;";

    document.getElementById("foot").innerHTML = footer;
        
    setInterval(StartTimer, 1000);
}
function AddingZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}