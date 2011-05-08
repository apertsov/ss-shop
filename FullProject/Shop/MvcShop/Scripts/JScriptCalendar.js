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

});