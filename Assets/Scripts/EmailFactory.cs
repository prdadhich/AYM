using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;
using System.Collections;
public class EmailFactory : MonoBehaviour
{
    public TMP_InputField bodyMessage;
    public TMP_InputField recipientEmail;



    //input text 
    
    public TMP_InputField FirstName;
    public TMP_InputField LastName;
    public TMP_InputField EmailAddress;
    public TMP_InputField PhoneNumber;
    public TMP_InputField Password;
    public TMP_InputField ConfirmPassword;
    public TMP_Dropdown Country;


    //send messgae strings 
    private string firstName = "abc";
    private string lastName = "bcd";
    private string emailAddress = "a";
    private string phoneNumber = "a";
    private string password = "a";
    private string confirmPassword = "a";
    private string country = "a";



    private string finalMessage = "Working";




    // send to mail 
    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("YourEmail");
        mail.To.Add(new MailAddress("YourEmail"));

        mail.Subject = "Signup Details";
        mail.Body = finalMessage;

        //Add your email and password here
        SmtpServer.Credentials = new System.Net.NetworkCredential("YourEmail", "Password") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }


    public void SendText(string phoneNumber)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;

        mail.From = new MailAddress("myEmail@gmail.com");

        mail.To.Add(new MailAddress(phoneNumber + "@txt.att.net"));//See carrier destinations below
                                                                   //message.To.Add(new MailAddress("5551234568@txt.att.net"));
        mail.To.Add(new MailAddress(phoneNumber + "@vtext.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@messaging.sprintpcs.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@tmomail.net"));
        mail.To.Add(new MailAddress(phoneNumber + "@vmobl.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@messaging.nextel.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@myboostmobile.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@message.alltel.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@mms.ee.co.uk"));



        mail.Subject = "Subject";
        mail.Body = "";

        SmtpServer.Port = 587;

        SmtpServer.Credentials = new System.Net.NetworkCredential("myEmail@gmail.com", "MyPasswordGoesHere") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }


    public void Changed()
    {

        firstName = FirstName.text;
        lastName = LastName.text;
        password = Password.text;
        emailAddress = EmailAddress.text;
        phoneNumber = PhoneNumber.text; 
        confirmPassword = ConfirmPassword.text;
        country = Country.options[Country.value].text;


        finalMessage = "First Name:" + firstName+ " "+ "Last Name:"+ lastName +" "+ "Password:"+password + " " + "EmailAddress:" +emailAddress + 
            " "+ "Phone:"+ phoneNumber + " " + "Country:"+ country;    
    }
    public void CallSendEmail()
    {
       

        if (password == confirmPassword && password.Length > 7)
        {
            SendEmail();
        
        
        }
    }
    public void CallSendForm()
    { 
        StartCoroutine(SendForm(firstName,
         lastName,
         emailAddress,
         phoneNumber,
         password,
         confirmPassword,
        "Jordan")); 
    
    }


    IEnumerator SendForm(string firstName,
    string lastName,
    string emailAddress,
    string phoneNumber,
    string password,
    string confirmPassword, string country)
    {


        //string json = JsonUtility.ToJson(user);

        WWWForm form = new WWWForm();
            form.AddField("email", firstName);   
            form.AddField("firstName", firstName);   
            form.AddField("lastName", firstName);
            form.AddField("mobile_number", firstName);
            form.AddField("password", firstName);
            form.AddField("userName", firstName);
            //form.AddField("extra", firstName);


        using (UnityWebRequest www = UnityWebRequest.Post("https://aymbot.com/core/user/rest/auth/signup", form))
        {
           // byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
           // www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.SetRequestHeader("Content-Type", "application/json");
            www.method = UnityWebRequest.kHttpVerbPOST;
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Post Request Complete!");
            }
        }


    }


}