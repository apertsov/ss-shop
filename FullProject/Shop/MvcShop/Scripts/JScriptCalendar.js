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
            success: function (data) { $('#tableCart').html(data); },
            error: function () { alert('error Add to Cart'); },
            completed: function () { alert('completed Add to Cart'); }
        });
    });

    $('#jCartPanel').slidePanel({
        triggerName: '#triggerCart',
        position: 'fixed',
        triggerTopPos: '40px',
        panelTopPos: '30px',
        ajax: false,
        ajaxSource: 'ajax.html'
    });


});