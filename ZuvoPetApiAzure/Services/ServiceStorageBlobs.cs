using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using ZuvoPetNuget.Models;

namespace ZuvoPetApiAzure.Services
{
    public class ServiceStorageBlobs
    {
        public BlobServiceClient client;
        public ServiceStorageBlobs(BlobServiceClient client)
        {
            this.client = client;
        }

        // Método para recuperar todos los containers
        public async Task<List<string>> GetContainersAsync()
        {
            List<string> containers = new List<string>();
            await foreach (BlobContainerItem item in this.client.GetBlobContainersAsync())
            {
                containers.Add(item.Name);
            }
            return containers;
        }

        // Método para crear un container
        public async Task CreateContainerAsync(string containerName)
        {
            await this.client.CreateBlobContainerAsync(containerName, PublicAccessType.Blob);
        }

        public async Task DeleteContainerAsync(string containerName)
        {
            await this.client.DeleteBlobContainerAsync(containerName);
        }

        // Método para recuperar todos los blobs de un container
        public async Task<List<BlobModel>> GetBlobsAsync(string containerName)
        {
            BlobContainerClient containerClient = this.client.GetBlobContainerClient(containerName);
            List<BlobModel> models = new List<BlobModel>();
            await foreach (BlobItem item in containerClient.GetBlobsAsync())
            {
                BlobClient blobClient = containerClient.GetBlobClient(item.Name);
                BlobModel blob = new BlobModel();
                blob.Nombre = item.Name;
                blob.Url = blobClient.Uri.AbsoluteUri;
                blob.Container = containerName;
                models.Add(blob);
            }
            return models;
        }

        // Método para eliminar un blob
        public async Task DeleteBlobAsync(string containerName, string blobName)
        {
            BlobContainerClient containerClient = this.client.GetBlobContainerClient(containerName);
            await containerClient.DeleteBlobAsync(blobName);
        }

        // Método para subir un blob a un container
        public async Task UploadBlobAsync(string containerName, string blobName, Stream stream)
        {
            BlobContainerClient containerClient = this.client.GetBlobContainerClient(containerName);
            await containerClient.UploadBlobAsync(blobName, stream);
        }
    }
}
