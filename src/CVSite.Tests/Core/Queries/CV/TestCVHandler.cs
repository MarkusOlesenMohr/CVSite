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
    public class TestCVHandler
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetCV_given_query_id_return_DTODetails()
        {
            var id = 1;
            var query = new GetCVQuery.Query(id);
            var expected = new CurriculumVitaeDetailsDTO();

            // Holy shit thats a lot of Moq
            var unitOfWorkResult = new CurriculumVitae();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.EntityRepository.GetAsync(id, CancellationToken.None))
                .ReturnsAsync(unitOfWorkResult);
            var mapper = TestHelpers.CreateTestAutoMapper();
            var handler = new GetCVQuery.Handler(unitOfWork.Object, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.That(result.DTO, Is.EqualTo(expected));
        }
    }
}
