$(document).ready(function () {
    $("div[myCtl='Album']").each(function () {
        $(".divShortCutHolder_hide", this).html($(".divShortCutHolder", this).html());
        $(".divShortCutHolder a", this).removeAttr("href");
        setStatus($(this), 0);
    });


    $(".imgCtlHolder").mouseenter(function () {
        $(".ctlPrevNext", this).fadeIn(300);
        var _outLine = $(this).parents("div[myCtl]");
        $(_outLine).attr("roll", "false");
    });

    $(".imgCtlHolder").mouseleave(function () {
        $(".ctlPrevNext", this).fadeOut(300);
        var _outLine = $(this).parents("div[myCtl]");
        $(_outLine).attr("roll", "true");
    });


    $(".btnPrev").click(function () {
        var _outLine = $(this).parents("div[myCtl]");
        var _count = $(".txtCount", _outLine).val();
        var _now = $(".txtNow", _outLine).val();
        var _targIndex = (parseInt(_now) + parseInt(_count) - 1) % _count;
        setStatus(_outLine, _targIndex);
    });

    $(".btnNext").click(function () {
        var _outLine = $(this).parents("div[myCtl]");
        var _count = $(".txtCount", _outLine).val();
        var _now = $(".txtNow", _outLine).val();
        var _targIndex = (parseInt(_now) + 1) % _count;
        setStatus(_outLine, _targIndex);
    });

    $(".divShortCutHolder a").click(function () {
        var _outLine = $(this).parents("div[myCtl]");
        var _targIndex = $(this).attr("imgIndex");
        setStatus(_outLine, _targIndex);
    });
});


function setStatus(ctlDiv, targIndex) {
    //切换图片
    var _targA = $(".divShortCutHolder_hide a[imgIndex='" + targIndex + "']", ctlDiv);
    $(".imgHolder", ctlDiv).html("").append(_targA.clone()).hide().fadeIn(500);

    $(".txtNow", ctlDiv).val(targIndex);
}



function showNext(_jsid) {
    var _outLine = $("div[jsid='" + _jsid + "']");
    var _roll = $(_outLine).attr("roll");
    if (_roll == "true") {
        $(".btnNext",_outLine).click();
    }
}