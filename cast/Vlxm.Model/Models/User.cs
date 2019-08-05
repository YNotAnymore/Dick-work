using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vlxm.Model.Models;

namespace Vlxm.Model.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }
}



