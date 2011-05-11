jQuery(document).ready(function(){
	
	$("#iconbar li a").hover(
		function(){
			$(this).css("cursor", "pointer");
			$(this).animate({ width: "140px" }, {queue:false, duration:"normal"} );
			$(this).children("span").animate({opacity: "show"}, "fast");
		}, 
		function(){
			$(this).animate({ width: "70px" }, {queue:false, duration:"normal"} );
			$(this).children("span").animate({opacity: "hide"}, "fast");
		});
});