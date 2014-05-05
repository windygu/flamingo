using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo
{
    /// <summary>
    /// 日放映计划数据结构
    /// </summary>
    public class DailyShowPlans
    {
        public DailyPlan DailyPlan { get; set; }
        public List<Hall> HallList { get; set; }
        public List<ShowPlan> ShowPlanList { get; set; }
    }

    public class FilmModeList //: FilmMode
    {
        public int? FilmModeId { get; set; }
        public string FilmModeName { get; set; }
        public bool Value { get; set; }
    }


    /// <summary>
    /// 影片下载数据结构
    /// </summary>
    public class FilmDownloadInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public string Publisher { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Brief { get; set; }
        public bool Check { get; set; }
    }

    /// <summary>
    /// 下载设置信息数据结构
    /// </summary>
    public class DownloadSettingInfo
    {
        public int? DownloadId { get; set; }
        public string TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string SourceName { get; set; }
        public string DownloadMethod { get; set; }
        public string DownloadAddr { get; set; }
        public int? Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsAnonymAllowed { get; set; }
        public bool? IsProxy { get; set; }
        public string ProxyServer { get; set; }
        public int? ProxyPort { get; set; }
    }
    /// <summary>
    /// 票卷批次信息结构表
    /// </summary>
    public class VoucherBatchInfo
    {
        public string VoucherBatchId { get; set; }
        public string VoucherName { get; set; }
        public float? VoucherPrice { get; set; }
        public float? UnitPrice { get; set; }
        public float? TotalPrice { get; set; }
        public int? Quantity { get; set; }
        public string SerialScope { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Description { get; set; }
        public int? IssuedBy { get; set; }
        public string UserName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }
        public string TemplateId { get; set; }
        public string TemplateName { get; set; }
    }

    /// <summary>
    /// 客户信息数据结构
    /// </summary>
    public class CustomerInfo
    {
        public int? CustomerId { get; set; }
        public int? CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string Telephone { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }

    /// <summary>
    /// 欠款信息数据结构
    /// </summary>
    public class DebtInfo
    {
        public string DebtId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Buyer { get; set; }
        public DateTime? BoughtDate { get; set; }
        public int? Tickets { get; set; }
        public float? Amount { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string ChequeNumber { get; set; }
        public bool? DebtStatus { get; set; }
        public DateTime? ClearDate { get; set; }
        public int? Casher { get; set; }
        public int? Accountant { get; set; }
    }
    /// <summary>
    /// 场次信息数据结构
    /// </summary>
    public class ShowPlanInfo
    {
        public string ShowPlanId { get; set; }
        public string ShowPlanName { get; set; }
        public string HallId { get; set; }
        public bool? IsLocked { get; set; }
        public int? ShowStatus { get; set; }
        public int? FareSettingId { get; set; }
        public float? SinglePrice { get; set; }
        public float? DoublePrice { get; set; }
        public float? StudentPrice { get; set; }
        public float? GroupPrice { get; set; }
        public float? BoxPrice { get; set; }
        public float? MemberPrice { get; set; }
    }

    /// <summary>
    /// 税费信息数据结构
    /// </summary>
    public class TaxAndTheater
    {
        public int? TaxId { get; set; }
        public string TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string TaxType { get; set; }
        public float? TaxRate { get; set; }
        public string ChargeMethod { get; set; }
    }


    /// <summary>
    /// 数据上报信息数据结构
    /// </summary>
    public class UploadSettingAndTheater
    {
        public int? UploadId { get; set; }
        public string TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string TargetName { get; set; }
        public string UploadMethod { get; set; }
        public bool? IsActive { get; set; }
        public string UploadAddr { get; set; }
        public TimeSpan? UploadTime { get; set; }
        public string EmailAddr { get; set; }
    }

    /// <summary>
    /// 经营时间信息数据结构
    /// </summary>
    public class TimeSettingAndTheater
    {
        public int? TimeSettingId { get; set; }
        public string RepeatDay { get; set; }
        public string TheaterId { get; set; }
        public string TheaterName { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public int? RefundDeadline { get; set; }
        public int? TicketingDeadline { get; set; }
        public int? BookingReleaseTime { get; set; }
        public int? Timespan { get; set; }
    }


    /// <summary>
    /// 影厅信息数据结构
    /// </summary>
    public class TheaterAndHall
    {
        public string HallId { get; set; }
        public string TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string HallName { get; set; }
        public int? Seats { get; set; }
        public int? Levels { get; set; }
        public string Screen { get; set; }
        public string Projector { get; set; }
        public string PlayMode { get; set; }
        public string SoundSystem { get; set; }
        public string Description { get; set; }

    }

    /// <summary>
    /// 影片信息以及放映模式数据结构
    /// </summary>
    public class FilmAndFilmMode
    {
        public string FilmId { get; set; }
        public string FilmCode { get; set; }
        public string FilmName { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Publisher { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Brief { get; set; }
        public string Poster { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? FilmLength { get; set; }
        public float? Rent { get; set; }
        public float? Ratio { get; set; }
        public float? LowestPrice { get; set; }
        public string FilmAreaId { get; set; }
        public string FilmCategoryId { get; set; }
        public bool? HasMode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool? ActiveFlag { get; set; }
        public string ColorCode { get; set; }
        public int? Film_FilmModeId { get; set; }
        public string Film_FilmModeColorCode { get; set; }
        public int? FilmModeId { get; set; }
        public string FilmModeName { get; set; }
    }

    public class Ticket_Refund
    {
        public string ShowPlanId { get; set; }
        public int? Ticket { get; set; }
        public float? Total { get; set; }
        public int? Refund { get; set; }
        public float? Rate { get; set; }
        public int? Emity { get; set; }
    }

    public class Ticket_BaseQuery
    {
        public string ShowPlanId { get; set; }
        public float? Total { get; set; }
        public string Hall { get; set; }
        public DateTime? Date { get; set; }
    }

    public class EmployeeInfo
    {
        public int? UserId { get; set; }
        public string UserNmae { get; set; }
        public int? RoleID { get; set; }
        public int? User_RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
