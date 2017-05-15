$(function () {
    var $menu = $('div#menu');
    $menu.mmenu({
        dragOpen	: true
    });
    $("#tab-news li a").click(function(){
        $(this).tab("show");
        $("#tab-news li a").removeClass("active");
        $(this).addClass("active");
    });
    $("#tab-news1 li a").click(function(){
        $(this).tab("show");
        $("#tab-news1 li a").removeClass("active");
        $(this).addClass("active");
    });
    $('#nav-game a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })


});