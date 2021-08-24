using Amazon;
using Amazon.S3;

namespace ConsoleApp1.APIs
{
    public partial class MyS3Service
    {
        public readonly IAmazonS3 s3Client;

        public MyS3Service(string AwsAccessKeyId, string AwsSecretAccessKey, string AwsZone)
        {
            s3Client = new AmazonS3Client(AwsAccessKeyId, AwsSecretAccessKey,
                 RegionEndpoint.GetBySystemName(AwsZone));
        }
    }
}
