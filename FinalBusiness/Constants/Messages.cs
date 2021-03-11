using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FinalBusiness.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi!";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi!";

        public static string UnitPriceInvalid = "Ürün fiyatı geçersiz...";
        public static string ProductCountOfCategoryError = "";
        public static string CategoriesFound = "All categories were found";

        public static string CountNotAvaible = "Count not avaible";
        public static string CategoryUpdated = "Category Updated!";
        public static string CategoryDeleted = "Category deleted...";
        public static string CategoryAdded = "Category added";
        public static string CategoryFound = "Category you searched found";

        public static string UserUpdated = "User Updated to Db!";
        public static string UserFound = "We found an User?";
        public static string UsersListed = "Woaw, There are a lot of Users!";
        public static string UserAdded = "Hello, new user. We thought that you will be a good friend for all of us.";
        public static string UserDeleted = "Goodbye LOOSER...";

        public static string ClaimsListed = "Here are your all claims";

        public static string Registered = "Thank you for the register.We hope that we will gain very good achievements";
        public static string Logined = "Hello again. It is nice to see you again. How is it going so on?";

        public static string WrongMail = "Maybe you want to try again one more time?";
        public static string IncorrectPassword = "Woups, Are you a mm.mm...ha..hacker or..r something like that ?!?!";

        public static string TokenCreated = "Here is your new token. Have a nice using !";

        public static string AuthorizationDenied = "You have not a access to this area... Get out of here, NOW!!!";
    }
}
