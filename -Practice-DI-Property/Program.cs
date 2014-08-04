using _Practice_DI_Constructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice_DI_Property
{
    class Program
    {
        static void Main(string[] args)
        {
            Login("", "");

            Console.Read();
        }

        public static void Login(string userId, string password)
        {
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
            #endregion
        }
    }
}
