#功能模块
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (1,'放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (2,'影院售票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (3,'统计分析','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (4,'影院信息管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (5,'影片信息管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (6,'票券管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (7,'座位图工具','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (8,'票版工具','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (9,'用户管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (10,'卖品部管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (11,'多屏显示','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (12,'员工考勤','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (13,'自动售票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (14,'会议场租','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (15,'语音预定','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into module (moduleId,moduleName,Created,Updated,ActiveFlag) Values (16,'会员系统','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#放映计划
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (100,1,'放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (101,1,'查看放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (102,1,'新建放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (103,1,'编辑放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (104,1,'复制放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (105,1,'保存放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (106,1,'删除放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (107,1,'打印放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (108,1,'开售放映计划','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (109,1,'票价设置','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
 insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (110,1,'影片设置','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (111,1,'快速查询','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (112,1,'基本查询','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#影院售票
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (200,2,'影院售票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
#售票类型
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (201,2,'零售票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (202,2,'学生票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (203,2,'团体票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (204,2,'特价票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
#支付方式
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (205,2,'现金','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (206,2,'支票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (207,2,'优惠券','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (208,2,'兑换券','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (209,2,'代用券','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (210,2,'会员卡','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (211,2,'会员卡支付卡','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (212,2,'积分','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (213,2,'赠票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
#售票操作
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (214,2,'售票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (215,2,'预订','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (216,2,'预定出票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (217,2,'解除预订','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (218,2,'预订查询','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (219,2,'锁定','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (220,2,'解锁','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (221,2,'单张退票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (222,2,'批量退票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
#售票设置
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (223,2,'售票设置','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (224,2,'放大','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (225,2,'还原','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (226,2,'翻转','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (227,2,'背景色设置','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (228,2,'切票设置','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (229,2,'验票','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (230,2,'售票查询','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (231,2,'人工补登','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (232,2,'补打','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#统计分析
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (300,3,'统计分析','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (301,3,'统计报表','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (302,3,'经营报表','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (303,3,'基础查询','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (304,3,'组合查询','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (305,3,'综合报表','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (306,3,'图形分析','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (307,3,'中影专用报表','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (308,3,'常用报表','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#影院信息管理
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (400,4,'影院信息管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (401,4,'影院信息维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (402,4,'影厅信息维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (403,4,'授权管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (404,4,'税费维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (405,4,'上报单位维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (406,4,'数据上报','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (407,4,'经营时间维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (408,4,'场次类型维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (409,4,'票价维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (410,4,'特价维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (411,4,'系统备份','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (412,4,'系统恢复','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#影片信息管理
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (500,5,'影片信息管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (501,5,'影片信息维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (502,5,'影片产地维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (503,5,'影片类别维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (504,5,'影片下载','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (505,5,'影片下载地址维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (506,5,'放映模式维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#票券管理
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (600,6,'票券管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (601,6,'客户信息维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (602,6,'客户类型维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (603,6,'欠款维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (604,6,'票券批次维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (605,6,'票券类型维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (606,6,'票券券类维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (607,6,'票券查询统计','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#座位图工具
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (700,7,'座位图工具','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (701,7,'座位图导入','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (702,7,'区域编辑','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (703,7,'座位类型编辑','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#票版工具
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (800,8,'票版工具','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (801,8,'新建票版','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (802,8,'编辑票版','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (803,8,'删除票版','2012-01-01 0:0:0','2012-01-01 0:0:0',1);

#用户管理
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (900,9,'用户管理','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (901,9,'本人信息维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (902,9,'基本信息维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (903,9,'角色权限维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (904,9,'角色用户维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);
insert into permission(permissionId,moduleId,permissionName,Created,Updated,ActiveFlag)
 Values (905,9,'用户权限维护','2012-01-01 0:0:0','2012-01-01 0:0:0',1);


#用户权限相关
INSERT INTO `user` VALUES ('1', 'flamingoadmin', '21232f297a57a5a743894a0e4a801fc3', '火烈鸟3.0系统超级管理员', '0000', null, null, '1', '2012-01-01 0:0:0', '2012-01-01 0:0:0', '1');
INSERT INTO `role` VALUES ('1', '全体用户', '2012-01-01 0:0:0', '2012-01-01 0:0:0', '1');
INSERT INTO `user_role` VALUES ('1', '1', '1', '2012-01-01 0:0:0', '2012-01-01 0:0:0', '1');
INSERT INTO `role_permission` VALUES (1,100,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(2,101,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(3,102,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(4,103,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(5,104,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(6,105,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(7,106,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(8,107,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(9,108,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(10,109,1,'2012-02-08 18:49:46','2012-02-08 18:49:46',1),(11,110,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(12,111,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(13,112,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(14,200,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(15,201,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(16,202,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(17,203,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(18,204,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(19,205,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(20,206,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(21,207,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(22,208,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(23,209,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(24,210,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(25,211,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(26,212,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(27,213,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(28,214,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(29,215,1,'2012-02-08 18:49:47','2012-02-08 18:49:47',1),(30,216,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(31,217,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(32,218,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(33,219,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(34,220,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(35,221,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(36,222,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(37,223,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(38,224,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(39,225,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(40,226,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(41,227,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(42,228,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(43,229,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(44,230,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(45,231,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(46,232,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(47,300,1,'2012-02-08 18:49:48','2012-02-08 18:49:48',1),(48,301,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(49,302,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(50,303,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(51,304,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(52,305,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(53,306,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(54,307,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(55,308,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(56,400,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(57,401,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(58,402,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(59,403,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(60,404,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(61,405,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(62,406,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(63,407,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(64,409,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(65,408,1,'2012-02-08 18:49:49','2012-02-08 18:49:49',1),(66,410,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(67,411,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(68,412,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(69,500,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(70,501,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(71,502,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(72,503,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(73,504,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(74,505,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(75,506,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(76,600,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(77,601,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(78,602,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(79,603,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(80,604,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(81,605,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(82,606,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(83,607,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(84,700,1,'2012-02-08 18:49:50','2012-02-08 18:49:50',1),(85,701,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(86,702,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(87,703,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(88,800,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(89,801,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(90,802,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(91,803,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(92,900,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(93,901,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(94,902,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(95,903,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(96,904,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1),(97,905,1,'2012-02-08 18:49:51','2012-02-08 18:49:51',1);
INSERT INTO `user_permission` VALUES (1,1,100,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(2,1,101,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(3,1,102,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(4,1,103,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(5,1,104,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(6,1,105,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(7,1,106,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(8,1,107,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(9,1,108,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(10,1,109,1,'2012-02-08 18:51:01','2012-02-08 18:51:01',1),(11,1,110,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(12,1,111,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(13,1,112,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(14,1,200,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(15,1,201,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(16,1,202,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(17,1,203,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(18,1,204,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(19,1,205,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(20,1,206,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(21,1,207,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(22,1,208,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(23,1,209,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(24,1,210,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(25,1,211,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(26,1,212,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(27,1,213,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(28,1,214,1,'2012-02-08 18:51:02','2012-02-08 18:51:02',1),(29,1,215,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(30,1,216,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(31,1,217,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(32,1,218,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(33,1,219,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(34,1,220,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(35,1,221,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(36,1,222,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(37,1,223,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(38,1,224,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(39,1,225,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(40,1,226,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(41,1,227,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(42,1,228,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(43,1,229,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(44,1,230,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(45,1,231,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(46,1,232,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(47,1,300,1,'2012-02-08 18:51:03','2012-02-08 18:51:03',1),(48,1,301,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(49,1,302,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(50,1,303,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(51,1,304,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(52,1,305,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(53,1,306,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(54,1,307,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(55,1,308,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(56,1,400,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(57,1,401,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(58,1,402,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(59,1,403,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(60,1,404,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(61,1,405,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(62,1,406,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(63,1,407,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(64,1,409,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(65,1,408,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(66,1,410,1,'2012-02-08 18:51:04','2012-02-08 18:51:04',1),(67,1,411,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(68,1,412,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(69,1,500,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(70,1,501,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(71,1,502,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(72,1,503,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(73,1,504,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(74,1,505,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(75,1,506,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(76,1,600,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(77,1,601,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(78,1,602,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(79,1,603,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(80,1,604,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(81,1,605,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(82,1,606,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(83,1,607,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(84,1,700,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(85,1,701,1,'2012-02-08 18:51:05','2012-02-08 18:51:05',1),(86,1,702,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(87,1,703,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(88,1,800,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(89,1,801,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(90,1,802,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(91,1,803,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(92,1,900,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(93,1,901,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(94,1,902,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(95,1,903,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(96,1,904,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1),(97,1,905,1,'2012-02-08 18:51:06','2012-02-08 18:51:06',1);