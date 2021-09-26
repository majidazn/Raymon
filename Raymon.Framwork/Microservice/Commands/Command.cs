

using Raymon.Framwork.Microservice.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raymon.Framwork.Microservice.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
