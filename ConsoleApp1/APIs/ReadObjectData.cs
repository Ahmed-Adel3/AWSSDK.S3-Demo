using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;

namespace ConsoleApp1.APIs
{
    public partial class MyS3Service
    {
        public void ReadObjectDataAsync(string yourBucketName, string yourfileKey)
        {
            string responseBody = "";
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = yourBucketName,
                    Key = yourfileKey
                };
                using (GetObjectResponse response = s3Client.GetObjectAsync(request).GetAwaiter().GetResult())
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title = response.Metadata["x-amz-meta-title"]; // Assume you have "title" as medata added to the object.
                    string contentType = response.Headers["Content-Type"];
                    Console.WriteLine("Object metadata, Title: {0}", title);
                    Console.WriteLine("Content type: {0}", contentType);
                    responseBody = reader.ReadToEnd(); // Now you process the response body.
                }
            }
            catch (AmazonS3Exception e)
            {
                // If bucket or object does not exist
                Console.WriteLine("Error encountered ***. Message:'{0}' when reading object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when reading object", e.Message);
            }
        }
    }
}
