using System.ComponentModel.DataAnnotations;

namespace Xpand.API.Models
{
    public class PlanetDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AssetImageName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string RobotsCrew { get; set; }
    }
}