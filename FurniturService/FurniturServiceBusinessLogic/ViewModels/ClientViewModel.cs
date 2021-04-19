using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
