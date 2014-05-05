using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class PermissionIds
    {
        #region SchedulesId

        public static readonly int SchedulesId = 100;
        public static readonly int ViewSchedulesId = 101;
        public static readonly int AddSchedulesId = 102;
        public static readonly int EditSchedulesId = 103;
        public static readonly int CopySchedulesId = 104;
        public static readonly int SaveSchedulesId = 105;
        public static readonly int DeleteSchedulesId = 106;
        public static readonly int PrintSchedulesId = 107;
        public static readonly int ReleaseSchedulesId = 108;
        public static readonly int FixedPriceSchedulesId = 109;
        public static readonly int SetFilmSchedulesId = 110;
        public static readonly int QuickSearchSchedulesId = 111;
        public static readonly int BasicSearchSchedulesId = 112;

        #endregion

        #region TicketSelling

        public static readonly int TicketSellingId = 200;

        public static readonly int RetailTicketSellingId = 201;
        public static readonly int StudentsTicketSellingId = 202;
        public static readonly int GroupTicketSellingId = 203;
        public static readonly int DiscountTicketSellingId = 204;

        public static readonly int CashTicketSellingId = 205;
        public static readonly int ChequeTicketSellingId = 206;
        public static readonly int DiscountVoucherSellingId = 207;
        public static readonly int ExchangeVoucherSellingId = 208;
        public static readonly int SubstituteVoucherSellingId = 209;
        public static readonly int MembercardTicketSellingId = 210;
        public static readonly int MembercardPayTicketSellingId = 211;
        public static readonly int CreditTicketSellingId = 212;
        public static readonly int FreeTicketSellingId = 213;

        public static readonly int SaleTicketSellingId = 214;
        public static readonly int BookTicketSellingId = 215;
        public static readonly int BookSaleTicketSellingId = 216;
        public static readonly int BookReleaseTicketSellingId = 217;
        public static readonly int BookSearchTicketSellingId = 218;
        public static readonly int LockTicketSellingId = 219;
        public static readonly int UnLockTicketSellingId = 220;
        public static readonly int RefundTicketSellingId = 221;
        public static readonly int BatchRefundTicketSellingId = 222;

        public static readonly int SettingTicketSellingId = 223;
        public static readonly int MagnifyTicketSellingId = 224;
        public static readonly int RestoreTicketSellingId = 225;
        public static readonly int RotationSettingTicketSellingId = 226;
        public static readonly int BgColorSettingTicketSellingId = 227;
        public static readonly int CutTicketSellingId = 228;
        public static readonly int ValidationTicketSellingId = 229;
        public static readonly int SearchTicketSellingId = 230;
        public static readonly int FillupTicketSellingId = 231;
        public static readonly int RePrintTicketSellingId = 232;

        #endregion

        #region Report

        public static readonly int ReportId = 300;

        public static readonly int StatisticsReportId = 301;
        public static readonly int BusinessReportId = 302;
        public static readonly int BasicQueryReportId = 303;
        public static readonly int CombinedQueryReportId = 304;
        public static readonly int TotalReportId = 305;
        public static readonly int GraphicReportId = 306;
        public static readonly int TicketReportId = 307;
        public static readonly int CommonReportId = 308;

        #endregion

        #region TheaterInformation

        public static readonly int TheaterManageId = 400;
        public static readonly int TheaterInformationId = 401;
        public static readonly int HallTheaterInformationId = 402;
        public static readonly int AuthorizationTheaterInformationId = 403;
        public static readonly int TaxTheaterInformationId = 404;
        public static readonly int UploadSettingTheaterInformationId = 405;
        public static readonly int DataReportTheaterInformationId = 406;
        public static readonly int TimeSettingTheaterInformationId = 407;
        public static readonly int ShowtypeTheaterInformationId = 408;
        public static readonly int PriceTheaterInformationId = 409;
        public static readonly int DiscountTheaterInformationId = 410;
        public static readonly int BackupTheaterInformationId = 411; 
        public static readonly int RestoreTheaterInformationId = 412;

        #endregion

        #region FilmInformation

        public static readonly int FilmManageId = 500;
        public static readonly int FilmInformationId = 501;
        public static readonly int AreaFilmInformationId = 502;
        public static readonly int CategoryFilmInformationId = 503;
        public static readonly int DownloadSettingFilmInformationId = 504;
        public static readonly int DownloadFilmInformationId = 505;
        public static readonly int PlayModeFilmInformationId = 506;

        #endregion

        #region VoucherManager

        public static readonly int VoucherManagerId = 600;
        public static readonly int CustomerManagerId = 601;
        public static readonly int CustomerTypeManagerId = 602;
        public static readonly int DebtManagerId = 603;
        public static readonly int VoucherBatchManagerId = 604;
        public static readonly int VoucherTypeManagerId = 605;
        public static readonly int VoucherSubTypeManagerId = 606;
        public static readonly int VoucherReportManagerId = 607;

        #endregion

        #region SeatingChat

        public static readonly int SeatingChatId = 700;
        public static readonly int BlockSeatingChatId = 701;
        public static readonly int ImportSeatingChatId = 702;
        public static readonly int EditStateSeatingChatId = 703;

        #endregion

        #region TemplateManager

        public static readonly int TemplateManagerId = 800;
        public static readonly int CreateTemplateManagerId = 801;
        public static readonly int EditTemplateManagerId = 802;
        public static readonly int DeleteTemplateManagerId = 803;

        #endregion

        #region EmployeeInformation

        public static readonly int EmployeeInformationId = 900;
        public static readonly int UserInformationId = 901;
        public static readonly int BasicInformationId = 902;
        public static readonly int RoleUserInformationId = 903;
        public static readonly int RolePermissionInformationId = 904;
        public static readonly int UserPermissionInformationId = 905;

        #endregion
    }
}
