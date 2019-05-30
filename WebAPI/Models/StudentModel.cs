using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class StudentModel : UserModel
    {
        public ClusterModel Cluster { get; set; }
    }
}
