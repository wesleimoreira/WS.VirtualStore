function TornarBotaoAtualizarQuantidadeVisivel(id, visible) {

    const atualizarQuantidade = document.querySelector(`button[data-itemId="${id}"]`);

    if (visible == true)
        atualizarQuantidade.style.display = "inline-block";
    else
        atualizarQuantidade.style.display = "none";    
}