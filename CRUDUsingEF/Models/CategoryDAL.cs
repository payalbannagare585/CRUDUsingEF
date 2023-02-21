using CRUDUsingEF.Data;

namespace CRUDUsingEF.Models
{
    public class CategoryDAL
    {
        private readonly ApplicationDbContext db;
        

        public CategoryDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.categories.ToList();

        }
        public Category GetCategoryById(int cid)
        {
            var cate = db.categories.Find(cid);
            return cate;

        }

        public int AddCategory(Category cate)
        {
            db.categories.Add(cate);
            int result = db.SaveChanges();

            return result;

        }
        public int UpdateCategory(Category cate)
        {
            // c contains old data
            int result = 0;
            var c = db.categories.Where(x => x.CId == cate.CId).FirstOrDefault();
            if (c != null)
            {
                c.CId = c.CId;
             
                result = db.SaveChanges();
            }
            return result;


        }

        public int DeleteCategory(int cid)
        {
            int result = 0;
            var c = db.categories.Where(x => x.CId == cid).FirstOrDefault();
            if (c != null)
            {
                db.categories.Remove(c);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
