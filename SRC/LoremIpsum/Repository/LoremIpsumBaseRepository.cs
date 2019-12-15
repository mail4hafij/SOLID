using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SRC.LIB;

namespace SRC.LoremIpsum.Repository
{
    public abstract class LoremIpsumBaseRepository
    {
        protected readonly ILoremIpsumUnitOfWork _unitOfWork;

        // see http://stackoverflow.com/questions/5851497/static-fields-in-a-base-class-and-derived-classes
        private static readonly IDictionary<Type, ILog> _logs = new Dictionary<Type, ILog>();

        private static readonly object _lock = new object();

        protected ILog Log
        {
            get
            {
                var type = GetType();
                var result = _logs.GetOrDefault(type);
                lock (_lock)
                {
                    if (result == null)
                    {
                        result = LogManager.GetLogger(type);
                        _logs.AddOrReplace(type, result);
                    }
                }
                return result;
            }
        }

        protected LoremIpsumBaseRepository(ILoremIpsumUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected virtual bool Exists<TEntity>(Expression<Func<TEntity, bool>> findExpression) where TEntity : class, IEntity
        {
            return _unitOfWork.Context.Set<TEntity>().Any(findExpression);
        }

        protected virtual List<T> GetProjected<T, TEntity>(Expression<Func<TEntity, bool>> findExpression, Expression<Func<TEntity, T>> selectExpression) where TEntity : class, IEntity
                                                                                                                                                           where T : class
        {
            return _unitOfWork.Context.Set<TEntity>().AsNoTracking().Where(findExpression).Select(selectExpression).ToList();
        }

        protected virtual IList<TEntity> GetEntities<TEntity>(Expression<Func<TEntity, bool>> findExpression, params Expression<Func<TEntity, object>>[] includeExpressions) where TEntity : class, IEntity
        {
            var allotmentApplicantQueriable = _unitOfWork.Context.Set<TEntity>().AsQueryable();

            if (includeExpressions != null && includeExpressions.Length > 0)
            {
                allotmentApplicantQueriable = includeExpressions.Aggregate(allotmentApplicantQueriable, (current, include) => current.Include(include));
            }

            return allotmentApplicantQueriable.Where(findExpression).ToList();
        }
    }
}
