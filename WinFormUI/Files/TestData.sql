/*!40101 SET NAMES utf8 */;
#影院信息相关

INSERT INTO `theater` (`TheaterId`, `TheaterType`, `TheaterName`, `Rating`, `Corporation`, `Telephone`, `Mobile`, `Manager`, `Halls`, `Seats`, `Province`, `City`, `District`, `PostCode`, `Address`, `CineChainId`, `Version`, `SerialNumber`, `Created`, `Updated`, `ActiveFlag`) VALUES ('95020202', '市区专业电影院', '内蒙古包头市第一文化宫立体影院', '无', '赵文军', '13624835168', '13624835168', '赵文军', 10, 1100, '内蒙古', '包头', '青山', '14030', '钢铁大街1号', '九州中原院线', '火烈鸟电影管理系统3.0A', '无', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('01', '95020202', '一厅', 150, 1, '金属幕', '科视', '数字', '5.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('02', '95020202', '二厅', 200, 1, '金属幕', '科视', '数字', '5.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('03', '95020202', '三厅', 100, 1, '金属幕', '科视', '数字', '5.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('04', '95020202', '四厅', 120, 1, '金属幕', '科视', '数字', '5.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('05', '95020202', '五厅', 160, 1, '金属幕', '科视', '数字', '5.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('06', '95020202', '六厅', 100, 1, '金属幕', '科视', '数字', '7.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('07', '95020202', '七厅', 100, 1, '金属幕', '科视', '数字', '7.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('08', '95020202', '八厅', 100, 1, '金属幕', '科视', '数字', '7.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('09', '95020202', 'VIP厅', 20, 1, '金属幕', '科视', '数字', '11.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `hall` (`HallId`, `TheaterId`, `HallName`, `Seats`, `Levels`, `Screen`, `Projector`, `PlayMode`, `SoundSystem`, `Created`, `Updated`, `ActiveFlag`) VALUES ('10', '95020202', 'D-MAX厅', 50, 1, '金属幕', '科视', '数字', '11.1声道', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `tax` (`TaxId`, `TheaterId`, `TaxType`, `TaxRate`, `ChargeMethod`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '95020202', '专项资金', 0.05, '按全额票款计算', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `tax` (`TaxId`, `TheaterId`, `TaxType`, `TaxRate`, `ChargeMethod`, `Created`, `Updated`, `ActiveFlag`) VALUES (2, '95020202', '营业税', 0.05, '按全额票款计算', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `tax` (`TaxId`, `TheaterId`, `TaxType`, `TaxRate`, `ChargeMethod`, `Created`, `Updated`, `ActiveFlag`) VALUES (3, '95020202', '城建税', 0.05, '按全额票款计算', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `tax` (`TaxId`, `TheaterId`, `TaxType`, `TaxRate`, `ChargeMethod`, `Created`, `Updated`, `ActiveFlag`) VALUES (4, '95020202', '教育附加税', 0.05, '按全额票款计算', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `tax` (`TaxId`, `TheaterId`, `TaxType`, `TaxRate`, `ChargeMethod`, `Created`, `Updated`, `ActiveFlag`) VALUES (5, '95020202', '预置税', 0, '按税后票款计算', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO  `timesetting` (`TimeSettingId`, `TheaterId`, `RepeatDay`, `OpenTime`, `CloseTime`, `RefundDeadline`, `TicketingDeadline`, `BookingReleaseTime`, `Timespan`, `DailyCount`, `StartDate`, `MonthlyCount`, `StartMonth`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '95020202', '每天', '9:0:0', '8:59:59', 30, 30, -30, 5, -1, 1, -1, 1, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `uploadsetting` (`UploadId`, `TheaterId`, `TargetName`, `UploadMethod`, `IsActive`, `UploadAddr`, `UploadTime`, `EmailAddr`, `FileFormat`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '95020202', '专资办平台', 'http', 1, 'http://data6.dyj1.chinasarft.gov.cn:98/', '10:00', 'dyj@dyj1.chinasarft.gov.cn', 'xml', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `uploadsetting` (`UploadId`, `TheaterId`, `TargetName`, `UploadMethod`, `IsActive`, `UploadAddr`, `UploadTime`, `EmailAddr`, `FileFormat`, `Created`, `Updated`, `ActiveFlag`) VALUES (2, '95020202', '非加密平台', 'http', 1, 'http://www.zgdypw.cn/report.html', '10:00', 'null', 'xml', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `uploadsetting` (`UploadId`, `TheaterId`, `TargetName`, `UploadMethod`, `IsActive`, `UploadAddr`, `UploadTime`, `EmailAddr`, `FileFormat`, `Created`, `Updated`, `ActiveFlag`) VALUES (3, '95020202', '加密平台', 'https', 1, 'https://www.zgdypw.cn/report.html', '10:00', 'null', '加密xml', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `downloadsetting` (`DownloadId`, `TheaterId`, `SourceName`, `DownloadMethod`, `DownloadAddr`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '95020202', '默认', 'http', 'http://data1.dyj1.chinasarft.gov.cn/****/filminfo****.xml', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

#影片信息相关

INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('001','中国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('002','香港', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('003','台湾', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('004','澳门', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('005','阿富汗', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('006','阿联酋', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('007','阿曼', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('008','阿塞拜疆', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('009','埃塞俄比亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('010','韩国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('011','朝鲜', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('012','日本', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('013','越南', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('014','泰国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('015','缅甸', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('016','新加坡', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('017','印尼', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('018','斯里兰卡', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('019','印度', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('020','巴基斯坦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('021','蒙古', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('022','伊拉克', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('023','黎巴嫩', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('024','土尔其', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('025','菲律宾', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('026','尼泊尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('027','叙利亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('028','马来西亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('029','以色列', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('030','爱尔兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('031','爱沙尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('032','安道尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('033','安哥拉', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('034','安提瓜和巴布达', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('035','澳大利亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('036','新西兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('037','巴巴多斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('038','巴布亚新几内亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('039','巴哈马', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('040','巴拉圭', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('041','埃及', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('042','阿尔及利亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('043','突尼斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('044','巴林', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('045','巴拿马', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('046','白俄罗斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('047','贝宁', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('048','秘鲁', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('049','波斯尼亚和黑塞哥维那', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('050','伯利兹', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('051','美国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('052','墨西哥', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('053','委内瑞拉', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('054','古巴', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('055','哥伦比亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('056','玻利维亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('057','智利', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('058','阿根廷', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('059','加拿大', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('060','巴西', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('061','博茨瓦纳', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('062','不丹', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('063','布基纳法索', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('064','布隆迪', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('065','赤道几内亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('066','德国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('067','东帝汶', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('068','多哥', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('069','多米尼加', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('070','多米尼克', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('071','芬兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('072','挪威', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('073','丹麦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('074','英国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('075','法国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('076','荷兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('077','西班牙', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('078','意大利', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('079','西德', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('080','东德', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('081','瑞士', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('082','奥地利', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('083','波兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('084','捷克', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('085','匈牙利', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('086','罗马尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('087','保加利亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('088','南斯拉夫', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('089','阿尔巴尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('090','希腊', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('091','俄罗斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('092','比利时', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('093','瑞典', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('094','摩洛哥', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('095','冰岛', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('096','南非', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('097','卢森堡', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('098','厄瓜多尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('099','厄立特里亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('100','斐济', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('101','佛得角', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('102','冈比亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('103','刚果', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('104','刚果民主共和国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('105','格林纳达', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('106','格鲁吉亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('107','哥斯达黎加', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('108','圭亚那', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('109','哈萨克斯坦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('110',' 海地', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('111','黑山共和国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('112','洪都拉斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('113','基里巴斯共和国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('114','吉布提', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('115','吉尔吉斯斯坦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('116','几内亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('117','几内亚比绍', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('118','加纳', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('119','加蓬', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('120','柬埔寨', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('121','津巴布韦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('122','喀麦隆', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('123','卡塔尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('124','科摩罗', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('125','科特迪瓦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('126','科威特', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('127','克罗地亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('128','肯尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('129','拉脱维亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('130','莱索托', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('131','老挝', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('132','立陶宛', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('133','利比里亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('134','列支敦士登', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('135','卢旺达', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('136','马达加斯加', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('137','马尔代夫', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('138','马耳他', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('139','马拉维', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('140','马里', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('141','马其顿', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('142','马绍尔群岛', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('143','毛里求斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('144','毛里塔尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('145','孟加拉国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('146','密克罗尼西亚联邦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('147','摩尔多瓦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('148','摩纳哥', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('149','莫桑比克', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('150','纳米比亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('151','南苏丹', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('152','瑙鲁', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('153','尼加拉瓜', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('154','尼日尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('155','尼日利亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('156','帕劳', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('157','葡萄牙', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('158','萨尔瓦多', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('159','萨摩亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('160','塞尔维亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('161','塞拉利昂', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('162','塞内加尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('163','塞浦路斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('164','塞舌尔', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('165','沙特阿拉伯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('166','圣多美和普林西比', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('167','圣基茨和尼维斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('168','圣卢西亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('169','圣马力诺', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('170','圣文森特和格林纳丁斯', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('171','斯洛伐克', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('172','斯洛文尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('173','斯威士兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('174','苏丹', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('175','苏里南', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('176','所罗门群岛', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('177','索马里', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('178','塔吉克斯坦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('179','坦桑尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('180','汤加', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('181','特立尼达和多巴哥', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('182','图瓦卢', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('183','土库曼斯坦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('184','瓦努阿图', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('185','危地马拉', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('186','文莱达鲁萨兰国', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('187','乌干达', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('188','乌克兰', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('189','乌拉圭', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('190','乌兹别克斯坦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('191','牙买加', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('192','亚美尼亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('193','也门', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('194','伊朗', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('195','印度尼西亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('196','约旦', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('197','赞比亚', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('198','乍得', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
INSERT INTO `filmarea` (`FilmAreaId`, `FilmAreaName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('199','中非', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('0', '观摩影片', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('1', '普通', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('2', '普通立体', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('3', '巨幕', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('4', '巨幕立体', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('5', '胶片(进口)', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('6', '其他特种电影', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('7', '其他', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('8', '未知', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('a', '动画片', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('b', '纪录片', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmcategory` (`FilmCategoryId`, `FilmCategoryName`, `Created`, `Updated`, `ActiveFlag`) VALUES ('c', '科教片', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `filmmode` (`FilmModeId`, `FilmModeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '原声', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

#放映计划相关

INSERT INTO `showtype` (ShowTypeId, ShowTypeName, `Created`, `Updated`, `ActiveFlag`) values (1, '普通场', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `showtype` (ShowTypeId, ShowTypeName, `Created`, `Updated`, `ActiveFlag`) values (2, '连场', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `faresetting` (`FareSettingId`, `FareSettingName`, `SinglePrice`, `DoublePrice`, `BoxPrice`, `StudentPrice`, `GroupPrice`, `MemberPrice`, `DiscountPrice`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '全场票价', 0, 0, 0, 0, 0, 0, 0, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `faresetting` (`FareSettingId`, `FareSettingName`, `SinglePrice`, `DoublePrice`, `BoxPrice`, `StudentPrice`, `GroupPrice`, `MemberPrice`, `DiscountPrice`, `Created`, `Updated`, `ActiveFlag`) VALUES (2, '分厅票价', 0, 0, 0, 0, 0, 0, 0, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `faresetting` (`FareSettingId`, `FareSettingName`, `SinglePrice`, `DoublePrice`, `BoxPrice`, `StudentPrice`, `GroupPrice`, `MemberPrice`, `DiscountPrice`, `Created`, `Updated`, `ActiveFlag`) VALUES (3, '时段票价', 0, 0, 0, 0, 0, 0, 0, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `faresetting` (`FareSettingId`, `FareSettingName`, `SinglePrice`, `DoublePrice`, `BoxPrice`, `StudentPrice`, `GroupPrice`, `MemberPrice`, `DiscountPrice`, `Created`, `Updated`, `ActiveFlag`) VALUES (4, '分片票价', 0, 0, 0, 0, 0, 0, 0, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `faresetting` (`FareSettingId`, `FareSettingName`, `SinglePrice`, `DoublePrice`, `BoxPrice`, `StudentPrice`, `GroupPrice`, `MemberPrice`, `DiscountPrice`, `Created`, `Updated`, `ActiveFlag`) VALUES (5, '分场票价', 0, 0, 0, 0, 0, 0, 0, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `faresetting` (`FareSettingId`, `FareSettingName`, `SinglePrice`, `DoublePrice`, `BoxPrice`, `StudentPrice`, `GroupPrice`, `MemberPrice`, `DiscountPrice`, `Created`, `Updated`, `ActiveFlag`) VALUES (6, '区域票价', 0, 0, 0, 0, 0, 0, 0, '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

#影票相关

INSERT INTO `tickettype` (`TicketTypeId`, `TicketTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '单人', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `tickettype` (`TicketTypeId`, `TicketTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (2, '双人', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `tickettype` (`TicketTypeId`, `TicketTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (3, '包厢', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `tickettype` (`TicketTypeId`, `TicketTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (4, '学生', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `tickettype` (`TicketTypeId`, `TicketTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (5, '特价', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `tickettype` (`TicketTypeId`, `TicketTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (6, '团体', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '现金', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (2, '刷卡', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (3, '支票', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (4, '兑换券', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (5, '代用券', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (6, '优惠券', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (7, '会员卡', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (8, '会员卡支付卡', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (9, '积分', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `payment` (`PaymentId`, `PaymentName`, `Created`, `Updated`, `ActiveFlag`) VALUES (10, '赠票', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1); 

INSERT INTO `vouchertype` (`VoucherTypeId`, `VoucherTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (1, '兑换券', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `vouchertype` (`VoucherTypeId`, `VoucherTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (2, '代用券', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);

INSERT INTO `vouchertype` (`VoucherTypeId`, `VoucherTypeName`, `Created`, `Updated`, `ActiveFlag`) VALUES (3, '优惠券', '2012-01-01 0:0:0', '2012-01-01 0:0:0', 1);
