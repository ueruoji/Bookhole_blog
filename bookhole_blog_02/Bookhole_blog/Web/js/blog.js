$(function () {
    var url = location.search;
    var id = url.substring(4,6)
    $.post("Bookashx/Blog.ashx",{"id":id}, function (jsval) {
        var js = $.parseJSON(jsval)
        var blog = js.Show_blog
        $(".blog-main").html(blog.Blog_text + "<hr /><span>时间:" + blog.Blog_time + "</span><p>阅读量:" + blog.Blog_read + "</p>")
        $("#blog_id").text(blog.Blog_id)
        $("#title").text(blog.Blog_title)
        var read = js.Show_list
        $(".list_a").each(function (index,val) {
            $(val).text(read[index].Blog_title)
            $(val).attr("href","blog.html?id="+read[index].Blog_id)
        })
        var tell = js.Show_tell
        for (var i = 0; i < tell.length; i++) {
            $("#tell_name").append("<li class=\"list-group-item\"><a href=\"javascript:void(0)\">" +tell[i].Tell_name + ":</a><span> "+tell[i].Tell_text+"</span></li>")
        }
        
    })
    //邮件
    $("#subscribe").click(function () {
        var email = $("#main").val()
        console.log(name)
        $.post("bookashx/email.ashx", { "email": email }, function (msg) {
            alert(msg)
        })
    })
    //评论
    $("#tell").click(function () {
        var text_tell = $("#text_tell").val();
        var bid = $("#blog_id").text();
        $.post("Bookashx/tell.ashx", { "text_tell": text_tell, "bid": bid }, function (json) {
            if (json == 1) {
                window.location.reload();
            }if(json==0){
                location.href = "login.html";
            }
        })
    })
})