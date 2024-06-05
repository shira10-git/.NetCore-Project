let currentUser = {};
let userId;

window.addEventListener("load", async function () {
    console.log("startUser");
    await getDetails()
});

const getDetails = async () => {
    userId = await JSON.parse(sessionStorage.getItem("userID"))
    currentUser = await getCurrentUser();
    console.log(currentUser);
    console.log("u", userId);
};

const getCurrentUser = async () => {
    try {
        const response = await fetch(`api/User/${userId}`);
        const user = await response.json();
        if (user) {
            console.log(user);
            return user; 
        }
    } catch {
        alert("try again");
    }
}

const showUpdateForm = () => {
    document.getElementById("update").style.display = "block";
    showUserDetails();
};

const showUserDetails = async () => {
    console.log("show", currentUser);
    document.getElementById("UserName").value = await currentUser.userName.trim();
    document.getElementById("LastName").value = await currentUser.lastName.trim();
    document.getElementById("Password").value = await currentUser.password.trim();
    document.getElementById("FirstName").value = await currentUser.firstName.trim();
    document.getElementById("Email").value = await currentUser.email.trim();
    await checkPasswordStrength(currentUser.password.trim())
}

const handleUpdate = async () => {
    const userId = sessionStorage.getItem("userID");
    const userName = document.getElementById("UserName").value;
    const lastName = document.getElementById("LastName").value;
    const password = document.getElementById("Password").value;
    const firstName = document.getElementById("FirstName").value;
    const email = document.getElementById("Email").value;

    let updatedUser = {};

    if (userName !== "") updatedUser.userName = userName;
    if (lastName !== "") updatedUser.lastName = lastName;
    if (password !== "") updatedUser.password = password;
    if (firstName !== "") updatedUser.firstName = firstName;
    if (email !== "") updatedUser.email = email;

    console.log(updatedUser);

    try {
        const response = await fetch(`api/User/${userId}`, {
            method: "PUT",
            headers: { 'Content-Type': "application/json" },
            body: JSON.stringify(updatedUser)
        });

        if (response.status === 204) {
            alert("Update failed");
        } else {
            alert("Update succeeded");
        }
    } catch (error) {
        console.error("Error updating user:", error);
    }
};

const backToShopping = () => {
    window.location.replace("Products.html");
};

const checkPasswordStrength = async (data) => {
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
                colorElement.style.backgroundColor = "red";
                break;
            case 1:
                colorElement.style.backgroundColor = "orange";
                break;
            default:
                if (result >= 2) {
                    colorElement.style.backgroundColor = "green";
                }
                break;
        }

        return result;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
};