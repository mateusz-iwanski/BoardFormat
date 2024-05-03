﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterBuilder
{
    public class DefaultUnitsBuilder : BaseCutterBuilder
    {
        public DataGroupInput Build() => 
            new DefaultUnits(
                    _length: settings.CutterDefaultsUnits.length,
                    _field: settings.CutterDefaultsUnits.field,
                    _angle: settings.CutterDefaultsUnits.angle
                    );
    }
}
