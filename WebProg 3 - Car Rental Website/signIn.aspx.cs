using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace WebProg_3___Car_Rental_Website
{
    public partial class signIn : System.Web.UI.Page
    {
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            //Collect user inputed data
            string userName = tbxUserName.Text;
            string passWord = tbxPassword.Text;

            try
            {
                //Store salt and password pulled from server
                string salt="";
                string pass="";

                var queryUser = from users in db.Users
                                where users.UserName == userName
                                select new
                                {
                                    pass = users.Password,
                                    salt = users.salt,
                                };

                //Unpack queried data into variables
                foreach (var item in queryUser)
                {
                    salt = item.salt;
                    pass = item.pass;
                }

                //Run MD5 hashing on entered password + salt from database
                if(queryUser.Count() == 0)
                {
                    throw new Exception("No User exists with the entered Username.");
                }
                
                else if (queryUser.Count() > 0)
                {
                    string checkPass = HashMD5(passWord + salt);

                    //Check if new password matches stored password
                    if (checkPass == pass)
                    {

                        //If passwords match fetch the rest of the users information from the database
                        var fullUserInfo = from user in db.Users
                                            where user.UserName == userName
                                            select new
                                            {
                                                fName = user.FName,
                                                lName = user.LName,
                                                address = user.Address,
                                                dOB = user.DOB,
                                                email = user.Email,
                                                phone = user.Phone,
                                                userType = user.UserType,
                                                licenseNum = user.LicenseNum,
                                            };

                        //Store the logged in user in the current session
                        foreach (var u in fullUserInfo)
                        {
                            Session.Add("fName", u.fName);
                            Session.Add("lName", u.lName);
                            Session.Add("address", u.address);
                            Session.Add("dOB", u.dOB);
                            Session.Add("email", u.email);
                            Session.Add("phone", u.phone);
                            Session.Add("userType", u.userType);
                            Session.Add("licenceNum", u.licenseNum);
                        }

                        Response.Redirect("home.aspx");
                    }
                    else
                        throw new Exception("Password is Incorrect");
                }
            }
            catch(Exception ex)
            {
                lblDbErrorNotice.Text = ex.Message; 
            }
        }


        string HashMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(input));
            string result = BitConverter.ToString(bytes).Replace("-", String.Empty);
            return result;
        }
    }
}