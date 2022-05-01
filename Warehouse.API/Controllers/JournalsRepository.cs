using Warehouse.Domain;

namespace Warehouse.API.Controllers
{
    public static class JournalsRepository
    {
        private static List<Journal> _journals = new List<Journal>();

        public static int Add(Journal journal)
        {
            int journalId = _journals.Count + 1;
            _journals.Add(journal with { Id = journalId });

            return journalId;
        }

        public static Journal? Get(int journalId)
        {
            return _journals.FirstOrDefault(x => x.Id == journalId);
        }

        public static bool Update(Journal updatedJournal)
        {
            var journal = _journals.FirstOrDefault(x => x.Id == updatedJournal.Id);
            if (journal == null)
            {
                return false;
            }

            _journals.Remove(journal);
            _journals.Add(updatedJournal);
            return true;
        }
    }
}
