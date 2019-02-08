using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcGarage2.Data.Helper;
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
                if (context.Member.Any())
                {
                    context.Member.RemoveRange(context.Member);
                    context.ParkedVehicle.RemoveRange(context.ParkedVehicle);
                    context.VehicleType.RemoveRange(context.VehicleType);
                }


                // Let's seed!
                var members = new List<Member>();
                for (int i = 0; i < 10; i++)
                {
                    string name = Faker.Name.FullName();
                    var member = new Member
                    {
                        Name = name

                    };
                    members.Add(member);
                }
                context.Member.AddRange(members);

                var vehicleTypes = new List<VehicleType>
                {
                  new VehicleType("Bil",10f),
                new VehicleType("Motorcykel",7f),
                     new VehicleType("Lastbil",15f),
                          new VehicleType("Cykel",2f)




                };
                context.VehicleType.AddRange(vehicleTypes);
                context.SaveChanges();

                var parkedVehicles = new List<ParkedVehicle>();
                foreach (var person in members)
                {
                    int f = Faker.RandomNumber.Next(200);
                    var rand = Enum.GetValues(typeof(Brands)).GetValue(f).ToString();
                    foreach (var vehicleType in vehicleTypes)
                    {
                      
                            var parkedVehicle = new ParkedVehicle
                            {
                                MemberId=person.Id,
                                VehicleTypeId=vehicleType.Id,
                                Member = person,
                                VehicleType = vehicleType,
                                Brand=Enum.GetValues(typeof(Brands)).GetValue(Faker.RandomNumber.Next(100)).ToString(),
                                VehicleModel =Faker.Name.First(),
                                Color=(VehicleColor)Faker.RandomNumber.Next(15),
                                StartTime =DateTime.Now,
                                RegistrationNumber=Faker.Name.First().ToUpper().Substring(0,3)+Faker.RandomNumber.Next(999).ToString(),
                                NumberOfWheels= Faker.RandomNumber.Next(6)
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

