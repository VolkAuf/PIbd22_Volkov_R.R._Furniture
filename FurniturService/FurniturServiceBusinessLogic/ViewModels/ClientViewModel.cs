using FurnitureServiceBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [Column(title: "Почта", width: 100)]
        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [Column(title: "Пароль", width: 100)]
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
