using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.IO
{
    public class FinalInt64
    {

        #region Variables

        public uint Low;
        public uint High;

        #endregion

        #region Builder

        public FinalInt64(uint param1 = 0, uint param2 = 0)
        {
            Low = param1;
            High = param2;
        }

        #endregion

        #region Methods

        public static FinalInt64 FromNumber(long param1)
        {
            return new FinalInt64((uint)param1, (uint)Math.Floor(param1 / 4.294967296E9));
        }

        public long ToNumber()
        {
            return (long)(High * 4.294967296E9 + Low);
        }

        #endregion

    }
}
