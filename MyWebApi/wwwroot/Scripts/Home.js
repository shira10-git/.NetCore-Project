let thisUser = {}
let id=0;

const handelRegister = async (data) => {
    console.log("ddddd" + data.Email)
    const checkValid = await validateEmail(data.email)
    console.log(checkValid)
    if (checkValid)
        sendToRegister(data)
    else {
        alert("invalid email!")
    }
}

const sendToRegister = async (data) => {
    const respones = await fetch("api/User/register",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    try {
        const user = await respones.json()
        if (user) {
            alert("add successfully")
        }
    }
    catch {
        alert("try again")
    }
}

const handelLogin = async () => {
    const userName = document.getElementById("UserName").value;
    const password = document.getElementById("Password").value;
    const user = { userName: userName, password: password }
    const respones = await fetch("api/User/login",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });
    if (!respones.status == 200) {
        alert("Unauthorized")
    }
    else {
        const data = await respones.json()
        alert("welcome to!! " + data.userName)
        console.log(data.userId)
        sessionStorage.setItem("userID", data.userId);
        sessionStorage.setItem("basket","[]")
        window.location.replace("Products.html")
    }

    }

const showReg = () => {
    document.getElementById("reg").style.display = "block"
}

//const showUpdate = () => {
//    document.getElementById("update").style.display = "block"
//}

//const handelUpdate = async () => {
//    const userId = sessionStorage.getItem("userID");
//    const userName = document.getElementById("UserName").value;
//    const LastName = document.getElementById("LastName").value;
//    const Password = document.getElementById("Password").value;
//    const firstName = document.getElementById("FirstName").value;

//    const user = { userName: userName, lastName: LastName, Password: Password, firstName: firstName ,userId:userId}
//    var respones = await fetch(`api/User/${userId}`,
//        {
//            method: "PUT",
//            headers: {
//                'Content-Type': "application/json"
//            },
//            body: JSON.stringify(user)

//        })
    
//    if (respones.status == 204) {
//        alert("can't update")
//    }
//    else {
//        alert("Updated succeded")
//    }
//}

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
        showRegister()
    }
    return result;
}

const showRegister = () => {
    document.getElementById("register").style.display = "block"
}

function validateEmail(email) {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}


