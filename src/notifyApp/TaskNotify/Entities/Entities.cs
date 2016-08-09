using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class UserInfo
    {
        [DataMember(Name = "SignalRId")]
        public string SignalRId;
        [DataMember(Name = "UserCd")]
        public string UserCd;
        [DataMember(Name = "Name")]
        public string Name;
    }

    [DataContract]
    public class Notify
    {
        [DataMember(Name = "Seq")]
        public long Seq { get; set; }

        [DataMember(Name = "ToId")]
        public string ToId { get; set; }

        [DataMember(Name = "FromId")]
        public string FromId { get; set; }

        [DataMember(Name = "FromCd")]
        public string FromCd { get; set; }

        [DataMember(Name = "ToCd")]
        public string ToCd { get; set; }



        [DataMember(Name = "Message")]
        public string Message { get; set; }

        [DataMember(Name = "IsRead")]
        public bool IsRead { get; set; }
    }

    [DataContract]
    public class HubNotifyArgs
    {
        [DataContract]
        public class JoinArg
        {
            [DataMember(Name = "Cd")]
            public string Cd { get; set; }

            [DataMember(Name = "Name")]
            public string Name { get; set; }
        }
        [DataContract]
        public class SendMessageArg
        {
            [DataMember(Name = "ToCd")]
            public string ToCd { get; set; }

            [DataMember(Name = "Message")]
            public string Message { get; set; }

        }
    }
}
