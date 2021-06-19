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
        [Column(title: "Номер", width: 50)]
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [Column(title: "Почта", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
