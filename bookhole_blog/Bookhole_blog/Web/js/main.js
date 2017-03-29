$(function () {
    
    $.post("bookashx/Main.ashx", function (jsval) {
        var js = $.parseJSON(jsval)
        //var user_name = js.name
        //$("#username").text(user_name)
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
        $(".section-paragraph").text(hotblog.Blog_abstract)
        $(".section-paragraph").attr("href","Blog.html?id="+hotblog.Blog_id+"")
        $("#hot_img").attr("src", hotblog.Blog_img)
        //图片分享
        var img = js.Main_img
        for (var i = 0; i < 6; i++) {
            $(".works-item:eq(" + i + ")").attr("src", img[i].Img_address);
           
            $(".works-icons-content:eq(" + i + ")").text(img[i].Img_text)
            $(".portfolio-item:eq(" + i + ")").attr("href", img[i].Img_address)
          }
       
        //评论
        var tell = js.Main_tell
        for (var i = 0; i < 3; i++) {
            $(".tell_img:eq("+i+")").attr("src", tell[i].Tell_img)
            $(".test-name:eq(" + i + ")").text(tell[i].Tell_name)
            $(".tell_p:eq(" + i + ")").text(tell[i].Tell_text);
        }
        //推荐博客
        var tuiblog = js.Main_tuiblogs
        for (var i = 0; i < 3; i++) {
            $(".meet-item-name:eq(" + i + ")").text(tuiblog[i].Blog_title)
            $(".meet-item-name:eq(" + i + ")").attr("href","Blog.html?id="+tuiblog[i].Blog_id)
            $(".meet-item-about:eq(" + i + ")").text(tuiblog[i].Blog_abstract)
            $(".tui_img:eq(" + i + ")").attr("src", tuiblog[i].Blog_img)
        }
       //邮件
        $("#email_submit").click(function () {
            var name =  $("#email_name").val()
            var email = $("#main_email").val()
            $.post("bookashx/email.ashx", { "name":name, "email":email, }, function (msg) {
                alert(msg)
            })
        })
    })
     



})