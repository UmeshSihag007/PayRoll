using Amazon.S3;
using Amazon.S3.Model;
using ApwPayroll_Application.Common.Exceptions;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.Documents;
using ApwPayroll_Domain.Entities.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Certificate_Persistence.Repositories.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        //private readonly IAmazonS3 _amazonS3;
        private readonly string _bucketName = "certificate-dev-data";
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private const string ImageTestingUrl = "https://localhost:7255/Images";
        private readonly CancellationToken cancellationToken;
        public DocumentRepository(IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork/*, IAmazonS3 amazonS3*/)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
            /*_amazonS3 = amazonS3;*/
        }
        public async Task<Document> GetDocumentByUrl(string url)
        {
            var data = await _unitOfWork.Repository<Document>().Entities
                .Where(x => x.Url == url && x.IsDeleted == false).FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }
            throw new NotFoundException();
        }
        //public async Task<Document> CreateDocument(IFormFile file, string? Tittle = null)
        //{
        //    if (file == null || file.Length <= 0)
        //        throw new BadRequestException("No file or empty file provided.");

        //    var fileExtension = Path.GetExtension(file.FileName).ToLower();
        //    var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };


        //    if (!allowedExtensions.Contains(fileExtension))
        //        throw new BadRequestException("Invalid file type. Allowed types are: pdf, jpg, jpeg, png.");

        //    var maxFileSize = 2  1024  1024; // 2 MB

        //    if (file.Length > maxFileSize)
        //        throw new BadRequestException("The image size cannot exceed 2 MB. Please upload a smaller image.");

        //    var fileName = $"{Guid.NewGuid():N}{fileExtension}";
        //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);

        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(fileStream);
        //    }

        //    var document = new Document
        //    {
        //        Tittle = Tittle ?? "Image",
        //        Url = $"{ImageTestingUrl}/{fileName}"
        //    };
        //    await _unitOfWork.Repository<Document>().AddAsync(document);
        //    await _unitOfWork.Save(cancellationToken);
        //    return document;
        //}
        public async Task<Document> updateDocument(int id, IFormFile file, string? Tittle = default, int? TypeId = default)
        {
            var checkExistDocument = await _unitOfWork.Repository<Document>().GetByIdAsync(id);
            if (checkExistDocument == null)
            {
                throw new BadRequestException();
            }
            if (file == null || file.Length <= 0)
                throw new BadRequestException("No file or empty file provided.");

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };


            if (!allowedExtensions.Contains(fileExtension))
                throw new BadRequestException("Invalid file type. Allowed types are: pdf, jpg, jpeg, png.");

            var maxFileSize = 2 * 1024*  1024; // 2 MB

            if (file.Length > maxFileSize)
                throw new BadRequestException("The image size cannot exceed 2 MB. Please upload a smaller image.");

            var fileName = $"{Guid.NewGuid():N}{fileExtension}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            checkExistDocument.Url = $"{ImageTestingUrl}/{fileName}";
            checkExistDocument.Tittle = Tittle ?? checkExistDocument.Tittle;

            await _unitOfWork.Repository<Document>().UpdateAsync(checkExistDocument);
            await _unitOfWork.Save(cancellationToken);
            return checkExistDocument;

        }



        public async Task<Document> CreateDocument(IFormFile file, string? title = default, int? TypeId = default)
        {
            if (file == null || file.Length <= 0)
                throw new BadRequestException("No file or empty file provided.");

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(fileExtension))
                throw new BadRequestException("Invalid file type. Allowed types are: pdf, jpg, jpeg, png.");

            var maxFileSize = 2 * 1024*  1024; // 2 MB

            if (file.Length > maxFileSize)
                throw new BadRequestException("The image size cannot exceed 2 MB. Please upload a smaller image.");

            var fileName = $"{Guid.NewGuid():N}{fileExtension}";


            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var document = new Document
            {
                Tittle = title ?? "Image",
                Url = $"{ImageTestingUrl}/{fileName}",

                TypeId = TypeId.Value
            };
            await _unitOfWork.Repository<Document>().AddAsync(document);
            await _unitOfWork.Save(cancellationToken);
            return document;






            // Upload file to S3 bucket
            /* var uploadRequest = new PutObjectRequest
         {
             InputStream = file.OpenReadStream(),
             BucketName = _bucketName,
             Key = fileName,
             ContentType = file.ContentType
         };

         var response = await _amazonS3.PutObjectAsync(uploadRequest, cancellationToken);

         if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
             throw new Exception("An error occurred while uploading the file to S3.");

         // Generate a pre-signed URL valid for a specific duration
         var preSignedUrl = GeneratePreSignedURL(_bucketName, fileName, TimeSpan.FromHours(1));

         var document = new Document
         {
             Tittle = title ?? "Image",
             Url = preSignedUrl
         };

         await _unitOfWork.Repository<Document>().AddAsync(document);
         await _unitOfWork.Save(cancellationToken);

         return document;*/
        }

        /*private string GeneratePreSignedURL(string bucketName, string key, TimeSpan expiry)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.UtcNow.Add(expiry)
            };

            return _amazonS3.GetPreSignedURL(request);
        }*/


    }
}
