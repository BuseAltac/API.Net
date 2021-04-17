using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string clientID = "24_68imz0u73kg8kkow4s4k88cggg4ow4gwwkss0ccgk40wsw0kwo";
        public static string clientSecret = "44q1i5js55og0w8ggw0ogccs08oswckg04048wg080c4gg4wg8";


        public string Get_AccessTokenAsync(string url, string userName, string password)
        {


            string response = "";

            try
            {
                WebClient webClient = new WebClient();

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                webClient.Headers.Add("cache-control", "no-cache");



                var requestParams = new System.Collections.Specialized.NameValueCollection();
               

                 response= webClient.DownloadString("https://senolozbek1.myideasoft.com/oauth/v2/token?client_id=24_68imz0u73kg8kkow4s4k88cggg4ow4gwwkss0ccgk40wsw0kwo" +
                    "&client secret=44q1i5js55og0w8ggw0ogccs08oswckg04048wg080c4gg4wg8" +
                    "&grant_type=password" +
                    "&username=buse" +
                    "&password=123456Aa");

                //response = Encoding.UTF8.GetString(responseBytes);

            }
            catch (Exception e)
            {

                return e.Message;
            }
            

            return response;           
            
        }


        private string GetProducts(string accessToken)
        {
            WebClient webClient = new WebClient();

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Headers.Add("cache-control", "no-cache");
            webClient.Headers.Add("Authorization", "Bearer " + accessToken);




            var requestParams = new System.Collections.Specialized.NameValueCollection();


            return webClient.DownloadString("https://senolozbek1.myideasoft.com/api/products");

        }



        private void GetAccessToken_Click(object sender, EventArgs e)
        {
            var tokenResponse = Get_AccessTokenAsync("https://appstore.kaptan.fun/oauth/v2/token", "buse", "123456Aa");

            TokenResponse tokenResponseObj = JsonConvert.DeserializeObject<TokenResponse>(tokenResponse);



            textBox1.Text = GetProducts(tokenResponseObj.access_token);

        }


    }
}


