﻿
function botaoInvisible() {
    let botaoMenu = document.getElementById("linkMenu").style.visibility = "hidden";
}

function executarLogin() {
    botaoInvisible();
    let usuario = document.getElementById("login");
    let senha = document.getElementById("senha");

    let SenhaVazia = (senha.value == "" || senha.value == null);
    let UsuarioVazio = (usuario.value == "" || usuario.value == null)

    let IsNullOrEmpty = (UsuarioVazio || SenhaVazia);

    if (IsNullOrEmpty) {
        document.getElementById("confirmacao").innerHTML = "Usuário ou senha inválidos.";
    }

    return alert("Bem-vindo, " + usuario.value + "!");

    document.getElementById("linkMenu").style.visibility = "visible";
}

//==========

var myIndex = 0;
carousel();

function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    setTimeout(carousel, 10000); // Change image every 10 seconds
}

//=======================



// SPINNER WRAPPER =================

var spinnerWrapper = document.getElementById("spinnerWrapper");
var spinnerModal = document.getElementById("spinMod");

window.addEventListener('load', function () {
    if (spinnerModal.style.display = "flex") {
        spinnerModal.style.display = "none";
        spinnerWrapper.style.display = "none";
    }
});

//============
