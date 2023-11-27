
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

/* global bootstrap: false */
(() => {
    'use strict'
    const tooltipTriggerList = Array.from(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    tooltipTriggerList.forEach(tooltipTriggerEl => {
        new bootstrap.Tooltip(tooltipTriggerEl)
    })
})()