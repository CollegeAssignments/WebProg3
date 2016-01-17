using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace WebProg_3___Car_Rental_Website
{
    public partial class register : System.Web.UI.Page
    {
        //Connect to database
        Entities db = new Entities();


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void btnSubmitReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Collect data inputs
                string fName = tbxFName.Text;
                string lName = tbxLName.Text;
                string pNumber = tbxPhone.Text;
                DateTime dOB = Convert.ToDateTime(tbxDate.Text);
                string address = tbxAddress1.Text + "," + tbxAddress2.Text + "," + tbxAddressCountry.Text;
                string licenseNum = tbxLicenseNum.Text;
                string userName = tbxUserName.Text;
                string email = tbxEmail.Text;

                string password = tbxPassword.Text;

                //Store salt & hashed password
                string salt = GenerateSalt();
                string passHashed = HashMD5(password + salt);

                //Check if the email address already exists in the database
                var queryUser = from users in db.Users
                                where users.Email == email
                                select 1;

                if (queryUser.Count() > 0)
                {
                    lblDbErrorNotice.Text = "Sorry. An account has already been registered with that email";
                }
                else
                {
                    WriteToDB(fName, lName, pNumber, dOB, address, licenseNum, userName, email, salt, passHashed);
                    VerifyEmail(userName, email);
                }

            }
            catch (Exception ex)
            {
                lblDbErrorNotice.Text = "Internal Server Error. Error Message: " + ex.Message + ". Please Contact the Site Administrator.";
            }
        }


        //Generate a random alphnumeric salt
        //Source: http://stackoverflow.com/questions/31957255/generating-a-random-number-in-c-sharp-with-alpha-numeric-values
        public static string GenerateSalt()
        {
            int size = 8;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            using (var crypto = new RNGCryptoServiceProvider())
            {
                var data = new byte[size];

                // If chars.Length isn't a power of 2 then there is a bias if
                // we simply use the modulus operator. The first characters of
                // chars will be more probable than the last ones.

                // buffer used if we encounter an unusable random byte. We will
                // regenerate it in this buffer
                byte[] smallBuffer = null;

                // Maximum random number that can be used without introducing a
                // bias
                int maxRandom = byte.MaxValue - ((byte.MaxValue + 1) % chars.Length);

                crypto.GetBytes(data);

                var result = new char[size];

                for (int i = 0; i < size; i++)
                {
                    byte v = data[i];

                    while (v > maxRandom)
                    {
                        if (smallBuffer == null)
                        {
                            smallBuffer = new byte[1];
                        }

                        crypto.GetBytes(smallBuffer);
                        v = smallBuffer[0];
                    }

                    result[i] = chars[v % chars.Length];
                }

                return new string(result);
            }
        }


        //Generates MD5 hashed password
        //
        //Accepts one string [password + salt]
        //Returns MD5 hash as a string
        string HashMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(input));
            string result = BitConverter.ToString(bytes).Replace("-", String.Empty);
            return result;
        }
        

        //Saves the new user to the database
        //On failed display error message
        void WriteToDB(string fName,string lname,string pNumber,DateTime dob,string address,string licenseNum,string userName,string email,string salt, string hashedPass)
        {
            //Create a User object
            User newUser = new User
            {
                FName = fName,
                LName = lname,
                Phone = pNumber,
                DOB = dob,
                Address = address,
                LicenseNum = licenseNum,
                UserName = userName,
                Email = email,
                salt = salt,
                Password = hashedPass
            };

            //Save User to database
            try
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                //TODO:Find out why address is throwing exception
                lblDbErrorNotice.Text = "Internal Server Error. Error Message: " + ex.Message + ". Please Contact the Site Administrator.";
            }
        }

        void VerifyEmail(string userName, string email)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);

            
            smtpClient.Credentials = new System.Net.NetworkCredential("info.rentacar1@gmail.com", "Qwerty12480");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("info.rentacar1@gmail.com", "Rent a Car");
            mail.To.Add(new MailAddress(email));
            mail.CC.Add(new MailAddress(""));
            mail.Subject = "Please Verify Your Email Address";
            mail.Body = "Hi " + userName + ",</br></br>" 
                        + "Please follow the link to activate your account.</br/><br/>" 
                        + "<a href='http://localhost:40959/verify.aspx?email=" + email + "?userName=" + userName + ">Activate Account</a>";

            smtpClient.Send(mail);
        }
    }
}