using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftGameService.Model
{
    public class ActiveUserModel
    {
        [DataMember]
        public int ActiveUserId { get; set; }

        [DataMember]
        public string ActiveUserName { get; set; }
    }
}