<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PhoneShop.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Phone Shop</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="UserStyle/css/styles.css" rel="stylesheet" />
    <link href="UserStyle/css/slider.css" rel="stylesheet" />
    <script src="UserStyle/js/jquery-1.7.2.min.js"></script> 
    <script src="UserStyle/js/move-top.js"></script>
    <script src="UserStyle/js/easing.js"></script>
   <!-- <script src="UserStyle/js/startstop-slider.js"></script>-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <div class="header">
                <div class="headertop_desc">
                    <div class="call">
                        <p><span>Need help?</span> call us <span class="number">090 5846 811</span></p>
                    </div>
                    <div class="account_desc">
                        <ul>
                            <li><a href="#">Register</a></li>
                            <li><a href="#">Login</a></li>
                            <li><a href="#">My Account</a></li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="header_top">
                    <div class="logo">
                        <a href="index.html">
                            <img src="/images/logo5.gif" alt="logo" /></a>
                    </div>
                    <div class="cart">
                        <p>
                            Welcome to our Online Store! <span>Cart:</span><div id="dd" class="wrapper-dropdown-2">
                                0 item(s) - $0.00
                                <ul class="dropdown">
                                    <li>you have no items in your Shopping cart</li>
                                </ul>
                            </div>
                        </p>
                    </div>
                    <script type="text/javascript">
                        function DropDown(el) {
                            this.dd = el;
                            this.initEvents();
                        }
                        DropDown.prototype = {
                            initEvents: function () {
                                var obj = this;

                                obj.dd.on('click', function (event) {
                                    $(this).toggleClass('active');
                                    event.stopPropagation();
                                });
                            }
                        }

                        $(function () {

                            var dd = new DropDown($('#dd'));

                            $(document).click(function () {
                                // all dropdowns
                                $('.wrapper-dropdown-2').removeClass('active');
                            });

                        });

		            </script>
                    <div class="clear"></div>
                </div>
                <div class="header_bottom">
	     	<div class="menu">
	     		<ul>
			    	<li class="active"><a href="index.html">Home</a></li>
			    	<li><a href="about.html">About</a></li>
			    	<li><a href="delivery.html">Delivery</a></li>
			    	<li><a href="news.html">News</a></li>
			    	<li><a href="contact.html">Contact</a></li>
     			</ul>
                 <div class="clear"></div>
	     	</div>
	     	<div class="search_box">
                    <div class="box">
                        <input type="text" value="Search"/>
                        <input type="submit" value=""/>
                    </div>
                </div>
	     	<div class="clear"></div>
	     </div>
              
                
                <div class="header_slide">
                    <div class="header_bottom_left">
                           
                        <div class="categories">
                            <h3>Danh mục sản phẩm</h3>
                            <%
                              Response.Write(strMenu);
                              %>  
                        </div>
                       
                    </div>
                    <div class="header_bottom_right">
                        <div class="slider">
                            <div id="slider">
                                <div id="mover">
                                    <div id="slide-1" class="slide">
                                        <div class="slider-img">
                                            <a href="preview.html">
                                            <img src="/images/slide_quangcao_iphonex.jpg" alt="learn more" /></a>
                                        </div>
                                    <div class="slider-text">
                                        <h1>Iphone X 64GB<br/>
                                            <span>SALE</span></h1>
                                        <h2>UPTo 5% OFF</h2>
                                        <div class="features_list">
                                            <h4>Fast and Beautiful</h4>
                                        </div>
                                        <a href="#" class="button">Shop Now</a>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
            <div class="main">
                <div class="content">
                    <div class="content_top">
                        <div class="heading">
                            <h3>New Products</h3>
                        </div>
                        <div class="see">
    			            <p><a href="#">See all Products</a></p>
    		            </div>
                        <div class="clear"></div>
                    </div>
                    <div class="section group">
                        <div class="grid_1_of_4 images_1_of_4">
                            <a href="#"><img src="/images/apple-iphone-8-plus-256gb-silver.jpg" width="250px" height="250px"/></a>
                            <h2>Iphone 8 plus 256GB</h2>
                            <div class="price-details">
                                <div class="price-number">
                                    <p><span class="rupees">10990000</span></p>
                                </div>
                                <div class="add-cart">
                                    <h4><a href="#">Add to Cart</a></h4>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="footer">
            <div class="copy_right">
                <p>&copy; 2019 Phone Shop.All rights reversed | Design by <a href="#">Team</a></p>
            </div>
        </div>
        <script type="text/javascript">
		    $(document).ready(function() {			
			    $().UItoTop({ easingType: 'easeOutQuart' });
			
		    });
	    </script>
        <a href="#" id="toTop"><span id="toTopHover"> </span></a>
        
    </form>
</body>
</html>
