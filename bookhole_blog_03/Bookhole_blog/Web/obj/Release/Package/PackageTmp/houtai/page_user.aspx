<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page_user.aspx.cs" Inherits="Bookhole_blog.Web.houtai.page_user" %>

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
     <!--PAGE LEVELC STYLES-->
    <link href="assets/css/invoice.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
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
                        <a href="#"  ><i ></i>博客<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                            <li>
                                <a  href="page_type.aspx"><i class="fa fa-toggle-on"></i>博客类型</a>
                            </li>
                            <li>
                                <a href="page_blog.aspx"><i class="fa fa-bell "></i>博客</a>
                            </li>
                             <li>
                                <a href="page_tell.aspx"><i class="fa fa-circle-o "></i>博客评论</a>
                            </li>
                        </ul>
                    </li>
                     <li >
                        <a href="#" class="active-menu-top"><i class="fa fa-yelp "></i>用户 <span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                            <li>
                                <a class="active-menu" href="page_user.aspx"><i class="fa fa-coffee"></i>用户管理</a>
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

     <div class="row">
         <div class="col-lg-12 col-md-12 col-sm-12">
           <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>账号</th>
                                    <th>用户名</th>
                                    <th>图片</th>
                                    <th>QQ</th>
                                    <th>电话</th>
                                    <th>编辑</th>
                                    <th>删除</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%for (int i = 0; i < list_user.Count; i++)
                                    {%>
                                 <tr>
                                    <td><%=list_user[i].User_id %></td>
                                    <td><%=list_user[i].User_name %></td>
                                    <td><img src="<%=list_user[i].User_img %>" style="width:50px;height:50px;"/></td>
                                    <td><%=list_user[i].User_qq %></td>
                                    <td><%=list_user[i].User_phone %></td>
                                    <td><a href="javascript:void(0)"  onclick="editor(<%=i %>)">编辑</a> </td>
                                    <td><a href="javascript:void(0)" onclick="t_delete(<%=list_user[i].User_id %>)">删除</a></td>
                                </tr>
                                  <%  } %>
                              <tr>
                                        <td><input type="text" id="text_id" style="width:100px;"/></td>
                                    
                                        <td><input type="text" id="text_name" style="width:70px;"/></td>
                                        <td style="width:100px;">
                                            <a href="javascript:;" class="a-upload">
                                                <input type="file" id="file1" name="file" />选择图片
                                            </a>
                                            <input type="button" value="上传" />
                                            <img id="img1"  src="" style="width:100px;height:100px" />
                                        </td>
                                        <td><input type="text" id="text_qq" style="width:100px;" /></td>
                                        <td><input type="text" id="text_phone" style="width:100px;"/></td>
                                        <td><a  href="javascript:void(0)" onclick="t_editor()">编辑完成</a></td>
                                        <td><a  href="javascript:void(0)" onclick="t_add()">添加</a></td>
                                    </tr>
                               
                                
                            </tbody>
                        </table>
               </div>
              <span id="msg"></span>
             
         </div>
     </div>
     
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
    <script>
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
                    data: { name: 'blog' },
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
            $("#text_name").val($("tr:eq(" + (i + 1) + ")").children("td:eq(1)").text())
            $("#img1").attr("src", $("tr:eq(" + (i + 1) + ")").children("td:eq(2)").children().attr("src"))
            $("#text_qq").val($("tr:eq(" + (i + 1) + ")").children("td:eq(3)").text())
            $("#text_phone").val($("tr:eq(" + (i + 1) + ")").children("td:eq(4)").text())
        }
        function t_add() {
            var id = $("#text_id").val();
            var name = $("#text_name").val()
            var img = $("#img1").attr("src")
            var qq = $("#text_qq").val()
            var phone = $("#text_phone").val()
            if (id != null && name != null && img != null && qq != null && phone != null ) {
                $.post("add.ashx", { "page": "user", "id": id, "name": name, "img": img, "qq": qq, "phone": phone}, function (a) {
                    window.location.reload();
                    $("#msg").text(a);
                })
            } else {
                $("#msg").text("输入有误");
            }
        }
        function t_editor() {
            var id = $("#text_id").val();
            var name = $("#text_name").val()
            var img = $("#img1").attr("src")
            var qq = $("#text_qq").val()
            var phone = $("#text_phone").val()
            if (id != null && name != null && img != null && qq != null && phone != null) {
                $.post("editor.ashx", { "page": "user", "id": id, "name": name, "img": img, "qq": qq, "phone": phone}, function (a) {
                    window.location.reload();
                    $("#msg").text(a);
                })
            } else {
                $("#msg").text("输入有误");
            }
        }
        function t_delete(i) {
            $.post("delete.ashx", { "page": "user", "id": i }, function (a) {
                window.location.reload();
                $("#msg").text(a);
            })
        }
    </script>

</body>
</html>
