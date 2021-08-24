using Amazon.S3;
using Amazon.S3.Model;
using System;

namespace ConsoleApp1.APIs
{
    public partial class MyS3Service
    {
        public void DeleteObject(string yourBucketName , string yourfileKey)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = yourBucketName,
                    Key = yourfileKey
                };

                Console.WriteLine("Deleting an object");
                s3Client.DeleteObjectAsync(deleteObjectRequest).GetAwaiter().GetResult();
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
        }
    }
}
