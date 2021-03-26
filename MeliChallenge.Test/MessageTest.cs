using MeLiChallenge.Business;
using MeLiChallenge.Business.Helper;
using MeLiChallenge.Model;
using MeLiChallenge.Model.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MeliChallenge.Test
{
    [TestFixture]
    public class MessageTest
    {
        private MessageService _messageService;

        [SetUp]
        public void SetUp()
        {
            _messageService = new MessageService(new TrilaterationHelper(), new Data.MeliDbContext());
        }

        //[Test]
        //[TestCaseSource(nameof(messageOKTestCases))]
        //public void DecodeMessageTest(Message message)
        //{
        //    var result = _messageService.DecodeMessage(message);

        //    Assert.AreEqual("este es un mensaje secreto", result);
        //}

        [Test]
        [TestCaseSource(nameof(addMessageTestCases))]
        public void AddMessageTest(TopSecretRequestDTO message)
        {
            _messageService.AddMessage(message);
        }

        //TestCases for messages
        static readonly Message[] messageOKTestCases = new Message[] {
            new Message
            {
                MessageItems = new List<MessageItem>()
                 {
                    new MessageItem
                    {
                        Phrases= new string[]{"este", "", "", "mensaje", ""},
                    },
                    new MessageItem
                    {
                        Phrases= new string[]{ "", "es", "", "", "secreto" }
                    },
                    new MessageItem
                    {
                        Phrases= new string[]{ "este", "", "un", "", "" }
                    }
}
            },
            new Message
            {
                MessageItems = new List<MessageItem>()
                 {
                    new MessageItem
                    {
                        Phrases= new string[]{"es", "", "", "mensaje", ""}
                    },
                    new MessageItem
                    {
                        Phrases= new string[]{ "", "es", "", "", "secreto" }
                    },
                    new MessageItem
                    {
                        Phrases= new string[]{ "este", "", "un", "", "" }
                    }
                }
            },
            new Message
            {
                MessageItems = new List<MessageItem>()
                 {
                    new MessageItem
                    {
                        Phrases= new string[]{"es", "", "", "mensaje", ""}
                    },
                    new MessageItem
                    {
                        Phrases= new string[]{ "", "es", "", "", "secreto" }
                    },
                    new MessageItem
                    {
                        Phrases= new string[]{ "este", "", "un", "secreto", "" }
                    }
                }
            }

            };

        static readonly TopSecretRequestDTO[] addMessageTestCases = new TopSecretRequestDTO[]
        {
            new TopSecretRequestDTO
            {
                Satellites= new List<TopSecretRequestDTO.TopSecretData>()
                {
                    new TopSecretRequestDTO.TopSecretData
                    {
                        Distance= 424.26,
                        Message = new string[]{"es", "", "", "mensaje", ""},
                        Name = "Skywalker"
                    },
                    new TopSecretRequestDTO.TopSecretData
                    {
                        Distance= 360.56,
                        Message =  new string[]{ "", "es", "", "", "secreto" },
                        Name = "Kenobi"
                    },
                    new TopSecretRequestDTO.TopSecretData
                    {
                        Distance= 700,
                        Message = new string[]{ "este", "", "un", "secreto", "" },
                        Name = "Sato"
                    },
                }
            }
        };


    }
}
