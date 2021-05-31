using System.Collections.Generic;
using System.Linq;
using WebApplication1.Business;
using WebApplication1.Domain;

namespace WebApplication1.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }
        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }
        public Category GetById(int Id)
        {
            return _context.Categories.Where(x => x.CategoryID == Id).FirstOrDefault();
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
