using System.Collections.Generic;

namespace UP.VitalBet.Common
{

    public interface IFailure
    {
        IEnumerable<string> Errors { get; }
    }
    public interface IResult: IFailure
    {
        bool Succeeded { get; }

        string ToString();
    }
}