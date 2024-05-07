using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecifications <T> : ISpecifications<T> where T: BaseEntity 
    {
        // Criteria >>>>>>>>>>> where
        //      auto Property
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } 
            = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; set; } 
        public Expression<Func<T, object>> OrderByDes { get; set; }
        public Func<Product, bool> Value { get; }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria= criteria;
        }
        public BaseSpecifications() { }
        public void addingInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        public void addingOrder (Expression<Func<T, object>> OrderExpression)
        {
            OrderBy = OrderExpression;
        }
        public void addingOrderDes(Expression<Func<T, object>> OrderExpressionDes)
        {
            OrderByDes = OrderExpressionDes;
        }
    }
}
