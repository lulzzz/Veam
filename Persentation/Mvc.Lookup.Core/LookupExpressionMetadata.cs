using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NonFactors.Mvc.Lookup
{
    internal static class LookupExpressionMetadata
    {
        public static String GetName(LambdaExpression expression)
        {
            Int32 length = 0;
            Int32 segmentCount = 0;
            Boolean lastIsModel = false;
            Int32 trailingMemberExpressions = 0;

            Expression? part = expression.Body;
            while (part != null)
            {
                switch (part.NodeType)
                {
                    case ExpressionType.Call:
                        lastIsModel = false;

                        MethodCallExpression methodExpression = (MethodCallExpression)part;
                        if (IsSingleArgumentIndexer(methodExpression))
                        {
                            part = methodExpression.Object;
                            trailingMemberExpressions = 0;
                            length += "[99]".Length;
                            segmentCount++;
                        }
                        else
                        {
                            part = null;
                        }

                        break;
                    case ExpressionType.ArrayIndex:
                        part = ((BinaryExpression)part).Left;
                        trailingMemberExpressions = 0;
                        length += "[99]".Length;
                        lastIsModel = false;
                        segmentCount++;

                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpressionPart = (MemberExpression)part;
                        String name = memberExpressionPart.Member.Name;

                        if (name.Contains("__"))
                        {
                            part = null;
                        }
                        else
                        {
                            lastIsModel = String.Equals("model", name, StringComparison.OrdinalIgnoreCase);
                            part = memberExpressionPart.Expression;
                            trailingMemberExpressions++;
                            length += name.Length + 1;
                            segmentCount++;
                        }

                        break;
                    case ExpressionType.Parameter:
                        lastIsModel = false;
                        part = null;

                        break;
                    default:
                        part = null;

                        break;
                }
            }

            if (lastIsModel)
            {
                segmentCount--;
                length -= ".model".Length;
                trailingMemberExpressions--;
            }

            if (trailingMemberExpressions > 0)
                length--;

            if (segmentCount == 0)
                return String.Empty;

            StringBuilder builder = new StringBuilder(length);
            part = expression.Body;
            while (part != null && segmentCount > 0)
            {
                segmentCount--;
                switch (part.NodeType)
                {
                    case ExpressionType.Call:
                        MethodCallExpression methodExpression = (MethodCallExpression)part;

                        InsertIndexerInvocationText(builder, methodExpression.Arguments.Single());

                        part = methodExpression.Object;

                        break;
                    case ExpressionType.ArrayIndex:
                        BinaryExpression binaryExpression = (BinaryExpression)part;

                        InsertIndexerInvocationText(builder, binaryExpression.Right);

                        part = binaryExpression.Left;

                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpression = (MemberExpression)part;
                        String name = memberExpression.Member.Name;

                        builder.Insert(0, name);
                        if (segmentCount > 0)
                            builder.Insert(0, '.');

                        part = memberExpression.Expression;

                        break;
                }
            }

            return builder.ToString();
        }
        public static ModelExplorer GetValue<TModel, TResult>(IHtmlHelper html, Expression<Func<TModel, TResult>> expression)
        {
            Type? containerType = null;
            String? propertyName = null;
            ModelMetadata? metadata = null;
            Boolean legalExpression = false;

            switch (expression.Body.NodeType)
            {
                case ExpressionType.ArrayIndex:
                    legalExpression = true;

                    break;
                case ExpressionType.Call:
                    legalExpression = IsSingleArgumentIndexer(expression.Body);

                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression member = (MemberExpression)expression.Body;
                    propertyName = member.Member is PropertyInfo ? member.Member.Name : null;
                    if (String.Equals(propertyName, "Model", StringComparison.Ordinal) &&
                        member.Type == typeof(TModel) && member.Expression.NodeType == ExpressionType.Constant)
                        return FromModel(html.ViewData, html.MetadataProvider);

                    containerType = member.Expression?.Type;

                    legalExpression = true;

                    break;
                case ExpressionType.Parameter:
                    return FromModel(html.ViewData, html.MetadataProvider);
            }

            if (!legalExpression)
                throw new InvalidOperationException("Resources.TemplateHelpers_TemplateLimitations");

            Object? ModelAccessor(Object container)
            {
                try
                {
                    return expression.Compile()((TModel)container);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }

            if (containerType != null && propertyName != null)
                metadata = html.MetadataProvider.GetMetadataForType(containerType).Properties[propertyName];

            if (metadata == null)
                metadata = html.MetadataProvider.GetMetadataForType(typeof(TResult));

            return html.ViewData.ModelExplorer.GetExplorerForExpression(metadata, ModelAccessor);
        }

        private static Boolean IsSingleArgumentIndexer(Expression expression)
        {
            if (expression is MethodCallExpression method && method.Arguments.Count == 1)
            {
                Type? type = method.Method.DeclaringType;

                if (type?.GetTypeInfo().GetCustomAttribute<DefaultMemberAttribute>(true) is DefaultMemberAttribute member)
                    foreach (PropertyInfo property in type.GetRuntimeProperties())
                        if (String.Equals(member.MemberName, property.Name, StringComparison.Ordinal) && property.GetMethod == method.Method)
                            return true;
            }

            return false;
        }
        private static void InsertIndexerInvocationText(StringBuilder builder, Expression index)
        {
            UnaryExpression converted = Expression.Convert(index, typeof(Object));
            ParameterExpression parameter = Expression.Parameter(typeof(Object), null);
            Expression<Func<Object?, Object>> lambda = Expression.Lambda<Func<Object?, Object>>(converted, parameter);

            builder.Insert(0, ']');
            builder.Insert(0, Convert.ToString(lambda.Compile()(null), CultureInfo.InvariantCulture));
            builder.Insert(0, '[');
        }
        private static ModelExplorer FromModel(ViewDataDictionary data, IModelMetadataProvider provider)
        {
            if (data.ModelMetadata.ModelType == typeof(Object))
                return provider.GetModelExplorerForType(typeof(String), data.Model ?? Convert.ToString(data.Model, CultureInfo.CurrentCulture));

            return data.ModelExplorer;
        }
    }
}
