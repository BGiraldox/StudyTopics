using AutoMapper;
using Core.Interfaces;
using Core.Mappers;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test
{
    public abstract class Setup<TEntity> : IDisposable where TEntity : IEntity
    {
        public IMapper _mapper;

        public IFacade _facade;

        public IRepository<TEntity> _repoMoq;

        protected IEnumerable<IEntity> EntityTestData { get; set; }

        public static string DEFAULT_REQUESTER_EMAIL = "Test@ey.com";

        public Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CoreProfile())));
            MockFacade();
            SetupData();
        }

        public void Dispose()
        {
            // Cleanup
        }

        private void MockFacade()
        {
            var mockFacade = new Mock<IFacade>();
            mockFacade
                .Setup(o => o.GetJobIdAsync(It.IsAny<string>()))
                .Returns(Task.Factory.StartNew(() =>
                {
                    return 1;
                }));
            mockFacade
                .Setup(o => o.PostAsync(It.IsAny<string>()))
                .Returns(Task.Factory.StartNew(() =>
                {
                    return new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }));

            _facade = mockFacade.Object;
        }

        protected abstract void LoadTestData();

        public void SetupData()
        {
            LoadTestData();

            // 1. Create moq object
            var entityRepoMoq = new Mock<IRepository<TEntity>>();

            // 2. Setup the returnables
            entityRepoMoq
            .Setup(o => o.CustomQueryEntity(It.IsAny<string>(), typeof(TEntity)))
            .Returns(Task.Factory.StartNew(() =>
            {
                return (Object)EntityTestData;
            }));

            entityRepoMoq
           .Setup(o => o.CustomQuery(It.IsAny<string>()))
           .Returns(Task.Factory.StartNew(() =>
            {
                return (object)(long)10;
            }));

            // 3. Assign to Object when needed
            _repoMoq = entityRepoMoq.Object;
        }
    }
}