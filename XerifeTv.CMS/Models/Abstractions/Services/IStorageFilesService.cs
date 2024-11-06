namespace XerifeTv.CMS.Models.Abstractions.Services;

public interface IStorageFilesService
{
  Task<Result<string>> UploadFileAsync(Stream fileStream, string fileName);
}