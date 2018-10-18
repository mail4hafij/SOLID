using API.Contracts.Dog.Messaging;
using API.Contracts.Tiger.Messaging;
using WCF.LoremIpsum.Data;
using WCF.LoremIpsum.Repository;
using WCF.LIB;

namespace WCF.Handler.Dog
{
    public class GetTigerHandler : RequestHandler<GetTigerReq, GetTigerResp>
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILoremIpsumRepositoryFactory _repositoryFactory;
        private readonly ILoremIpsumMapperFactory _mapperFactory;

        public GetTigerHandler(IUnitOfWorkFactory unitOfWorkFactory, ILoremIpsumRepositoryFactory repositoryFactory, ILoremIpsumMapperFactory mapperFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
            _mapperFactory = mapperFactory;
        }
        public override GetTigerResp Process(GetTigerReq req)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForLoremIpsum(false))
            {
                return new GetTigerResp { Tiger = _mapperFactory.CreateTigerMapper(unitOfWork).Map(_repositoryFactory.CreateTigerRepository(unitOfWork).LoadAll()[0]) };
            }
        }
    }
}
