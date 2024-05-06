using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    internal class SpecificationEvaluator<T> where T :BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery , ISpecifications <T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
            if (spec.Includes != null)
            {
                query =  spec.Includes.Aggregate(query , (curr , includ) => curr.Include(includ));
            }
            return query;
        }
    }
}
