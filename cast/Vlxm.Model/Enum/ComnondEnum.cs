using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 所有的枚举类
/// </summary>
namespace Vlxm.Data
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum sex : byte
    {
        [Description("男")]
        Male,
        [Description("女")]
        Female
    }
    /// <summary>
    /// 订单状态（管理员|供应商）
    /// </summary>
    public enum OrderState : byte
    {
        //新增
        [Description("未填写|未填写")]
        Notfilled = 0,
        [Description("待核对|待核对")]
        Filled = 1,
        [Description("已核对|已核对")]
        Check = 2,
        [Description("已发送|新订单")]
        [SupKey("Order_State_New")]
        Send = 3,
        [Description("新单已接|新单已接")]
        [SupKey("Order_State_New_Received")]
        SendReceive = 4,
        [Description("确认待检|已确认")]
        [SupKey("Order_State_Confirmed")]
        Confirm = 5,
        [Description("已确认|已确认")]
        [SupKey("Order_State_Confirmed")]
        SencondConfirm = 6,
        [Description("拒绝待检|已拒绝")]
        [SupKey("Order_State_Rejected")]
        Full = 7,
        [Description("已拒绝|已拒绝")]
        [SupKey("Order_State_Rejected")]
        SencondFull = 8,
        //取消
        [Description("请求取消|请求取消")]
        [SupKey("Order_State_Request_Cancel")]
        RequestCancel = 9,
        [Description("取消待检|已取消")]
        [SupKey("Order_State_Canceled")]
        Cancel = 10,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消|已取消")]
        [SupKey("Order_State_Canceled")]
        SencondCancel = 11,
        //变更
        [Description("请求变更|请求变更")]
        [SupKey("Order_State_Request_Amend")]
        RequestChange = 12,
        //作废
        [Description("已作废|已作废")]
        [SupKey("I_Void")]
        Invalid = 13,
        //状态拆分
        [Description("取消已接|取消已接")]
        [SupKey("Order_State_Cancel_Received")]
        CancelReceive = 14,
        [Description("变更已接|变更已接")]
        [SupKey("Order_State_Amend_Received")]
        ChangeReceive = 15,
        [Description("无效状态|无效状态")]
        nullandvoid = 16,
    }
    /// <summary>
    /// 订单操作
    /// </summary>
    public enum OrderOperations
    {
        [Description("核对")]
        Check,
        [Description("发送")]
        Send,
        [Description("确认")]
        [ResKey("Order_Operate_Confirm")]
        Confirm,
        [Description("取消")]
        [ResKey("Order_Operate_Cancel")]
        Cancel,
        [Description("拒绝")]
        [ResKey("Order_Operate_Reject")]
        Full,
        [Description("请求取消")]
        RequestCancel,
        [Description("接单")]
        [ResKey("Order_Operate_Receive")]
        Receive,
        [Description("作废")]
        Invalid,
    }
    /// <summary>
    /// 订单操作角色（浪花朵朵or供应商）
    /// </summary>
    public enum OrderOperator : byte
    {
        [Description("浪花朵朵")]
        inside,
        [Description("供应商")]
        supplier,
    }
    /// <summary>
    ///  订单状态（客户）
    /// </summary>
    public enum OrderCustomerState : byte
    {
        [Description("未填写")]
        Notfilled = 0,
        [Description("已拒绝")]
        SencondFull = 10,
        [Description("待核对")]
        Filled = 20,
        [Description("已核对")]
        Check = 30,
        [Description("预定中")]
        Ordering = 40,
        [Description("变更中")]
        Changeing = 50,
        [Description("取消中")]
        Canceling = 60,
        [Description("已确认")]
        SencondConfirm = 70,
        [Description("已取消")]
        SencondCancel = 80,
    }
    /// <summary>
    /// 价格结算方式
    /// </summary>
    public enum PricingMethod : byte
    {
		/// <summary>
		/// 按游客人头数
		/// </summary>
		[Description("按游客人头数（例如一日游,门票）")]
        ByPerson,
		/// <summary>
		/// 按产品数量
		/// </summary>
		[Description("按产品数量（例如酒店,包车）")]
        other
    }
    /// <summary>
    /// 结算状态
    /// </summary>
    public enum StatusAccounting : byte
    {
        /// <summary>
        /// 未结算
        /// </summary>
        [Description("未结算")]
        Not = 0,
        /// <summary>
        /// 结算中
        /// </summary>
        [Description("结算中")]
        In = 1,
        /// <summary>
        /// 已结算
        /// </summary>
        [Description("已结算")]
        Finish = 2,
    }
    /// <summary>
    /// 状态
    /// </summary>
    public enum EnableState : byte
    {
        [Description("启用")]
        Enable,
        [Description("禁用")]
        Disable
    }
    /// <summary>
    /// 兑换方式
    /// </summary>
    public enum ChangeType : byte
    {
        /// <summary>
        /// 人民币-外币
        /// </summary>
        [Description("人民币-外币")]
        FromChina,
        /// <summary>
        /// 外币-人民币
        /// </summary>
        [Description("外币-人民币")]
        ToChina
    }
	/// <summary>
	/// 生效方式（账单报表）
	/// </summary>
	public enum EffectiveWay : byte
	{
		[Description("按下单日期")]
		ByCreateTime,
		[Description("按出行日期")]
		BySendTime
	}
	/// <summary>
	/// 规则类型
	/// </summary>
	public enum RuleType : byte
    {
        /// <summary>
        /// 日期范围
        /// </summary>
        [Description("日期范围")]
        ByDateRange,
        /// <summary>
        /// 星期选择
        /// </summary>
        [Description("星期选择")]
        ByWeek,
        /// <summary>
        /// 单双选择
        /// </summary>
        [Description("单双选择")]
        ByDouble,
        /// <summary>
        /// 固定日期
        /// </summary>
        [Description("固定日期")]
        ByDate
    }
    //规则使用状态
    public enum RuleUseType : byte
    {
        [Description("允许")]
        Allow,
        [Description("禁止")]
        Prohibit
    }
    /// <summary>
    /// 跟进方式
    /// </summary>
    public enum BackType : byte
    {
        [Description("电话")]
        ByPhone,
        [Description("旺旺")]
        ByWangwang,
        [Description("微信")]
        ByWeixing,
        [Description("QQ")]
        ByQQ,
        [Description("当面")]
        ByMeet,
        [Description("其他")]
        ByOther

    }
    /// <summary>
    /// 订单导出字段
    /// </summary>
    public enum ExportField
    {
        [Description("订单号")]
        [ResKey("O_Order_No")]
        OrderNo,
        [Description("淘宝订单号")]
        TBOrderNo,
        [Description("用户ID")]
        TBID,
        [Description("中文姓名")]
        [ResKey("O_Guest_Chinese_Name")]
        cnName,
        [Description("英文姓名")]
        [ResKey("O_Guest_English_Name")]
        enName,
        [Description("订单来源")]
        OrderSourse,
        [Description("联系电话")]
        [ResKey("O_Contact")]
        Tel,
        [Description("备用联系电话")]
        [ResKey("O_Contact2")]
        BakTel,
        [Description("供应商")]
        SupplierCode,
        [Description("预定项目")]
        [ResKey("O_Service_Package")]
        cnItemName,
        [Description("产品编码")]
        [ResKey("O_Product_Code")]
        ServiceCode,
        [Description("成人人数")]
        [ResKey("O_Adult")]
        AdultNum,
        [Description("儿童人数")]
        [ResKey("O_Child")]
        ChildNum,
        [Description("婴儿人数")]
        [ResKey("O_Infant")]
        INFNum,
        [Description("间数")]
        RoomNum,
        [Description("晚数")]
        NightNum,
        [Description("出行日期")]
        [ResKey("O_Service_Date")]
        TravelDate,
        [Description("订单状态")]
        [ResKey("O_Order_Status")]
        OrderState,
        [Description("团号")]
        [ResKey("O_Voucher_No")]
        GroupNo,
        [Description("备注")]
        [ResKey("O_Remark")]
        Remark,
        [Description("订单创建人")]
        CreateUserNikeName,
        [Description("微信号")]
        //[ResKey("O_WeChat")]
        Wechat,
        //[Description("手机号")]
        //Tel,
        [Description("目的地")]
        CityName,
        [Description("产品类型")]
        [ResKey("O_Product_Type")]
        ServiceTypeName,
        [Description("所有附加项目")]
        [ResKey("O_All_Attached_Items")]
        ExtraServices,
    }
    /// <summary>
    /// 转账类型
    /// </summary>
    public enum TransferType : byte
    {
        [Description("线下退款")]
        DifferenceReturn,
        [Description("售后赔偿")]
        Compensation,
        [Description("好评返现")]
        ReturnMoney,
        [Description("给优惠")]
        GiveDiscounts,
    }
    /// <summary>
    /// 支付宝转账操作类型
    /// </summary>
    public enum TransferOperate : byte
    {
        [Description("新增")]
        Add,
        [Description("修改")]
        Edit,
        [Description("核实")]
        Check,
        [Description("转账")]
        Transfer,
        [Description("备注")]
        Remark,
        [Description("作废")]
        Delete,
    }
    //转账状态
    public enum TransferState : byte
    {
        [Description("待核实")]
        New,
        [Description("待转账")]
        Check,
        /// <summary>
        /// 已转账
        /// </summary>
        [Description("已转账")]
        Transfer,
        /// <summary>
        /// 已作废
        /// </summary>
        [Description("已作废")]
        IsDelete
    }
    //对账状态
    public enum CheckState : byte
    {
        [Description("待对账")]
        [ResKey("I_Wait_To_Confirm")]
        New,
        [Description("待支付")]
        [ResKey("I_Wait_To_Pay")]
        Check,
        [Description("已支付")]
        [ResKey("I_Paid")]
        Transfer,
        [Description("已作废")]
        [ResKey("I_Void")]
        IsDelete
    }
    //供应商价格维护状态
    public enum SupplierPriceState : byte
    {
        [Description("√")]
        Seted,
        [Description("未设置")]
        NotSeted,
        [Description("已过期")]
        Expired,
        [Description("一周内过期")]
        OneWeekExpired,
        [Description("两周内过期")]
        TwoWeekExpired,
        [Description("一个月内过期")]
        OneMonthExpired
    }
    /// <summary>
    /// 用户操作
    /// </summary>
    public enum UserOperate : byte
    {
        [Description("新增")]
        Add,
        [Description("修改")]
        Edit,
        [Description("删除")]
        Delete,
        [Description("禁用")]
        Disable,
        [Description("启用")]
        Enable,
        [Description("重置密码")]
        ResetPassWord,
        [Description("登录")]
        Login,
        [Description("解绑微信")]
        UnbindWeixin
    }
    /// <summary>
    /// 模块
    /// </summary>
    public enum Modular : byte
    {
        [Description("工作台")]
        WorkTable,
        [Description("订单")]
        Order,
        [Description("客户")]
        Customer,
        [Description("产品")]
        Product,
        [Description("系统")]
        System
    }
    /// <summary>
    /// 二维码使用场景
    /// </summary>
    public enum QRcode : byte
    {
        [Description("其他")]
        Other,
        [Description("确认单")]
        Voucher,
        [Description("电子邮件")]
        Email,
        [Description("衣服")]
        Clothes,
        [Description("旅行中")]
        Trip
    }
    public enum SellControlModelState : byte
    {
        [Description("人数为0")]
        While,
        [Description("人数大于0")]
        Green,
        [Description("确认加上预扣大于0")]
        Yellow,
        [Description("人数超过控位数")]
        Red,
        [Description("规则禁止")]
        Gray,
    }
    /// <summary>
    /// 供应商扣款来源
    /// </summary>
    public enum DeductMoneySource : byte
    {
        /// <summary>
        /// 手动新增
        /// </summary>
        [Description("手动新增")]
        Manual = 0,
        [Description("支付宝转账")]
        AlipayTransfer = 1,
        /// <summary>
        /// 请求变更
        /// </summary>
        [Description("请求变更")]
        Change = 2,
        /// <summary>
        /// 请求取消
        /// </summary>
        [Description("请求取消")]
        Cancel = 3,
        [Description("红字冲抵")]
        Offset = 4,
    }
    /// <summary>
    /// 接口类型
    /// </summary>
    public enum InterfaceType
    {
        [Description("度假类")]
        HolidayType = 1,
    }

    public class EnumHelper
    {
        public static string GetEnumDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            DescriptionAttribute da = (DescriptionAttribute)objs[0];
            return da.Description;
        }
		public static string ToPinyinInitials(TransferType value)
		{
			switch (value)
			{
				case TransferType.DifferenceReturn: return "XXTK";
				case TransferType.Compensation: return "SHPC";
				case TransferType.ReturnMoney: return "HPFX";
				case TransferType.GiveDiscounts: return "GYH";
			}
			throw new ArgumentOutOfRangeException("未定义拼音缩写");
		}
    }
    public class EnumHelper<TAttr> where TAttr : AttributeBase
    {
        public static string GetEnumText<T>(T en) where T : struct
        {
            //if (null == en) return string.Empty;
            var objs = en.GetType().GetField(en.ToString())?.GetCustomAttributes(typeof(TAttr), false);
            if (objs == null || objs.Length == 0) return string.Empty;
            var attr = (TAttr)objs[0];
            return attr.Value;
        }
    }
    public abstract class AttributeBase : Attribute
    {
        public string Value;
    }
    public class SupKeyAttribute : AttributeBase
    {
        public SupKeyAttribute(string v)
        {
            this.Value = v;
        }
    }
    public class ResKeyAttribute : AttributeBase
    {
        public ResKeyAttribute(string v)
        {
            this.Value = v;
        }
    }
}
