const modal = document.querySelector(".modal-excluir");
const fundoPreto = document.querySelector(".fundo-preto-excluir");

function openModalExcluir() {

    modal.classList.add("modal-open");
    fundoPreto.classList.add("modal-open")
}

function fecharModalExcluir() {
    modal.classList.remove("modal-open");
    fundoPreto.classList.remove("modal-open");
}