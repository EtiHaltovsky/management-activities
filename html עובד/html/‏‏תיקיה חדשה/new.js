
// Copyright 2012 Google Inc. All rights reserved.
(function(){

    var data = {
    "resource": {
      "version":"1",
      
      "macros":[{"function":"__e"},{"function":"__cid"}],
      "tags":[{"function":"__rep","once_per_event":true,"vtp_containerId":["macro",1],"tag_id":1}],
      "predicates":[{"function":"_eq","arg0":["macro",0],"arg1":"gtm.js"}],
      "rules":[[["if",0],["add",0]]]
    },
    "runtime":[]
    
    };
})

    // const device = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
    // let messageCarouselItem, flag_slide_door = true;
    // let commentsChangeCarousel;
    
    function nav_on_click() {
        if (device) {
            $(".header.only_mobile").removeClass("active");
        }
        $(".nav").slideDown(400);
        $("#nav-btn").addClass("change");
        $("#nav-btn").css("background", "#ffffff");
    }
    
    function closeNav(e) {
        if ($("#nav-btn").hasClass('change')) {
            $(".nav").slideUp(400)
            $("#nav-btn").removeClass("change")
            $("#nav-btn").css("background", "#222")
        }
    } 
  
    function carousel(myIndex) {
        $(".mySlides").each(function (i, item) {
            if ($(item).hasClass("active")) {
                $(item).animate({
                    opacity: 0.1,
                    "z-index": 100
                }, 1000)
                $(".slide_inside:eq(" + $(item).index() + ")").css({ "display": "none" })
            }
        });
        ++myIndex
        if (myIndex > $(".mySlides").length) { myIndex = 1 }
        $(".mySlides").eq(myIndex - 1).addClass("active")
        $(".mySlides").eq(myIndex - 1).animate({
            opacity: 1,
            "z-index": 200
        }, 700, function () {
            $(".slide_inside").eq(myIndex - 1).css({ "display": "block" })
            $(".overlay_slides_wrap").animate({
                opacity: "0.7"
            }, 500)
        })
    
        setTimeout(function () { carousel_addons(true, myIndex) }, 2000);
    }

    function carousel_addons(slidein, myIndex) {
        if (device) {
            if (slidein) {
                $(".door_img").animate({ opacity: 1, right: "10%" }, 1000)
                $(".door_info_container").animate({ opacity: 1, right: "40%" }, 1000)
                $(".slider_left_text").animate({ opacity: 1, left: "9%" }, 1000)
                setTimeout(function () { carousel_addons(false, myIndex) }, 4000);
            } else {
                $(".door_img").animate({ opacity: 0, right: "0" }, 500)
                $(".door_info_container").animate({ opacity: 0, right: "25%" }, 500)
                $(".slider_left_text").animate({ opacity: 0, left: "-25%" }, 500)
                $(".overlay_slides_wrap").animate({ opacity: 0 }, 800)
                setTimeout(function () { carousel(myIndex) }, 1000);
            }
        } else {
            if (slidein) {
                $(".door_img").animate({ opacity: 1, right: "15%" }, 1000)
                $(".door_info_container").animate({ opacity: 1, right: "40%" }, 1000)
                $(".slider_left_text").animate({ opacity: 1, left: "9%" }, 1000)
                setTimeout(function () { carousel_addons(false, myIndex) }, 4000);
            } else {
                $(".door_img").animate({ opacity: 0, right: "10%" }, 500)
                $(".door_info_container").animate({ opacity: 0, right: "25%" }, 500)
                $(".slider_left_text").animate({ opacity: 0, left: "-25%" }, 500)
                $(".overlay_slides_wrap").animate({ opacity: 0 }, 800)
                setTimeout(function () { carousel(myIndex) }, 1800);
            }
        }
    }
    
    function carousel_comments() {
        var curr = $(".scrollingImagesWrapper.active");
        var next = $(".scrollingImagesWrapper:not(.active)")
        curr.animate({ left: "-1150px" }, 600, "easeInOutBack")
        next.animate({ left: "0" }, 700, "easeInOutBack", function () {
            curr.css({ "left": "1200px" }).removeClass("active")
            next.addClass("active")
        });
    }
    