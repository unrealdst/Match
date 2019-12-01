using DataLayer;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Tests
{
    [TestClass]
    public class MatchServiceTests
    {
        MatchService matchService;

        Mock<IDataRepositry> dataRepository;

        [TestInitialize]
        public void SetUp()
        {
            dataRepository = new Mock<IDataRepositry>();

            matchService = new MatchService(dataRepository.Object);
        }

        [TestMethod]
        public void Play_CurrentMatchExist_Play()
        {
            //Given
            dataRepository.Setup(x => x.GetMatch()).Returns(new List<DataLayer.Models.Match>()
            {
                new DataLayer.Models.Match()
                {
                    Start = DateTime.Now.AddMinutes(-10),
                    End = DateTime.Now.AddMinutes(10),
                    Id = 1
                }
            });

            //When
            matchService.Play(new LogicLayer.Models.MatchPlayParameters() { Login = "Login" });

            //Assert
            dataRepository.Verify(x => x.AddPlay("Login", It.IsAny<int>(), 1), Times.Once);
        }

        [TestMethod]
        public void Play_TwoMatch_PlayCurrent()
        {
            //Given
            dataRepository.Setup(x => x.GetMatch()).Returns(new List<DataLayer.Models.Match>()
            {
                new DataLayer.Models.Match()
                {
                    Start = DateTime.Now.AddMinutes(-10),
                    End = DateTime.Now.AddMinutes(10),
                    Id = 2
                },
                new DataLayer.Models.Match()
                {
                    Start = DateTime.Now.AddMinutes(-20),
                    End = DateTime.Now.AddMinutes(-10),
                    Id = 1
                }
            });

            //When
            matchService.Play(new LogicLayer.Models.MatchPlayParameters() { Login = "Login" });

            //Assert
            dataRepository.Verify(x => x.AddPlay("Login", It.IsAny<int>(), 2), Times.Once);
        }

        [TestMethod]
        public void Play_NoCurrentMatch_NoPlay()
        {
            //Given
            dataRepository.Setup(x => x.GetMatch()).Returns(new List<DataLayer.Models.Match>()
            {
                new DataLayer.Models.Match()
                {
                    Start = DateTime.Now.AddMinutes(-20),
                    End = DateTime.Now.AddMinutes(-10),
                    Id = 2
                },
                new DataLayer.Models.Match()
                {
                    Start = DateTime.Now.AddMinutes(-30),
                    End = DateTime.Now.AddMinutes(-20),
                    Id = 1
                }
            });

            //When
            matchService.Play(new LogicLayer.Models.MatchPlayParameters() { Login = "Login" });

            //Assert
            dataRepository.Verify(x => x.AddPlay(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
    }
}
