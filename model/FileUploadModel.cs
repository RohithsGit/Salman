namespace firstAPI.model
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
        public string CustomerName { get; set; } = "unknown";     // Default if not given
        public string CustomerMobile { get; set; } = "90000000000";
        public string CustomFolderPath { get; set; } = "D:\\Billphots";
    }
}
