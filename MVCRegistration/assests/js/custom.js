$(document).ready(function () {
    $(".mobile_menu a").click(function () {
        $(".menu").slideToggle();
        $(".mobile_menu a").toggleClass("active");
        return false;
    });

    $('#accordionList .panel-heading').on('click', function () {
        if ($(this).hasClass("active")) {
            $('#accordionList .panel-heading').removeClass('active');
        } else {
            $('#accordionList .panel-heading').removeClass('active');
            $(this).addClass('active');
        }


    });
    /* my-comment-page */

    var $textarea = $(".conver-type > textarea");
    jQuery('.conver-type i').hide();
    $textarea.keyup(function () {
        if (jQuery(this).val()) {
            jQuery('.notification-tag').show();
            jQuery('.conver-type i').show()
            jQuery('.conver-type').addClass('closed');
        } else {
            jQuery('.notification-tag').hide();
            jQuery('.conver-type i').hide();
            jQuery('.conver-type').removeClass('closed');
        }
    })

    $(".user-interaction .dropdown").on("show.bs.dropdown", function (event) {
        $(".overlay-box").show();
    });
    $(".user-interaction .dropdown").on("hide.bs.dropdown", function () {
        $(".overlay-box").hide();
    });

    /* my-mynetwork-page */

    $("a#mynetwork").click(function () {
        $(".networkSearch").toggle('slow');
        $(".neiughberHood-Article").toggle('slow');
        changeSearchIcon();
    });
    function changeSearchIcon() {
        var img = document.getElementById('mynetworkArrow');
        if (img.src.search(/arrow2/) == -1) {
            document.getElementById('mynetworkArrow').src = 'assests/images/arrow2.png';
        } else {
            document.getElementById('mynetworkArrow').src = 'assests/images/arrow.png';
        }
    }

    /* my-page-default */

    $('.close').click(function () {
        $('.tabContent').hide();
        $('.profiledesc ul li').removeClass('active');
    });

    $('.profiledesc ul li').click(function () {
        $('.tabContent').show();
    });

    $("input#people-user").click(function () {
        $("li.regionHead").hide();
    });

    $("input#people-neighbourhood").click(function () {
        $("li.regionHead").show();
    });

    $("input#region-neighbourhood").click(function () {
        $("li.regionHead").hide();
    });

    $("input#region-name").click(function () {
        $("li.regionHead").show();
    });

    $("#mapForNeighbourhood").click(function () {
        $(".hideofShowMap").hide();
        $("#mapForNeighbourhoodImg").show();
    });

    $("#listIcons").click(function () {
        $(".hideofShowMap").show();
        $("#mapForNeighbourhoodImg").hide();
    });


    /* my-neighbourhood */

    $("a.neiughberHood-specific").click(function () {
        $("#neighbourhood2").show();
    });

    $("a.neiughberHood-nearby").click(function () {
        $("#neighbourhood3").show();
    });

    $("#neighbourhood3 a.lightColor").click(function () {
        $("#neighbourhood3").hide();
    });

    $("#neighbourhood2 a.lightColor").click(function () {
        $("#neighbourhood2").hide();
    });

    $(".networkSearch a").click(function () {
        $(".search-box-section").show();
        $(".resources-box-section").hide();
    });

    $(".search-box-section li").click(function () {
        $('.search-box-section li').removeClass('active');
        $(this).addClass('active');

    });

    $(".headingBoxIcon li").click(function () {
        $('.headingBoxIcon li').removeClass('active');
        $(this).addClass('active');

    });


});
