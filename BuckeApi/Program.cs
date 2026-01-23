using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var s3Client = new AmazonS3Client(
    "Murilo",
    "murilo",
    new AmazonS3Config
    {
        ServiceURL = "http://localhost:4566",
        ForcePathStyle = true,
        UseHttp = true
    }
);

app.MapPost("/presigned-url", ([FromForm] string fileName) =>
{
    if (string.IsNullOrWhiteSpace(fileName))
        return Results.BadRequest("fileName é obrigatório");

    var request = new GetPreSignedUrlRequest
    {
        BucketName = "teste",
        Key = fileName,
        Verb = HttpVerb.PUT,
        Expires = DateTime.UtcNow.AddMinutes(5)
    };

    var url = s3Client.GetPreSignedURL(request);

    return Results.Ok(new { uploadUrl = url });
})
.DisableAntiforgery();

app.MapPut("/edit-text", async (EditTextRequest request) =>
{
    var bucketName = "teste";

    // 1. Baixar o arquivo atual
    var getObject = await s3Client.GetObjectAsync(bucketName, request.FileName);

    string currentContent;
    using (var reader = new StreamReader(getObject.ResponseStream))
    {
        currentContent = await reader.ReadToEndAsync();
    }

    // 2. Editar conteúdo (exemplo: substituir tudo)
    var updatedContent = request.NewContent;

    // 3. Subir novamente (overwrite)
    var putRequest = new PutObjectRequest
    {
        BucketName = bucketName,
        Key = request.FileName,
        ContentBody = updatedContent
    };

    await s3Client.PutObjectAsync(putRequest);

    return Results.Ok(new
    {
        message = "Arquivo atualizado com sucesso",
        file = request.FileName
    });
});

app.Run("http://localhost:5000");
record EditTextRequest(string FileName, string NewContent);
