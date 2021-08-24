using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using System;

namespace ConsoleApp1.APIs
{
    public partial class MyS3Service
    {
        public void CreateNewBucketAsync(string yourBucketName,string region)
        {
            try
            {
                // to check if there is another bucket with the same name
                //make sure to use V2 of the function because V1 is obsolete
                if (!(AmazonS3Util.DoesS3BucketExistV2Async(s3Client, yourBucketName).Result))
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = yourBucketName,
                        UseClientRegion = true,
                    };
                    PutBucketResponse putBucketResponse = s3Client.PutBucketAsync(putBucketRequest).Result;
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
    }
}
