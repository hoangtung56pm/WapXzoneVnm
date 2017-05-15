$(document).ready(function(){
   $(".box-about .content").hide();
    $(".box-about:first-child .content").show();
    $(".box-about .button-add").click(function(){
        $(".box-about .content").hide();
        $(this).parent().find(".content").toggle();
    });
});