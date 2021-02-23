using System;
namespace HousePlantApi.Models
{
    public class HousePlantItem
    {
        public long ID { get; set; }
        public string CommonName { get; set; }
        public bool IsWatered { get; set; }
        public string Secret { get; set; }
    }
}
