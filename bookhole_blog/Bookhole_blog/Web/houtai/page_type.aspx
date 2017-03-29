<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page_type.aspx.cs" Inherits="Bookhole_blog.Web.houtai.page_type" %>

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
                                <a class="active-menu" href="page_type.aspx"><i class="fa fa-toggle-on"></i>博客类型</a>
                            </li>
                            <li>
                                <a href="page_blog.aspx"><i class="fa fa-bell "></i>博客</a>
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
                        <a  href="page_img.aspx"><i class="fa fa-anchor "></i>图片</a>
                    </li>
                    
                </ul>

            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner">
                
                            <table class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>博客类型</th>
                                        <th>类型所占百分比</th>
                                        <th>编辑</th>
                                        <th>删除</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%for (int i = 0; i <list_type.Count; i++)
                                        {%>
                                        <tr>
                                        <td><%=list_type[i].Type_id %></td>
                                        <td><span class="label label-danger"><%=list_type[i].Type_name %></span></td>
                                        <td><%=list_type[i].Type_percentage %></td>
                                        <td><a href="javascript:void(0)" onclick="editor(<%=i %>)">编辑</a></td>
                                        <td><a href="javascript:void(0)" onclick="t_delete(<%=list_type[i].Type_id %>)">删除</a></td>
                                    </tr>
                                        <%} %>
                                    <tr>
                                        <td><input type="text" id="text_id"/></td>
                                        <td><input type="text" id="text_type"/></td>
                                        <td><input type="text" id="text_bai"/></td>
                                        <td><a href="javascript:void(0)" onclick="t_editor()">完成</a></td>
                                        <td><a href="javascript:void(0)" onclick="t_add()">添加</a></td>
                                       
                                    </tr>
                                    <hr />
                                    <span id="msg">

                                    </span>
                                </tbody>
                            </table>
                     
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
        <script>
        function editor(i) {
        $("#text_id").val($("tr:eq("+(i+1)+")").children("td:eq(0)").text())
        $("#text_type").val($("tr:eq(" + (i + 1) + ")").children("td:eq(1)").text())
        $("#text_bai").val($("tr:eq(" + (i + 1) + ")").children("td:eq(2)").text())
    }
        function t_delete(i) {
            $.post("delete.ashx", { "page": "type", "id": i }, function (a) {
                window.location.reload();
                $("#msg").text(a);
            })
        }
            
        function t_add() {
            var id = $("#text_id").val();
            var type= $("#text_type").val()
            var bai = $("#text_bai").val()
            if (id != null && type != null && bai != null) {
                $.post("add.ashx", { "page": "type", "id": id, "type": type, "bai": bai }, function (a) {
                    window.location.reload();
                    $("#msg").text(a);
                })
            } else {
                $("#msg").text("输入有误");
            }
        }
        function t_editor() {
            var id = $("#text_id").val();
            var type = $("#text_type").val()
            var bai = $("#text_bai").val()
            if (id != null && type != null && bai != null) {
                $.post("editor.ashx", { "page": "type", "id": id, "type": type, "bai": bai }, function (a) {
                    window.location.reload();
                    $("#msg").text(a);
                })
            } else {
                $("#msg").text("输入有误");
            }
        }


    </script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>


</body>
</html>

