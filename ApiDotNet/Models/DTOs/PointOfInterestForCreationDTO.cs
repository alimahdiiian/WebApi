using System.ComponentModel.DataAnnotations;

namespace ApiDotNet.Models.DTOs
{
    //advantages of DTO
    // changing without make changes in main model
    //  open for adding validation ... 
    public class PointOfInterestForCreationDTO
    {
        [Required(ErrorMessage ="Please Enter the Name ")]
        [MaxLength(50)]
        public string Name { get; set; }
         = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
