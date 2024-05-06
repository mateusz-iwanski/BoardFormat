﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public interface ICabinetResize
    {
        public ICabinetResize ResizeCabinet(ICabinetSize<float> size);
    }
}
