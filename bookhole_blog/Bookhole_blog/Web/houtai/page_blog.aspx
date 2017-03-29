<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="page_blog.aspx.cs" Inherits="Bookhole_blog.Web.houtai.page_blog" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Responsive Bootstrap Advance Admin Template</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <!-- 配置文件 -->
                <script src="assets/utf8-net/ueditor.config.js"></script>
    <!-- 编辑器源码文件 -->
                <script src="assets/utf8-net/ueditor.all.js"></script>
    <style type="text/css">
        .a-upload {
    padding: 4px 10px;
    height: 30px;
    line-height: 20px;
    position: relative;
    cursor: pointer;
    color: #888;
    background: #fafafa;
    border: 1px solid #ddd;
    border-radius: 4px;
    overflow: hidden;
    display: inline-block;
    *display: inline;
    *zoom: 1
}

.a-upload  input {
    position: absolute;
    font-size: 100px;
    right: 0;
    top: 0;
    opacity: 0;
    filter: alpha(opacity=0);
    cursor: pointer
}

.a-upload:hover {
    color: #444;
    background: #eee;
    border-color: #ccc;
    text-decoration: none
}
    </style>
</head>
<body>
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">COMPANY NAME</a>
            </div>

            <div class="header-right">

              <a href="message-task.html" class="btn btn-info" title="New Message"><b>30 </b><i class="fa fa-envelope-o fa-2x"></i></a>
                <a href="message-task.html" class="btn btn-primary" title="New Task"><b>40 </b><i class="fa fa-bars fa-2x"></i></a>
                <a href="login.html" class="btn btn-danger" title="Logout"><i class="fa fa-exclamation-circle fa-2x"></i></a>


            </div>
        </nav>
        <!-- /. NAV TOP  -->
        <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">
                    <li>
                        <div class="user-img-div">
                            <img src="assets/img/user.png" class="img-thumbnail" />

                            <div class="inner-text">
                                Jhon Deo Alex
                            <br />
                                <small>Last Login : 2 Weeks Ago </small>
                            </div>
                        </div>

                    </li>


                    <li>
                        <a href="Home_page.aspx"><i class="fa fa-dashboard "></i>主页</a>
                    </li>
                    <li>
                        <a href="#"  class="active-menu-top"><i class="fa fa-desktop "></i>博客<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                            <li>
                                <a href="page_type.aspx"><i class="fa fa-toggle-on"></i>博客类型</a>
                            </li>
                            <li>
                                <a  class="active-menu" href="page_blog.aspx"><i class="fa fa-bell "></i>博客</a>
                            </li>
                             <li>
                                <a href="page_tell.aspx"><i class="fa fa-circle-o "></i>博客评论</a>
                            </li>
                        </ul>
                    </li>
                     <li>
                        <a href="#"><i class="fa fa-yelp "></i>用户 <span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                            <li>
                                <a href="page_user.aspx"><i class="fa fa-coffee"></i>用户管理</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="page_img.aspx"><i class="fa fa-anchor "></i>图片</a>
                    </li>
                    
                </ul>

            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner">
              
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>博客标题</th>
                                        <th style="width:250px;">博客简介</th>
                                        <th>博客图片</th>
                                        <th>博客显示</th>
                                        <th>博客时间</th>
                                        <th>博客类型</th>
                                        <th>编辑</th>
                                        <th>删除</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%for (int i = 0; i < oblogs.Count; i++)
                                        {%>
                                    <tr>
                                        <td><%=oblogs[i].Blog_id %></td>
                                        <td><span class="label label-danger"><%=oblogs[i].Blog_title %></span></td>
                                        <td style="width:250px;"><%=oblogs[i].Blog_abstract %></td>
                                        <td>
                                            <img src="<%=oblogs[i].Blog_img %>" alt="Alternate Text" style="width:50px;height:50px;"/></td>
                                        <td><%=oblogs[i].Blog_is %></td>
                                        <td><%=oblogs[i].Blog_time %></td>
                                        <td><%=oblogs[i].Blog_typename %></td>
                                        <td><a href="javascript:void(0)" onclick="editor(<%=i %>)">编辑</a></td>
                                        <td><a href="javascript:void(0)" onclick="t_delete(<%=oblogs[i].Blog_id %>)">删除</a></td>

                                    </tr>
                                      <%  }  %>
                                     <tr>
                                        <td><input type="text" id="text_id" style="width:50px;"/></td>
                                    
                                        <td><input type="text" id="text_title" /></td>
                                        <td><input type="text" id="text_abs" style="width:230px;"/></td>
                                        <td style="width:100px;">
                                            <a href="javascript:;" class="a-upload">
                                                <input type="file" id="file1" name="file" />选择图片
                                            </a>
                                            <input type="button" value="上传" />
                                            <img id="img1"  src="" style="width:100px;height:100px" />

                                        </td>
                                        <td><input type="text" id="text_is" style="width:30px;" /></td>
                                        <td><input type="text" id="text_time" style="width:100px;"/></td>
                                        <td><input type="text" id="text_typename"  style="width:50px;"/></td>
                                        <td><a  href="javascript:void(0)" onclick="t_editor()">编辑完成</a></td>
                                        <td><a  href="javascript:void(0)" onclick="t_add()">添加</a></td>
                                        
                                    </tr>
                                   
                                </tbody>
                            </table>
                    <span id="msg"></span>

            </div>
    <!-- 加载编辑器的容器 -->
    <script id="container" name="content" type="text/plain">
      
    </script>
       
    <!-- 实例化编辑器 -->


            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
    <!-- /. WRAPPER  -->
    <!-- /. FOOTER  -->
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
        <script src="assets/js/ajaxfileupload.js"></script>
    <script type="text/javascript">
        var ue = UE.getEditor('container', {
            initialFrameHeight:300}
        )
        $(function () {
           
            $(":button").click(function () {
                ajaxFileUpload();
            })
        })
        function ajaxFileUpload() {
            $.ajaxFileUpload
            (
                {
                    url: 'img.ashx', //用于文件上传的服务器端请求地址
                    secureuri: false, //是否需要安全协议，一般设置为false
                    fileElementId: 'file1', //文件上传域的ID
                    dataType: 'json', //返回值类型 一般设置为json
                    type: "post",
                    data:{name:'blog'},
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        $("#img1").attr("src", "../" + data.imgurl);
                        if (typeof (data.error) != 'undefined') {
                            if (data.error != '') {
                                alert(data.error);
                            } else {
                                alert(data.msg);
                            }
                        }
                    },
                    error: function (data, status, e)//服务器响应失败处理函数
                    {
                        alert(e);
                    }
                }
            )
            return false;
        }
        function editor(i) {
            var id = $("tr:eq(" + (i + 1) + ")").children("td:eq(0)").text();
            $("#text_id").val(id)
            $("#text_title").val($("tr:eq(" + (i + 1) + ")").children("td:eq(1)").text())
            $("#text_abs").val($("tr:eq(" + (i + 1) + ")").children("td:eq(2)").text())
            $("#img1").attr("src", $("tr:eq(" + (i + 1) + ")").children("td:eq(3)").children().attr("src"))
            $("#text_is").val($("tr:eq(" + (i + 1) + ")").children("td:eq(4)").text())
            $("#text_time").val($("tr:eq(" + (i + 1) + ")").children("td:eq(5)").text())
            $("#text_typename").val($("tr:eq(" + (i + 1) + ")").children("td:eq(6)").text())
            $.post("blog_select.ashx", { "id": id }, function (text) {
                ue.setContent(text);
            })
            
        }
        function t_delete(i) {
            $.post("delete.ashx", { "page": "blog", "id": i }, function (a) {
                window.location.reload();
                $("#msg").text(a);
            })
        }
        function t_add() {
            var id = $("#text_id").val();
            var title = $("#text_title").val()
            var img = $("#img1").attr("src")
            var showis = $("#text_is").val()
            var time = $("#text_time").val()
            var typename = $("#text_typename").val()
            var text = ue.getContent();
            var abstract = null;
            if ($("#text_abs").val() == null) {
                abstract = ue.getContentTxt().substring(0, 20);
            } else {
                abstract = $("#text_abs").val();
            }
            
            if (id != null && title != null && img != null && showis != null && time != null && typename != null&&text!=null) {
                $.post("add.ashx", { "page": "blog", "id": id, "title": title, "img": img, "showis": showis, "time": time, "typename": typename, "text": text, "abstract": abstract }, function (a) {
                    window.location.reload();
                    $("#msg").text(a);
                })
            } else {
                $("#msg").text("输入有误");
            }
        }
        function t_editor() {
            var id = $("#text_id").val();
            var title = $("#text_title").val()
            var img = $("#img1").attr("src")
            var showis = $("#text_is").val()
            var time = $("#text_time").val()
            var typename = $("#text_typename").val()
            var abs = $("#text_abs").val()
            var text = ue.getContent();
            if (id != null && title != null && img != null && showis != null && time != null && typename != null && text != null) {
                $.post("editor.ashx", { "page": "blog", "id": id, "title": title, "img": img, "showis": showis, "time": time, "typename": typename, "text": text,"abs":abs }, function (a) {
                    window.location.reload();
                    $("#msg").text(a);
                })
            } else {
                $("#msg").text("输入有误");
            }
        }
    </script>

</body>
</html>
