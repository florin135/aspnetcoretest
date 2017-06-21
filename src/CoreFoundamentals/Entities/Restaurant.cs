using System.ComponentModel.DataAnnotations;

namespace CoreFoundamentals.Entities
{
    public enum CusineType
    {
        None,
        Italian,
        Romanian,
        Other
    }

    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant name")]

        public string Name { get; set; }
        public CusineType Cusine { get; set; }
    }
}