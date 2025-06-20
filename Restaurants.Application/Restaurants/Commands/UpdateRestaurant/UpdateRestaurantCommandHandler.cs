using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating a restaurant with id {request.Id}");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
        if (restaurant is null) throw new NotFoundException(nameof(Restaurant),request.Id.ToString());;
        mapper.Map(request, restaurant);
        await restaurantsRepository.SaveChanges();
    }
}
