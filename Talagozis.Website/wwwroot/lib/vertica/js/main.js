//Strict Mode 
//first intro description height
jQuery(document).ready(function(){
	var vt_windoww_width = jQuery(window).width();
	if(vt_windoww_width > 991){
	var vtautoheight = jQuery(".vt_description").height();
		jQuery(".profile-intro .col-md-7").css("height", 1);
		jQuery(".timeline:first-child .content-wrap:first-child").css("height", vtautoheight+20);
		}
	});
	
	jQuery(window).resize(function(){
	var vt_windoww_width = jQuery(window).width();
	if(vt_windoww_width > 991){
	var vtautoheight = jQuery(".vt_description").height();
		jQuery(".profile-intro .col-md-7").css("height", 1);
		jQuery(".timeline:first-child .content-wrap:first-child").css("height", vtautoheight+20);
		}
		else{
		jQuery(".profile-intro .col-md-7").css("height", '');
		jQuery(".timeline:first-child .content-wrap:first-child").css("height", '');
		}
	});

(function($) {
  "use strict";

//Run on Document Ready
$(document).ready(function(){   
//Add home class 
var aaa = document.querySelector('.timeline:first-child').id;
$(".introclass").attr("id",aaa);

$(".timeline-bg")[0]
  //Smooth scrool
  $("html").niceScroll({styler:"fb",cursorcolor:"#000"});
  $(".side-menu").niceScroll({styler:"fb",cursorcolor:"#000"});

  //Side menu - Open
  // You can also make this on mouseenter by replacing the click event by mouseenter
  $('.side-menu-open').click(function(){
    $('.side-menu').animate({'left': '0px'}, 600, 'easeOutCubic');
  });

  //Side menu - Close
  $('#side-menu-close').click(function(){
    var sideWidth = $('.side-menu').outerWidth();
    var sideWidthClose = '-' + sideWidth + 'px';
    $('.side-menu').animate({'left': sideWidthClose}, 600, 'easeOutCubic');

  });
  //Side menu - Close
  var vt_windoww_width = $(window).width();
  if(vt_windoww_width < 500){
  $('.menu-item a').click(function(){
    var sideWidth = $('.side-menu').outerWidth();
    var sideWidthClose = '-' + sideWidth + 'px';
    $('.side-menu').animate({'left': sideWidthClose}, 600, 'easeOutCubic');
  });
  }
  //Smooth Scroll on anchor links
  $('a[href*=#]:not([href=#])').click(function() {
    if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
      if (target.length) {
        $('html,body').animate({
          scrollTop: target.offset().top
        }, 700, 'easeInOutExpo');
        return false;
      }
    }
  });



  //Bxslider -see options at http://bxslider.com/
  $('.portfolio-itens').bxSlider({
      slideWidth: 200,
      minSlides: 1,
      maxSlides: 4,
      moveSlides: 3,
      slideMargin: 5,
      auto: false,
      mode: 'horizontal',
      useCSS: false,
      // speed: 900,
      infiniteLoop: false,
      hideControlOnEnd: true,
      // easing: 'easeOutElastic',
      pager: false,
      prevText: '<i class="fa fa-chevron-left"></i>',
      nextText: '<i class="fa fa-chevron-right"></i>'
  });

  
  //Nivo Lightbox
  $('a.nivobox').nivoLightbox({ effect: 'fade' });

  //Portfolio Animations
  $('.portfolio-item').hover(function(){
    $(this).find('.hover-bg-wrapper').fadeIn(200);
    $(this).find('.hover').show();  
    $(this).find('p').addClass('animated').addClass('fadeInUp');
  }, function(){
    $(this).find('.hover-bg-wrapper').fadeOut(200);
    $(this).find('.hover').fadeOut(200);
    $(this).find('p').removeClass('fadeInUp');
  });

  //Contact Form Validator and Ajax Sender
  $("#contactForm").validate({
    submitHandler: function(form) {
      $.ajax({
        type: "POST",
        url: "php/contact-form.php",
        data: {
          "name": $("#contactForm #name").val(),
          "email": $("#contactForm #email").val(),
          "subject": $("#contactForm #subject").val(),
          "message": $("#contactForm #message").val()
        },
        dataType: "json",
        success: function (data) {
          if (data.response == "success") {
            $("#contactSuccess").fadeIn(300);
            $("#contactError").addClass("hidden");

            $("#contactForm #name, #contactForm #email, #contactForm #subject, #contactForm #message")
              .val("")
              .blur()
              .closest(".control-group")
              .removeClass("success")
              .removeClass("error");              
            
          } else {
            $("#contactError").fadeIn(300);
            $("#contactSuccess").addClass("hidden");
          }
        }

      });
    }
  });

  //Modal for Contact Form
  $('.modal-wrap').click(function(){
    $('.modal-wrap').fadeOut(300);
  });      

  //Background Height fix for vertical progress
  $( ".full-height" ).each(function() {
    var $stretch = $(this);
    $stretch.css({ height: $stretch.closest('.line').find('.content-wrap').height() });
  }); 

  //Top button hover
  var aa = $(".btn-hide-text1").width();
	$(".btn-top-resume .btn-hide-text").css("width", "0");
	$(".btn-top-resume").mouseenter(function(){
		$(".btn-top-resume .btn-hide-text").css("width", $(".btn-hide-text-r").width()+5);
	}).mouseleave(function(){
		$(".btn-top-resume .btn-hide-text").css("width", "0");
	});

	$(".btn-top-message .btn-hide-text").css("width", "0");
	$(".btn-top-message").mouseenter(function(){
		$(".btn-top-message .btn-hide-text").css("width", $(".btn-hide-text-c").width()+5);
	}).mouseleave(function(){
		$(".btn-top-message .btn-hide-text").css("width", "0");
	});

	$(".btn-top-blog .btn-hide-text").css("width", "0");
	$(".btn-top-blog").mouseenter(function(){
		$(".btn-top-blog .btn-hide-text").css("width", $(".btn-hide-text-b").width()+5);
	}).mouseleave(function(){
		$(".btn-top-blog .btn-hide-text").css("width", "0");
	});
  
});

//Run on Window Load
$(window).on("load", function(){
  //Page loader
  $('#page-loader').fadeOut(200, function(){});

  //Safari Crossbrowser animation Fix
  if ($('html').hasClass('safari')) {
      $('#content-body').removeClass('animated');
  }


  //Fade In load
 // $('#content-body').addClass('fadeInUp');

  //Background Height fix for vertical progress
  setTimeout(function () {    
      $( ".full-height" ).each(function() {
        var $stretch = $(this);
        $stretch.css({ height: $stretch.closest('.line').find('.content-wrap').outerHeight() });
      });  
    }, 300
  );
  
  //Background Height fix for vertical progress on window resize
  $(window).resize(function(){ 
     $( ".full-height" ).each(function() {
      var $stretch = $(this);
      $stretch.css({ height: $stretch.closest('.line').find('.content-wrap').outerHeight() });
    }); 
  });
});

})(jQuery);
