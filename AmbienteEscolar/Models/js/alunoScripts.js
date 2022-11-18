
//Aluno===============================================

function limparCampos() {
    document.getElementById("idAluno").value = 0;
    document.getElementById("nome").value = "";
    document.getElementById("email").value = "";
    document.getElementById("idCursoId").value = "";
    //
    document.getElementById("idAlunoDelete").value = 0;
    document.getElementById("nomeAlunoDelete").value = "";
    document.getElementById("emailAlunoDelete").value = "";
    document.getElementById("idCursoAlunoDelete").value = "";
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
    document.getElementById("delete").disabled = true;
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
            document.getElementById("delete").disabled = false;

            document.getElementById("idAluno").value = this.cells[0].innerHTML;
            document.getElementById("nome").value = this.cells[1].innerHTML;
            document.getElementById("email").value = this.cells[2].innerHTML;
            document.getElementById('idCursoId').value = this.cells[3].innerHTML;

            //para o Delete

            document.getElementById("idAlunoDelete").value = this.cells[0].innerHTML;
            document.getElementById("nomeAlunoDelete").value = this.cells[1].innerHTML;
            document.getElementById("emailAlunoDelete").value = this.cells[2].innerHTML;
            document.getElementById("idCursoAlunoDelete").value = this.cells[3].innerHTML;

            //para o Generate

            document.getElementById("idAlunoGenerate").value = this.cells[0].innerHTML;
            document.getElementById("nomeAlunoGenerate").value = this.cells[1].innerHTML;
            document.getElementById("emailAlunoGenerate").value = this.cells[2].innerHTML;
            document.getElementById("idCursoAlunoGenerate").value = this.cells[3].innerHTML;
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

// CRESCENTE E DECRESCENTE =============================

function sortTable(n) {

    if (n == 1) {
        document.getElementById('carretNome').style.display = "none";
        document.getElementById('carretNameEnabled').style.display = "inline";
        document.getElementById('carretEmail').style.display = "inline";
        document.getElementById('carretEmailEnabled').style.display = "none";
        document.getElementById('carretCurso').style.display = "inline";
        document.getElementById('carretCursoEnabled').style.display = "none";
        document.getElementById('carretTurno').style.display = "inline";
        document.getElementById('carretTurnoEnabled').style.display = "none";
    } else if (n == 2) {
        document.getElementById('carretEmail').style.display = "none";
        document.getElementById('carretEmailEnabled').style.display = "inline";
        document.getElementById('carretNome').style.display = "inline";
        document.getElementById('carretNameEnabled').style.display = "none";
        document.getElementById('carretCurso').style.display = "inline";
        document.getElementById('carretCursoEnabled').style.display = "none";
        document.getElementById('carretTurno').style.display = "inline";
        document.getElementById('carretTurnoEnabled').style.display = "none";
    } else if (n == 3) {
        document.getElementById('carretCurso').style.display = "none";
        document.getElementById('carretCursoEnabled').style.display = "inline";
        document.getElementById('carretNome').style.display = "inline";
        document.getElementById('carretNameEnabled').style.display = "none";
        document.getElementById('carretEmail').style.display = "inline";
        document.getElementById('carretEmailEnabled').style.display = "none";
        document.getElementById('carretTurno').style.display = "inline";
        document.getElementById('carretTurnoEnabled').style.display = "none";
    } else if (n == 5) {
        document.getElementById('carretTurno').style.display = "none";
        document.getElementById('carretTurnoEnabled').style.display = "inline";
        document.getElementById('carretCurso').style.display = "inline";
        document.getElementById('carretCursoEnabled').style.display = "none";
        document.getElementById('carretNome').style.display = "inline";
        document.getElementById('carretNameEnabled').style.display = "none";
        document.getElementById('carretEmail').style.display = "inline";
        document.getElementById('carretEmailEnabled').style.display = "none";
    }

    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("table");
    switching = true;
    dir = "asc";
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}


//Professor============================================

function limparCamposP() {
    document.getElementById("idProf").value = 0;
    document.getElementById("nomeProf").value = "";
    document.getElementById("emailProf").value = "";
    document.getElementById("idCursoId").value = "";
    //
    document.getElementById("idProfessorDelete").value = 0;
    document.getElementById("nomeProfessorDelete").value = "";
    document.getElementById("emailProfessorDelete").value = "";
    document.getElementById("idCursoProfessorDelete").value = "";
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
    document.getElementById("delete").disabled = true;
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
            document.getElementById("delete").disabled = false;
            bloquearCamposP();

            document.getElementById("idProf").value = this.cells[0].innerHTML;
            document.getElementById("nomeProf").value = this.cells[1].innerHTML;
            document.getElementById("emailProf").value = this.cells[2].innerHTML;
            document.getElementById("idCursoId").value = this.cells[3].innerHTML;

            //para o Delete

            document.getElementById("idProfessorDelete").value = this.cells[0].innerHTML;
            document.getElementById("nomeProfessorDelete").value = this.cells[1].innerHTML;
            document.getElementById("emailProfessorDelete").value = this.cells[2].innerHTML;
            document.getElementById("idCursoProfessorDelete").value = this.cells[3].innerHTML;
        };
    }
}

// USER =========================

function limparCamposU() {
    document.getElementById("idUsuario").value = 0;
    document.getElementById("loginUsuario").value = "";
    document.getElementById("senhaUsuario").value = "";
    document.getElementById("idAcesso").value = "";
    //
    document.getElementById("idUsuarioDelete").value = 0;
    document.getElementById("loginUsuarioDelete").value = "";
    document.getElementById("senhaUsuarioDelete").value = "";
    document.getElementById("idNivelAcessoUsuarioDelete").value = "";
}

function liberarCamposU() {
    document.getElementById("loginUsuario").disabled = false;
    document.getElementById("senhaUsuario").disabled = false;
    document.getElementById("idAcesso").disabled = false;
    document.getElementById("insert").disabled = false;
}

function bloquearCamposU() {
    document.getElementById("loginUsuario").disabled = true;
    document.getElementById("senhaUsuario").disabled = true;
    document.getElementById("idAcesso").disabled = true;
}

function CancelarU() {
    bloquearCamposU();
    limparCamposU();
    document.getElementById("update").disabled = true;
    document.getElementById("insert").disabled = true;
}

function NewU() {
    liberarCamposU();
    limparCamposU();
}

function UpdateU() {
    liberarCamposU();
}

function userInfo() {
    let tabela = document.getElementById("table");

    for (var i = 1; i < tabela.rows.length; i++) {
        tabela.rows[i].onclick = function () {
            document.getElementById("update").disabled = false;
            document.getElementById("delete").disabled = false;

            document.getElementById("idUsuario").value = this.cells[0].innerHTML;
            document.getElementById("loginUsuario").value = this.cells[1].innerHTML;
            document.getElementById("senhaUsuario").value = this.cells[3].innerHTML;
            document.getElementById("idAcesso").value = this.cells[5].innerHTML;

            //para o Delete

            document.getElementById("idUsuarioDelete").value = this.cells[0].innerHTML;
            document.getElementById("loginUsuarioDelete").value = this.cells[1].innerHTML;
            document.getElementById("senhaUsuarioDelete").value = this.cells[3].innerHTML;
            document.getElementById("idNivelAcessoUsuarioDelete").value = this.cells[5].innerHTML;
        };
    }
}

function sortTableUser(n) {

    if (n == 1) {
        document.getElementById('carretNome').style.display = "none";
        document.getElementById('carretNameEnabled').style.display = "inline";
        document.getElementById('carretEmail').style.display = "inline";
        document.getElementById('carretEmailEnabled').style.display = "none";
        document.getElementById('carretCurso').style.display = "inline";
        document.getElementById('carretCursoEnabled').style.display = "none";
    } else if (n == 5) {
        document.getElementById('carretCurso').style.display = "none";
        document.getElementById('carretCursoEnabled').style.display = "inline";
        document.getElementById('carretNome').style.display = "inline";
        document.getElementById('carretNameEnabled').style.display = "none";
        document.getElementById('carretEmail').style.display = "inline";
        document.getElementById('carretEmailEnabled').style.display = "none";
    }

    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("table");
    switching = true;
    dir = "asc";
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}

function myfunction() {
    var b = document.getElementById('selectAlunoMatricula');
    alert("Valor: ", b.value);
}