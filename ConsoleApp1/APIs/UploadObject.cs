using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;

namespace ConsoleApp1.APIs
{
    partial class MyS3Service
    {
        public void UploadObjectAsync(string yourBucketName, string yourfileKey)
        {
            try
            {
                // Method 1. Put object-specify only key name for the new object.
                var putRequest1 = new PutObjectRequest
                {
                    BucketName = yourBucketName,
                    Key = yourfileKey+"--1", // prefix added to key because we are uploading 2 files here
                    ContentBody = "sample text"
                };

                PutObjectResponse response1 = s3Client.PutObjectAsync(putRequest1).Result;

                //______________________________________________________________________

                //Method  2. Put the object-set ContentType and add metadata.
                var getSecondObjectPath = Path.Combine(AppContext.BaseDirectory, "TestFile.txt");
                var putRequest2 = new PutObjectRequest
                {
                    BucketName = yourBucketName,
                    Key = yourfileKey+"--2",
                    FilePath = getSecondObjectPath, // upload from a directory (test file located in bin folder)
                    ContentType = "text/plain"
                };

                putRequest2.Metadata.Add("x-amz-meta-title", "someTitle");
                PutObjectResponse response2 = s3Client.PutObjectAsync(putRequest2).Result;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
    }
}
