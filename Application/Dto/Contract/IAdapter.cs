using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Contract
{
    /// <summary>
    /// Copies one value from one type to another
    /// </summary>
    public interface IAdapter<T1, TResult> where TResult : class
    {
        TResult Transform(T1 origin);
    }

    /// <summary>
    /// Copies one value from one type to another
    /// </summary>
    public interface IAdapter<T1, T2, TResult> where TResult : class
    {
        TResult Transform(T1 origin, T2 origin2);
    }

    /// <summary>
    /// Copies one value from one type to another
    /// </summary>
    public interface IAdapter<T1, T2, T3, TResult> where TResult : class
    {
        TResult Transform(T1 origin, T2 origin2, T3 origin3);
    }
}
