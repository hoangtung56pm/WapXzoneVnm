/*! jQuery - javascript */

/**
 * HTML/CSS Slicer - JQUERY PLUGIN
 *
 * @category   JQUERY
 * @author     KienNT <kien.hnaptech@gmail.com>
 * @phone      0902002710
 * @Skype      kien.ppt
 * @Yahoo      aptech.vietnam
 * @version    CSS 2.1 / CSS 3 / HTML5
 */

//jQuery.noConflict();

$(document).ready(function(){
    
	$(".item").hover(function() {
	    $(this).find('.hoverState').show().css('height',$(this).height());
		$(this).height();
			}, function() {
	    $(this).find('.hoverState').hide();
	});
    
    // open overlay
    $('.btn-category , .btn-register').bind('click', function() { 
        
        var heightWin = $(window).height();
        var heightCategory = $('.overlay-category').height();
        var heightRegister = $('.overlay-register').height();
        
        if($(this).hasClass('btn-category')) {
            $('.overlay-wrap').fadeIn('fast',function(){
                if(heightWin>heightCategory){
                    var centerBox = (heightWin-heightCategory)/2;
                }else{
                    var centerBox = '14px';
                }                
                $('.overlay-category').animate({'top':centerBox},500);
            });
            
        } else if($(this).hasClass('btn-register')) {
            $('.overlay-wrap').fadeIn('fast',function(){
                if(heightWin>heightRegister){
                    var centerBox = (heightWin-heightRegister)/2;
                }else{
                    var centerBox = '14px';
                } 
                $('.overlay-register').animate({'top':centerBox},500); 
            });
            
        }
        
    });
    
    // close overlay
    $('.boxclose').click(function(){
        $('.overlay-conten').animate({'top':'-2600px'},500,function(){
            $('.overlay-wrap').fadeOut('fast');
        });
    });
    
});

// window resize - function
$(window).resize(function() {
    
});
    
