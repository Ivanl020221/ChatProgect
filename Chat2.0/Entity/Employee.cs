using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.Entity
{
   [DataContractAttribute]
    class Employee
    {
        [DataMemberAttribute]
        public long ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public long Department_Id { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
