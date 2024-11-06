namespace XerifeTv.CMS.Models.Abstractions.Services;

public class StorageFilesService : IStorageFilesService
{
  private readonly IEnumerable<string> AcceptedExtensions = new[] { ".vtt" };
  
  public async Task<Result<string>> UploadFileAsync(Stream fileStream, string fileName)
  {
    var fileExtension = Path.GetExtension(fileName);

    if (!AcceptedExtensions.Contains(fileExtension))
      return Result<string>.Failure(
        new Error("400", $"file extension {fileExtension} is not accepted."));
    
    return Result<string>.Success(fileName);
  }
}