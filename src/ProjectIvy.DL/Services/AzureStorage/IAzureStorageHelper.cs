﻿using System.Threading.Tasks;

namespace ProjectIvy.DL.Services.AzureStorage
{
    public interface IAzureStorageHelper
    {
        Task<byte[]> GetFile(string fileName);

        Task UploadFile(string fileName, byte[] fileData);
    }
}