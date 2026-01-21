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
        ForcePathStyle = true
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

app.Run("http://localhost:5000");
