
//Aluno===============================================

function limparCampos() {
    document.getElementById("idAluno").value = 0;
    document.getElementById("nome").value = "";
    document.getElementById("email").value = "";
    document.getElementById("idCursoId").value = "";
}

function liberarCampos() {
    document.getElementById("nome").disabled = false;
    document.getElementById("email").disabled = false;
    document.getElementById("idCursoId").disabled = false;
    document.getElementById("insert").disabled = false;
}

function bloquearCampos() {
    document.getElementById("nome").disabled = true;
    document.getElementById("email").disabled = true;
    document.getElementById("idCursoId").disabled = true;
}

function Cancelar() {
    bloquearCampos();
    limparCampos();
    document.getElementById("update").disabled = true;
    document.getElementById("insert").disabled = true;
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

            document.getElementById("idAluno").value = this.cells[0].innerHTML;
            document.getElementById("nome").value = this.cells[1].innerHTML;
            document.getElementById("email").value = this.cells[2].innerHTML;
            document.getElementById('idCursoId').value = this.cells[3].innerHTML;
        };
    }
}

function getElement() {
    alert(document.getElementById("idAluno").value);
}

function testeGravar() {
    let a = document.getElementById('idAluno').value;
    let n = document.getElementById('nome').value;
    let e = document.getElementById('email').value;
    let c = document.getElementById('idCursoId').value;
    alert(a);
    alert(n);
    alert(e);
    alert(c);
}

//Professor============================================

function limparCamposP() {
    document.getElementById("nomeProf").value = "";
    document.getElementById("emailProf").value = "";
    document.getElementById("idCursoId").value = "";
}

function liberarCamposP() {
    document.getElementById("nomeProf").disabled = false;
    document.getElementById("emailProf").disabled = false;
    document.getElementById("idCursoId").disabled = false;
    document.getElementById("insert").disabled = false;
}

function bloquearCamposP() {
    document.getElementById("nomeProf").disabled = true;
    document.getElementById("emailProf").disabled = true;
    document.getElementById("idCursoId").disabled = true;
}

function CancelarP() {
    bloquearCamposP();
    limparCamposP();
    document.getElementById("update").disabled = true;
    document.getElementById("insert").disabled = true;
}

function NewP() {
    liberarCamposP();
    limparCamposP();
}

function UpdateP() {
    liberarCamposP();
}

function profInfo() {
    let tabela = document.getElementById("table");

    for (var i = 1; i < tabela.rows.length; i++) {
        tabela.rows[i].onclick = function () {
            document.getElementById("update").disabled = false;
            bloquearCamposP();

            let idC = document.getElementById("idCursoId");

            document.getElementById("idProf").value = this.cells[0].innerHTML;
            document.getElementById("nomeProf").value = this.cells[1].innerHTML;
            document.getElementById("emailProf").value = this.cells[2].innerHTML;
            idC = this.cells[3].innerHTML;
        };
    }
}