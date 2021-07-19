using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.IO
{
    public class FinalUInt64
    {

        #region Variables

        public uint Low;
        public uint High;

        #endregion

        #region Builder

        public FinalUInt64(uint param1 = 0, uint param2 = 0)
        {
            Low = param1;
            High = param2;
        }

        #endregion

        #region Methods

        public static FinalUInt64 FromNumber(ulong param1)
        {
            return new FinalUInt64((uint)param1, (uint)Math.Floor(param1 / 4.294967296E9));
        }

        public ulong ToNumber()
        {
            return (ulong)(this.High * 4.294967296E9 + Low);
        }

        #endregion

    }
}
