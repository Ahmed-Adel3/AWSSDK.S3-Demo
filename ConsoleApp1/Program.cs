using System;
using ConsoleApp1.APIs;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string AwsAccessKeyId = "Put your aws access key here";
            string AwsSecretAccessKey = "put your aws secret access key here";
            string AwsZone = "Put your aws zone here  ex. eu-west-3";

            var service = new MyS3Service(AwsAccessKeyId, AwsSecretAccessKey, AwsZone);

            service.CreateNewBucketAsync("your-new-bucket-name", AwsZone);

            service.UploadObjectAsync("your-new-bucket-name", DateTime.Now.Ticks.ToString());

            var uploadFileKey = DateTime.Now.Ticks.ToString(); //to save the key created
            service.UploadFileAsync("your-new-bucket-name", uploadFileKey);

            service.ReadObjectDataAsync("your-new-bucket-name", uploadFileKey+"--3"); // Read the last uploaded image

            service.DeleteObject("your-new-bucket-name", uploadFileKey + "--3");// Delete the last uploaded image

            service.GetObjectsList("your-new-bucket-name");
        }
    }
}
