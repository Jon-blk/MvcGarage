using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcGarage2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Data
{
    public class SeedData
    {


        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<MvcGarage2Context>>();
            using (var context = new MvcGarage2Context(options))
            {
                if (context.ParkedVehicle.Any())
                {
                    context.Member.RemoveRange(context.Member);
                    context.ParkedVehicle.RemoveRange(context.ParkedVehicle);
                    context.VehicleType.RemoveRange(context.VehicleType);
                }


                // Let's seed!
                var members = new List<Member>();
                for (int i = 0; i < 100; i++)
                {
                    string name = Faker.Name.FullName();
                    var member = new Member
                    {
                        Name = name

                    };
                    members.Add(member);
                }
                context.Member.AddRange(members);

                var vehicleTypes = new List<VehicleType>();
                for (int i = 0; i < 5; i++)
                {
                    var vehicleType = new VehicleType
                    {
                        Type = Faker.Company.BS(),
                        ParkingPrice=Faker.RandomNumber.Next(5)

                    };
                    vehicleTypes.Add(vehicleType);
                }
                context.VehicleType.AddRange(vehicleTypes);
                context.SaveChanges();

                var parkedVehicles = new List<ParkedVehicle>();
                foreach (var person in members)
                {
                    foreach (var vehicleType in vehicleTypes)
                    {
                      
                            var parkedVehicle = new ParkedVehicle
                            {
                                MemberId=person.Id,
                                VehicleTypeId=vehicleType.Id,
                                Member = person,
                                VehicleType = vehicleType,
                                Brand=Faker.Company.Name(),
                                VehicleModel=Faker.Name.First(),
                                Color=(VehicleColor) 4,
                                StartTime=DateTime.Now,
                                RegistrationNumber=Faker.Name.First()+Faker.RandomNumber.Next(5).ToString()

                            };
                            parkedVehicles.Add(parkedVehicle);
                        
                    }
                }
                context.ParkedVehicle.AddRange(parkedVehicles);
                context.SaveChanges();
            }
        }
    }
}

