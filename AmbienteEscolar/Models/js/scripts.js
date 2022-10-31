
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

function formularioAlerta() {
    botaoInvisible();
    var usuario = document.getElementById("login");
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

function MostraTelaHome() {
    document.getElementById("home").style.display = 'block';
    document.getElementById("alunos").style.display = 'none';
    document.getElementById("matriculas").style.display = 'none';
    document.getElementById("professores").style.display = 'none';
    document.getElementById("suporte").style.display = 'none';
}

function MostraTelaAlunos() {
    document.getElementById("alunos").style.display = 'block';
    document.getElementById("home").style.display = 'none';
    document.getElementById("matriculas").style.display = 'none';
    document.getElementById("professores").style.display = 'none';
    document.getElementById("suporte").style.display = 'none';
}

function MostraTelaMatriculas() {
    document.getElementById("matriculas").style.display = 'block';
    document.getElementById("home").style.display = 'none';
    document.getElementById("alunos").style.display = 'none';
    document.getElementById("professores").style.display = 'none';
    document.getElementById("suporte").style.display = 'none';
}

function MostraTelaProfs() {
    document.getElementById("professores").style.display = 'block';
    document.getElementById("home").style.display = 'none';
    document.getElementById("matriculas").style.display = 'none';
    document.getElementById("alunos").style.display = 'none';
    document.getElementById("suporte").style.display = 'none';
}

function MostraTelaSuporte() {
    document.getElementById("suporte").style.display = 'block';
    document.getElementById("home").style.display = 'none';
    document.getElementById("matriculas").style.display = 'none';
    document.getElementById("professores").style.display = 'none';
    document.getElementById("alunos").style.display = 'none';
}