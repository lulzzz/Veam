using Veam.Services;
using System.Threading.Tasks;

using System.Linq;

namespace Veam.Data
{
    public static class DataDbInitializer
    {
        public static async Task Initialize(DataDbContext context,
            IDbInitService dbInitlize)
        {
            context.Database.EnsureCreated();

            // check if seeded
            if (context.CenterTypes.Any())
            {
                return; //if user is not empty, DB has been seed
            }

            //init demo
            await dbInitlize.InitDemo();

        }
    }
}
