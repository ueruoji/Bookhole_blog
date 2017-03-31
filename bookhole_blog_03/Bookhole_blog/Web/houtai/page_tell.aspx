<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page_tell.aspx.cs" Inherits="Bookhole_blog.Web.houtai.page_tell" %>

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
                                <a  href="page_type.aspx"><i class="fa fa-toggle-on"></i>博客类型</a>
                            </li>
                            <li>
                                <a href="page_blog.aspx"><i class="fa fa-bell "></i>博客</a>
                            </li>
                             <li>
                                <a class="active-menu" href="page_tell.aspx"><i class="fa fa-circle-o "></i>博客评论</a>
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
                <div class="row">

                    <div class="col-md-8">

                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>博客</th>
                                        <th>查看</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%for (int i = 0; i < list_blog.Count; i++)
                                        { %>
                                    <tr>
                                        <td><%=list_blog[i].Blog_id %></td>
                                        <td><span class="label label-danger"></span><%=list_blog[i].Blog_title %></td>
                                        <td><span class="label label-info"><a href="javascript:void(0)" onclick="select(<%=list_blog[i].Blog_id%>)">查看</a></span></td>
                                    </tr>
                                       <% } %>
                                </tbody>
                            </table>
                            <table class="table table-striped table-bordered table-hover">
                                 <thead>
                                    <tr>
                                        <th>用户</th>
                                        <th>评论</th>
                                        <th>时间</th>
                                        <th>删除</th>
                                    </tr>
                                </thead>
                                <tbody id="tell_table">
                                    
                                   
                                </tbody>

                            </table>
                          <span id="msg"></span>  
                        </div>
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
    <script>
        function select(i) {
            $.post("editor.ashx", { "id": i,"page":"tell" }, function (a) {
                var js = $.parseJSON(a);
                $("#tell_table").children().remove();
                for (var i = 0; i < js.length; i++) {
                    $("#tell_table").append("<tr><td>" + js[i].Tell_username + "</td><td><span class=\"label label-danger\">" + js[i].Tell_text + "</span></td><td>" + js[i].Tell_time + "</td><td><span class=\"label label-info\"><a href=\"javascript:void(0)\" onclick=\"tell_delete("+js[i].Tell_id+")\">删除</a></span></td></tr>")
                }
            })
        }
        function tell_delete(i) {
            $.post("delete.ashx", { "id": i, "page": "tell" }, function (a) {
                window.location.reload();
                $("#msg").text(a);
            })
        }
    </script>

</body>
</html>

