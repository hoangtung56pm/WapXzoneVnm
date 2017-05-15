$(document).ready(function(){
    $("#audio").hide();
    $("#hide-you-like .gioitinh-head h2").click(function(e){
        e.preventDefault();
        var $this = $(this);
        $("#hide-you-like .gioitinh-head h2").removeClass("active");
        $this.addClass("active");
        $("#hide-you-like .you-like").hide();
        var $href = $this.find("a").attr("href");
        $($href).show();
    });
});