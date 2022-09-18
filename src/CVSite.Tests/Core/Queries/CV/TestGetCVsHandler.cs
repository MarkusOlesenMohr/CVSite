using AutoMapper;
using CVSite.Application.Common.Interfaces;
using CVSite.Application.CV.Data;
using CVSite.Application.CV.Queries;
using CVSite.Domain.Master;
using CVSite.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSite.Tests.Core.Queries.CV
{
    public class TestGetCVsHandler
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllCVs_given_query_return_DTOList()
        {
            var query = new GetAllCVsQuery.Query();
            var expected = new List<CurriculumVitaeDTO>();

            // Holy shit thats a lot of Moq
            var unitOfWorkResult = new List<CurriculumVitae>();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.EntityRepository.GetAllAsync(CancellationToken.None))
                .ReturnsAsync(unitOfWorkResult);
            var mapper = TestHelpers.CreateTestAutoMapper();
            var handler = new GetAllCVsQuery.Handler(unitOfWork.Object, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.That(result.List, Is.EqualTo(expected));
        }
    }
}
