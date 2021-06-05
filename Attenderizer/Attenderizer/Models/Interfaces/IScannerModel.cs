namespace Attenderizer.Models
{
    public interface IScannerModel
    {
        string Id { get; set; }
        string QRCode { get; set; }
    }
}