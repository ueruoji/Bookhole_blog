$(function () {
    
    $.post("bookashx/Main.ashx", function (jsval) {
        var js = $.parseJSON(jsval)
        //分类
        var type = js.Main_type
        for (var i = 0; i < 3; i++) {
            $(".row_p1:eq(" + i + ")").text(type[i].Type_name)
            $(".custom-red:eq(" + i + ")").text(type[i].Type_percentage)
            $(".perc:eq(" + i + ")").text(type[i].Type_percentage + "%")
        }
        //热门博客
        var hotblog = js.Main_hotblogs
        $("#hot_p").text(hotblog.Blog_title)
        $(".section-paragraph").text(hotblog.Blog_text + "......")
        $("#hot_img").css("background","url(../" + hotblog.Blog_img + ")")
        //图片分享
        //推荐博客
        var tuiblog = js.Main_tuiblogs
        for (var i = 0; i < 3; i++) {
            $(".meet-item-name:eq("+i+")").text(tuiblog[i].Blog_title)
            $(".meet-item-about:eq(" + i + ")").text(tuiblog[i].Blog_text)
            $(".tui_img:eq(" + i + ")").attr("src", tuiblog[i].Blog_img)
        }
      

    })
     



})