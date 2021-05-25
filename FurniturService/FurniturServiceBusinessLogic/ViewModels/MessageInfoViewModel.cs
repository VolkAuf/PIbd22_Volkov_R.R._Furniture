using FurnitureServiceBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    [DataContract]
    public class MessageInfoViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public string MessageId { get; set; }

        [Column(title: "Отправитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Отправитель")]
        [DataMember]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 100)]
        [DisplayName("Дата письма")]
        [DataMember]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 100)]
        [DisplayName("Заголовок")]
        [DataMember]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Текст")]
        [DataMember]
        public string Body { get; set; }
    }
}
