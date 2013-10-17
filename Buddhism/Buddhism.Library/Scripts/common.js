/* 提交窗体*/
function submitForm($form) {
    $form.submit();
}

function submitParentForm(element) {
    var $form = $(element).parents("form");
    $form.find(".loading").show();
    submitForm($form);
}

function gotoPage(element, page) {
    $(element).parents(".pager").find(".page").val(page);
    submitParentForm(element);
}
/*分页--------------------------------------------------------------------------------*/
$(function () {
    $(".pager input").live("keydown", function (event) {
        if (event.keyCode >= 96 && event.keyCode <= 105) { return true; } //小键盘数字
        if (event.keyCode == 37 || event.keyCode == 39) { return true; } // 左箭头、右箭头
        if (event.keyCode >= 48 && event.keyCode <= 57) { return true; }
        if (event.keyCode == 8) { return true; } //后退
        if (event.keyCode == 13) {
            submitParentForm(this);
        }
        return false;
    });
    /*每页数量修改后 ，马上提交*/
    /* IE 不支持 live change, 事件直接写入了分页控件中*/
    $(".pager .first, .pager .prev, .pager .next, .pager .last").live("click", function () {
        var page = $(this).text();
        gotoPage(this, page);
    });

    $(".pager .refresh").live("click", function () {
        submitParentForm(this);
    });

    //分页中的输入控 自动提交
    $(".autosubmit input[type=text]").live("keyup", function () {
        submitParentForm(this);
    });

    $(".autosubmit input[type=checkbox]").live("change", function () {
        submitParentForm(this);
    });

    //分页 Ajax 提交
    $("form.dialogForm").live("submit", function () {
        var _oldFormParent = formParent.length;
        var $form = $(this);
        var data = $form.serialize();
        if (this.extraData) { data = this.extraData + data; }
        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: data,
            success: function (response) {
                if (_oldFormParent > 0) {
                    funVerify.ActionVerify($form);  //父页面的父页面执行函数                   
                }
                $(".gridForm").html($(response).find(".gridForm").html());
                $form.find('.pager .loading').hide();
            }
        });
        this.extraData = "";
        return false;
    });

    //回车提交查询
    $('form').each(function (index) {
        var submitButtons = $(':submit', $(this));
        var firstQuerySubmitbutton = null;
        submitButtons.each(function () {
            if ($(this).val() == "查询" || $(this).text() == "查询") {
                firstQuerySubmitbutton = $(this);
                return;
            }
        });
        var firstSubmitButton = $(':submit:first', $(this));
        if (firstQuerySubmitbutton != null && firstSubmitButton.length > 0
            && firstQuerySubmitbutton[0] != firstSubmitButton[0]) {
            $(":text", $(this)).live('keydown', function (e) {
                if (e.keyCode == 13) {
                    firstQuerySubmitbutton.trigger("click");
                    return false;
                }
            });
        }
    });

});