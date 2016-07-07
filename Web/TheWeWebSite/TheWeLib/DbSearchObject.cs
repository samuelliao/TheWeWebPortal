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



}
