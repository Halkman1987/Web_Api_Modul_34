using System.ComponentModel.DataAnnotations;

namespace HomeApi.Contracts.Models.Devices
{
    public class AddDeviceRequest
    {
        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
       // [Range(120,220,ErrorMessage ="неподдреживаемый диапазон")]
        public int CurrentVolts { get; set; }
        public bool GasUsage { get; set; }
        public string Location { get; set; }
    }
}
