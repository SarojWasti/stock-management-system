(function ($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('#content').toggleClass('sidebar-open');
  });

})(jQuery);

// Set active page on the basis of URL
$(document).ready(function () {
    var pageName = window.location.pathname;
    var newPageName = pageName;

    if (pageName.indexOf('/') == 0) {
        newPageName = pageName.substring(1, pageName.length);

        $.each($('#sidebar-list').find('li'), function () {
            var hrefVal = $(this).find('a').attr('href');

            if (hrefVal.indexOf(newPageName) >= 0) {
                $(this).addClass('active').siblings().removeClass('active');
            }

        });
    }
});