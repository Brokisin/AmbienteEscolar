
//Aluno======

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
}

function New() {
    liberarCampos();
    limparCampos();
}

function Update() {
    liberarCampos();
}

function infoAlunos() {
    let tabela = document.getElementById("table");

    for (var i = 1; i < tabela.rows.length; i++) {
        tabela.rows[i].onclick = function () {
            document.getElementById("update").disabled = false;

            let idC = document.getElementById("idCursoId");
            let txtC = document.getElementsByClassName("option");

            document.getElementById("id").value = this.cells[0].innerHTML;
            document.getElementById("nome").value = this.cells[1].innerHTML;
            document.getElementById("email").value = this.cells[2].innerHTML;
            idC.value = this.cells[3].innerHTML;
        };
    }
}

//Professor======

function limparCamposP() {
    document.getElementById("nome").value = "";
    document.getElementById("email").value = "";
    document.getElementById("idCursoId").value = "";
}

function liberarCamposP() {
    document.getElementById("nome").disabled = false;
    document.getElementById("email").disabled = false;
    document.getElementById("idCursoId").disabled = false;
}

function bloquearCamposP() {
    document.getElementById("nome").disabled = true;
    document.getElementById("email").disabled = true;
    document.getElementById("idCursoId").disabled = true;
}

function Cancelar() {
    bloquearCampos();
    limparCampos();
}

function New() {
    liberarCampos();
    limparCampos();
}