using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.TemplateCore
{
    public class TemplatePrintModelVoucher
    {
        string voucherName = "";

        public string VoucherName
        {
            get { return voucherName; }
            set { voucherName = value; }
        }

        string voucherPrice = "";

        public string VoucherPrice
        {
            get { return voucherPrice; }
            set { voucherPrice = value; }
        }

        string voucheTheaterName = "";

        public string VoucheTheaterName
        {
            get { return voucheTheaterName; }
            set { voucheTheaterName = value; }
        }

        string releaseDate = "";

        public string ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        string expireDate = "";

        public string ExpireDate
        {
            get { return expireDate; }
            set { expireDate = value; }
        }

        string desciption = "";

        public string Desciption
        {
            get { return desciption; }
            set { desciption = value; }
        }

        string voucherType = "";

        public string VoucherType
        {
            get { return voucherType; }
            set { voucherType = value; }
        }

        string voucherSubType = "";

        public string VoucherSubType
        {
            get { return voucherSubType; }
            set { voucherSubType = value; }
        }

        string serialNumber;

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        } 
    }
}
