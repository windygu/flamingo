using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class Permissions
    {
        #region Other
    
        public static Permission Null
        {
            get
            {
                Permission p = new Permission();
                p.Module = null;
                p.PermissionId = -1;
                p.PermissionName = "";
                return p;
            }
        }

        #endregion

        #region 放映计划

        public static Permission Schedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.SchedulesId;
                p.PermissionName = "放映计划";
                return p;
            }
        }

        public static Permission ViewSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.ViewSchedulesId;
                p.PermissionName = "查看放映计划";
                return p;
            }
        }

        public static Permission AddSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.AddSchedulesId;
                p.PermissionName = "新建放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission EditSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.EditSchedulesId;
                p.PermissionName = "编辑放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission CopySchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.CopySchedulesId;
                p.PermissionName = "复制放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission SaveSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.SaveSchedulesId;
                p.PermissionName = "保存放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission DeleteSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.DeleteSchedulesId;
                p.PermissionName = "删除放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission PrintSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.PrintSchedulesId;
                p.PermissionName = "打印放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission ReleaseSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.ReleaseSchedulesId;
                p.PermissionName = "开售放映计划";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission FixedPriceSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.FixedPriceSchedulesId;
                p.PermissionName = "票价设置";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission SetFilmSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.SetFilmSchedulesId;
                p.PermissionName = "影片设置";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission QuickSearchSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.QuickSearchSchedulesId;
                p.PermissionName = "快速查询";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        public static Permission BasicSearchSchedules
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Schedules;
                p.PermissionId = PermissionIds.BasicSearchSchedulesId;
                p.PermissionName = "基本查询";
                p.ParentPermissionId = PermissionIds.ViewSchedulesId;
                return p;
            }
        }

        #endregion

        #region 影院售票

        public static Permission TicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.TicketSellingId;
                p.PermissionName = "影院售票";
                return p;
            }
        }

        public static Permission RetailTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.RetailTicketSellingId;
                p.PermissionName = "零售票";
                return p;
            }
        }

        public static Permission StudentsTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.StudentsTicketSellingId;
                p.PermissionName = "学生票";
                return p;
            }
        }

        public static Permission GroupTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.GroupTicketSellingId;
                p.PermissionName = "团体票";
                return p;
            }
        }

        public static Permission DiscountTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.DiscountTicketSellingId;
                p.PermissionName = "特价票";
                return p;
            }
        }

        public static Permission CashTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.CashTicketSellingId;
                p.PermissionName = "现金";
                return p;
            }
        }

        public static Permission ChequeTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.ChequeTicketSellingId;
                p.PermissionName = "支票";
                return p;
            }
        }

        public static Permission DiscountVoucherSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.DiscountVoucherSellingId;
                p.PermissionName = "优惠券";
                return p;
            }
        }

        public static Permission ExchangeVoucherSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.ExchangeVoucherSellingId;
                p.PermissionName = "兑换券";
                return p;
            }
        }

        public static Permission SubstituteVoucherSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.SubstituteVoucherSellingId;
                p.PermissionName = "代用券";
                return p;
            }
        }

        public static Permission MembercardTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.MembercardTicketSellingId;
                p.PermissionName = "会员卡";
                return p;
            }
        }

        public static Permission MembercardPayTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.MembercardPayTicketSellingId;
                p.PermissionName = "会员卡支付卡";
                return p;
            }
        }

        public static Permission CreditTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.CreditTicketSellingId;
                p.PermissionName = "积分";
                return p;
            }
        }

        public static Permission FreeTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.FreeTicketSellingId;
                p.PermissionName = "赠票";
                return p;
            }
        }

        public static Permission SaleTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.SaleTicketSellingId;
                p.PermissionName = "售票";
                return p;
            }
        }

        public static Permission BookTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.BookTicketSellingId;
                p.PermissionName = "预订";
                return p;
            }
        }

        public static Permission BookSaleTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.BookSaleTicketSellingId;
                p.PermissionName = "预定出票";
                return p;
            }
        }

        public static Permission BookReleaseTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.BookReleaseTicketSellingId;
                p.PermissionName = "解除预订";
                return p;
            }
        }

        public static Permission BookSearchTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.BookSearchTicketSellingId;
                p.PermissionName = "预订查询";
                return p;
            }
        }

        public static Permission LockTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.LockTicketSellingId;
                p.PermissionName = "锁定";
                return p;
            }
        }

        public static Permission UnLockTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.UnLockTicketSellingId;
                p.PermissionName = "解除锁定";
                return p;
            }
        }

        public static Permission RefundTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.RefundTicketSellingId;
                p.PermissionName = "单张退票";
                return p;
            }
        }

        public static Permission BatchRefundTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.BatchRefundTicketSellingId;
                p.PermissionName = "批量退票";
                return p;
            }
        }

        public static Permission SettingTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.SettingTicketSellingId;
                p.PermissionName = "售票设置";
                return p;
            }
        }

        public static Permission MagnifyTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.MagnifyTicketSellingId;
                p.PermissionName = "放大";
                return p;
            }
        }

        public static Permission RestoreTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.RestoreTicketSellingId;
                p.PermissionName = "还原";
                return p;
            }
        }

        public static Permission RotationSettingTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.RotationSettingTicketSellingId;
                p.PermissionName = "旋转设置";
                return p;
            }
        }

        public static Permission BgColorSettingTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.BgColorSettingTicketSellingId;
                p.PermissionName = "背景色设置";
                return p;
            }
        }

        public static Permission CutTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.CutTicketSellingId;
                p.PermissionName = "切票设置";
                return p;
            }
        }

        public static Permission ValidationTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.ValidationTicketSellingId;
                p.PermissionName = "验票";
                return p;
            }
        }

        public static Permission SearchTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.SearchTicketSellingId;
                p.PermissionName = "售票查询";
                return p;
            }
        }

        public static Permission FillupTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.FillupTicketSellingId;
                p.PermissionName = "人工补登";
                return p;
            }
        }

        public static Permission RePrintTicketSelling
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TicketSelling;
                p.PermissionId = PermissionIds.RePrintTicketSellingId;
                p.PermissionName = "补打";
                return p;
            }
        }

        #endregion

        #region 统计分析

        public static Permission Report
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.ReportId;
                p.PermissionName = "统计分析";
                return p;
            }
        }
        public static Permission StatisticsReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.StatisticsReportId;
                p.PermissionName = "统计报表";
                return p;
            }
        }
        public static Permission BusinessReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.BusinessReportId;
                p.PermissionName = "经营报表";
                return p;
            }
        }
        public static Permission BasicQueryReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.BasicQueryReportId;
                p.PermissionName = "基础查询";
                return p;
            }
        }
        public static Permission CombinedQueryReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.CombinedQueryReportId;
                p.PermissionName = "组合查询";
                return p;
            }
        }
        public static Permission TotalReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.TotalReportId;
                p.PermissionName = "综合报表";
                return p;
            }
        }
        public static Permission GraphicReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.GraphicReportId;
                p.PermissionName = "图形分析";
                return p;
            }
        }
        public static Permission TicketReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.TicketReportId;
                p.PermissionName = "中影专用报表";
                return p;
            }
        }
        public static Permission CommonReport
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.Report;
                p.PermissionId = PermissionIds.CommonReportId;
                p.PermissionName = "常用报表";
                return p;
            }
        }
        #endregion

        #region 影院信息管理

        public static Permission TheaterManage
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.TheaterManageId;
                p.PermissionName = "影院信息管理";
                return p;
            }
        }

        public static Permission TheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.TheaterInformationId;
                p.PermissionName = "影院信息维护";
                return p;
            }
        }

        public static Permission HallTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.HallTheaterInformationId;
                p.PermissionName = "影厅信息维护";
                return p;
            }
        }

        public static Permission AuthorizationTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.AuthorizationTheaterInformationId;
                p.PermissionName = "授权管理";
                return p;
            }
        }

        public static Permission TaxTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.TaxTheaterInformationId;
                p.PermissionName = "税费维护";
                return p;
            }
        }

        public static Permission UploadSettingTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.UploadSettingTheaterInformationId;
                p.PermissionName = "上报单位维护";
                return p;
            }
        }

        public static Permission DataReportTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.DataReportTheaterInformationId;
                p.PermissionName = "数据上报";
                return p;
            }
        }

        public static Permission TimeSettingTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.TimeSettingTheaterInformationId;
                p.PermissionName = "经营时间维护";
                return p;
            }
        }

        public static Permission ShowtypeTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.ShowtypeTheaterInformationId;
                p.PermissionName = "场次类型维护";
                return p;
            }
        }

        public static Permission PriceTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.PriceTheaterInformationId;
                p.PermissionName = "票价维护";
                return p;
            }
        }

        public static Permission DiscountTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.DiscountTheaterInformationId;
                p.PermissionName = "特价维护";
                return p;
            }
        }

        public static Permission BackupTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.BackupTheaterInformationId;
                p.PermissionName = "系统备份";
                return p;
            }
        }

        public static Permission RestoreTheaterInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TheaterInformation;
                p.PermissionId = PermissionIds.RestoreTheaterInformationId;
                p.PermissionName = "系统恢复";
                return p;
            }
        }

        #endregion

        #region 影片信息

        public static Permission FilmManage
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.FilmManageId;
                p.PermissionName = "影片信息管理";
                return p;
            }
        }

        public static Permission FilmInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.FilmInformationId;
                p.PermissionName = "影片信息维护";
                return p;
            }
        }

        public static Permission AreaFilmInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.AreaFilmInformationId;
                p.PermissionName = "影片产地维护";
                return p;
            }
        }

        public static Permission CategoryFilmInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.CategoryFilmInformationId;
                p.PermissionName = "影片类型维护";
                return p;
            }
        }

        public static Permission DownloadSettingFilmInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.DownloadSettingFilmInformationId;
                p.PermissionName = "影片下载地址维护";
                return p;
            }
        }

        public static Permission DownloadFilmInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.DownloadFilmInformationId;
                p.PermissionName = "影片下载";
                return p;
            }
        }

        public static Permission PlayModeFilmInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.FilmInformation;
                p.PermissionId = PermissionIds.PlayModeFilmInformationId;
                p.PermissionName = "放映模式维护";
                return p;
            }
        }

        #endregion

        #region 票券管理

        public static Permission VoucherManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.VoucherManagerId;
                p.PermissionName = "票券管理";
                return p;
            }
        }

        public static Permission CustomerManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.CustomerManagerId;
                p.PermissionName = "客户信息维护";
                return p;
            }
        }

        public static Permission CustomerTypeManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.CustomerTypeManagerId;
                p.PermissionName = "客户类型维护";
                return p;
            }
        }

        public static Permission DebtManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.DebtManagerId;
                p.PermissionName = "欠款维护";
                return p;
            }
        }

        public static Permission VoucherBatchManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.VoucherBatchManagerId;
                p.PermissionName = "票券批次维护";
                return p;
            }
        }

        public static Permission VoucherTypeManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.VoucherTypeManagerId;
                p.PermissionName = "票券类型维护";
                return p;
            }
        }

        public static Permission VoucherSubTypeManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.VoucherSubTypeManagerId;
                p.PermissionName = "票券券类维护";
                return p;
            }
        }

        public static Permission VoucherReportManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.VoucherManager;
                p.PermissionId = PermissionIds.VoucherReportManagerId;
                p.PermissionName = "票券查询统计";
                return p;
            }
        }

        #endregion

        #region 座位图

        public static Permission SeatingChat
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.SeatingChat;
                p.PermissionId = PermissionIds.SeatingChatId;
                p.PermissionName = "座位图工具";
                return p;
            }
        }

        public static Permission ImportSeatingChat
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.SeatingChat;
                p.PermissionId = PermissionIds.ImportSeatingChatId;
                p.PermissionName = "座位图导入";
                return p;
            }
        }

        public static Permission BlockSeatingChat
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.SeatingChat;
                p.PermissionId = PermissionIds.BlockSeatingChatId;
                p.PermissionName = "区域编辑";
                return p;
            }
        }

        public static Permission EditStateSeatingChat
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.SeatingChat;
                p.PermissionId = PermissionIds.EditStateSeatingChatId;
                p.PermissionName = "座位类型编辑";
                return p;
            }
        }

        #endregion

        #region 票版管理

        public static Permission TemplateManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TemplateManager;
                p.PermissionId = PermissionIds.TemplateManagerId;
                p.PermissionName = "票版管理";
                return p;
            }
        }

        public static Permission CreateTemplateManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TemplateManager;
                p.PermissionId = PermissionIds.CreateTemplateManagerId;
                p.PermissionName = "新建票版";
                return p;
            }
        }

        public static Permission EditTemplateManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TemplateManager;
                p.PermissionId = PermissionIds.EditTemplateManagerId;
                p.PermissionName = "编辑票版";
                return p;
            }
        }

        public static Permission DeleteTemplateManager
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.TemplateManager;
                p.PermissionId = PermissionIds.DeleteTemplateManagerId;
                p.PermissionName = "删除票版";
                return p;
            }
        }

        #endregion

        #region 员工管理

        public static Permission EmployeeInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.EmployeeInformation;
                p.PermissionId = PermissionIds.EmployeeInformationId;
                p.PermissionName = "用户管理";
                return p;
            }
        }

        public static Permission UserInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.EmployeeInformation;
                p.PermissionId = PermissionIds.UserInformationId;
                p.PermissionName = "本人信息维护";
                return p;
            }
        }

        public static Permission BasicInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.EmployeeInformation;
                p.PermissionId = PermissionIds.BasicInformationId;
                p.PermissionName = "基本信息维护";
                return p;
            }
        }

        public static Permission RolePermissionInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.EmployeeInformation;
                p.PermissionId = PermissionIds.RolePermissionInformationId;
                p.PermissionName = "角色权限维护";
                return p;
            }
        }

        public static Permission RoleUserInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.EmployeeInformation;
                p.PermissionId = PermissionIds.RoleUserInformationId;
                p.PermissionName = "角色用户维护";
                return p;
            }
        }

        public static Permission UserPermissionInformation
        {
            get
            {
                Permission p = new Permission();
                p.Module = Modules.EmployeeInformation;
                p.PermissionId = PermissionIds.UserPermissionInformationId;
                p.PermissionName = "用户权限维护";
                return p;
            }
        }

        #endregion

        public static Permission GetPermissionById(int id)
        {
            #region 放映计划

            if (id == PermissionIds.SchedulesId)
            {
                return Schedules;
            }
            if (id == PermissionIds.ViewSchedulesId)
            {
                return ViewSchedules;
            }
            if (id == PermissionIds.AddSchedulesId)
            {
                return AddSchedules;
            }
            if (id == PermissionIds.EditSchedulesId)
            {
                return EditSchedules;
            }
            if (id == PermissionIds.CopySchedulesId)
            {
                return CopySchedules;
            }
            if (id == PermissionIds.SaveSchedulesId)
            {
                return SaveSchedules;
            }
            if (id == PermissionIds.DeleteSchedulesId)
            {
                return DeleteSchedules;
            }
            if (id == PermissionIds.PrintSchedulesId)
            {
                return PrintSchedules;
            }
            if (id == PermissionIds.ReleaseSchedulesId)
            {
                return ReleaseSchedules;
            }
            if (id == PermissionIds.FixedPriceSchedulesId)
            {
                return FixedPriceSchedules;
            }
            if (id == PermissionIds.SetFilmSchedulesId)
            {
                return SetFilmSchedules;
            }
            if (id == PermissionIds.QuickSearchSchedulesId)
            {
                return QuickSearchSchedules;
            }
            if (id == PermissionIds.BasicSearchSchedulesId)
            {
                return BasicSearchSchedules;
            }

            #endregion

            #region 影院售票


            if (id == PermissionIds.TicketSellingId)
            {
                return TicketSelling;
            }
            if (id == PermissionIds.RetailTicketSellingId)
            {
                return RetailTicketSelling;
            }
            if (id == PermissionIds.StudentsTicketSellingId)
            {
                return StudentsTicketSelling;
            }
            if (id == PermissionIds.GroupTicketSellingId)
            {
                return GroupTicketSelling;
            }
            if (id == PermissionIds.DiscountTicketSellingId)
            {
                return DiscountTicketSelling;
            }
            if (id == PermissionIds.CashTicketSellingId)
            {
                return CashTicketSelling;
            }
            if (id == PermissionIds.ChequeTicketSellingId)
            {
                return ChequeTicketSelling;
            }
            if (id == PermissionIds.DiscountVoucherSellingId)
            {
                return DiscountVoucherSelling;
            }
            if (id == PermissionIds.ExchangeVoucherSellingId)
            {
                return ExchangeVoucherSelling;
            }
            if (id == PermissionIds.SubstituteVoucherSellingId)
            {
                return SubstituteVoucherSelling;
            }
            if (id == PermissionIds.MembercardTicketSellingId)
            {
                return MembercardTicketSelling;
            }
            if (id == PermissionIds.MembercardPayTicketSellingId)
            {
                return MembercardPayTicketSelling;
            }
            if (id == PermissionIds.CreditTicketSellingId)
            {
                return CreditTicketSelling;
            }
            if (id == PermissionIds.FreeTicketSellingId)
            {
                return FreeTicketSelling;
            }

            if (id == PermissionIds.SaleTicketSellingId)
            {
                return SaleTicketSelling;
            }
            if (id == PermissionIds.BookTicketSellingId)
            {
                return BookTicketSelling;
            }
            if (id == PermissionIds.BookSaleTicketSellingId)
            {
                return BookSaleTicketSelling;
            }
            if (id == PermissionIds.BookReleaseTicketSellingId)
            {
                return BookReleaseTicketSelling;
            }
            if (id == PermissionIds.BookSearchTicketSellingId) 
            {
                return BookSearchTicketSelling;
            }
            if (id == PermissionIds.LockTicketSellingId)
            {
                return LockTicketSelling;
            }
            if (id == PermissionIds.UnLockTicketSellingId)
            {
                return UnLockTicketSelling;
            }
            if (id == PermissionIds.RefundTicketSellingId)
            {
                return RefundTicketSelling;
            }
            if (id == PermissionIds.BatchRefundTicketSellingId)
            {
                return BatchRefundTicketSelling;
            }

            if (id == PermissionIds.SettingTicketSellingId)
            {
                return SettingTicketSelling;
            }
            if (id == PermissionIds.MagnifyTicketSellingId)
            {
                return MagnifyTicketSelling;
            }
            if (id == PermissionIds.RestoreTicketSellingId)
            {
                return RestoreTicketSelling;
            }
            if (id == PermissionIds.RotationSettingTicketSellingId)
            {
                return RotationSettingTicketSelling;
            }
            if (id == PermissionIds.BgColorSettingTicketSellingId)
            {
                return BgColorSettingTicketSelling;
            }
            if (id == PermissionIds.CutTicketSellingId)
            {
                return CutTicketSelling;
            }
            if (id == PermissionIds.ValidationTicketSellingId)
            {
                return ValidationTicketSelling;
            }
            if (id == PermissionIds.SearchTicketSellingId)
            {
                return SearchTicketSelling;
            }
            if (id == PermissionIds.FillupTicketSellingId)
            {
                return FillupTicketSelling;
            }
            if (id == PermissionIds.RePrintTicketSellingId)
            {
                return RePrintTicketSelling;
            }

            #endregion

            #region 报表分析

            if (id == PermissionIds.ReportId)
            {
                return Report;
            }
            if (id == PermissionIds.StatisticsReportId)
            {
                return StatisticsReport;
            }
            if (id == PermissionIds.BusinessReportId)
            {
                return BusinessReport;
            }
            if (id == PermissionIds.BasicQueryReportId)
            {
                return BasicQueryReport;
            }
            if (id == PermissionIds.CombinedQueryReportId)
            {
                return CombinedQueryReport;
            }
            if (id == PermissionIds.TotalReportId)
            {
                return TotalReport;
            }
            if (id == PermissionIds.GraphicReportId)
            {
                return GraphicReport;
            }
            if (id == PermissionIds.TicketReportId)
            {
                return TicketReport;
            }
            if (id == PermissionIds.CommonReportId)
            {
                return CommonReport;
            }
            #endregion

            #region 影院信息

            if (id == PermissionIds.TheaterManageId)
            {
                return TheaterManage;
            }

            if (id == PermissionIds.TheaterInformationId)
            {
                return TheaterInformation;
            }

            if (id == PermissionIds.HallTheaterInformationId)
            {
                return HallTheaterInformation;
            }

            if (id == PermissionIds.AuthorizationTheaterInformationId)
            {
                return AuthorizationTheaterInformation;
            }

            if (id == PermissionIds.TaxTheaterInformationId)
            {
                return TaxTheaterInformation;
            }

            if (id == PermissionIds.DataReportTheaterInformationId)
            {
                return DataReportTheaterInformation;
            }

            if (id == PermissionIds.UploadSettingTheaterInformationId)
            {
                return UploadSettingTheaterInformation;
            }

            if (id == PermissionIds.TimeSettingTheaterInformationId)
            {
                return TimeSettingTheaterInformation;
            }

            if (id == PermissionIds.PriceTheaterInformationId)
            {
                return PriceTheaterInformation;
            }

            if (id == PermissionIds.ShowtypeTheaterInformationId)
            {
                return ShowtypeTheaterInformation;
            }

            if (id == PermissionIds.DiscountTheaterInformationId)
            {
                return DiscountTheaterInformation;
            }

            if (id == PermissionIds.RestoreTheaterInformationId)
            {
                return RestoreTheaterInformation;
            }

            if (id == PermissionIds.BackupTheaterInformationId)
            {
                return BackupTheaterInformation;
            }

            #endregion

            #region 影片信息

            if (id == PermissionIds.FilmManageId)
            {
                return FilmManage;
            }

            if (id == PermissionIds.FilmInformationId)
            {
                return FilmInformation;
            }

            if (id == PermissionIds.AreaFilmInformationId)
            {
                return AreaFilmInformation;
            }

            if (id == PermissionIds.CategoryFilmInformationId)
            {
                return CategoryFilmInformation;
            }

            if (id == PermissionIds.DownloadSettingFilmInformationId)
            {
                return DownloadSettingFilmInformation;
            }

            if (id == PermissionIds.DownloadFilmInformationId)
            {
                return DownloadFilmInformation;
            }

            if (id == PermissionIds.PlayModeFilmInformationId)
            {
                return PlayModeFilmInformation;
            }

            #endregion

            #region 票券管理

            if (id == PermissionIds.VoucherManagerId)
            {
                return VoucherManager;
            }

            if (id == PermissionIds.CustomerManagerId)
            {
                return CustomerManager;
            }

            if (id == PermissionIds.CustomerTypeManagerId)
            {
                return CustomerTypeManager;
            }

            if (id == PermissionIds.DebtManagerId)
            {
                return DebtManager;
            }

            if (id == PermissionIds.VoucherBatchManagerId)
            {
                return VoucherBatchManager;
            }

            if (id == PermissionIds.VoucherBatchManagerId)
            {
                return VoucherBatchManager;
            }

            if (id == PermissionIds.VoucherTypeManagerId)
            {
                return VoucherTypeManager;
            }

            if (id == PermissionIds.VoucherSubTypeManagerId)
            {
                return VoucherSubTypeManager;
            }

            if (id == PermissionIds.VoucherReportManagerId)
            {
                return VoucherReportManager;
            }

            #endregion

            #region 座位图

            if (id == PermissionIds.SeatingChatId)
            {
                return SeatingChat;
            }

            if (id == PermissionIds.ImportSeatingChatId)
            {
                return ImportSeatingChat;
            }

            if (id == PermissionIds.BlockSeatingChatId)
            {
                return BlockSeatingChat;
            }

            if (id == PermissionIds.EditStateSeatingChatId)
            {
                return EditStateSeatingChat;
            }

            #endregion

            #region 票版管理

            if (id == PermissionIds.TemplateManagerId)
            {
                return TemplateManager;
            }

            if (id == PermissionIds.CreateTemplateManagerId)
            {
                return CreateTemplateManager;
            }

            if (id == PermissionIds.EditTemplateManagerId)
            {
                return EditTemplateManager;
            }

            if (id == PermissionIds.DeleteTemplateManagerId)
            {
                return DeleteTemplateManager;
            }

            #endregion

            #region 员工管理

            if (id == PermissionIds.EmployeeInformationId)
            {
                return EmployeeInformation;
            }

            if (id == PermissionIds.UserInformationId)
            {
                return UserInformation;
            }

            if (id == PermissionIds.BasicInformationId)
            {
                return BasicInformation;
            }

            if (id == PermissionIds.RoleUserInformationId)
            {
                return RoleUserInformation;
            }

            if (id == PermissionIds.RolePermissionInformationId)
            {
                return RolePermissionInformation;
            }

            if (id == PermissionIds.UserPermissionInformationId)
            {
                return UserPermissionInformation;
            }

            #endregion

            return Null;
        }

        public static IList<Permission> GetPermissionByModules(Module module) 
        {
            IList<Permission> permissions = new List<Permission>();
            switch (module.Id)
            {
                case ModuleIds.SchedulesId:
                    permissions.Add(Schedules);
                    permissions.Add(ViewSchedules);
                    permissions.Add(AddSchedules);
                    permissions.Add(EditSchedules);
                    permissions.Add(CopySchedules);
                    permissions.Add(SaveSchedules);
                    permissions.Add(DeleteSchedules);
                    permissions.Add(PrintSchedules);
                    permissions.Add(ReleaseSchedules);
                    permissions.Add(FixedPriceSchedules);
                    permissions.Add(SetFilmSchedules);
                    permissions.Add(QuickSearchSchedules);
                    permissions.Add(BasicSearchSchedules);
                    break;

                case ModuleIds.TicketSellingId:

                    permissions.Add(TicketSelling);
                    permissions.Add(RetailTicketSelling);
                    permissions.Add(StudentsTicketSelling);
                    permissions.Add(GroupTicketSelling);
                    permissions.Add(DiscountTicketSelling);

                    permissions.Add(CashTicketSelling);
                    permissions.Add(ChequeTicketSelling);
                    permissions.Add(DiscountVoucherSelling);
                    permissions.Add(ExchangeVoucherSelling);
                    permissions.Add(SubstituteVoucherSelling);

                    permissions.Add(MembercardTicketSelling);
                    permissions.Add(MembercardPayTicketSelling);
                    permissions.Add(CreditTicketSelling);
                    permissions.Add(FreeTicketSelling);

                    permissions.Add(SaleTicketSelling);
                    permissions.Add(BookTicketSelling);
                    permissions.Add(BookSaleTicketSelling);
                    permissions.Add(BookReleaseTicketSelling);
                    permissions.Add(BookSearchTicketSelling);

                    permissions.Add(LockTicketSelling);
                    permissions.Add(UnLockTicketSelling);
                    permissions.Add(RefundTicketSelling);
                    permissions.Add(BatchRefundTicketSelling);

                    permissions.Add(SettingTicketSelling);
                    permissions.Add(MagnifyTicketSelling);
                    permissions.Add(RestoreTicketSelling);
                    permissions.Add(RotationSettingTicketSelling);
                    permissions.Add(BgColorSettingTicketSelling);
                    permissions.Add(CutTicketSelling);
                    permissions.Add(ValidationTicketSelling);
                    permissions.Add(SearchTicketSelling);
                    permissions.Add(FillupTicketSelling);
                    permissions.Add(RePrintTicketSelling);
                    break;

                case ModuleIds.ReportId:
                    permissions.Add(Report);
                    permissions.Add(StatisticsReport);
                    permissions.Add(BusinessReport);
                    permissions.Add(BasicQueryReport);
                    permissions.Add(CombinedQueryReport);
                    permissions.Add(TotalReport);
                    permissions.Add(GraphicReport);
                    permissions.Add(TicketReport);
                    permissions.Add(CommonReport);
                    break;

                case ModuleIds.TheaterInformationId:
                    permissions.Add(TheaterManage);
                    permissions.Add(TheaterInformation);
                    permissions.Add(HallTheaterInformation);
                    permissions.Add(AuthorizationTheaterInformation);
                    permissions.Add(TaxTheaterInformation);
                    permissions.Add(UploadSettingTheaterInformation);
                    permissions.Add(DataReportTheaterInformation);
                    permissions.Add(TimeSettingTheaterInformation);
                    permissions.Add(PriceTheaterInformation);
                    permissions.Add(ShowtypeTheaterInformation);
                    permissions.Add(DiscountTheaterInformation);
                    permissions.Add(BackupTheaterInformation);
                    permissions.Add(RestoreTheaterInformation);
                    break;      

                case ModuleIds.FilmInformationId:
                    permissions.Add(FilmManage);
                    permissions.Add(FilmInformation);
                    permissions.Add(AreaFilmInformation);
                    permissions.Add(CategoryFilmInformation);
                    permissions.Add(DownloadSettingFilmInformation);
                    permissions.Add(DownloadFilmInformation);
                    permissions.Add(PlayModeFilmInformation);
                    break;

                case ModuleIds.VoucherManagerId:
                    permissions.Add(VoucherManager);
                    permissions.Add(CustomerManager);
                    permissions.Add(CustomerTypeManager);
                    permissions.Add(DebtManager);
                    permissions.Add(VoucherBatchManager);
                    permissions.Add(VoucherTypeManager);
                    permissions.Add(VoucherSubTypeManager);
                    permissions.Add(VoucherReportManager);
                    break;

                case ModuleIds.SeatingChatId:
                    permissions.Add(SeatingChat);
                    permissions.Add(BlockSeatingChat);
                    permissions.Add(ImportSeatingChat);
                    permissions.Add(EditStateSeatingChat);
                    break; 

                case ModuleIds.TemplateManagerId:
                    permissions.Add(TemplateManager);
                    permissions.Add(CreateTemplateManager);
                    permissions.Add(EditTemplateManager);
                    permissions.Add(DeleteTemplateManager);
                    break;

                case ModuleIds.EmployeeInformationId:
                    permissions.Add(EmployeeInformation);
                    permissions.Add(UserInformation);
                    permissions.Add(BasicInformation);
                    permissions.Add(RoleUserInformation);
                    permissions.Add(RolePermissionInformation);
                    permissions.Add(UserPermissionInformation);
                    break;
            }
            return permissions;
        }
    }
}
