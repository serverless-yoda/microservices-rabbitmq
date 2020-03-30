﻿using RMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }
        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
