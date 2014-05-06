/*!40101 SET NAMES utf8 */;

drop table if exists Authorization;

drop table if exists BackupLog;

drop table if exists BackupSetting;

drop table if exists Block;

drop table if exists BlockPrice;

drop table if exists CommonItem;

drop table if exists Customer;

drop table if exists CustomerType;

drop table if exists DailyPlan;

drop table if exists Debt;

drop table if exists Discount;

drop table if exists DiscountType;

drop table if exists Discount_Type;

drop table if exists DownloadSetting;

drop table if exists FareSetting;

drop table if exists Film;

drop table if exists FilmArea;

drop table if exists FilmCategory;

drop table if exists FilmMode;

drop table if exists FilmType;

drop table if exists Film_FilmMode;

drop table if exists Film_FilmType;

drop table if exists Hall;

drop table if exists Module;

drop table if exists OnlineUserLog;

drop table if exists Payment;

drop table if exists Permission;

drop table if exists PrintSetting;

drop table if exists Reservation;

drop table if exists Role;

drop table if exists Role_Permission;

drop table if exists Rpt_TicketReport;

drop table if exists Seat;

drop table if exists SeatStatus;

drop table if exists SeatingChart;

drop table if exists ShowPlan;

drop table if exists ShowType;

drop table if exists Tax;

drop table if exists Template;

drop table if exists TemplateItem;

drop table if exists Theater;

drop table if exists Ticket;

drop table if exists TicketType;

drop table if exists TimeSetting;

drop table if exists UploadLog;

drop table if exists UploadSetting;

drop table if exists User;

drop table if exists UserLog;

drop table if exists User_Permission;

drop table if exists User_Role;

drop table if exists Voucher;

drop table if exists VoucherBatch;

drop table if exists VoucherSubType;

drop table if exists VoucherType;


#Table: Authorization

create table Authorization
(
   AuthorizationId      int not null auto_increment,
   TheaterId            char(32),
   StartDate            date,
   ExpireDate           date,
   FeatureFile          longblob,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (AuthorizationId)
);


#Table: BackupLog

create table BackupLog
(
   BackupLogId          int not null auto_increment,
   BackupSettingId      int,
   ServerDirectionId    int,
   BackupDate           date,
   Result               bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (BackupLogId)
);


#Table: BackupSetting

create table BackupSetting
(
   BackupSettingId      int not null auto_increment,
   BackupMethod         varchar(64),
   BackupTime           time,
   RepeatDay            varchar(64),
   ServerAddress        varchar(255),
   DatabasePath         varchar(255),
   BackupPath           varchar(255),
   IsLocalFolder        bool,
   LoginName            varchar(64),
   LoginPswd            varchar(64),
   CurrentBackupDate    datetime,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (BackupSettingId)
);


#Table: Block

create table Block
(
   BlockId              char(32) not null,
   SeatingChartId       char(32),
   BlockName            varchar(64),
   BgColour             varchar(64),
   Seats                int,
   HasBlockPrice        bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (BlockId)
);


#Table: BlockPrice

create table BlockPrice
(
   BlockPriceId         char(32) not null,
   BlockId              char(32),
   ShowPlanId           char(32),
   SinglePrice          float(8,2),
   DoublePrice          float(8,2),
   BoxPrice             float(8,2),
   StudentPrice         float(8,2),
   GroupPrice           float(8,2),
   MemberPrice          float(8,2),
   DiscountPrice        float(8,2),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (BlockPriceId)
);


#Table: CommonItem

create table CommonItem
(
   CommonItemId         int not null auto_increment,
   CommonItemName       varchar(64),
   TemplateType         varchar(64),
   DataItem             varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (CommonItemId)
);


#Table: Customer

create table Customer
(
   CustomerId           int not null auto_increment,
   CustomerTypeId       int,
   CustomerName         varchar(64),
   BankBranch           varchar(64),
   BankAccount          varchar(64),
   Telephone            varchar(64),
   Contact              varchar(64),
   Email                varchar(255),
   Address              varchar(255),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (CustomerId)
);


#Table: CustomerType

create table CustomerType
(
   CustomerTypeId       int not null auto_increment,
   CustomerTypeName     varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (CustomerTypeId)
);


#Table: DailyPlan

create table DailyPlan
(
   DailyPlanId          char(32) not null,
   TheaterId            char(32),
   PlanDate             date,
   StartTime            time,
   EndTime              time,
   Timespan             int,
   Halls                int,
   IsApproved           bool,
   IsSalable            bool,
   IsLocked             bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (DailyPlanId)
);


#Table: Debt

create table Debt
(
   DebtId               char(32) not null,
   CustomerId           int,
   Buyer                varchar(64),
   BoughtDate           date,
   Tickets              int,
   Amount               float(8,2),
   BankBranch           varchar(64),
   BankAccount          varchar(64),
   ChequeNumber         varchar(64),
   DebtStatus           bool,
   ClearDate            date,
   Casher               int,
   Accountant           int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (DebtId)
);


#Table: Discount

create table Discount
(
   DiscountId           int not null auto_increment,
   DiscountPrice        float(8,2),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (DiscountId)
);


#Table: DiscountType

create table DiscountType
(
   DiscountTypeId       int not null auto_increment,
   DiscountTypeName     varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (DiscountTypeId)
);


#Table: Discount_Type

create table Discount_Type
(
   Discount_TypeId      int not null auto_increment,
   DiscountTypeId       int,
   DiscountId           int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (Discount_TypeId)
);


#Table: DownloadSetting

create table DownloadSetting
(
   DownloadId           int not null auto_increment,
   TheaterId            char(32) not null,
   SourceName           varchar(64),
   DownloadMethod       varchar(64),
   DownloadAddr         varchar(255),
   Port                 int,
   UserName             varchar(64),
   Password             varchar(64),
   IsAnonymAllowed      bool,
   IsProxy              bool,
   ProxyServer          varchar(255),
   ProxyPort            int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (DownloadId)
);


#Table: FareSetting

create table FareSetting
(
   FareSettingId        int not null auto_increment,
   FareSettingName      varchar(64),
   SinglePrice          float(8,2),
   DoublePrice          float(8,2),
   BoxPrice             float(8,2),
   StudentPrice         float(8,2),
   GroupPrice           float(8,2),
   MemberPrice          float(8,2),
   DiscountPrice        float(8,2),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (FareSettingId)
);


#Table: Film

create table Film
(
   FilmId               char(32) not null,
   FilmAreaId           char(32),
   FilmCategoryId       char(32),
   FilmCode             char(32),
   FilmName             varchar(64),
   PublishDate          date,
   Publisher            varchar(64),
   Producer             varchar(64),
   Director             varchar(64),
   Cast                 varchar(255),
   Brief                varchar(255),
   Poster               longblob,
   StartDate            date,
   EndDate              date,
   FilmLength           int,
   Rent                 float(10,2),
   Ratio                float,
   LowestPrice          float(8,2),
   BorderColour         varchar(64),
   HasMode              bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (FilmId)
);


#Table: FilmArea

create table FilmArea
(
   FilmAreaId           char(32) not null,
   FilmAreaName         varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (FilmAreaId)
);


#Table: FilmCategory

create table FilmCategory
(
   FilmCategoryId       char(32) not null,
   FilmCategoryName     varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (FilmCategoryId)
);


#Table: FilmMode

create table FilmMode
(
   FilmModeId           int not null auto_increment,
   FilmModeName         varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (FilmModeId)
);


#Table: FilmType

create table FilmType
(
   FilmTypeId           int not null auto_increment,
   FilmTypeName         varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (FilmTypeId)
);


#Table: Film_FilmMode

create table Film_FilmMode
(
   Film_FilmModeId      int not null auto_increment,
   FilmId               char(32),
   FilmModeId           int,
   BorderColour         varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (Film_FilmModeId)
);


#Table: Film_FilmType

create table Film_FilmType
(
   Film_FilmTypeId      int not null auto_increment,
   FilmTypeId           int,
   FilmId               char(32),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (Film_FilmTypeId)
);


#Table: Hall

create table Hall
(
   HallId               char(32) not null,
   TheaterId            char(32),
   HallName             varchar(64),
   Seats                int,
   Levels               int,
   BarColour            varchar(64),
   Screen               varchar(64),
   Projector            varchar(64),
   PlayMode             varchar(64),
   SoundSystem          varchar(64),
   Description          varchar(255),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (HallId)
);


#Table: Module

create table Module
(
   ModuleId             int not null,
   ModuleName           varchar(64) not null,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (ModuleId)
);


#Table: OnlineUserLog

create table OnlineUserLog
(
   UserId               int,
   UserName             varchar(64),
   WS_IP                varchar(64),
   WS_MAC               varchar(64),
   Created              datetime,
   primary key (UserId)
);


#Table: Payment

create table Payment
(
   PaymentId            int not null auto_increment,
   PaymentName          varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (PaymentId)
);


#Table: Permission

create table Permission
(
   PermissionId         int not null,
   ModuleId             int,
   PermissionName       varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (PermissionId)
);


#Table: PrintSetting

create table PrintSetting
(
   PrintSettingId       int not null auto_increment,
   PrintModel           varchar(64),
   SettingFile          text,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (PrintSettingId)
);


#Table: Reservation

create table Reservation
(
   ReservationId        char(32) not null,
   SeatStatusId         char(32) not null,
   TicketTypeId         int,
   ShowPlanId           char(32),
   CustomerName         varchar(64),
   CustomerMobile       varchar(64),
   CustomerCode         varchar(64),
   Identity             varchar(64),
   SeatNumber           varchar(64),
   TicketPrice          float(8,2),
   IssuedBy             int,
   BookedTime           datetime,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (ReservationId)
);


#Table: Role

create table Role
(
   RoleID               int not null auto_increment,
   RoleName             varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (RoleID)
);


#Table: Role_Permission

create table Role_Permission
(
   Role_PermissionId    int not null auto_increment,
   PermissionId         int not null,
   RoleID               int not null,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (Role_PermissionId)
);


#Table: Rpt_TicketReport

create table Rpt_TicketReport
(
   Rpt_TicketReportId   int not null,
   BusinessDate         date,
   CinemaID             char(32),
   HallID               char(32),
   FilmID               char(32),
   ShowPlan             int,
   ShowDatetime         datetime,
   SingleSeatPrice      float(8,2),
   DoubleSeatPrice      float(8,2),
   StudentPrice         float(8,2),
   BoxPrice             float(8,2),
   GroupHighPrice       float(8,2),
   GroupLowPrice        float(8,2),
   GroupAveragePrice    float(8,4),
   SingleSeatAudienceQuantity int,
   DoubleSeatAudienceQuantity int,
   StudentAudienceQuantity int,
   BoxAudienceQuantity  int,
   GroupAudienceQuantity int,
   SingleReturnedQuantity int,
   DoubleReturnedQuantity int,
   StudentReturnedQuantity int,
   BoxReturnedQuantity  int,
   GroupReturnedQuantity int,
   SingleTotalEarning   float(8,2),
   DoubleTotalEarning   float(8,2),
   StudentTotalEarning  float(8,2),
   BoxTotalEarning      float(8,2),
   GroupTotalEarning    float(8,2),
   TotalAudienceQuantity int,
   TotalEarning         float(10,2),
   GroupTotalReturn     float(10,2),
   TotalReturn          float(10,2),
   primary key (Rpt_TicketReportId)
);


#Table: Seat

create table Seat
(
   SeatId               char(32) not null,
   BlockId              char(32),
   SeatingChartId       char(32),
   SeatNumber           varchar(64),
   RowNumber            varchar(64),
   ColumnNumber         varchar(64),
   Xaxis                int,
   Yaxis                int,
   Height               int,
   Width                int,
   SeatType             char(32),
   SeatGroup            char(32),
   Capacity             int,
   Property             varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (SeatId)
);


#Table: SeatStatus

create table SeatStatus
(
   SeatStatusId         char(32) not null,
   SeatId               char(32),
   ShowPlanId           char(32),
   TicketingState       char(32),
   LockedBy             int,
   SoldBy               int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (SeatStatusId)
);


#Table: SeatingChart

create table SeatingChart
(
   SeatingChartId       char(32) not null,
   HallId               char(32),
   SeatingChartName     varchar(64),
   Level                int,
   Seats                int,
   Rows                 int,
   Columns              int,
   RowSpace             int,
   ColumnSpace          int,
   Shape                varchar(64),
   BgColour             varchar(64),
   Rotation             int,
   Thumbnail            longblob,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (SeatingChartId)
);

#Table: ServerDirection

create table ServerDirection
(
   ServerDirectionId    int not null auto_increment,
   ServerDirectionDateTime datetime,
   UserId               int,
   DirectionType        int,
   IsTransacted         bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (ServerDirectionId)
);

#Table: ShowPlan

create table ShowPlan
(
   ShowPlanId           char(32) not null,
   DailyPlanId          char(32),
   ShowTypeId           int,
   FareSettingId        int,
   HallId               char(32),
   FilmId               char(32),
   DiscountTypeId       int,
   ShowPlanName         varchar(64),
   Film_FilmModeId      int,
   Position             int,
   StartTime            datetime,
   EndTime              datetime,
   FilmLength           int,
   Timespan             int,
   Ratio                float,
   LowestPrice          float(8,2),
   SinglePrice          float(8,2),
   DoublePrice          float(8,2),
   BoxPrice             float(8,2),
   StudentPrice         float(8,2),
   GroupPrice           float(8,2),
   MemberPrice          float(8,2),
   DiscountPrice        float(8,2),
   ShowStatus           int,
   ShowGroup            int,
   IsDiscounted         bool,
   IsCheckingNumber     bool,
   IsTicketChecking     bool,
   IsOnlineTicketing    bool,
   IsApproved           bool,
   IsSalable            bool,
   IsLocked             bool,
   Stagehand            int,
   Projectionist        int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (ShowPlanId)
);


#Table: ShowType

create table ShowType
(
   ShowTypeId           int not null auto_increment,
   ShowTypeName         varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (ShowTypeId)
);


#Table: Tax

create table Tax
(
   TaxId                int not null auto_increment,
   TheaterId            char(32) not null,
   TaxType              varchar(64),
   TaxRate              float,
   ChargeMethod         varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TaxId)
);


#Table: Template

create table Template
(
   TemplateId           int not null auto_increment,
   PrintSettingId       int,
   TemplateName         varchar(64),
   TemplateType         varchar(64),
   BgImage              longblob,
   BgHeight             int,
   BgWidth              int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TemplateId)
);


#Table: TemplateItem

create table TemplateItem
(
   TemplateItemId       int not null auto_increment,
   TemplateId           int,
   CommonItemId         int,
   TemplateItemName     varchar(64),
   Xaxis                int,
   Yaxis                int,
   Font                 varchar(64),
   FontSize             int,
   FontColour           varchar(64),
   DataItem             varchar(64),
   Description          varchar(255),
   IsOnTemplate         bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TemplateItemId)
);


#Table: Theater

create table Theater
(
   TheaterId            char(32) not null,
   TheaterType          varchar(64),
   TheaterName          varchar(64),
   Rating               varchar(64),
   Corporation          varchar(64),
   Telephone            varchar(64),
   Mobile               varchar(64),
   Fax                  varchar(64),
   Manager              varchar(64),
   Halls                int,
   Seats                int,
   Province             varchar(64),
   City                 varchar(64),
   District             varchar(64),
   PostCode             char(32),
   Address              varchar(255),
   TheaterCode          char(32),
   CineChainId          char(32),
   Version              varchar(64),
   SerialNumber         varchar(64),
   ServerModle          varchar(64),
   ServerCPU            varchar(64),
   ServerMemory         varchar(64),
   ServerHardDriver     varchar(64),
   Clients              int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TheaterId)
);


#Table: Ticket

create table Ticket
(
   TicketId             char(36) not null,
   SeatStatusId         char(32) not null,
   TemplateId           int,
   PaymentId            int,
   FilmId               char(32),
   TicketTypeId         int,
   ShowPlanId           char(32),
   TicketPrice          float(8,2),
   SpecialFund          float(8,4),
   SalesTax             float(8,4),
   CityTax              float(8,4),
   EducationTax         float(8,4),
   AdditionalTax        float(8,4),
   RatioFee             float(8,4),
   NetIncome            float(8,4),
   BarCode              varchar(255),
   SoldTime             datetime,
   SoldBy               int,
   PrintStatus          int,
   TicketStatus         int,
   RefundedBy           int,
   RefundTime           datetime,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TicketId)
);


#Table: TicketType

create table TicketType
(
   TicketTypeId         int not null auto_increment,
   TicketTypeName       varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TicketTypeId)
);


#Table: TimeSetting

create table TimeSetting
(
   TimeSettingId        int not null auto_increment,
   TheaterId            char(32) not null,
   RepeatDay            varchar(64) not null,
   OpenTime             time not null,
   CloseTime            time not null,
   RefundDeadline       int not null,
   TicketingDeadline    int not null,
   BookingReleaseTime   int not null,
   Timespan             int not null,
   DailyCount           int,
   StartDate            int,
   MonthlyCount         int,
   StartMonth           int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (TimeSettingId)
);


#Table: UploadLog

create table UploadLog
(
   UploadLogId          int not null auto_increment,
   UploadId             int not null,
   Result               bool,
   Tries                int,
   BusnessDate          date,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (UploadLogId)
);


#Table: UploadSetting

create table UploadSetting
(
   UploadId             int not null auto_increment,
   TheaterId            char(32) not null,
   TargetName           varchar(64),
   UploadMethod         varchar(64),
   IsActive             bool,
   UploadAddr           varchar(255),
   UploadTime           time,
   EmailAddr            varchar(255),
   FileFormat           varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (UploadId)
);


#Table: User

create table User
(
   UserId               int not null auto_increment,
   UserName             varchar(64),
   Password             varchar(64),
   EmployeeName         varchar(64),
   EmployeeId           varchar(64),
   Telephone            varchar(64),
   Mobile               varchar(64),
   IsActive             bool,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (UserId)
);


#Table: UserLog

create table UserLog
(
   UserLogId            char(32) not null,
   UserId               int,
   UserName             varchar(64),
   Operation            varchar(64),
   Created              datetime not null,
   primary key (UserLogId)
);


#Table: User_Permission

create table User_Permission
(
   User_PermissionId    int not null auto_increment,
   UserId               int not null,
   PermissionId         int not null,
   RoleID               int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (User_PermissionId)
);


#Table: User_Role

create table User_Role
(
   User_RoleId          int not null auto_increment,
   RoleID               int,
   UserId               int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (User_RoleId)
);


#Table: Voucher

create table Voucher
(
   VoucherId            char(32) not null,
   VoucherBatchId       char(32),
   TicketId             char(36),
   Price                float(8,2),
   BarCode              varchar(255),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (VoucherId)
);


#Table: VoucherBatch

create table VoucherBatch
(
   VoucherBatchId       char(32) not null,
   VoucherTypeId        int,
   CustomerId           int,
   VoucherSubTypeId     int,
   VoucherName          varchar(64),
   VoucherPrice         float(8,2),
   UnitPrice            float(8,2),
   TotalPrice           float(8,2),
   Quantity             int,
   SerialScope          varchar(255),
   ReleaseDate          date,
   ExpireDate           date,
   Description          varchar(255),
   IssuedBy             int,
   PrintStatus          int,
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (VoucherBatchId)
);


#Table: VoucherSubType

create table VoucherSubType
(
   VoucherSubTypeId     int not null auto_increment,
   VoucherSubTypeName   varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (VoucherSubTypeId)
);


#Table: VoucherType

create table VoucherType
(
   VoucherTypeId        int not null auto_increment,
   VoucherTypeName      varchar(64),
   Created              datetime not null,
   Updated              datetime not null,
   ActiveFlag           bool not null,
   primary key (VoucherTypeId)
);

alter table Authorization add constraint FK_Authorization2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table BackupLog add constraint FK_BackupLog2BackupSetting foreign key (BackupSettingId)
      references BackupSetting (BackupSettingId) on delete restrict on update restrict;

alter table BackupLog add constraint FK_BackupLog2ServerDirection foreign key (ServerDirectionId)
      references ServerDirection (ServerDirectionId) on delete restrict on update restrict;

alter table Block add constraint FK_Block2SeatingChart foreign key (SeatingChartId)
      references SeatingChart (SeatingChartId) on delete restrict on update restrict;

alter table BlockPrice add constraint FK_BlockPrice2Block foreign key (BlockId)
      references Block (BlockId) on delete restrict on update restrict;

alter table BlockPrice add constraint FK_BlockPrice2ShowPlan foreign key (ShowPlanId)
      references ShowPlan (ShowPlanId) on delete restrict on update restrict;

alter table Customer add constraint FK_Customer2CustomerType foreign key (CustomerTypeId)
      references CustomerType (CustomerTypeId) on delete restrict on update restrict;

alter table DailyPlan add constraint FK_DailyPlan2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table Debt add constraint FK_Debt2Customer foreign key (CustomerId)
      references Customer (CustomerId) on delete restrict on update restrict;

alter table Discount_Type add constraint FK_D_T2D foreign key (DiscountId)
      references Discount (DiscountId) on delete restrict on update restrict;

alter table Discount_Type add constraint FK_D_T2DT foreign key (DiscountTypeId)
      references DiscountType (DiscountTypeId) on delete restrict on update restrict;

alter table DownloadSetting add constraint FK_DownloadSetting2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table Film add constraint FK_Film2FilmArea foreign key (FilmAreaId)
      references FilmArea (FilmAreaId) on delete restrict on update restrict;

alter table Film add constraint FK_Film2FilmCategory foreign key (FilmCategoryId)
      references FilmCategory (FilmCategoryId) on delete restrict on update restrict;

alter table Film_FilmMode add constraint FK_F_F2Film foreign key (FilmId)
      references Film (FilmId) on delete restrict on update restrict;

alter table Film_FilmMode add constraint FK_F_F2FilmMode foreign key (FilmModeId)
      references FilmMode (FilmModeId) on delete restrict on update restrict;

alter table Film_FilmType add constraint FK_Film_FilmType2Film foreign key (FilmId)
      references Film (FilmId) on delete restrict on update restrict;

alter table Film_FilmType add constraint FK_Film_FilmType2FilmType foreign key (FilmTypeId)
      references FilmType (FilmTypeId) on delete restrict on update restrict;

alter table Hall add constraint FK_Hall2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table Permission add constraint FK_Permission2Module foreign key (ModuleId)
      references Module (ModuleId) on delete restrict on update restrict;

alter table Reservation add constraint FK_Reservation2SeatStatus foreign key (SeatStatusId)
      references SeatStatus (SeatStatusId) on delete restrict on update restrict;

alter table Reservation add constraint FK_Reservation2TicketType foreign key (TicketTypeId)
      references TicketType (TicketTypeId) on delete restrict on update restrict;

alter table Role_Permission add constraint FK_R_P2Permission foreign key (PermissionId)
      references Permission (PermissionId) on delete restrict on update restrict;

alter table Role_Permission add constraint FK_R_P2Role foreign key (RoleID)
      references Role (RoleID) on delete restrict on update restrict;

alter table Seat add constraint FK_Seat2Block foreign key (BlockId)
      references Block (BlockId) on delete restrict on update restrict;

alter table Seat add constraint FK_Seat2SeatingChart foreign key (SeatingChartId)
      references SeatingChart (SeatingChartId) on delete restrict on update restrict;

alter table SeatStatus add constraint FK_SeatSataus2Seat foreign key (SeatId)
      references Seat (SeatId) on delete restrict on update restrict;

alter table SeatStatus add constraint FK_SeatStatus2ShowPlan foreign key (ShowPlanId)
      references ShowPlan (ShowPlanId) on delete restrict on update restrict;

alter table SeatingChart add constraint FK_SeatingChart2Hall foreign key (HallId)
      references Hall (HallId) on delete restrict on update restrict;

alter table ShowPlan add constraint FK_ShowPlan2DailyPlan foreign key (DailyPlanId)
      references DailyPlan (DailyPlanId) on delete restrict on update restrict;

alter table ShowPlan add constraint FK_ShowPlan2DiscountType foreign key (DiscountTypeId)
      references DiscountType (DiscountTypeId) on delete restrict on update restrict;

alter table ShowPlan add constraint FK_ShowPlan2FareSetting foreign key (FareSettingId)
      references FareSetting (FareSettingId) on delete restrict on update restrict;

alter table ShowPlan add constraint FK_ShowPlan2Film foreign key (FilmId)
      references Film (FilmId) on delete restrict on update restrict;

alter table ShowPlan add constraint FK_ShowPlan2Hall foreign key (HallId)
      references Hall (HallId) on delete restrict on update restrict;

alter table ShowPlan add constraint FK_ShowPlan2ShowType foreign key (ShowTypeId)
      references ShowType (ShowTypeId) on delete restrict on update restrict;

alter table Tax add constraint FK_Tax2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table Template add constraint FK_Template2PrintSetting foreign key (PrintSettingId)
      references PrintSetting (PrintSettingId) on delete restrict on update restrict;

alter table TemplateItem add constraint FK_TemplateItem2CommonItem_FK foreign key (CommonItemId)
      references CommonItem (CommonItemId) on delete restrict on update restrict;

alter table TemplateItem add constraint FK_TemplateItem2Template_FK foreign key (TemplateId)
      references Template (TemplateId) on delete restrict on update restrict;

alter table Ticket add constraint FK_Ticket2Film foreign key (FilmId)
      references Film (FilmId) on delete restrict on update restrict;

alter table Ticket add constraint FK_Ticket2Payment foreign key (PaymentId)
      references Payment (PaymentId) on delete restrict on update restrict;

alter table Ticket add constraint FK_Ticket2SeatStatus foreign key (SeatStatusId)
      references SeatStatus (SeatStatusId) on delete restrict on update restrict;

alter table Ticket add constraint FK_Ticket2ShowPlan foreign key (ShowPlanId)
      references ShowPlan (ShowPlanId) on delete restrict on update restrict;

alter table Ticket add constraint FK_Ticket2Template foreign key (TemplateId)
      references Template (TemplateId) on delete restrict on update restrict;

alter table Ticket add constraint FK_Ticket2TicketType foreign key (TicketTypeId)
      references TicketType (TicketTypeId) on delete restrict on update restrict;

alter table TimeSetting add constraint FK_TimeSetting2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table UploadLog add constraint FK_UploadLog2UploadSetting foreign key (UploadId)
      references UploadSetting (UploadId) on delete restrict on update restrict;

alter table UploadSetting add constraint FK_UploadSetting2Theater foreign key (TheaterId)
      references Theater (TheaterId) on delete restrict on update restrict;

alter table User_Permission add constraint FK_U_P2Permission foreign key (PermissionId)
      references Permission (PermissionId) on delete restrict on update restrict;

alter table User_Permission add constraint FK_U_P2Role foreign key (RoleID)
      references Role (RoleID) on delete restrict on update restrict;

alter table User_Permission add constraint FK_U_P2User foreign key (UserId)
      references User (UserId) on delete restrict on update restrict;

alter table User_Role add constraint FK_U_R2Role foreign key (RoleID)
      references Role (RoleID) on delete restrict on update restrict;

alter table User_Role add constraint FK_U_R2User foreign key (UserId)
      references User (UserId) on delete restrict on update restrict;

alter table Voucher add constraint FK_Voucher2Ticket foreign key (TicketId)
      references Ticket (TicketId) on delete restrict on update restrict;

alter table Voucher add constraint FK_Voucher2VoucherBatch foreign key (VoucherBatchId)
      references VoucherBatch (VoucherBatchId) on delete restrict on update restrict;

alter table VoucherBatch add constraint FK_VoucherBatch2Customer foreign key (CustomerId)
      references Customer (CustomerId) on delete restrict on update restrict;

alter table VoucherBatch add constraint FK_VoucherBatch2VoucherSubType foreign key (VoucherSubTypeId)
      references VoucherSubType (VoucherSubTypeId) on delete restrict on update restrict;

alter table VoucherBatch add constraint FK_VoucherBatch2VoucherType foreign key (VoucherTypeId)
      references VoucherType (VoucherTypeId) on delete restrict on update restrict;

# Table: TheaterPrices

CREATE TABLE `TheaterPrices` (
  `TheaterPriceId` CHAR(16) NOT NULL,
  `DailyPlanId` char(16) DEFAULT NULL,
  `SinglePrice` float(8,2) DEFAULT '0.00',
  `DoublePrice` float(8,2) DEFAULT '0.00',
  `StudentPrice` float(8,2) DEFAULT '0.00',
  `GroupPrice` float(8,2) DEFAULT '0.00',
  `BoxPrice` float(8,2) DEFAULT '0.00',
  `MemberPrice` float(8,2) DEFAULT '0.00',
  `DiscountPrice` float(8,2) DEFAULT '0.00',
  PRIMARY KEY (`TheaterPriceId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# Table: PeriodPrices

CREATE TABLE `PeriodPrices` (
  `PeriodPriceId` INT  NOT NULL,
  `DailyPlanId` char(16) DEFAULT NULL,
  `StartTime` time DEFAULT NULL,
  `EndTime` time DEFAULT NULL,
  `SinglePrice` float(8,2) DEFAULT '0.00',
  `DoublePrice` float(8,2) DEFAULT '0.00',
  `StudentPrice` float(8,2) DEFAULT '0.00',
  `GroupPrice` float(8,2) DEFAULT '0.00',
  `BoxPrice` float(8,2) DEFAULT '0.00',
  `MemberPrice` float(8,2) DEFAULT '0.00',
  `DiscountPrice` float(8,2) DEFAULT '0.00',
  PRIMARY KEY (`PeriodPriceId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# Table: HallPrices

CREATE TABLE `HallPrices` (
  `HallPriceId` INT  NOT NULL,
  `DailyPlanId` char(16) DEFAULT NULL,
  `HallId` char(16) DEFAULT NULL,
  `SinglePrice` float(8,2) DEFAULT '0.00',
  `DoublePrice` float(8,2) DEFAULT '0.00',
  `StudentPrice` float(8,2) DEFAULT '0.00',
  `GroupPrice` float(8,2) DEFAULT '0.00',
  `BoxPrice` float(8,2) DEFAULT '0.00',
  `MemberPrice` float(8,2) DEFAULT '0.00',
  `DiscountPrice` float(8,2) DEFAULT '0.00',
  PRIMARY KEY (`HallPriceId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

# Table: FilmPrices

CREATE TABLE `FilmPrices` (
  `FilmPriceId` INT  NOT NULL,
  `DailyPlanId` char(16) DEFAULT NULL,
  `FilmId` char(16) DEFAULT NULL,
  `SinglePrice` float(8,2) DEFAULT '0.00',
  `DoublePrice` float(8,2) DEFAULT '0.00',
  `StudentPrice` float(8,2) DEFAULT '0.00',
  `GroupPrice` float(8,2) DEFAULT '0.00',
  `BoxPrice` float(8,2) DEFAULT '0.00',
  `MemberPrice` float(8,2) DEFAULT '0.00',
  `DiscountPrice` float(8,2) DEFAULT '0.00',
  PRIMARY KEY (`FilmPriceId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
