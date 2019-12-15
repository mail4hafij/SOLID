using log4net;
using System;
using System.Collections.Generic;
using SRC.LIB;

namespace SRC.LoremIpsum.Logic
{
    public abstract class LoremIpsumBaseLogic
    {
        protected readonly ILoremIpsumUnitOfWork _unitOfWork;
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

        protected LoremIpsumBaseLogic(ILoremIpsumUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
