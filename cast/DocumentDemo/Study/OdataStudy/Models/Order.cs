using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlxm.LH.Data
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        public int OrderID { get; set; }

        [Display(Name = "订单编号"), Required(AllowEmptyStrings = true)]
        public string OrderNo { get; set; }

        [Display(Name = "淘宝订单id")]
        public int TBOrderID { get; set; }


        [Display(Name = "预订客户")]
        public int CustomerID { get; set; }

        public bool IsPay { get; set; }
        [Display(Name = "是否已正式")]
        public bool IsConfirm { get; set; }
		/// <summary>
		/// 是否紧急订单
		/// </summary>
        [Display(Name = "是否紧急订单")]
        public bool isUrgent { get; set; }

        public int CreateUserID { get; set; }
        [Display(Name = "发起人昵称"), Required, MaxLength(200)]
        public string CreateUserNikeName { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime CreateTime { get; set; }
		/// <summary>
		/// 客户查看确认单的时间
		/// </summary>
		public DateTime CustomCheckTime { get; set; }
		/// <summary>
		/// 是否要售后
		/// </summary>
        public bool IsNeedCustomerService { get; set; }
		/// <summary>
		/// 是否已经发送确认单邮件
		/// </summary>
		public bool IsSentEmail { get; set; }
        //[Display(Name = "要售后信息")]
        //public List<CustomerService> CustomerServices { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注"), Required(AllowEmptyStrings = true), MaxLength(2000)]
        public string Remark { get; set; }
        /// <summary>
        /// 淘宝订单号
        /// </summary>
        [Display(Name = "淘宝订单号"), Required, MaxLength(100)]
        public string TBNum { get; set; }
		/// <summary>
		/// 补贴金额
		/// </summary>
		public float SubsidyAmount { get; set; }
		/// <summary>
		/// 利润调整
		/// </summary>
		public float AdjustProfit{ get; set; }

		//联系人信息
		/// <summary>
		/// 联系人中文名
		/// </summary>
		[Display(Name = "中文名"), Required(AllowEmptyStrings = true)]
        public string CustomerName { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [Display(Name = "拼音"), Required(AllowEmptyStrings = true)]
        public string CustomerEnname { get; set; }
        [Display(Name = "电话"), Required(AllowEmptyStrings = true)]
        public string Tel { get; set; }
        [Display(Name = "备用电话"), Required(AllowEmptyStrings = true)]
        public string BakTel { get; set; }
        [Display(Name = "Email"), Required(AllowEmptyStrings = true)]
        public string Email { get; set; }
        [Display(Name = "微信号"), Required(AllowEmptyStrings = true)]
        public string Wechat { get; set; }

        [Display(Name = "售后客服ID")]
        public int AfterSalesUserID { get; set; }
        [Display(Name = "售后客服Name"), MaxLength(50), Required(AllowEmptyStrings = true)]
        public string AfterSalesNickName { get; set; }
        [Display(Name = "非售后客服ID")]
        public int NotAfterSalesUserID { get; set; }
        [Display(Name = "非售后客服Name"), MaxLength(50), Required(AllowEmptyStrings = true)]
        public string NotAfterSalesNickName { get; set; }

        /// <summary>
        /// 是隐藏的
        /// </summary>
        public bool IsHide { get; set; }

        public string ReplaceHtml(string html)
        {
            html = html.Replace("#cnName#", this.CustomerName);
            html = html.Replace("#enName#", this.CustomerEnname);
            html = html.Replace("#Tel#", this.Tel);
            html = html.Replace("#BakTel#", this.BakTel);
            html = html.Replace("#Email#", this.Email);
            html = html.Replace("#Wechat#", this.Wechat);
            html = html.Replace("#Remark#", this.Remark);
            return html;
        }
    }

}
