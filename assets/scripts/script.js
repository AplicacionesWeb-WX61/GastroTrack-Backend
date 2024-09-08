$(document).ready(function(){
    $(".mobile-nav i").click(function(){
        $(".site-nav-menu").toggleClass("mobile-menu");
    });
});

function changePageEnglish(){
    
    window.location.href ='index.html';
    document.getElementById('button-lenguage-english').disabled = true;

}
function changePageSpanish(){
    window.location.href ='index_es.html';
    document.getElementById('button-lenguage-spanish').disabled = true;

}