using _Practice_DI_Property;
using System;

namespace _Practice_DI_Constructor
{
    public class AuthenticationService
    {
        // Property Injection
        private IMessageService msgService;        

        #region 如果上層沒有設定 MessageService 屬性呢? _1
        /*
         * 為避免用戶端, 實作 AuthenticationService 物件, 卻沒有設定屬性, 而發生 NullReferenceExceptio
         * 1. 類別本身提供預設實作
         * 2. 撰寫 null 檢查邏輯
        */

        // 1. 類別本身提供預設實作
        internal IMessageService MessageService
        {
            get
            {
                if (this.msgService == null)
                {
                    this.msgService = new EmailService();// EmailService or ShortMessageService      
                }

                return this.msgService;
            }

            set { this.msgService = value; }
        }
        #endregion

        public AuthenticationService()
        {
        }

        #region 驗證的副程式

        public bool TwoFactorLogin(string userId, string pwd)
        {
            // 檢查帳號密碼，若正確，則傳回一個包含使用者資訊的物件。
            User user = CheckPassword(userId, pwd);
            if (user != null)
            {
                #region 如果用戶端() 沒有設定 MessageService 屬性呢? _2
                //// 2. 撰寫 null 檢查邏輯
                if (MessageService == null)
                {
                    Console.WriteLine("未設定 MessageService 屬性");
                    return false;
                }
                #endregion

                // 接著發送驗證碼給使用者，假設隨機產生的驗證碼為"123456"。
                MessageService.Send(user, " 您的登入驗證碼為 123456");
                return true;
            }

            return false;
        }

        public bool VerifyToken(string verifyToken)
        {
            if (verifyToken == "123456")
            {
                return true;
            }

            return false;
        }

        private User CheckPassword(string userId, string pwd)
        {
            if (true)
            {
                return new User();
            }
        }

        #endregion 驗證的副程式
    }
}