﻿using API.Contracts.Cat.Messaging;
using WCF.Database;
using WCF.Database.Data;
using WCF.Database.Repository;
using WCF.LIB;

namespace WCF.Handler.Cat
{
    public class GetCatHandler : RequestHandler<GetCatReq, GetCatResp>
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IHelloWorldRepositoryFactory _repositoryFactory;
        private readonly IHelloWorldMapperFactory _mapperFactory;

        public GetCatHandler(IUnitOfWorkFactory unitOfWorkFactory, IHelloWorldRepositoryFactory repositoryFactory, IHelloWorldMapperFactory mapperFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
            _mapperFactory = mapperFactory;
        }
        public override GetCatResp Process(GetCatReq req)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForHelloWorld(false))
            {
                return new GetCatResp { Cat = _mapperFactory.CreateCatMapper(unitOfWork).Map(_repositoryFactory.CreateCatRepository(unitOfWork).LoadAll()[0]) };
            }
        }
    }
}
