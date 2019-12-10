<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhoneShop.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style>
        /* Popup Box */
        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 8888; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        /* Modal Content/Box */
        .modal-content {
            background-color: #fefefe;
            margin: 10vh auto; /* 15% from the top and centered */
            padding: 20px;
            border: 1px solid #888;
            width: 60%; /* Could be more or less, depending on screen size */
        }

        @media (min-width: 1366px) {
            .modal-content {
                background-color: #fefefe;
                margin: 10vh auto; /* 15% from the top and centered */
                padding: 20px;
                border: 1px solid #888;
                width: 30%; /* Could be more or less, depending on screen size */
            }
        }

        h2, p {
            margin: 0 0 20px;
            font-weight: 400;
            color: #666;
        }

        span {
            color: #666;
            display: block;
            padding: 0 0 5px;
        }

        form {
            padding: 25px;
            margin: 25px;
            box-shadow: 0 2px 5px #f5f5f5;
            background: #eee;
        }

        input, textarea {
            width: calc(100% - 18px);
            padding: 8px;
            margin-bottom: 20px;
            border: 1px solid #1c87c9;
            outline: none;
        }

        .contact-form button {
            width: 100%;
            padding: 10px;
            border: none;
            background: #1c87c9;
            font-size: 16px;
            font-weight: 400;
            color: #fff;
        }

        button:hover {
            background: #2371a0;
        }
        /* The Close Button */
        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: black;
                text-decoration: none;
                cursor: pointer;
            }

        button.button {
            background: none;
            border-top: none;
            outline: none;
            border-right: none;
            border-left: none;
            border-bottom: #02274a 1px solid;
            padding: 0 0 3px 0;
            font-size: 16px;
            cursor: pointer;
        }

            button.button:hover {
                border-bottom: #a99567 1px solid;
                color: #a99567;
            }
    </style>
  </head>
  <body>
    <h2>Multiple Popup Forms</h2>
    <p>
        <button class="button" data-modal="modalOne">Contact Us</button>
    </p>
    <p>
        <button class="button" data-modal="modalTwo">Send a Compliant Form</button>
    </p>
    <div id="modalOne" class="modal">
        <div class="modal-content">
            <div class="contact-form">
                <a class="close">&times;</a>
                <form action="/">
                    <h2>Contact Us</h2>
                    <div>
                        <input class="fname" type="text" name="name" placeholder="Full name">
                        <input type="text" name="name" placeholder="Email">
                        <input type="text" name="name" placeholder="Phone number">
                        <input type="text" name="name" placeholder="Website">
                    </div>
                    <span>Message</span>
                    <div>
                        <textarea rows="4"></textarea>
                    </div>
                    <button type="submit" href="/">Submit</button>
                </form>
            </div>
        </div>
    </div>
    <div id="modalTwo" class="modal">
        <div class="modal-content">
            <div class="contact-form">
                <span class="close">&times;</span>
                <form action="/">
                    <h2>Complaint form</h2>
                    <div>
                        <input class="fname" type="text" name="name" placeholder="Full name">
                        <input type="text" name="name" placeholder="Email">
                        <input type="text" name="name" placeholder="Phone number">
                        <input type="text" name="name" placeholder="Website">
                    </div>
                    <span>Message</span>
                    <div>
                        <textarea rows="4"></textarea>
                    </div>
                    <button type="submit" href="/">Submit</button>
                </form>
            </div>
        </div>
    </div>
    <script>
      var modalBtns = [...document.querySelectorAll(".button")];
      modalBtns.forEach(function(btn){
        btn.onclick = function() {
          var modal = btn.getAttribute('data-modal');
          document.getElementById(modal).style.display = "block";
        }
      });

      var closeBtns = [...document.querySelectorAll(".close")];
      closeBtns.forEach(function(btn){
        btn.onclick = function() {
          var modal = btn.closest('.modal');
          modal.style.display = "none";
        }
      });

      window.onclick = function(event) {
        if (event.target.className === "modal") {
          event.target.style.display = "none";
        }
      }
    </script>
</body>
</html>
