using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheWeLib
{
    public class DbSearchObject
    {
        public string AttrName;
        public AtrrTypeItem AttrType;
        public string AttrValue;
        public AttrSymbolItem AttrSymbol;
        public DbSearchObject() { }
        public DbSearchObject(string name, AtrrTypeItem type, AttrSymbolItem symbol, string value)
        {
            AttrName = name;
            AttrSymbol = symbol;
            AttrType = type;
            AttrValue = value;
        }
    }

    public enum AtrrTypeItem
    {
        Integer = 0,
        String = 1,
        DateTime = 2,
        Date = 3,
        Bit = 4
    }

    public enum AttrSymbolItem
    {
        Equal = 0,
        Like = 1,
        Less = 3,
        Greater = 4,
        LessOrEqual = 5,
        GreaterOrEqual = 6,
        NotEaqual = 7
    }

    public enum MsSqlTable
    {
        Accessory = 0,
        AccessoryMan = 1,
        AccessoryOther = 2,
        AccessoryRingPillow = 3,
        ApprovalRating = 4,
        Area = 5,
        Church = 6,
        ConferenceInfo = 7,
        ConferenceItem = 8,
        Consultation = 9,
        ConsultLocation = 10,
        ConsultServiceItem = 11,
        Country = 15,
        Currency = 16,
        Customer = 17,
        Dress = 18,
        DressBack = 19,
        DressBouquet = 20,
        DressBracelet = 21,
        DressCategory = 22,
        DressClogs = 23,
        DressColor = 24,
        DressCorsage = 25,
        DressEarring = 26,
        DressFitting = 27,
        DressGloves = 28,
        DressHeadwear = 29,
        DressImg = 30,
        DressMaterial = 31,
        DressNecklace = 32,
        DressNeckline = 33,
        DressOther = 34,
        DressShawl = 35,
        DressShoulder = 36,
        DressStatusCode = 37,
        DressSupplier = 38,
        DressTrailing = 39,
        DressType = 40,
        DressUseStatus = 41,
        DressVeil = 42,
        DressWorn = 43,
        Employee = 44,
        FunctionItem = 45,
        HairStyleCategory = 46,
        HairStyleItem = 47,
        InforSourceItem = 48,
        InfoSource = 49,
        ItemUnit = 50,
        Messenger = 51,
        OrderInfo = 52,
        OrderOutput = 53,
        OrderResponsible = 54,
        Partner = 55,
        PerformItem = 56,
        PerformList = 57,
        Permission = 58,
        PermissionItem = 59,
        PermissonGroup = 60,
        ProductSet = 61,
        ProductSetServiceItem = 62,
        ReadMe = 63,
        RelDressAccessory = 64,
        RoomStyle = 65,
        ScheduleChurch = 66,
        ScheduleEmployee = 67,
        ScheduleEventDetail = 68,
        ScheduleItemCategory = 69,
        ServiceItem = 70,
        ServiceItemCategory = 71,
        ServiceWindow = 72,
        Store = 73,
        WeddingPhotoConsultation = 74,
        vwEN_Employee = 75,
        vwEN_Partner = 76,
        vwEN_Customer = 77,
        SnsMgt = 78,
        vwEN_Consultation
    }

    public enum LanguageCode
    {         
        zhTW =0,
        zhCN = 1,
        en = 2,
        jaJP = 3
    }



}
