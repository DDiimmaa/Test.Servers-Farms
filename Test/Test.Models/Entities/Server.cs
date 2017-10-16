
namespace Test.Models.Entities
{
    public class Server
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EndPointURL { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }

        //in seconds
        public int AutoRefreshTime { get; set; }
    }
}
