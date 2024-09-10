namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

public record UpdateRestaurantResource(int RestaurantId, string Name, string Location, string Type);
