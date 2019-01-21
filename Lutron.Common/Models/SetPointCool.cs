using System;

namespace Lutron.Common.Models
{
    public class SetPointCool
    {
        private readonly int _setPointCool;

        public SetPointCool(int setPointCool)
        {
            if (setPointCool < 32) throw new ArgumentException(nameof(setPointCool));
            if (setPointCool > 212 && setPointCool != 255) throw new ArgumentException(nameof(setPointCool));
            _setPointCool = setPointCool;
        }

        public override string ToString()
        {
            return $"{_setPointCool}";
        }
    }
}