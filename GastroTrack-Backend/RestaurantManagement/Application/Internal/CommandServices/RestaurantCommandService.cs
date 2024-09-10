using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using System;

namespace chefstock_platform.RestaurantManagement.Application.Internal.CommandServices;

public class RestaurantCommandService(IRestaurantRepository restaurantRepository, IUnitOfWork unitOfWork)
    : IRestaurantCommandService
{
    public async Task<Restaurant?> Handle(CreateRestaurantCommand command)
    {
        var restaurant = new Restaurant(command);
        try
        {
            await restaurantRepository.AddAsync(restaurant);
            await unitOfWork.CompleteAsync();
            return restaurant;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the restaurant: {e.Message}");
            throw;
        }
    }

    public async Task<Restaurant?> Handle(UpdateRestaurantCommand command)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(command.RestaurantId);
        if (restaurant != null)
        {
            restaurant.Update(command);
            await restaurantRepository.UpdateAsync(restaurant);
            await unitOfWork.CompleteAsync();
            return restaurant;
        }
        else
        {
            Console.WriteLine($"Restaurant with id {command.RestaurantId} not found");
            throw new Exception($"Restaurant with id {command.RestaurantId} not found");
        }
    }

    public async Task Handle(DeleteRestaurantCommand command)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(command.RestaurantId);
        if (restaurant != null)
        {
            await restaurantRepository.DeleteAsync(restaurant.RestaurantId);
            await unitOfWork.CompleteAsync();
        }
        else
        {
            Console.WriteLine($"Restaurant with id {command.RestaurantId} not found");
            throw new Exception($"Restaurant with id {command.RestaurantId} not found");
        }
    }
}