﻿using System.IO;
using System.Threading.Tasks;
using yumaster.FileService.Sdk.Client.Models;

namespace yumaster.FileService.Sdk.Client
{
    public static class FileServiceClientExtensions
    {
        public static async Task<DataResult<FileUploadDataResult>> UploadAsync(this IFileServiceClient client, string ownerToken, string filePath, int periodMinute = 0)
        {
            var fi = new FileInfo(filePath);
            if (!fi.Exists)
                throw new FileNotFoundException(filePath);

            using (var fs = File.OpenRead(filePath))
            {
                return await client.UploadAsync(ownerToken, fs, fi.Name, periodMinute);
            }
        }

        public static async Task<DataResult<FileUploadDataResult>> UploadAsync(this IFileServiceClient client, string ownerToken, byte[] fileBytes, string fileName, int periodMinute = 0)
        {
            using (var ms = new MemoryStream(fileBytes, false))
            {
                return await client.UploadAsync(ownerToken, ms, fileName, periodMinute);
            }
        }
    }
}
