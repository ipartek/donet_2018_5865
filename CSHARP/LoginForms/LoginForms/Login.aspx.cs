﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if(TxtEmail.Text == "javierlete@email.net" && TxtPassword.Text == "contra")
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TxtEmail.Text, false);
            }
            else
            {
                BtnLogin.Text = "Error";
            }
        }
    }
}