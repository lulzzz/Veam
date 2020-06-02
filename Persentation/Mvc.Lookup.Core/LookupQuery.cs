using System;
using System.Linq;
using System.Linq.Expressions;

namespace NonFactors.Mvc.Lookup
{
    public static class LookupQuery
    {
        public static Boolean IsOrdered(IQueryable models)
        {
            LookupExpressionVisitor expression = new LookupExpressionVisitor();
            expression.Visit(models.Expression);

            return expression.Ordered;
        }

        private class LookupExpressionVisitor : ExpressionVisitor
        {
            public Boolean Ordered { get; private set; }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.DeclaringType != typeof(Queryable))
                    return base.VisitMethodCall(node);

                if (!node.Method.Name.StartsWith("OrderBy"))
                    return base.VisitMethodCall(node);

                Ordered = true;

                return node;
            }
        }
    }
}
