$(document).ready(function () {
    $('.datepicker').datetimepicker({ dateFormat: 'dd.mm.yy' });

    $('.orderStatus').everyTime(5000, function () {
        $.ajax({
            type: "POST",
            url: '/Orders/GetStatusById/' + $('.orderStatus').attr("id"),
            success: function (data) { $('.orderStatus').html(data); },
            error: function () { $('.orderStatus').html("error"); },
            completed: function () { $('.orderStatus').html("completed"); }
        });
    });

    $('.orderDetailsClick').click(function () {
        $.ajax({
            type: "POST",
            url: '/Orders/GetOrderDataById/' + $(this).attr("id"),
            success: function (data) { $('#detailsOrder').html(data); },
            error: function () { $('#detailsOrder').html("error"); },
            completed: function () { $('#detailsOrder').html("completed"); }
        });
    });

    $('tr.order-det').click(function () {
        $('tr.order-det').removeClass("activeOrder");
        $(this).addClass("activeOrder");
    });

    $('.receptToCart').click(function () {
        var idI = $(this).attr("id");
        $.ajax({
            type: "POST",
            url: '/Cart/AddToCartAsync/' + idI + '/' + $('#receptQuantity' + idI).attr("value"),
            success: function (data) { $('#tableCart').html(data); UpdateCart(); },
            error: function () { alert('error Add to Cart'); },
            completed: function () { alert('completed Add to Cart'); }
        });
    });

    $('.removeItemCart').live("click", function () {
        var idI = $(this).attr("id");
        $.ajax({
            type: "POST",
            url: '/Cart/RemoveFromCartRecept/' + idI ,
            success: function (data) { $('#tableCart').html(data); UpdateCart(); },
            error: function () { alert('error Delete from Cart'); },
            completed: function () { alert('completed Delete from Cart'); }
        });
        return false;
    });

    $('.addItemCart').live("click", function () {
        var idI = $(this).attr("id");
        $.ajax({
            type: "POST",
            url: '/Cart/AddToCartAsync/' + idI + '/1',
            success: function (data) { $('#tableCart').html(data); UpdateCart(); },
            error: function () { alert('error Delete from Cart'); },
            completed: function () { alert('completed Delete from Cart'); }
        });
        return false;
    });

    $('.minusItemCart').live("click", function () {
        var idI = $(this).attr("id");
        $.ajax({
            type: "POST",
            url: '/Cart/RemoveFromCartAsync/' + idI + '/1',
            success: function (data) { $('#tableCart').html(data); UpdateCart(); },
            error: function () { alert('error Minus from Cart'); },
            completed: function () { alert('completed Minus from Cart'); }
        });
        return false;
    });

    $('#clearCart').click(function () {
        $.ajax({
            type: "POST",
            url: '/Cart/ClearCart/',
            success: function (data) { $('#tableCart').html(data); UpdateCart(); },
            error: function () { alert('error Clear to Cart'); },
            completed: function () { alert('completed Clear to Cart'); }
        });
    });

    function UpdateCart() {
        $.ajax({
            type: "POST",
            url: '/Cart/GetInfoAboutCartAsync/',
            success: function (data) { $('#triggerCart').html(data); },
            error: function () { alert('error Get info about Cart'); },
            completed: function () { alert('completed Add to Cart'); }
        });
    }

    $('#jCartPanel').slidePanel({
        triggerName: '#triggerCart',
        position: 'fixed',
        triggerTopPos: '110px',
        panelTopPos: '100px',
        ajax: false,
        ajaxSource: 'ajax.html'
    });

    $("#iconbar li a").hover(
		function () {
		    $(this).css("cursor", "pointer");
		    $(this).animate({ width: "140px" }, { queue: false, duration: "normal" });
		    $(this).children("span").animate({ opacity: "show" }, "fast");
		},
		function () {
		    $(this).animate({ width: "70px" }, { queue: false, duration: "normal" });
		    $(this).children("span").animate({ opacity: "hide" }, "fast");
		});

});