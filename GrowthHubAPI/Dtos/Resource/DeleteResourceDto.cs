using System;
namespace GrowthHubAPI.Dtos.Resource
{
    public class DeleteResourceDto
    {
        public int ResourceId { get; set; }

        public string ResourceName { get; set; } = String.Empty;

        public string ResourceSubject { get; set; } = String.Empty;

        public string ResourceLink { get; set; } = String.Empty;

    }
}

