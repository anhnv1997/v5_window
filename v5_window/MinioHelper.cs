using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kztek.Tools;
using Minio;

namespace iParkingv5_window
{   
    public static class MinioHelper
    {
        public static string EndPoint = string.Empty;
        public static string AccessKey = string.Empty;
        public static string SecretKey = string.Empty;
        public static bool secure = false;
        public static string bucketName = "parking-images";
        public static async Task<string> GetImage(string path)
        {
            try
            {
                MinioClient minio = new MinioClient()
                            .WithEndpoint(EndPoint)
                            .WithCredentials(AccessKey, SecretKey)
                            .WithSSL(secure)
                            .Build();
                var getListBucketsTask = await minio.ListBucketsAsync().ConfigureAwait(false);
                PresignedGetObjectArgs args = new PresignedGetObjectArgs()
                                        .WithBucket(bucketName)
                                        .WithObject(path)
                                        .WithExpiry(60 * 60 * 24);
                string url = await minio.PresignedGetObjectAsync(args);
                return url;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static Stream ToStream(this Image image, ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }

        public static async Task<string> UploadPicture(Image? image, string imageKey)
        {
            try
            {
                if (image == null)
                {
                    return string.Empty;
                }
                MinioClient minio = new MinioClient()
                            .WithEndpoint(EndPoint)
                            .WithCredentials(AccessKey, SecretKey)
                            .WithSSL(secure)
                            .Build();

                BucketExistsArgs bucketExistsArgs = new BucketExistsArgs().WithBucket(bucketName);
                bool bucketExists = await minio.BucketExistsAsync(bucketExistsArgs);
                if (!bucketExists)
                {
                    MakeBucketArgs makeBucketArgs = new MakeBucketArgs().WithBucket(bucketName);
                    await minio.MakeBucketAsync(makeBucketArgs);
                }

                Stream data = image.ToStream(ImageFormat.Jpeg);
                PutObjectArgs putObjectArgs = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithStreamData(data)
                    .WithObjectSize(data.Length)
                    .WithObject(imageKey)
                    .WithContentType("application/octet-stream");
                var response = await minio.PutObjectAsync(putObjectArgs);
                return imageKey;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu hình ảnh lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}
