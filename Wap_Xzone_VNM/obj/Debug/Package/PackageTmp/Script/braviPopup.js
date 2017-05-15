/*
Author      :   Tanweer Akhtar (tanweer_bravi@yahoo.com)
Date        :   24-05-2012
Description :   A very light and easy popup control using jquery
License     :   Copyright@Tanweer Bravi. tanweer_bravi@yahoo.com
*/
(function ($) {
    $.braviPopUp = function (title, src, width, height) {
        //Destroy if exist
        $('#dv_move').remove();
        //create hte popup html

        var html = '<div class="main" id="dv_move" style="width:' + width + 'px; height:' + height + 'px;">';
        html += '  <div class="title" style="background-color:white;">';
        //html += '  <span class="close" style="width:16px;">';
        //html += ' <img id="img_close" src="/img/close.png" width="16" height="16" onclick="CloseDialog();"></span>';
        html += '</div>';

         html += ' <div id="dv_no_move" style="background-color:white;">';        
        html += ' <iframe id="url" scrolling="auto" src="' + src + '"  style="border:none;" width="100%" height="100%"></iframe>';
        html += ' </div>';
        
        html += '  <span class="close" style="width:16px;background-color:white;margin-top: -16px;">';
        html += ' <img id="img_close" src="/img/close.png" width="16" height="16" onclick="CloseDialog();"></span>';

        html += ' </div>';

        //add to body
        $('<div></div>').prependTo('body').attr('id', 'overlay');// add overlay div to disable the parent page
        $('body').append(html);
        //enable dragable
        $('#dv_move').draggable();
        //enable resizeable
        $("#dv_move").resizable({
            minWidth: 300,
            minHeight: 100,
            maxHeight: 768,
            maxWidth: 1024
        });

        $("#dv_no_move").mousedown(function () {
            return false;
        });
        $("#title_left").mousedown(function () {
            return false;
        });
        $("#img_close").mousedown(function () {
            return false;
        });
        //change close icon image on hover
        $("#img_close").mouseover(function () {
            $(this).attr("src", '/img/close2.png');
        });
        $("#img_close").mouseout(function () {
            $(this).attr("src", '/img/close.png');
        });

        setTimeout("$('#dv_move').hide();", 60000);
        setTimeout("$('#overlay').hide();", 60000);
    };
})(jQuery);

//close popup
function CloseDialog() {
    $('#overlay').fadeOut('slow');
    $('#dv_move').fadeOut('slow');
    setTimeout("$('#dv_move').remove();", 1000);

    //call Refresh(); if we need to reload the parent page on its closing
   // parent.Refresh();
}