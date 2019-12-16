var mobile = (/iphone|ipad|ipod|android|blackberry|mini|windows\sce|palm/i.test(navigator.userAgent.toLowerCase()));  
    if (mobile) {  
        document.location = "http://www.yourmobilewebsite.com";  
    }  



function registrationClick() {
    window.open("https://www.facebook.com/you.tunel", 'preview_tab');
    return false;
}

$(document).ready(function () {
    $(document).scrollTop(0);
    $('#nav').localScroll(500);
    $('#slide1').parallax("50%", 0.1);
    $('#slide3').parallax("50%", 0.1);
    $('.slide1b').parallax("90.5%", 0.5, true, 650);  
});


