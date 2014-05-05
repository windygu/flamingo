using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Entity
{
    /// <summary>
    /// debt:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Debt
    {
        public Debt()
        { }
        #region Model
        private string _debtid;
        private int? _customerid;
        private string _buyer;
        private DateTime? _boughtdate;
        private int? _tickets;
        private float? _amount;
        private string _bankbranch;
        private string _bankaccount;
        private string _chequenumber;
        private int? _debtstatus;
        private DateTime? _cleardate;
        private int? _casher;
        private int? _accountant;
        private DateTime _created;
        private DateTime _updated;
        private int _activeflag;
        /// <summary>
        /// 
        /// </summary>
        public string DebtId
        {
            set { _debtid = value; }
            get { return _debtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CustomerId
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Buyer
        {
            set { _buyer = value; }
            get { return _buyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BoughtDate
        {
            set { _boughtdate = value; }
            get { return _boughtdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Tickets
        {
            set { _tickets = value; }
            get { return _tickets; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankBranch
        {
            set { _bankbranch = value; }
            get { return _bankbranch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccount
        {
            set { _bankaccount = value; }
            get { return _bankaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChequeNumber
        {
            set { _chequenumber = value; }
            get { return _chequenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DebtStatus
        {
            set { _debtstatus = value; }
            get { return _debtstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ClearDate
        {
            set { _cleardate = value; }
            get { return _cleardate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Casher
        {
            set { _casher = value; }
            get { return _casher; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Accountant
        {
            set { _accountant = value; }
            get { return _accountant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Created
        {
            set { _created = value; }
            get { return _created; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Updated
        {
            set { _updated = value; }
            get { return _updated; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ActiveFlag
        {
            set { _activeflag = value; }
            get { return _activeflag; }
        }
        #endregion Model
    }
}
