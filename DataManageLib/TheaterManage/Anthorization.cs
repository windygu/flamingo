using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;

namespace Flamingo.DataManageLib.TheaterManage
{
    public class Anthorization
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        private FlamingoEntities de;

        /// <summary>
        /// 列信息表
        /// </summary>
        private List<DataGridViewColumnInfo> columnInfoList;

        public Anthorization()
        {
            de = Database.GetNewDataEntity();
        }
        /// <summary>
        /// 获取列信息表
        /// </summary>
        public List<RCLibrary.DataGridViewColumnInfo> ColumnInfoList
        {
            get
            {
                if (this.columnInfoList == null)
                {
                    this.columnInfoList = new List<DataGridViewColumnInfo>();

                    this.columnInfoList.Add(new DataGridViewColumnInfo("AuthorizationId", "授权编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("TheaterId", "影院编号"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("StartDate", "开始时间" ));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("ExpireDate", "截止时间"));
                    this.columnInfoList.Add(new DataGridViewColumnInfo("FeatureFile", "特征文件"));
                    // 设置其它属性
                    for (int i = 0; i < this.columnInfoList.Count; i++)
                    {
                        DataGridViewColumnInfo colInfo = this.columnInfoList[i];
                        // 设置单元格只读
                        switch (colInfo.ColumnName)
                        {
                            case "AuthorizationId":
                            case "TheaterId":
                            case "StartDate":
                            case "ExpireDate":
                            case "FeatureFile":
                                colInfo.IsReadOnly = true;
                                break;
                        }
                        // 保存属性设置
                        this.columnInfoList[i] = colInfo;
                    }
                }
                return this.columnInfoList;

            }
        }

        public List<Authorization> GetDataList()
        {
            return de.Authorization.ToList();
        }
    }
}
