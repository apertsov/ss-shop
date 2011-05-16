    $(document).ready(function () {

        //Larger thumbnail preview 

        $("div.korzina").mousedown(function () {
            $(this).css({ 'z-index': '10' });
            $(this).find('img').addClass("hover").stop()
		.animate({
		    marginTop: '-20px',
		    marginLeft: '-20px',
		    top: '50%',
		    left: '50%',
		    width: '90px',
		    height: '90px',
		    padding: '20px'
		}, 50);

        });
        $("div.korzina").mouseup(function () {
            $(this).css({ 'z-index': '0' });
            $(this).find('img').removeClass("hover").stop()
		.animate({
		    marginTop: '0',
		    marginLeft: '0',
		    top: '0',
		    left: '0',
		    width: '80px',
		    height: '80px',
		    padding: '5px'
		}, 600);
        });



    });