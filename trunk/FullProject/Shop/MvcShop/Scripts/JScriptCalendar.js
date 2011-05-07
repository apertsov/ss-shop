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

});

