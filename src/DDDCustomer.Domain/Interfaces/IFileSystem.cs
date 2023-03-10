using System.Threading.Tasks;

namespace DDDCustomer.Domain.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64);
    }
}