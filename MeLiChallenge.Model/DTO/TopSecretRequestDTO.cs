using System;
using System.Collections.Generic;
using System.Text;

namespace MeLiChallenge.Model.DTO
{
    public class TopSecretRequestDTO
    {
        public List<TopSecretData> Satellites { get; set; }
        public struct TopSecretData
        {
            public string Name { get; set; }
            public double Distance { get; set; }
            public string[] Message { get; set; }
        }
    }
}
