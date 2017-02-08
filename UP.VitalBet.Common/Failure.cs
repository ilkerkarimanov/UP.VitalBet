using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UP.VitalBet.Core
{
    public class Failure : Exception, IFailure
    {
        public IEnumerable<string> Errors { get; }

        public Failure()
        {
        }

        public Failure(string message) : base(message)
        {
        }

        public Failure(string message, params string[] Errors) : base(message)
        {
            this.Errors = Errors;
        }

        public Failure(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Failure(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
