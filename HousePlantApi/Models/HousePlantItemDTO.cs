using System;
namespace HousePlantApi.Models
{
    public class HousePlantItemDTO
    {
        public long ID { get; set; }
        public string CommonName { get; set; }
        public bool IsWatered { get; set; }
    }
}
