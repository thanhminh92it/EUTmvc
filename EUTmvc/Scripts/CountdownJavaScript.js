$(document).ready(function () {
    var time = $('#time').text();
    //$('#defaultCountdown').countdown({ until: +time, onTick: highlightLast5 });
    $('#defaultCountdown').countdown({
        until: +time,
        //compact: true, 
        //format: 'HMS',
        //expiryText: '<div class="over">Hết Giờ</div>',
        onTick: highlightLast5
    });

    function highlightLast5(periods) {
        if ($.countdown.periodsToSeconds(periods) === 5) {
            $(this).addClass('highlight');
        }
    }
});