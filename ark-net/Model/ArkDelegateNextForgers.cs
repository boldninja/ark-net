﻿using System.Collections.Generic;

namespace ArkNet.Model
{
    public class ArkDelegateNextForgers
    {
        public long CurrentBlock { get; set; }
        public long CurrentSlot { get; set; }
        public List<string> Delegates { get; set; }
    }
}