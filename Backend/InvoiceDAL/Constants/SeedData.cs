using InvoiceDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Constants
{
    internal static class SeedData
    {
        #region Ids
        private static readonly string AdminRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84";
        private static readonly string ShopRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85";
        private static readonly string CustomerRole = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86";
        private static readonly string RestaurantRole = "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86";
        private static readonly string AdminAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe84";
        private static readonly string ShopAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe85";
        private static readonly string CustomerAppUser = "28b21eb8-d6dc-4acf-9ab8-91bf746efe86";
        private static readonly string RestaurantAppUser = "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86";
        private static readonly string FoodCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe81";
        private static readonly string ElectronicsCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe82";
        private static readonly string ClothesCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe83";
        private static readonly string FurnitureCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe84";
        private static readonly string EducationCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe85";
        private static readonly string TransportationCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe86";
        private static readonly string HealthCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe87";
        private static readonly string ServicesCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe88";
        private static readonly string EntertainmentCategory = "78b21eb8-d6dc-4acf-9ab8-91bf746efe89";

        // Clothes
        private static readonly string MensWear = "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84";
        private static readonly string WomensWear = "8f5d2472-3f60-4f66-a4ee-7a26f57e2e0f";
        private static readonly string KidsAndBabies = "9a1a3b1e-d066-4dd6-8e6a-4e97f7b2ef70";
        private static readonly string Shoes = "2cf7a9a5-1dd6-40a1-b04a-4eb1c7f54838";
        private static readonly string Accessories = "6bbf63c4-2528-4e30-8a68-33dcb4ee0ef3";

        // Education
        private static readonly string SchoolSupplies = "f2a76835-c5cd-4d91-b355-37c818db9490";
        private static readonly string BooksStationery = "84d4485e-4060-4df3-80ed-64ff1d2099d3";
        private static readonly string OnlineCourses = "51dfd39d-564e-4de2-8135-0f05366d68d0";
        private static readonly string PrivateLessons = "8e482041-1844-4d3b-bd7f-89dba3a10941";

        // Electronics
        private static readonly string MobilePhones = "52f51a2a-4e85-4d91-a8a0-171a8a39e318";
        private static readonly string LaptopsComputers = "5b2ffca7-8af2-4c5b-9f45-2f908be9c1ea";
        private static readonly string TVAudio = "e9b9b4ae-84e3-4ef9-8920-baeac7cb241b";
        private static readonly string HomeAppliances = "c62e935d-5d7a-4ee0-9a30-c6888f2b4f6a";

        // Entertainment
        private static readonly string CinemaMovies = "20722ad6-174a-4eea-9e97-491e88f8e394";
        private static readonly string Streaming = "e1220173-0844-4a28-b3f0-bdb3ba6e5b54";
        private static readonly string GamesToys = "2033b319-2149-45bb-94a0-6804f883d49a";
        private static readonly string ConcertsEvents = "cfcaf271-27c6-4b64-8470-5af597004003";

        // Food
        private static readonly string Groceries = "cbab53b5-76b3-41e1-8485-0d7585a61b85";
        private static readonly string RestaurantsCafes = "fe8b4964-87e4-401f-9a44-45348d8d1af8";
        private static readonly string FastFood = "3e1e27a0-7261-4b62-8e4c-2a3fc7ebc090";
        private static readonly string BakeriesSweets = "38e37c89-0ef4-4a6a-951f-9a5bc82a2920";

        // Furniture
        private static readonly string LivingRoomFurniture = "7ef51658-cc02-4af9-89e0-29d189b30a69";
        private static readonly string BedroomFurniture = "6bbfcb72-5528-4f68-89e4-2cbfcd16621c";
        private static readonly string OfficeFurniture = "6b9a5061-18a2-45cc-9e0e-2170f79cfe7b";
        private static readonly string OutdoorFurniture = "03e2fca0-5313-4d59-b78d-303e70a17a71";

        // Transportation
        private static readonly string PublicTransport = "1896315a-3c1e-4b20-b6af-423902cd8ee7";
        private static readonly string Fuel = "d84df214-cf36-4eea-b3ec-422693e1c74f";
        private static readonly string TaxiRideSharing = "b69fc653-85bb-46f8-9c92-70e85eb0fc68";
        private static readonly string VehicleMaintenance = "8d775015-7f63-43de-aab3-6c9cb2294170";

        // Health
        private static readonly string MedicinesPharmacy = "10df0b8c-10a1-4cc5-95d0-7f0d3cce0f88";
        private static readonly string DoctorVisits = "a16cc45a-1ef0-4745-b7cc-25e699a40c47";
        private static readonly string HealthInsurance = "e6895ef5-df64-4781-b099-98f2f7af5f70";
        private static readonly string FitnessGym = "bbf29261-3bc1-42ba-9c63-7086f7a3cc39";

        // Services
        private static readonly string CleaningServices = "de5f74bc-33ff-4b3a-bc48-1c6993e1a40d";
        private static readonly string RepairMaintenance = "9a6dcb70-899e-4c5f-b2d2-4bfb60126f5f";
        private static readonly string BeautySalon = "22622b36-1538-4de7-a171-9f40ce6232a8";
        private static readonly string DeliveryServices = "aef55b58-19e0-4964-bf1c-8e0545276ef7";


        #endregion
        #region Roles
        public static HashSet<IdentityRole> GetRoles()
        {
            return new HashSet<IdentityRole>(){

                new()
                {
                    Name=AppRoles.Admin,
                    NormalizedName=AppRoles.Admin.ToUpper(),
                    Id=AdminRole,
                },
                new()
                {
                    Name=AppRoles.Shop,
                    NormalizedName=AppRoles.Shop.ToUpper(),
                    Id=ShopRole
                },
                new()
                {
                    Name=AppRoles.Customer,
                    NormalizedName=AppRoles.Customer.ToUpper(),
                    Id = CustomerRole
                },
                new(){
                    Name=AppRoles.Restaurant,
                    NormalizedName=AppRoles.Restaurant.ToUpper(),
                    Id = RestaurantRole
                },
            };
        }
        #endregion
        #region Users
        public static HashSet<UserApp> GetUsers()
        {
            //Invoice123+
            return new HashSet<UserApp>()
            {
                new()
                {
                    Id = CustomerAppUser,
                    Email = "customer@invoice.com",
                    NormalizedEmail = "customer@invoice.com".ToUpper(),
                    UserName = "customer",
                    PhoneNumber = "01020210495",
                    PasswordHash="AQAAAAIAAYagAAAAEL7WjDMwY3woFxTEb0W7TPm2KCYv32cjIiqIycV9hbLbAQPGcBdVTUD6J0zqwNtEzQ==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                },
                new()
                {
                    Id = ShopAppUser,
                    Email = "shop@invoice.com",
                    NormalizedEmail = "shop@invoice.com".ToUpper(),
                    UserName = "shop",
                    PhoneNumber = "01020210795",
                    PasswordHash="AQAAAAIAAYagAAAAEIK9uTYXCvIWty97KaIFFZD3WEtTOnLwhEEd8Rmeh8pVc2CT6Nz4SaZ29Q/gcAPsmQ==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                },
                new()
                {
                    Id = AdminAppUser,
                    Email = "admin@invoice.com",
                    NormalizedEmail = "admin@invoice.com".ToUpper(),
                    UserName = "admin",
                    PhoneNumber = "01020210595",
                    PasswordHash= "AQAAAAIAAYagAAAAEKPr74T9wKgN2Rckq/lrBX/SBjQmOeXJxxeikNvCivCUe3THuR7c/fmcvzMMhkppuA==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                },
                new()
                {
                    Id = RestaurantAppUser,
                    Email = "restaurant@invoice.com",
                    NormalizedEmail = "restaurant@invoice.com".ToUpper(),
                    UserName = "restaurant",
                    PhoneNumber = "01020211595",
                    PasswordHash= "AQAAAAIAAYagAAAAEGdbCxXrHMnHDB8zj2UlxfY4/BPnIhBuTiykMG6xIwwGZXqwRZdtJBzu6bRIM98HQw==",
                    ConcurrencyStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d",
                    SecurityStamp = "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d"
                }

            };

        }
        #endregion
        #region User Roles
        public static HashSet<IdentityUserRole<string>> GetUserRoles()
        {
            return new HashSet<IdentityUserRole<string>>(){
                new(){
                    RoleId=AdminRole,
                    UserId=AdminAppUser,
                },
                new(){
                    RoleId=CustomerRole,
                    UserId=CustomerAppUser,
                },
                new(){
                    RoleId=ShopRole,
                    UserId=ShopAppUser,
                },
                new(){
                    RoleId=RestaurantRole,
                    UserId=RestaurantAppUser,
                },
            };
        }
        #endregion
        #region Categories
        public static HashSet<Category> GetCategories()
        {
            return new HashSet<Category>
            {
                new()
                {
                    Id=ClothesCategory,
                    ConcurrencyStamp=ClothesCategory,
                    Name="Clothes"
                },
                new()
                {
                    Id=EducationCategory,
                    ConcurrencyStamp=EducationCategory,
                    Name="Education"
                },
                new()
                {
                    Id=ElectronicsCategory,
                    ConcurrencyStamp=ElectronicsCategory,
                    Name="Electronics"
                },
                new()
                {
                    Id=EntertainmentCategory,
                    ConcurrencyStamp=EntertainmentCategory,
                    Name="Entertainment"
                },
                new()
                {
                    Id=FoodCategory,
                    ConcurrencyStamp=FoodCategory,
                    Name="Food"
                },
                new()
                {
                    Id=FurnitureCategory,
                    ConcurrencyStamp=FurnitureCategory,
                    Name = "Furniture"
                },
                new()
                {
                    Id=TransportationCategory,
                    ConcurrencyStamp=TransportationCategory,
                    Name="Transportation",
                },
                new()
                {
                    Id=HealthCategory,
                    ConcurrencyStamp=HealthCategory,
                    Name="Health"
                },
                new()
                {
                    Id=ServicesCategory,
                    ConcurrencyStamp=ServicesCategory,
                    Name="Services"
                }

            };
        }
        #endregion
        #region SubCategories



        public static HashSet<SubCategory> GetSubCategories()
        {
            return new HashSet<SubCategory> { 
            // Clothes
            new() { Id = MensWear, Name = "Men’s Wear", CategoryId = ClothesCategory, ConcurrencyStamp = MensWear },
            new() { Id = WomensWear, Name = "Women’s Wear", CategoryId = ClothesCategory, ConcurrencyStamp = WomensWear },
            new() { Id = KidsAndBabies, Name = "Kids & Babies", CategoryId = ClothesCategory, ConcurrencyStamp = KidsAndBabies },
            new() { Id = Shoes, Name = "Shoes", CategoryId = ClothesCategory, ConcurrencyStamp = Shoes },
            new() { Id = Accessories, Name = "Accessories", CategoryId = ClothesCategory, ConcurrencyStamp = Accessories },

            // Education
            new() { Id = SchoolSupplies, Name = "School Supplies", CategoryId = EducationCategory, ConcurrencyStamp = SchoolSupplies },
            new() { Id = BooksStationery, Name = "Books & Stationery", CategoryId = EducationCategory, ConcurrencyStamp = BooksStationery },
            new() { Id = OnlineCourses, Name = "Online Courses", CategoryId = EducationCategory, ConcurrencyStamp = OnlineCourses },
            new() { Id = PrivateLessons, Name = "Private Lessons", CategoryId = EducationCategory, ConcurrencyStamp = PrivateLessons },

            // Electronics
            new() { Id = MobilePhones, Name = "Mobile Phones", CategoryId = ElectronicsCategory, ConcurrencyStamp = MobilePhones },
            new() { Id = LaptopsComputers, Name = "Laptops & Computers", CategoryId = ElectronicsCategory, ConcurrencyStamp = LaptopsComputers },
            new() { Id = TVAudio, Name = "TV & Audio", CategoryId = ElectronicsCategory, ConcurrencyStamp = TVAudio },
            new() { Id = HomeAppliances, Name = "Home Appliances", CategoryId = ElectronicsCategory, ConcurrencyStamp = HomeAppliances },

            // Entertainment
            new() { Id = CinemaMovies, Name = "Cinema & Movies", CategoryId = EntertainmentCategory, ConcurrencyStamp = CinemaMovies },
            new() { Id = Streaming, Name = "Streaming Subscriptions", CategoryId = EntertainmentCategory, ConcurrencyStamp = Streaming },
            new() { Id = GamesToys, Name = "Games & Toys", CategoryId = EntertainmentCategory, ConcurrencyStamp = GamesToys },
            new() { Id = ConcertsEvents, Name = "Concerts & Events", CategoryId = EntertainmentCategory, ConcurrencyStamp = ConcertsEvents },

            // Food
            new() { Id = Groceries, Name = "Groceries", CategoryId = FoodCategory, ConcurrencyStamp = Groceries },
            new() { Id = RestaurantsCafes, Name = "Restaurants & Cafes", CategoryId = FoodCategory, ConcurrencyStamp = RestaurantsCafes },
            new() { Id = FastFood, Name = "Fast Food", CategoryId = FoodCategory, ConcurrencyStamp = FastFood },
            new() { Id = BakeriesSweets, Name = "Bakeries & Sweets", CategoryId = FoodCategory, ConcurrencyStamp = BakeriesSweets },

            // Furniture
            new() { Id = LivingRoomFurniture, Name = "Living Room Furniture", CategoryId = FurnitureCategory, ConcurrencyStamp = LivingRoomFurniture },
            new() { Id = BedroomFurniture, Name = "Bedroom Furniture", CategoryId = FurnitureCategory, ConcurrencyStamp = BedroomFurniture },
            new() { Id = OfficeFurniture, Name = "Office Furniture", CategoryId = FurnitureCategory, ConcurrencyStamp = OfficeFurniture },
            new() { Id = OutdoorFurniture, Name = "Outdoor Furniture", CategoryId = FurnitureCategory, ConcurrencyStamp = OutdoorFurniture },

            // Transportation
            new() { Id = PublicTransport, Name = "Public Transport", CategoryId = TransportationCategory, ConcurrencyStamp = PublicTransport },
            new() { Id = Fuel, Name = "Fuel", CategoryId = TransportationCategory, ConcurrencyStamp = Fuel },
            new() { Id = TaxiRideSharing, Name = "Taxi & Ride Sharing", CategoryId = TransportationCategory, ConcurrencyStamp = TaxiRideSharing },
            new() { Id = VehicleMaintenance, Name = "Vehicle Maintenance", CategoryId = TransportationCategory, ConcurrencyStamp = VehicleMaintenance },

            // Health
            new() { Id = MedicinesPharmacy, Name = "Medicines & Pharmacy", CategoryId = HealthCategory, ConcurrencyStamp = MedicinesPharmacy },
            new() { Id = DoctorVisits, Name = "Doctor Visits", CategoryId = HealthCategory, ConcurrencyStamp = DoctorVisits },
            new() { Id = HealthInsurance, Name = "Health Insurance", CategoryId = HealthCategory, ConcurrencyStamp = HealthInsurance },
            new() { Id = FitnessGym, Name = "Fitness & Gym", CategoryId = HealthCategory, ConcurrencyStamp = FitnessGym },

            // Services
            new() { Id = CleaningServices, Name = "Cleaning Services", CategoryId = ServicesCategory, ConcurrencyStamp = CleaningServices },
            new() { Id = RepairMaintenance, Name = "Repair & Maintenance", CategoryId = ServicesCategory, ConcurrencyStamp = RepairMaintenance },
            new() { Id = BeautySalon, Name = "Beauty & Salon", CategoryId = ServicesCategory, ConcurrencyStamp = BeautySalon },
            new() { Id = DeliveryServices, Name = "Delivery Services", CategoryId = ServicesCategory, ConcurrencyStamp = DeliveryServices }
        };
        }



        #endregion
    }
}
