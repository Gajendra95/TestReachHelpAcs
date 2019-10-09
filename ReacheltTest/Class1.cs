using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;




namespace ReachheltTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void tcLogin()
        {
            string url = "http://172.16.51.194/AcsReachHelp/";
            //string AdminUsername = "9611703294";
            //string AdminPassword = "test1";

            IWebDriver oWD = new ChromeDriver();
            oWD.Navigate().GoToUrl(url);
            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[2]/ul[1]/li[2]/a[1]")).Click();
            //oWD.Navigate().GoToUrl("http://172.16.51.47/ReachhelpAcs/index.aspx#");
            //oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[2]/ul[1]/li[2]/a[1]")).Click();
            Task.Delay(2000).Wait();
            
            oWD.FindElement(By.Id("mobileno")).SendKeys("9611703294");
            oWD.FindElement(By.Id("password")).SendKeys("test1");
            oWD.FindElement(By.Id("loginbtn")).Submit();
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/ul[1]/li[2]/a[1]")).Click();

            //oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/ul[1]/li[2]/a[1]")).Click();

            Task.Delay(2000).Wait();
            String value = oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/h3[1]")).GetAttribute("data-trn-key");

            Assert.AreEqual("All Users", value);
            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[2]/div[1]/nav[1]/ul[1]/li[2]/a[1]/span[1]")).Click();
            oWD.Close();
        }


        [Test]
        public void tcUser()
        {
            string url = "http://172.16.51.194/AcsReachHelp/";
            string AdminUsername = "8801227744";
            string AdminPassword = "12345";

            IWebDriver oWD = new ChromeDriver();
            oWD.Navigate().GoToUrl(url);
            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[2]/ul[1]/li[2]/a[1]")).Click();
            //oWD.Navigate().GoToUrl("http://172.16.51.47/ReachhelpAcs/index.aspx#");
            //oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[2]/ul[1]/li[2]/a[1]")).Click();
            Task.Delay(2000).Wait();

            oWD.FindElement(By.Id("mobileno")).SendKeys(AdminUsername);
            oWD.FindElement(By.Id("password")).SendKeys(AdminPassword);
            oWD.FindElement(By.Id("loginbtn")).Submit();
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/ul[1]/li[1]/a[1]/span[1]")).Click(); //need
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[3]/div[1]/div[1]/a[1]")).Click(); //Post need
            Task.Delay(2000).Wait();
            oWD.FindElement(By.Id("select2-category-container")).Click(); //dropdown
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//input[@class='select2-search__field']")).SendKeys("Food");
            oWD.FindElement(By.XPath("//input[@class='select2-search__field']")).SendKeys(Keys.Enter);

            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//span[@id='select2-subCategory-container']")).Click(); //dropdown2
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//input[@class='select2-search__field']")).SendKeys("Sugar");
            oWD.FindElement(By.XPath("//input[@class='select2-search__field']")).SendKeys(Keys.Enter);

            Task.Delay(2000).Wait();  //Quantity
            oWD.FindElement(By.Id("qty")).SendKeys(Keys.Delete);

            Task.Delay(2000).Wait();  //Quantity
            oWD.FindElement(By.Id("qty")).SendKeys("5");



            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//span[@id='select2-unit-container']")).Click(); //dropdown3
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//input[@class='select2-search__field']")).SendKeys("Kg");
            oWD.FindElement(By.XPath("//input[@class='select2-search__field']")).SendKeys(Keys.Enter);
            //span[@id='select2-unit-container']

            Task.Delay(2000).Wait();
            oWD.FindElement(By.Id("expectedDate")).SendKeys(Keys.Delete); //Date


            Task.Delay(2000).Wait();
            oWD.FindElement(By.Id("expectedDate")).SendKeys("2019/09/13"); 


            Task.Delay(2000).Wait();
            oWD.FindElement(By.Id("deliveryAddress")).SendKeys("Manipal"); //Address

            Task.Delay(2000).Wait();
            oWD.FindElement(By.Id("btnCreateRequest")).Click(); //Submit Button

            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//button[@class='swal-button swal-button--confirm']")).Click(); //Ok Button


            oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[2]/div[1]/nav[1]/ul[1]/li[2]/a[1]/span[1]")).Click(); //Logout
            oWD.Close();
            //div[@class = 'swal-title']
            //oWD.FindElement(By.XPath(".//span[contains(@title, 'Food')]")).Click();
            //new WebDriverWait(oWD, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span[title='Food']"))).Click();

            //oWD.FindElement(By.("//span[@id='select2-category-container']/title[Food]")).Click();
            //oWD.FindElement(By.CssSelector("button[title*='Food']")).Click();
            //oWD.FindElement(By.CssSelector("#select2-category-container/@title='Clothing'")).Click();
            //IWebElement myselect = oWD.FindElement(By.Name("select2-selection__rendered"));
            //SelectElement select2-selection__rendered = new SelectElement(myselect);
            // SelectElement myselect = new SelectElement(oWD.FindElement(By.Id("select2-category-container")));
            //myselect.SelectByValue("Food");
            Task.Delay(2000).Wait();
            //oWD.Close();
            /*oWD.FindElement(By.Id("homelink")).Click();
            Task.Delay(2000).Wait();
            oWD.FindElement(By.Id("btnRequestHelp")).Click();
            Task.Delay(2000).Wait();
            oWD.FindElement(By.XPath("//div[@class='container']//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//input[1]")).Click();*/
            //String data = oWD.FindElement(By.Id("myModalLabel")).GetAttribute("innerhtml");
         
            //Assert.AreEqual("Description", data);


            //Task.Delay(2000).Wait();

            //SelectElement catvalue = new SelectElement(category);
            //catvalue.SelectByText("Food");
            //var item = "Food";
            //oWD.FindElement(By.XPath("//td[@id='select2-category-container']/span[text()='" + item+ "']")).Click();

            //System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> options = category.FindElements(By.ClassName("select2-results__option"));

            //int count = options.Count;

            //Console.WriteLine(count);
            //var selectElement = new SelectElement(category);
            //oWD.FindElement(By.XPath("/html[1]/body[1]/span[1]/span[1]/span[2]/ul[1]/li[2]")).se;
            //select by value
            //selectElement.SelectByText("Food");

            //Task.Delay(2000).Wait();
            //String value = oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/h3[1]")).GetAttribute("data-trn-key");

            //Assert.AreEqual("All Users", value);
            //oWD.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[3]/div[1]/div[1]/div[2]/div[1]/nav[1]/ul[1]/li[2]/a[1]/span[1]")).Click();
            //oWD.Close();
        }


    }
}
