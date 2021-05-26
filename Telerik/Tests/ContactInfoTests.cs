using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Data.BillingInformation;
using Telerik.Common.Enums;
using Telerik.Pages;
using Telerik.Utils;

namespace Telerik.Tests
{
    class ContactInfoTests : BaseTest
    {

        ShoppingCartPage shoppingCartPage;
        ContactInfoPage contactInfoPage;
        OrderSummaryPage orderSummaryPage;
        string firstName = "Jonh";
        string lastName = "Dole";
        string email = "Jonh.test@gmail.com";
        string company = "My Company";
        string phone = "08834443333";
        string addressInfo = "Ave Street 1";
        CountryEnum country = CountryEnum.Bulgaria;
        string VATID = "443234234434";
        string city = "Sofia";
        string zip = "234";

        [Test]
        public void TestBillingAddressWithValidInfoAndSameHolderAddress()
        {
            contactInfoPage = new ContactInfoPage(driverUtils.GetDriver());
            shoppingCartPage = new ShoppingCartPage(driverUtils.GetDriver());
            orderSummaryPage = new OrderSummaryPage(driverUtils.GetDriver());
            country = CountryEnum.Albania;
            Address address = new Address(addressInfo, country, city, zip);
            BillingInformation billing = new BillingInformation(firstName, lastName, email, company, phone, address);
            driverUtils.NavigateToUrl(AppSettingsReaderUtils.GetKey("urlShoppingCart"));
            shoppingCartPage.ClickOnContinueButton();
            contactInfoPage.AcceptCookies();
            contactInfoPage.AddBillingInformation(billing);
            contactInfoPage.ClickOnContinueButton();

            Assert.AreEqual("Order Summary", orderSummaryPage.GetSummaryPageTitle());
        }

        [Test]
        public void TestBillingAddressWithInvalidVatID()
        {
            contactInfoPage = new ContactInfoPage(driverUtils.GetDriver());
            shoppingCartPage = new ShoppingCartPage(driverUtils.GetDriver());
            Address address = new Address(addressInfo, country, city, zip);
            BillingInformation billing = new BillingInformation(firstName, lastName, email, company, phone, address);
            billing.VatID = VATID;
            driverUtils.NavigateToUrl(AppSettingsReaderUtils.GetKey("urlShoppingCart"));
            shoppingCartPage.ClickOnContinueButton();
            contactInfoPage.AcceptCookies();
            contactInfoPage.AddBillingInformation(billing);

            Assert.AreEqual("Invalid VAT ID", contactInfoPage.GetVatIdValidatonError());

        }




        [Test]
        public void TestInvalidCompanyValidationError()
        {
            contactInfoPage = new ContactInfoPage(driverUtils.GetDriver());
            shoppingCartPage = new ShoppingCartPage(driverUtils.GetDriver());
            Address address = new Address(addressInfo, country, city, zip);
            company = "";
            BillingInformation billing = new BillingInformation(firstName, lastName, email, company,phone, address);

            driverUtils.NavigateToUrl(AppSettingsReaderUtils.GetKey("urlShoppingCart"));
            shoppingCartPage.ClickOnContinueButton();
            contactInfoPage.AcceptCookies();
            contactInfoPage.AddBillingInformation(billing);

            Assert.AreEqual("Company is required", contactInfoPage.GetCompanyValidationError());
        }
        [Test]
        public void TestInvalidEmailValidationError()
        {
            contactInfoPage = new ContactInfoPage(driverUtils.GetDriver());
            shoppingCartPage = new ShoppingCartPage(driverUtils.GetDriver());
            email = "JonsEmail";
            Address address = new Address(addressInfo, country, city, zip);
            BillingInformation billing = new BillingInformation(firstName, lastName, email, company, phone, address);

            driverUtils.NavigateToUrl(AppSettingsReaderUtils.GetKey("urlShoppingCart"));
            shoppingCartPage.ClickOnContinueButton();
            contactInfoPage.AcceptCookies();
            contactInfoPage.AddBillingInformation(billing);

            Assert.AreEqual("Invalid Email", contactInfoPage.GetEmailValidationError());
        }
    }
}
