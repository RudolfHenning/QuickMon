﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface ICollector : IAgent
    {
        MonitorState GetState();
        MonitorState CurrentState { get; set; }
        bool PrimaryUIValue { get; set; }
    }
}
