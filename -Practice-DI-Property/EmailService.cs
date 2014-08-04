﻿using _Practice_DI_Property;
using System;

namespace _Practice_DI_Constructor
{
    public class EmailService : IMessageService
    {
        public void Send(User user, string msg)
        {
            // 寄送電子郵件給指定的user (略)
            Console.WriteLine(" 寄送 **電子郵件** 給使用者，訊息內容：" + msg);
        }
    }
}