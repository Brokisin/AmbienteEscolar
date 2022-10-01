function limparCampos() {
    document.getElementById("nome").value = "";
    document.getElementById("email").value = "";
    document.getElementById("idCursoId").value = "";
}

function liberarCampos() {
    document.getElementById("nome").disabled = false;
    document.getElementById("email").disabled = false;
    document.getElementById("idCursoId").disabled = false;
}

function bloquearCampos() {
    document.getElementById("nome").disabled = true;
    document.getElementById("email").disabled = true;
    document.getElementById("idCursoId").disabled = true;
}

function Cancelar() {
    bloquearCampos();
    limparCampos();

    let buttonNew = document.getElementById("insert");
    buttonNew.setAttribute("type", "button");
    buttonNew.disabled = true;
}

function New() {
    liberarCampos();
    limparCampos();

    let buttonNew = document.getElementById("insert");
    buttonNew.setAttribute("type", "submit");
    buttonNew.disabled = false;    
}