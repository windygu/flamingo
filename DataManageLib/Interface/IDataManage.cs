using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCLibrary;
using System.Data.Objects;

namespace Flamingo
{
    /// <summary>
    /// 数据管理接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataManage<T>
    {
        /// <summary>
        /// 获取 DataGridView 列信息表
        /// </summary>
        List<DataGridViewColumnInfo> ColumnInfoList { get; }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        List<T> GetDataList();

        /// <summary>
        /// 获取搜索结果
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="value">关键词</param>
        /// <returns></returns>
        List<T> GetSearchList(string columnName, string value);

        /// <summary>
        /// 生成新的数据项
        /// </summary>
        /// <returns></returns>
        T NewData();

        /// <summary>
        /// 删除数据项
        /// </summary>
        /// <param name="data"></param>
        void DeleteData(T data);

        /// <summary>
        /// 提交所有修改
        /// </summary>
        /// <returns></returns>
        void Save();
    }
}
