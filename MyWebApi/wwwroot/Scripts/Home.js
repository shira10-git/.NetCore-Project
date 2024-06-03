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


//const checkStrong = async (data) => {
//    const respones = await fetch("api/User/check",
//        {
//            method: 'POST',
//            headers: { 'Content-Type': 'application/json' },
//            body: JSON.stringify(data)
//        });
//    const result = await respones.json()
//    if (result == 0) {
//        let color = document.getElementById("check")
//        color.style.setProperty("background-color", "red")
//    }
//    if (result == 1) {
//        let color = document.getElementById("check")
//        color.style.setProperty("background-color", "orange")
//    }
//    if (result >= 2) {
//        let color = document.getElementById("check")
//        color.style.setProperty("background-color", "green")
//        showRegister()
//    }
//    return result;
//}
const checkStrong = async (data) => {
    try {
        const response = await fetch("api/User/check", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const result = await response.json();
        const colorElement = document.getElementById("check");

        switch (result) {
            case 0:
                colorElement.style.setProperty("background-color", "red");
                break;
            case 1:
                colorElement.style.setProperty("background-color", "orange");
                break;
            default:
                if (result >= 2) {
                    colorElement.style.setProperty("background-color", "green");
                    showRegister();
                }
                break;
        }

        return result;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
};

const showRegister = () => {
    document.getElementById("register").style.display = "block"
}

function validateEmail(email) {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}


