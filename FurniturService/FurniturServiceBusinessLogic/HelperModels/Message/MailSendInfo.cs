using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.HelperModels.Message
{
    public class MailSendInfo
    {
        public string MailAddress { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
