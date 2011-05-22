    $(document).ready(function () {

        //Larger thumbnail preview 

        $("div.korzina").mousedown(function () {
            $(this).css({ 'z-index': '10' });
            $(this).find('img').addClass("hover").stop()
		.animate({
		    marginTop: '0px',
		    marginLeft: '0px',
		    top: '5%',
		    left: '5%',
		    width: '70px',
		    height: '70px',
		    padding: '10px'
		}, 200);

        });
        $("div.korzina").mouseup(function () {
            $(this).css({ 'z-index': '0' });
            $(this).find('img').removeClass("hover").stop()
		.animate({
		    marginTop: '0',
		    marginLeft: '0',
		    top: '0',
		    left: '0',
		    width: '60px',
		    height: '60px',
		    padding: '5px'
		}, 600);
        });



    });