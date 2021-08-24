using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.IO;

namespace ConsoleApp1.APIs
{
    public partial class MyS3Service
    {
        public void UploadFileAsync(string yourBucketName, string yourfileKey)
        {
            try
            {
                string yourFilepath = Path.Combine(AppContext.BaseDirectory, "Amazon-Web-Services.jpg");

                var fileTransferUtility = new TransferUtility(s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.
                fileTransferUtility.UploadAsync(yourFilepath, yourBucketName).GetAwaiter().GetResult();
                Console.WriteLine("Upload 1 completed");

                //______________________________________________________________________

                // Option 2. Specify object key name explicitly.
                fileTransferUtility.UploadAsync(yourFilepath, yourBucketName, yourfileKey+"--1").GetAwaiter().GetResult(); ;
                Console.WriteLine("Upload 2 completed");

                //______________________________________________________________________

                // Option 3. Upload data from a type of System.IO.Stream.
                using (var fileToUpload = new FileStream(yourFilepath, FileMode.Open, FileAccess.Read))
                {
                    fileTransferUtility.UploadAsync(fileToUpload, yourBucketName, yourfileKey+"--2").GetAwaiter().GetResult();
                }
                Console.WriteLine("Upload 3 completed");

                //______________________________________________________________________
                // Option 4. Specify advanced settings.
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = yourBucketName,
                    FilePath = yourFilepath,
                    StorageClass = S3StorageClass.StandardInfrequentAccess,
                    PartSize = 6291456, // 6 MB.
                    Key = yourfileKey+"--3",
                    CannedACL = S3CannedACL.PublicRead // to determine Access control list to file
                };

                //if you need to add metadata to your files
                fileTransferUtilityRequest.Metadata.Add("x-amz-meta-title", "Image Custom Title");

                fileTransferUtility.UploadAsync(fileTransferUtilityRequest).GetAwaiter().GetResult(); ;
                Console.WriteLine("Upload 4 completed");
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
