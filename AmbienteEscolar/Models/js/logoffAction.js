function LogOff() {
    var data = new Date(2010, 0, 01);
    data = data.toGMTString();
    document.cookie = 'UserLogin=; expires = ' + data + '; path = /';
    window.location.href = "/Login.cshtml";
}