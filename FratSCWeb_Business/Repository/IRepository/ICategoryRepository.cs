using FratSCWeb_Models;

namespace FratSCWeb_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> Create(CategoryDTO objDto);
        public Task<CategoryDTO> Update(CategoryDTO objDto);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
