


function GetUserList() {
    $.get("/People/GetListOfPeople", function (response) {
        document.getElementById('userListHere').innerHTML = response;
    })
    }
}