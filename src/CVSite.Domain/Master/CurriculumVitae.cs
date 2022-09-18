using CVSite.Domain.Common;
using System.Collections.Generic;

namespace CVSite.Domain.Master
{
    public class CurriculumVitae : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = new Person();
        public List<Interest> Interests { get; set; } = new List<Interest>();
        public int ProfileId { get; set; }
        public Profile Profile { get; set; } = new Profile();
        public List<WorkingHistory> WorkingHistory { get; set; } = new List<WorkingHistory>();
        public List<Education> Educations { get; set; } = new List<Education>();
    }
}