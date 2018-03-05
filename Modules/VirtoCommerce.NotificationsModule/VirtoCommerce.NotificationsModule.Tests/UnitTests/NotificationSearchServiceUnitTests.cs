using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using VirtoCommerce.NotificationsModule.Core.Abstractions;
using VirtoCommerce.NotificationsModule.Core.Model;
using VirtoCommerce.NotificationsModule.Data.Repositories;
using VirtoCommerce.NotificationsModule.Data.Services;
using VirtoCommerce.NotificationsModule.Tests.NotificationTypes;
using Xunit;

namespace VirtoCommerce.NotificationsModule.Tests.UnitTests
{
    public class NotificationSearchServiceUnitTests
    {
        private readonly Mock<INotificationRepository> _repositoryMock;
        private readonly Mock<Func<INotificationRepository>> _repositoryFactoryMock;
        private readonly INotificationRegistrar _notificationRegistrar;
        private readonly NotificationSearchService _notificationSearchService;

        public NotificationSearchServiceUnitTests()
        {
            _repositoryMock = new Mock<INotificationRepository>();
            _repositoryFactoryMock = new Mock<Func<INotificationRepository>>();
            _notificationRegistrar = new NotificationService(_repositoryFactoryMock.Object);
            _notificationSearchService = new NotificationSearchService(_repositoryMock.Object);
        }

        [Fact]
        public void SearchNotificationsAsync_GetNotifications()
        {
            //Arrange
            var searchCriteria = new NotificationSearchCriteria();
            _notificationRegistrar.RegisterNotification<RegistrationEmailNotification>();
            _notificationRegistrar.RegisterNotification<InvoiceEmailNotification>();
            _notificationRegistrar.RegisterNotification<OrderSentEmailNotification>();

            //Act
            var result = _notificationSearchService.SearchNotifications(searchCriteria);

            //Assert
            Assert.NotEmpty(result.Results);
        }

        [Fact]
        public void SearchNotificationsAsync_GetEmptyList()
        {
            //Arrange
            var searchCriteria = new NotificationSearchCriteria();

            //Act
            var result = _notificationSearchService.SearchNotifications(searchCriteria);

            //Assert
            Assert.Empty(result.Results);
        }

        [Fact]
        public void SearchNotificationsAsync_Get2Items()
        {
            //Arrange
            _notificationRegistrar.RegisterNotification<RegistrationEmailNotification>();
            _notificationRegistrar.RegisterNotification<InvoiceEmailNotification>();
            _notificationRegistrar.RegisterNotification<OrderSentEmailNotification>();
            var searchCriteria = new NotificationSearchCriteria
            {
                Take = 2,
                Skip = 0
            };

            //Act
            var result = _notificationSearchService.SearchNotifications(searchCriteria);

            //Assert
            Assert.Equal(2, result.Results.Count);
        }

        [Fact]
        public void SearchNotificationsAsync_ContainsActiveNotications()
        {
            //Arrange
            _notificationRegistrar.RegisterNotification<RegistrationEmailNotification>();
            _notificationRegistrar.RegisterNotification<InvoiceEmailNotification>();
            _notificationRegistrar.RegisterNotification<OrderSentEmailNotification>();
            var searchCriteria = new NotificationSearchCriteria();
            _repositoryMock.Setup(n => n.GetNotificationEntityForListByType(nameof(OrderSentEmailNotification), null, null))
                .Returns(new Data.Model.NotificationEntity() { IsActive = true });

            //Act
            var result = _notificationSearchService.SearchNotifications(searchCriteria);

            //Assert
            Assert.Contains(result.Results, n => n.IsActive);
        }
    }
}
