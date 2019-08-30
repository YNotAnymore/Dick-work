using System.Data;
using TestSpeed;

namespace LanghuaNew.Data
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class LanghuaContent : DbContext
    {
        public LanghuaContent()
            : base("name=LanghuaContent")
        {
        }
        public DbSet<Area> Areas { get; set; }

    }
}
