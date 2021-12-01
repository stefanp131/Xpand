using System.ComponentModel.DataAnnotations;
using Xpand.DATA.Enums;

namespace Xpand.DATA.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AssetImageName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string RobotsCrew { get; set; }
        public string LastEditedBy { get; set; }
    }
}