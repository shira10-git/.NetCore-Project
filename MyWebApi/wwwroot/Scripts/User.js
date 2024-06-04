let thisUser = {}
let id;

const getDetailes = (user) => {
    console.log(user);
    thisUser = user;
    id = user.id;
    alert(id)
}

const showUpdate = () => {
    document.getElementById("update").style.display = "block"
}

const handelUpdate = async () => {
    const userId = sessionStorage.getItem("userID");
    const userName = document.getElementById("UserName").value;
    const lastName = document.getElementById("LastName").value;
    const password = document.getElementById("Password").value;
    const firstName = document.getElementById("FirstName").value;
    const email = document.getElementById("Email").value;

    let user = {}
    if (userName != "")
        user.userName = userName;
    if (lastName != "")
        user.lastName = lastName;
    if (password != "")
        user.password = password;
    if (firstName != "")
        user.firstName = firstName;
    if (email != "")
        user.email = email;
    //const user = { userName: userName, lastName: lastName, password: password, firstName: firstName, userId: userId, email: email }
    console.log(user);

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

const BackToShopping = () => {
    window.location.replace("Products.html")
}
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
                }
                break;
        }

        return result;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
};

