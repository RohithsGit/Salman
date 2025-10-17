namespace firstAPI.model
{
    public class ExcelUploadModel
    {
        public IFormFile File { get; set; }
        public string CustomerName { get; set; } = "unknown";
        public string CustomerMobile { get; set; } = "90000000000";
        public string CustomFolderPath { get; set; } = "D:\\Excelphots";
        public string FileExtension { get; set; } = ".xlsx"; // Default Excel, can be set if needed
    }
}
