using System.ComponentModel.DataAnnotations;

namespace CoreRouting.Models
{
    public class Payload
    {
        public required string BodyParam1 { get; set; }
        public required string BodyParam2 { get; set; }
    }
}
