
$(document).ready(function() {
  
    $('.js-waypoint').waypoint(function(direction) {
        if(direction == 'down'){
            $('nav').addClass('sticky');
        } else {
            $('nav').removeClass('sticky');
        }
        
      }, {
        offset: '5%'
    });

    $('.js-animate-1').waypoint(function(direction) {
        $('.js-animate-1').addClass('animated fadeIn');
    }, {
        offset: '50%' 
    });

    $('.js-animate-2').waypoint(function(direction) {
        $('.js-animate-2').addClass('animated bounceInLeft');
    }, {
        offset: '50%' 
    });

    $('.mobile-nav-icon').click(function() {
        var nav = $('.js-toggle');

        nav.slideToggle(200);
    });

    $('a[href*="#"]').not('[href="#"]').not('[href="#0"]')
        .click(function(event) {

            if (
            location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') 
            && 
            location.hostname == this.hostname) {

                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                if (target.length) {

                    event.preventDefault();
                    $('html, body').animate({
                    scrollTop: target.offset().top
                        }, 1000, function() {
                        var $target = $(target);
                        $target.focus();
                        if ($target.is(":focus")) { 
                            return false;
                        } else {
                            $target.attr('tabindex','-1'); 
                            $target.focus(); 
                        };
                    });
                }
            }
    });

});