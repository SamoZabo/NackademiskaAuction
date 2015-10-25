$(function () {
    $('.remaining').each(function () {
        var remaing = $(this);
        remaing.countdown({
            until: new Date(remaing.data('year'), remaing.data('month'),
                remaing.data('day'), remaing.data('hour'), remaing.data('minute'), remaing.data('second')),
            onTick: lastFiveMinutes,
            onExpiry: function () { $('#container_' + remaing.data('modelId')).remove(); }
        });
    });
});
function lastFiveMinutes(time) {
    if ($.countdown.periodsToSeconds(time) <= 300 && !$(this).hasClass('highlight')) {
        $(this).addClass('highlight');
    }

}