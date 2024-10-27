using MediatR;

namespace WebApiMediator.Features.Products.Notifications;

public record ProductCreatedNotification(Guid Id) : INotification;
