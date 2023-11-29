const modal = document.querySelector(".modal-sair");
const fundoPreto = document.querySelector(".fundo-preto");

function openModal() {
    
    modal.classList.add("modal-open");
    fundoPreto.classList.add("modal-open")
}

function fecharModal() {
    modal.classList.remove("modal-open");
    fundoPreto.classList.remove("modal-open");
}