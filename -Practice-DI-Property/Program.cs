using _Practice_DI_Constructor;
using System;

namespace _Practice_DI_Property
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Login("", "");

            Console.Read();
        }

        public static void Login(string userId, string password)
        {
            //var authService = new AuthenticationService()
            //    {
            //        MessageService = new EmailService()
            //    };

            // 實作 AuthenticationService 類別時, 沒有注入 IMessageService 屬性
            var authService = new AuthenticationService();

            #region 使用 authService 物件進行驗證判斷

            if (authService.TwoFactorLogin(userId, password))
            {
                if (authService.VerifyToken("123456"))
                {
                    // 登入成功。
                    Console.WriteLine("登入成功");
                    return;
                }
            }

            // 登入失敗。
            Console.WriteLine("登入失敗");

            #endregion 使用 authService 物件進行驗證判斷
        }
    }
}