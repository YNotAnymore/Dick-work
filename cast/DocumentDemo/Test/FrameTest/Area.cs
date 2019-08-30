using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestSpeed
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/29 14:19:22
    /// @source : 
    /// @des : 
    /// </summary>
    public class Area
    {

        public int AreaID { get; set; }
        [Required, MaxLength(100), Display(Name = "区域名称")]
        public string AreaName { get; set; }
        [Required, MaxLength(100), Display(Name = "区域英文名")]
        public string AreaEnName { get; set; }

        [Display(Name = "省市")]
        public int CityID { get; set; }

    }
}
