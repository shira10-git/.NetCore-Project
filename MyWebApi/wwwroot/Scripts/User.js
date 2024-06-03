let thisUser = {}
let id;

const getDetailes = (user) => {
    console.log(user);
    thisUser = user;
    id = user.id;
    alert(id)
}

//const showUpdate = () => {
//    document.getElementById("update").style.display = "block"
//}

//const handelUpdate = async (data) => {
//    const respones = await fetch(`api/User/${id}`,
//        {
//            method: 'PUT',
//            headers: { 'Content-Type': 'application/json' },
//            body: JSON.stringify(data)
//        });
//    const user = await respones.json()
//}
const showUpdate = () => {
    document.getElementById("update").style.display = "block"
}

const handelUpdate = async () => {
    const userId = sessionStorage.getItem("userID");
    const userName = document.getElementById("UserName").value;
    const LastName = document.getElementById("LastName").value;
    const Password = document.getElementById("Password").value;
    const firstName = document.getElementById("FirstName").value;

    const user = { userName: userName, lastName: LastName, Password: Password, firstName: firstName, userId: userId }
    var respones = await fetch(`api/User/${userId}`,
        {
            method: "PUT",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(user)

        })

    if (respones.status == 204) {
        alert("can't update")
    }
    else {
        alert("Updated succeded")
    }
}

const checkStrong = async (data) => {
    const respones = await fetch("api/User/check",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    const result = await respones.json()
    if (result == 0) {
        let color = document.getElementById("check")
        color.style.setProperty("background-color", "red")
    }
    if (result == 1) {
        let color = document.getElementById("check")
        color.style.setProperty("background-color", "orange")
    }
    if (result >= 2) {
        let color = document.getElementById("check")
        color.style.setProperty("background-color", "green")
    }
    return result;
}

const BackToShopping = () => {
    window.location.replace("Products.html")
}