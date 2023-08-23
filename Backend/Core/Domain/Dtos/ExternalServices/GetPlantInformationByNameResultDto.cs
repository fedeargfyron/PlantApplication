using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.ExternalServices
{
    public class GetPlantInformationByNameResultDto
    {
        public string CommonName { get; set; } = string.Empty;
        public string ScientificName { get; set; } = string.Empty;
        public string Cycle { get; set; } = string.Empty;
        public string Watering { get; set; } = string.Empty;
        public List<string> Sunlight { get; set; } = new();
    }
}
