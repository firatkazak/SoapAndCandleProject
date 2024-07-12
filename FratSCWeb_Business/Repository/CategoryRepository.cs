using AutoMapper;
using FratSCWeb_Business.Repository.IRepository;
using FratSCWeb_DataAccess;
using FratSCWeb_DataAccess.Data;
using FratSCWeb_Models;
using Microsoft.EntityFrameworkCore;

namespace FratSCWeb_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO objDto)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDto);
            obj.CreatedDate = DateTime.Now;
            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDto)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == objDto.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDto.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return objDto;
        }
    }
}
