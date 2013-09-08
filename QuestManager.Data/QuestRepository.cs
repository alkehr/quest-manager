using System.Data.Entity;

namespace QuestManager.Data
{
    public class QuestRepository : EntityFrameworkRepository<Quest>, IQuestRepository
    {
        public QuestRepository(DbContext context)
            : base(context)
        {
        }
    }
}