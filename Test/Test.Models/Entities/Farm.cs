using System.Collections.Generic;

namespace Test.Models.Entities
{
    public class Farm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Server> Servers { get; set; }
    }
}
