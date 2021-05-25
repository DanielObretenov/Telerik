using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Data.BillingInformation;
using Telerik.Common.Enums;
using Telerik.Common.Utils;

namespace Telerik.Pages
{
    class ContactInfoPage : BasePage
    {


        [FindsBy(How = How.CssSelector, Using = "#biFirstName")]
        protected IWebElement FirstNameInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biLastName")]
        protected IWebElement LastNameInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biEmail")]
        protected IWebElement EmailInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biCompany")]
        protected IWebElement CompanyInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biPhone")]
        protected IWebElement PhoneInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biAddress")]
        protected IWebElement AddressInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biCountry .k-select")]
        protected IWebElement CountryDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biCity")]
        protected IWebElement CityInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biState .k-select")]
        protected IWebElement StateDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biZipCode")]
        protected IWebElement ZipInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#biVatId")]
        protected IWebElement VatIdInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='biEmail']/following-sibling::validation-messages//span")]
        protected IWebElement EmailValidationError { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='biVatId']/following-sibling::validation-messages//span")]
        protected IWebElement VatIdValidatioError { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='biCompany']/following-sibling::validation-messages//span")]
        protected IWebElement CompanyValidationError { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.e2e-continue")]
        protected IWebElement ContinueButton { get; set; }

        public ContactInfoPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddBillingInformation(BillingInformation billing)
        {
            SetFirstName(billing.FirstName);
            SetLastName(billing.LastName);
            SetEmail(billing.Email);
            SetCompany(billing.Company);
            SetPhone(billing.Phone);
            SetAddress(billing.Address);
            if (billing.VatID != null)
            {
                SetVatId(billing.VatID);
            }
        }

        public void SetFirstName(string firstName)
        {
            common.ClearAndSendKeys(FirstNameInputField, firstName);
        }
        public void SetLastName(string lastName)
        {
            common.ClearAndSendKeys(LastNameInputField, lastName);

        }
        public void SetEmail(string email)
        {
            common.ClearAndSendKeys(EmailInputField, email);

        }
        public void SetCompany(string company)
        {
            common.ClearAndSendKeys(CompanyInputField, company);

        }
        public void SetPhone(string phone)
        {
            common.ClearAndSendKeys(PhoneInputField, phone);

        }
        public void SetAddress(Address address)
        {
            SetAddressInfo(address.AddressInfo);
            SetCountry(address.Country);
            SetCity(address.City);
            SetZip(address.Zip);
        }
        public void SetAddressInfo(string addressInfo)
        {
            common.ClearAndSendKeys(AddressInputField, addressInfo);

        }
        public void SetCountry(CountryEnum country)
        {
            common.ClickOnElement(CountryDropdown);
            string dropdownTextLocator = "//li[contains(@class,'ng-star-inserted')][normalize-space(text()) = '{0}']";
            string concat = common.ConcatText(dropdownTextLocator, country.ToString());
            common.MoveToElementAndClick(driver, CountryDropdown.FindElement(By.XPath(concat)));

        }
        public void SetCity(string city)
        {
            common.ClearAndSendKeys(CityInputField, city);
        }
        public void SetState(string city)
        {

        }
        public void SetZip(string zip)
        {
            common.ClearAndSendKeys(ZipInputField, zip);
        }
        public void SetVatId(string vatId)
        {
            common.ClearAndSendKeys(VatIdInputField, vatId);
        }

        public string GetEmailValidationError()
        {
            return EmailValidationError.Text;

        }
        public string GetCompanyValidationError()
        {
            return CompanyValidationError.Text;
        }
        public string GetVatIdValidatonError()
        {
            string loaderElement = "div.row.loader-container:not(.is-loading)";
            WaitUtil.WaitForLoaderToDisapear(driver, loaderElement);
            return VatIdValidatioError.Text;
        }
        public void ClickOnContinueButton()
        {
            common.ClickOnElement(ContinueButton);
        }
    }
}
