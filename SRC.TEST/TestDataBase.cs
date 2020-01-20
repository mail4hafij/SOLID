using SRC.TEST.Data;

namespace SRC.TEST
{
    public class TestDataBase
    {
        public TestDataBase()
        {

        }

        public Cats Cats => new Cats();
        public Dogs Dogs => new Dogs();
        public Tigers Tigers => new Tigers();

    }
}
