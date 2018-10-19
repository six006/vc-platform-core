using System;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.PricingModule.Core.Model;
using linq = System.Linq.Expressions;

namespace VirtoCommerce.PricingModule.Data.DynamicExpressions.Common.Conditions.Browse
{
    //Shopper searched for phrase [] in store
    public class ConditionStoreSearchedPhrase : MatchedConditionBase
    {
        public override linq.Expression<Func<IEvaluationContext, bool>> GetConditionExpression()
        {
            var paramX = linq.Expression.Parameter(typeof(IEvaluationContext), "x");
            var castOp = linq.Expression.MakeUnary(linq.ExpressionType.Convert, paramX, typeof(EvaluationContextBase));
            var propertyValue = linq.Expression.Property(castOp, typeof(EvaluationContextBase).GetProperty(ReflectionUtility.GetPropertyName<EvaluationContextBase>(x => x.ShopperSearchedPhraseInStore)));

            var result = linq.Expression.Lambda<Func<IEvaluationContext, bool>>(GetConditionExpression(propertyValue), paramX);
            return result;
        }
    }
}
