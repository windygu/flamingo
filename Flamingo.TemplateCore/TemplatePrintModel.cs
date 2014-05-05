using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flamingo.TemplateCore
{
    public class TemplatePrintModel
    {
        string theaterName;

        public string TheaterName
        {
            get { return theaterName; }
            set { theaterName = value; }
        }

        private string hallName;

        public string HallName
        {
            get { return hallName; }
            set { hallName = value; }
        }

        private string filmName;

        public string FilmName
        {
            get { return filmName; }
            set { filmName = value; }
        }

        private string seatNumberStr;
        /// <summary>
        /// 座位号码 (A排C座) lzz
        /// </summary>
        public string SeatNumberStr
        {
            get { return seatNumberStr; }
            set { seatNumberStr = value; }
        }

        private string rowNumber;

        public string RowNumber
        {
            get { return rowNumber; }
            set { rowNumber = value; }
        }

        private string seatNumber;

        public string SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        string ticketDate;

        public string TicketDate
        {
            get { return ticketDate; }
            set { ticketDate = value; }
        }

        string ticketTime;

        public string TicketTime
        {
            get { return ticketTime; }
            set { ticketTime = value; }
        }

        string ticketPrice;

        public string TicketPrice
        {
            get { return ticketPrice; }
            set { ticketPrice = value; }
        }

        string ticketType;

        public string TicketType
        {
            get { return ticketType; }
            set { ticketType = value; }
        }

        string staffNumber;

        public string StaffNumber
        {
            get { return staffNumber; }
            set { staffNumber = value; }
        }

        string sellTime;

        public string SellTime
        {
            get { return sellTime; }
            set { sellTime = value; }
        }

        //Image barCode;

        //public Image BarCode
        //{
        //    get { return barCode; }
        //    set { barCode = value; }
        //}

        string barCodeStr;

        public string BarCodeStr
        {
            get { return barCodeStr; }
            set { barCodeStr = value; }
        }

        string hallFieldCode;

        public string HallFieldCode
        {
            get { return hallFieldCode; }
            set { hallFieldCode = value; }
        }

        string payType;

        public string PayType
        {
            get { return payType; }
            set { payType = value; }
        }

        string checkingType;

        public string CheckingType
        {
            get { return checkingType; }
            set { checkingType = value; }
        }

        Image icon;

        public Image Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        string ticketid;

        public string TicketId
        {
            get { return ticketid; }
            set { ticketid = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

    }
}
