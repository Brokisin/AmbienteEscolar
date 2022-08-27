
function botaoInvisible() {
    let botaoMenu = document.getElementById("linkMenu").style.visibility = "hidden";
}

function executarLogin() {
    botaoInvisible();
    let usuario = document.getElementById("usuario");
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

function formularioAlerta() {
    botaoInvisible();
    var usuario = document.getElementById("usuario");
    var senha = document.getElementById("senha");

    let charsPreenchidos = (usuario.value != "" & senha.value != "");

    if (charsPreenchidos) {
        document.getElementById("confirmacao").innerHTML = "Logue.";
    } else {
        document.getElementById("confirmacao").innerHTML = "Preencha todos os campos.";
    }
}

function limparCampos() {
    document.getElementById("nome").value = "";
    document.getElementById("email").value = "";
}