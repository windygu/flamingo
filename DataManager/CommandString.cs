using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataManager
{
    public class CommandString
    {
        #region Template

        public static readonly string DeleteTemplateItem = "Delete from templateItem where templateItemId=?templateItemId";

        public static readonly string GetAllCommonTemplate = "Select * from Template"; //"Select name,TemplateId,bgWidth,bgHeight from Template";

        public static readonly string GetImageBytesById = "select BgImage from Template where TemplateId=(1)";

        public static readonly string GetNewTemplateId = "select TemplateId from Template order by TemplateId desc limit 0,1";

        public static readonly string InsertTemplate = "insert into Template(TemplateId,TemplateName,BgImage,bgWidth,bgHeight,Created,Updated,ActiveFlag,printsettingId,templateType) values(?TemplateId,?TemplateName,?BgImage,?bgWidth,?bgHeight,?Created,?Updated,'1',?printsettingId,?templateType)";

        public static readonly string EditTemplate = "update template set templateName=?templateName,bgimage=?bgimage,bgheight=?bgheight,bgwidth=?bgwidth,updated=?updated,printsettingId=?printsettingId,templateType=?templateType where  TemplateId=?TemplateId";

        public static readonly string GetNextItemId = "select TemplateItemId from Templateitem order by TemplateItemId desc limit 0,1";

        public static readonly string InsertTemplateItem = "insert into templateItem(TemplateItemId,TemplateItemName,xAxis,yAxis,font,fontSize,fontcolour,description,dataItem,templateId,created,Updated,IsOnTemplate,ActiveFlag) " +
            "values(?TemplateItemId,?TemplateItemName,?xAxis,?yAxis,?font,?fontSize,?fontcolour,?description,?dataItem,?templateId,?created,?Updated,'1','1')";

        public static readonly string UpdateTemplateItem = "update templateitem set TemplateItemName=?TemplateItemName,xAxis=?xAxis,yAxis=?yAxis,font=?font,fontSize=?fontSize,fontcolour=?fontcolour,dataItem=?dataItem,Updated=?Updated where templateId=?templateId and templateitemId=?templateitemId";

        public static readonly string GetTemplateItemById = "select TemplateItemId,TemplateItemName,xAxis,yAxis,font,fontSize,fontcolour,description,dataItem from templateItem where templateId=?templateId";

        public static readonly string DeleteTemplateOnly = "delete from Template where templateId=?templateId";

        public static readonly string DeleteTemplateItemByTemplateId = "delete from TemplateItem where templateId=?templateId";

        public static readonly string GetPrintSettingById = "select printSettingId,printModel,settingfile from printsetting where printSettingId=?printSettingId";

        public static readonly string GetNextPrintId = "select printsettingId from printsetting order by printsettingId desc limit 0,1";

        public static readonly string InsertPrintSetting = "insert into printsetting(printSettingId,printModel,settingfile, Created,Updated,ActiveFlag)values(?printSettingId,?printModel,?settingfile,?Created,?Updated,'1')";

        public static readonly string EditPrintSetting = "update printsetting set printModel=?printModel,settingfile=?settingfile,Updated=?Updated where printSettingId=?printSettingId";

        public static readonly string ExsitTemplateExtItem = "select * from commonItem where templateType=?templateType and commonItemName=?commonItemName";

        public static readonly string InsertCustomItem = "insert into commonItem(templateType,commonItemName,created,Updated,ActiveFlag)values(?templateType,?commonItemName,?created,?Updated,'1')";

        public static readonly string DeleteCustomItemByTemplateId = "delete from commonItem where templateType=?templateType";

        public static readonly string GetAllTemplateItemExt = "select commonItemName from commonItem  where templateType=?templateType";

        public static readonly string GetTheaterName = "select theaterName from theater";

        #endregion

        #region Right

        public static readonly string GetRoleNameByRoleId = "select roleName from role where roleId=?roleId";

        public static readonly string GetPermissionIdsByRoleId = "select permissionId from role_permission where roleId=?roleId";

        public static readonly string UpdateRole = "Update role set roleName=?roleName,Updated=?Updated where roleId=?roleId";

        public static readonly string GetNewRoleId = "select roleId from role order by roleId desc limit 0,1";

        public static readonly string InsertRole = "insert into Role(roleId,roleName,Created,Updated,ActiveFlag) values(?roleId,?roleName,?Created,?Updated,'1')";

        public static readonly string HaveRolePermission = "select * from role_permission where roleId=?roleId and permissionId=?permissionId";

        public static readonly string InsertRolePermission = "insert into role_permission(permissionId,roleId,Created,Updated,ActiveFlag) values(?permissionId,?roleId,?Created,?Updated,'1')";

        public static readonly string DeleteRoleByRoleId = "delete from role where roleId=?roleId";

        public static readonly string DeleteRolePermissionByRoleId = "delete from role_permission where roleId=?roleId";

        public static readonly string GetRoleIds = "select roleId from role";

        public static readonly string GetAllUserBasicInfo = "select userId,userName,employeeName,password,employeeId,mobile,isActive from user";

        public static readonly string GetAllRolesIdByUserID = "select roleId from user_role where userId=?userId";

        public static readonly string GetAllRolePermissionsByUserId = "select roleId,permissionId from user_permission  where userId=?userId";

        public static readonly string GetUserId = "select userId from user order by userId desc limit 0,1";

        public static readonly string InsertUserBasicInfo = "insert into user(userId,userName,employeeName,password,employeeId,mobile,isActive,created,updated,activeFlag) "
            + "values(?userId,?userName,?employeeName,?password,?employeeId,?mobile,?isActive,?created,?updated,'1')";

        public static readonly string UpdateUserBasicInfo = "update user set userName=?userName,employeeName=?employeeName,password=?password,employeeId=?employeeId,mobile=?mobile,updated=?updated,isActive=?isActive where userId=?userId";

        public static readonly string HaveUserRole = "select * from user_role where roleId=?roleId and userId=?userId";

        public static readonly string InsertUserRole = "insert into user_role(userId,roleId,Created,Updated,ActiveFlag) values(?userId,?roleId,?Created,?Updated,'1')";

        public static readonly string DeleteUserRoleByRoleId = "delete from user_role where userId=?userId";

        public static readonly string DeleteUserByUserId = "delete from user where userId=?userId";

        public static readonly string DeleteUserRoleByUserId = "delete from user_role where userId=?userId";

        public static readonly string DeleteUserPermissionByUserId = "delete from user_permission where userId=?userId";

        public static readonly string HaveUserRolePermission = "select * from user_Permission where roleId=?roleId and userId=?userId and permissionId=?permissionId";

        public static readonly string InsertUserRolePermission = "insert into user_Permission(userId,permissionId,roleId,Created,Updated,ActiveFlag) values(?userId,?permissionId,?roleId,?Created,?Updated,'1')";

        public static readonly string DeleteUserRolePermissionByUserRoleId = "delete from user_Permission where userId=?userId and roleId=?roleId";

        public static readonly string UserNameExsit = "select * from user where userName=?userName";

        public static readonly string Valid = "select userId from user where userName=?userName and password=?password and isActive='1'";

        public static readonly string UserBasicInfoByUserId = "select userId,userName,password,employeeId,employeeName,mobile,isActive from user where userId=?userId";

        public static readonly string GetUsersByName = "select userId,userName,employeeName,password,employeeId,mobile,isActive from user where userName like '(1)'";

        public static readonly string HaveExsitUserName = "select userId from user where userId!=?userId and userName=?userName";

        public static readonly string ExistRightPassword = "select userId from user where userId=?userId and password=?password";

        public static readonly string GetRoleIdsMatchTrue = "select roleId from role where roleName='?roleName'";

        public static readonly string GetRoleIdsMatchFalse = "select roleId from role where roleName like '%?roleName%'";

        public static readonly string GetUsersByRoleId = "select user.userId,userName,employeeName,password,employeeId,mobile,user.isActive from user,user_role where user.userId=user_role.userId and user_role.roleId=?roleId";

        public static readonly string DeleteUserPermissionByRole = "delete from user_permission where userId=?userId and roleId=?roleId";

        public static readonly string GetEmpId = "select employeeId from user order by employeeId desc"; 

        #endregion

        public static string ConnectionString
        {
            get
            {
                return Flamingo.Common.ConfigHelper.GetConnectionString("ConnectionString");
            }
        }
    }
}
