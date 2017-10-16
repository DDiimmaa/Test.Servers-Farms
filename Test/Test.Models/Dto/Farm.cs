using System.Collections.Generic;

namespace Test.Models.Dto
{
    public class Farm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Server> Servers { get; set; }
    }
}
