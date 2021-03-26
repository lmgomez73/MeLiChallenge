using MeLiChallenge.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeLiChallenge.Business.Interface
{
    public interface IMessageService
    {
        TopSecretResponseDTO AddMessage(TopSecretRequestDTO message);
        void AddMessageBySatellite(TopSecretSplitRequestDTO message, string satelliteName);
        TopSecretResponseDTO GetLastMessage();
    }
}
