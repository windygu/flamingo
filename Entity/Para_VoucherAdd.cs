using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Entity
{
    public class Para_VoucherAdd
    {
        public Para_VoucherAdd(List<Flamingo.Entity.Para_Voucher> list)
        {
            if (list.Count == 0)
                return;
            StringBuilder sb_voucherids = new StringBuilder();
            StringBuilder sb_prices = new StringBuilder();
            //StringBuilder sb_barcodes = new StringBuilder();   //==sb_voucherids
            StringBuilder sb_voucherbatchids = new StringBuilder();
            foreach (Flamingo.Entity.Para_Voucher v in list)
            {
                sb_voucherids.Append(v.VoucherId);
                sb_voucherids.Append("|");

                sb_prices.Append(v.Price.ToString());
                sb_prices.Append("|");

                sb_voucherbatchids.Append(v.VoucherBatchId);
                sb_voucherbatchids.Append("|");
            }
            _voucherids = sb_voucherids.Remove(sb_voucherids.Length - 1, 1).ToString();
            _prices = sb_prices.Remove(sb_prices.Length - 1, 1).ToString();
            _barcodes = _voucherids;
            _voucherbatchids = sb_voucherbatchids.Remove(sb_voucherbatchids.Length - 1, 1).ToString();
        }
        #region Model
        private string _voucherids;
        private string _prices;
        private string _barcodes;
        private int _vouchertypeid;
        private string _voucherbatchids;

        private int? _paymentmethodid;
        private int? _tickettype;
        private float _ticketprice;
        private string _barcode;
        private int? _soldby;
        private string _showplanid;
        private string _seatid;
        private int? _templateid;
        private string _filmid;
        private string _TicketId;
        /// <summary>
        /// 影票ID
        /// </summary>
        public string TicketId
        {
            set { _TicketId = value; }
            get { return _TicketId; }
        }
        /// <summary>
        /// 票券ID(编号)
        /// </summary>
        public string VoucherIds
        {
            get { return _voucherids; }
        }
        /// <summary>
        /// 票券面值
        /// </summary>
        public string Prices
        {
            get { return _prices; }
        }
        /// <summary>
        /// 票券条形码
        /// </summary>
        public string BarCodes
        {
            set { _barcodes = value; }
            get { return _barcodes; }
        }
        /// <summary>
        /// 票券类型ID
        /// </summary>
        public int VoucherTypeId
        {
            set { _vouchertypeid = value; }
            get { return _vouchertypeid; }
        }
        /// <summary>
        /// 票券批次ID 集合 |
        /// </summary>
        public string VoucherBatchIds
        {
            get { return _voucherbatchids; }
        }
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public int? PaymentMethodId
        {
            set { _paymentmethodid = value; }
            get { return _paymentmethodid; }
        }
        /// <summary>
        /// 售票类型
        /// </summary>
        public int? TicketType
        {
            set { _tickettype = value; }
            get { return _tickettype; }
        }
        /// <summary>
        /// 票价
        /// </summary>
        public float TicketPrice
        {
            set { _ticketprice = value; }
            get { return _ticketprice; }
        }
        /// <summary>
        /// 影票条形码
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 售票员
        /// </summary>
        public int? SoldBy
        {
            set { _soldby = value; }
            get { return _soldby; }
        }
        /// <summary>
        /// 场次ID
        /// </summary>
        public string ShowPlanId
        {
            set { _showplanid = value; }
            get { return _showplanid; }
        }
        /// <summary>
        /// 座位ID
        /// </summary>
        public string SeatId
        {
            set { _seatid = value; }
            get { return _seatid; }
        }
        /// <summary>
        /// 模版ID
        /// </summary>
        public int? TemplateId
        {
            set { _templateid = value; }
            get { return _templateid; }
        }
        /// <summary>
        /// 影片ID
        /// </summary>
        public string FilmId
        {
            set { _filmid = value; }
            get { return _filmid; }
        }

        private string groupTicketId;

        public string GroupTicketId
        {
            get { return groupTicketId; }
            set { groupTicketId = value; }
        }
        private string groupTicketPrice;

        public string GroupTicketPrice
        {
            get { return groupTicketPrice; }
            set { groupTicketPrice = value; }
        }
        private string groupSeatStatusId;

        public string GroupSeatStatusId
        {
            get { return groupSeatStatusId; }
            set { groupSeatStatusId = value; }
        }
        private string groupTicketType;

        public string GroupTicketType
        {
            get { return groupTicketType; }
            set { groupTicketType = value; }
        }
        private string groupShowPlanId;

        public string GroupShowPlanId
        {
            get { return groupShowPlanId; }
            set { groupShowPlanId = value; }
        }
        private string groupFilmId;

        public string GroupFilmId
        {
            get { return groupFilmId; }
            set { groupFilmId = value; }
        }
        private int groupCount;

        public int GroupCount
        {
            get { return groupCount; }
            set { groupCount = value; }
        }
        #endregion Model
    }
}
