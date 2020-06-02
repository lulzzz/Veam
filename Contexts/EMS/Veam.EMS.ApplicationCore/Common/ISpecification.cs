using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Veam.EMS.ApplicationCore.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Filter { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
