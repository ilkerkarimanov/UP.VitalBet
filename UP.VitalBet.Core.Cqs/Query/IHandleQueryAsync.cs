﻿using System.Threading.Tasks;

namespace UP.VitalBet.Core.Cqs.Query
{
    public interface IHandleQueryAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}