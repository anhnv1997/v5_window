using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class SystemConfig
    {
        public string id { get; set; }
        public string companyName { get; set; }
        public string companyAddress { get; set; }
        public string companyTelephone { get; set; }
        public string companyFax { get; set; }
        public string logoFileKey { get; set; }
        public string companyTax { get; set; }
        public string InvoiceTemplateCode { get; set; }
        public string InvoiceTypeCode { get; set; }
        public string InvoiceSymbolCode { get; set; }
        public float taxRate { get; set; }
        public string projectName { get; set; }
        public string projectCode { get; set; }
        public int chargeType { get; set; }
        public int eventOutApproval { get; set; }
    }

    public class PhysicalFileSetting
    {
        // 1: Hiển thị ảnh tại index
        // 2: Hiển thị trong modal
        public int DisplayType { get; set; } = 2;

        // 1: Theo đường dẫn
        // 2: Minio
        public int Type { get; set; } = 2;

        public string Endpoint { get; set; } = string.Empty;
        public string ImageBucketName { get; set; } = "parking-images";
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;

        public string Host { get; set; } = string.Empty;
        public string EventInFilePath { get; set; } = string.Empty;
        public string EventOutFilePath { get; set; } = string.Empty;
    }

    public class AddSystemConfigModel
    {
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string Tel { get; set; } = "";
        public string Fax { get; set; } = "";
        public string FeeName { get; set; } = "";
        public bool EnableDeleteCardFailed { get; set; } = false;
        public string SystemCode { get; set; } = "";
        public string KeyA { get; set; } = "";
        public string KeyB { get; set; } = "";
        public bool EnableSoundAlarm { get; set; } = false;
        public string Logo { get; set; } = "";
        public bool EnableAlarmMessageBox { get; set; } = false;
        public bool EnableAlarmMessageBoxIn { get; set; } = false;
        public string Tax { get; set; } = "";
        public int DelayTime { get; set; } = 0;
        public string Para1 { get; set; } = "";
        public string Para2 { get; set; } = "";
    }

    public class UpdateSystemConfigModel
    {
        public string Id { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string Tel { get; set; } = "";
        public string Fax { get; set; } = "";
        public string FeeName { get; set; } = "";
        public bool EnableDeleteCardFailed { get; set; } = false;
        public string SystemCode { get; set; } = "";
        public string KeyA { get; set; } = "";
        public string KeyB { get; set; } = "";
        public bool EnableSoundAlarm { get; set; } = false;
        public string Logo { get; set; } = "";
        public bool EnableAlarmMessageBox { get; set; } = false;
        public bool EnableAlarmMessageBoxIn { get; set; } = false;
        public string Tax { get; set; } = "";
        public int DelayTime { get; set; } = 0;
        public string Para1 { get; set; } = "";
        public string Para2 { get; set; } = "";
        public bool IsAuthInView { get; set; } = false;
    }
}
