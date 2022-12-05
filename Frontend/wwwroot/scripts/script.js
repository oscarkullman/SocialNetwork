function alertMessage(message) {
    alert(message);
}

function logIn(username) {
    window.localStorage.setItem("user", username);
}

function getUser() {
    return window.localStorage.getItem("user");
}

function logOut() {
    window.localStorage.removeItem("user");
}

function isAuthenticated() {
    var username = window.localStorage.getItem("user");

    if (username == null) {
        return false;
    } else {
        return true;
    }
}
