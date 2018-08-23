using System;
using System.Collections.Generic;
using TourManagement.API.Entities;
using System.Linq;

namespace TourManagement.API.Services
{
    public static class TourManagementContextExtensions
    {
        public static void EnsureSeedDataForContext(this TourManagementContext context)
        {
            // first, clear the database.  This ensures we can always start 
            // fresh with each demo.  Not advised for production environments, obviously :-)

            context.Shows.RemoveRange(context.Shows);
            context.Tours.RemoveRange(context.Tours);
            context.Bands.RemoveRange(context.Bands);
            context.Managers.RemoveRange(context.Managers);
            context.Orders.RemoveRange(context.Orders);
            context.Customers.RemoveRange(context.Customers);
            context.States.RemoveRange(context.States);
            context.Users.RemoveRange(context.Users);
            context.Departments.RemoveRange(context.Departments);

            context.SaveChanges();

//             init seed data
            var departments = new List<Department>()
            {
                new Department()
                {
                    Name = "Spacely Sprockets",                 
                },
                new Department()
                {                  
                    Name = "Mystery Machine",    
                }
            };
            context.Departments.AddRange(departments);

            var users = new List<User>()
            {
                new User(){FirstName = "George",LastName="Jetson",Phone="123-4560",Department=departments[0] },
                new User(){FirstName = "Jane",LastName="Jetson",Phone="123-4560",Department=departments[0] },
                new User(){FirstName = "Velma",LastName="Dinkley",Phone="987-6543",Department=departments[1]},
                new User(){FirstName = "Daphne",LastName="Blake",Phone="654-3210",Department=departments[1] },
                new User(){FirstName = "Norville",LastName="Rodgers",Phone="321-9876",Department=departments[1] },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // init seed data
            var managers = new List<Manager>()
            {
                new Manager()
                {
                    ManagerId = new Guid("fec0a4d6-5830-4eb8-8024-272bd5d6d2bb"),
                    Name = "Kevin",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                },
                new Manager()
                {
                    ManagerId = new Guid("c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d"),
                    Name = "Sven",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                }
            };

            var bands = new List<Band>()
            {
                new Band()
                {
                    BandId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Name = "Queens of the Stone Age",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                },
                new Band()
                {
                    BandId = new Guid("83b126b9-d7bf-4f50-96dc-860884155f8b"),
                    Name = "Nick Cave and the Bad Seeds",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                }
            };

            var tours = new List<Tour>()
            {
                new Tour()
                {
                    TourId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                    BandId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    ManagerId = new Guid("fec0a4d6-5830-4eb8-8024-272bd5d6d2bb"),
                    Title = "Villains World Tour",
                    Description = "The Villains World Tour is a concert tour in support of the band's seventh studio album, Villains.",
                    StartDate = new DateTimeOffset(2017,6,22,0,0,0, new TimeSpan()),
                    EndDate = new DateTimeOffset(2018,3,18,0,0,0, new TimeSpan()),
                    EstimatedProfits = 2500000,
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow,
                    Shows = new List<Show>()
                    {
                        new Show() {
                            Venue = "The Rapids Theatre",
                            City = "Niagara Falls",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,6,22,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Marina de Montebello",
                            City = "Montebello",
                            Country = "Canada",
                            Date = new DateTimeOffset(2017,6,24,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Ventura Theatre",
                            City = "Venture",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,8,10,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Golden Gate Park",
                            City = "San Francisco",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,8,12,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Capitol Theatre",
                            City = "Port Chester",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,9,6,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Festival Pier",
                            City = "Philadelphia",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,9,7,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Budweiser Stage",
                            City = "Toronto",
                            Country = "Canada",
                            Date = new DateTimeOffset(2017,9,9,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        }
                    }
                },
                new Tour()
                {
                    TourId = new Guid("f67ba678-b6e0-4307-afd9-e804c23b3cd3"),
                    BandId = new Guid("83b126b9-d7bf-4f50-96dc-860884155f8b"),
                    ManagerId = new Guid("c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d"),
                    Title = "Skeleton Tree European Tour",
                    Description = "Nick Cave and The Bad Seeds have announced an 8-week European tour kicking off in the UK at Bournemouth’s International Centre on 24th September. The tour will be the first time European audiences can experience live songs from new album Skeleton Tree alongside other Nick Cave & The Bad Seeds classics.  The touring line up features Nick Cave, Warren Ellis, Martyn Casey, Thomas Wydler, Jim Sclavunos, Conway Savage, George Vjestica and Larry Mullins.",
                    StartDate = new DateTimeOffset(2017,9,24,0,0,0, new TimeSpan()),
                    EndDate = new DateTimeOffset(2017,11,20,0,0,0, new TimeSpan()),
                    EstimatedProfits = 1200000,
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow,
                    Shows = new List<Show>()
                    {
                        new Show() {
                            Venue = "Bournemouth International Centre",
                            City = "Bournemouth",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,24,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Arena",
                            City = "Manchester",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,25,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "The SSE Hydro",
                            City = "Glasgow",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,27,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Motorpoint Arena",
                            City = "Nottingham",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,28,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "The O2",
                            City = "London",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,30,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Zénith",
                            City = "Paris",
                            Country = "France",
                            Date = new DateTimeOffset(2017,10,3,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Ziggo Dome",
                            City = "Amsterdam",
                            Country = "The Netherlands",
                            Date = new DateTimeOffset(2017,10,6,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Jahrhunderthalle",
                            City = "Frankfurt",
                            Country = "Germany",
                            Date = new DateTimeOffset(2017,10,7,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Sporthalle",
                            City = "Hamburg",
                            Country = "Germany",
                            Date = new DateTimeOffset(2017,10,9,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Rockhal",
                            City = "Luxembourg",
                            Country = "Luxembourg",
                            Date = new DateTimeOffset(2017,10,10,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Mitsubishi Electric Halle",
                            City = "Düsseldorf",
                            Country = "Germany",
                            Date = new DateTimeOffset(2017,10,10,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Sportpaleis",
                            City = "Antwerp",
                            Country = "Belgium",
                            Date = new DateTimeOffset(2017,10,13,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        }
                    }
                }
             };

            context.Managers.AddRange(managers);
            context.Bands.AddRange(bands);
            context.Tours.AddRange(tours);


            context.SaveChanges();

                var states = GetStates();
                context.States.AddRange(states);
                try
                {
                    int numAffected = context.SaveChanges();
                }
                catch (Exception exp)
                {
                    throw;
                }

                var customers = GetCustomers(states);
                context.Customers.AddRange(customers);

                try
                {
                    int numAffected = context.SaveChanges();
            }
                catch (Exception exp)
                {
                    throw;
                }

            }

            static List<Customer> GetCustomers(List<State> states)
            {
                //Customers
                var customerNames = new string[]
                {
                "Marcus,HighTower,Male,acmecorp.com",
                "Jesse,Smith,Female,gmail.com",
                "Albert,Einstein,Male,outlook.com",
                "Dan,Wahlin,Male,yahoo.com",
                "Ward,Bell,Male,gmail.com",
                "Brad,Green,Male,gmail.com",
                "Igor,Minar,Male,gmail.com",
                "Miško,Hevery,Male,gmail.com",
                "Michelle,Avery,Female,acmecorp.com",
                "Heedy,Wahlin,Female,hotmail.com",
                "Thomas,Martin,Male,outlook.com",
                "Jean,Martin,Female,outlook.com",
                "Robin,Cleark,Female,acmecorp.com",
                "Juan,Paulo,Male,yahoo.com",
                "Gene,Thomas,Male,gmail.com",
                "Pinal,Dave,Male,gmail.com",
                "Fred,Roberts,Male,outlook.com",
                "Tina,Roberts,Female,outlook.com",
                "Cindy,Jamison,Female,gmail.com",
                "Robyn,Flores,Female,yahoo.com",
                "Jeff,Wahlin,Male,gmail.com",
                "Danny,Wahlin,Male,gmail.com",
                "Elaine,Jones,Female,yahoo.com",
                "John,Papa,Male,gmail.com"
                };
                var addresses = new string[]
                {
                "1234 Anywhere St.",
                "435 Main St.",
                "1 Atomic St.",
                "85 Cedar Dr.",
                "12 Ocean View St.",
                "1600 Amphitheatre Parkway",
                "1604 Amphitheatre Parkway",
                "1607 Amphitheatre Parkway",
                "346 Cedar Ave.",
                "4576 Main St.",
                "964 Point St.",
                "98756 Center St.",
                "35632 Richmond Circle Apt B",
                "2352 Angular Way",
                "23566 Directive Pl.",
                "235235 Yaz Blvd.",
                "7656 Crescent St.",
                "76543 Moon Ave.",
                "84533 Hardrock St.",
                "5687534 Jefferson Way",
                "346346 Blue Pl.",
                "23423 Adams St.",
                "633 Main St.",
                "899 Mickey Way"
                };

                var citiesStates = new string[]
                {
                "Phoenix,AZ,Arizona",
                "Encinitas,CA,California",
                "Seattle,WA,Washington",
                "Chandler,AZ,Arizona",
                "Dallas,TX,Texas",
                "Orlando,FL,Florida",
                "Carey,NC,North Carolina",
                "Anaheim,CA,California",
                "Dallas,TX,Texas",
                "New York,NY,New York",
                "White Plains,NY,New York",
                "Las Vegas,NV,Nevada",
                "Los Angeles,CA,California",
                "Portland,OR,Oregon",
                "Seattle,WA,Washington",
                "Houston,TX,Texas",
                "Chicago,IL,Illinois",
                "Atlanta,GA,Georgia",
                "Chandler,AZ,Arizona",
                "Buffalo,NY,New York",
                "Albuquerque,AZ,Arizona",
                "Boise,ID,Idaho",
                "Salt Lake City,UT,Utah",
                "Orlando,FL,Florida"
                };

                var citiesIds = new int[] { 5, 9, 44, 5, 36, 17, 16, 9, 36, 14, 14, 6, 9, 24, 44, 36, 25, 19, 5, 14, 5, 23, 38, 17 };
                var zip = 85229;

                var orders = new List<Order>
            {
                new Order { Product = "Basket", Price = 29.99M, Quantity = 1 },
                new Order { Product = "Yarn", Price = 9.99M, Quantity = 1 },
                new Order { Product = "Needes", Price = 5.99M, Quantity = 1 },
                new Order { Product = "Speakers", Price = 499.99M, Quantity = 1 },
                new Order { Product = "iPod", Price = 399.99M, Quantity = 1 },
                new Order { Product = "Table", Price = 329.99M, Quantity = 1 },
                new Order { Product = "Chair", Price = 129.99M, Quantity = 4 },
                new Order { Product = "Lamp", Price = 89.99M, Quantity = 5 },
                new Order { Product = "Call of Duty", Price = 59.99M, Quantity = 1 },
                new Order { Product = "Controller", Price = 49.99M, Quantity = 1 },
                new Order { Product = "Gears of War", Price = 49.99M, Quantity = 1 },
                new Order { Product = "Lego City", Price = 49.99M, Quantity = 1 },
                new Order { Product = "Baseball", Price = 9.99M, Quantity = 5 },
                new Order { Product = "Bat", Price = 19.99M, Quantity = 1 }
            };

                int firstOrder, lastOrder, tempOrder = 0;
                var ordersLength = orders.Count;
                var customers = new List<Customer>();
                var random = new Random();

                for (var i = 0; i < customerNames.Length; i++)
                {
                    var nameGenderHost = customerNames[i].Split(',');
                    var cityState = citiesStates[i].Split(',');
                    var state = states.Where(s => s.Abbreviation == cityState[1]).SingleOrDefault();

                    var customer = new Customer
                    {
                        FirstName = nameGenderHost[0],
                        LastName = nameGenderHost[1],
                        Email = nameGenderHost[0] + '.' + nameGenderHost[1] + '@' + nameGenderHost[3],
                        Address = addresses[i],
                        City = cityState[0],
                        State = state,
                        Zip = zip + i,
                        Gender = nameGenderHost[2],
                        OrderCount = 0
                    };

                    firstOrder = (int)Math.Floor(random.NextDouble() * orders.Count);
                    lastOrder = (int)Math.Floor(random.NextDouble() * orders.Count);

                    if (firstOrder > lastOrder)
                    {
                        tempOrder = firstOrder;
                        firstOrder = lastOrder;
                        lastOrder = tempOrder;
                    }

                    customer.Orders = new List<Order>();

                    for (var j = firstOrder; j <= lastOrder && j < ordersLength; j++)
                    {
                        var order = new Order
                        {
                            Product = orders[j].Product,
                            Price = orders[j].Price,
                            Quantity = orders[j].Quantity
                        };
                        customer.Orders.Add(order);
                    }
                    customer.OrderCount = customer.Orders.Count;
                    customers.Add(customer);
                }

                return customers;
            }

            static List<State> GetStates()
            {
                var states = new List<State>
            {
                new State { Name = "Alabama", Abbreviation = "AL" },
                new State { Name = "Montana", Abbreviation = "MT" },
                new State { Name = "Alaska", Abbreviation = "AK" },
                new State { Name = "Nebraska", Abbreviation = "NE" },
                new State { Name = "Arizona", Abbreviation = "AZ" },
                new State { Name = "Nevada", Abbreviation = "NV" },
                new State { Name = "Arkansas", Abbreviation = "AR" },
                new State { Name = "New Hampshire", Abbreviation = "NH" },
                new State { Name = "California", Abbreviation = "CA" },
                new State { Name = "New Jersey", Abbreviation = "NJ" },
                new State { Name = "Colorado", Abbreviation = "CO" },
                new State { Name = "New Mexico", Abbreviation = "NM" },
                new State { Name = "Connecticut", Abbreviation = "CT" },
                new State { Name = "New York", Abbreviation = "NY" },
                new State { Name = "Delaware", Abbreviation = "DE" },
                new State { Name = "North Carolina", Abbreviation = "NC" },
                new State { Name = "Florida", Abbreviation = "FL" },
                new State { Name = "North Dakota", Abbreviation = "ND" },
                new State { Name = "Georgia", Abbreviation = "GA" },
                new State { Name = "Ohio", Abbreviation = "OH" },
                new State { Name = "Hawaii", Abbreviation = "HI" },
                new State { Name = "Oklahoma", Abbreviation = "OK" },
                new State { Name = "Idaho", Abbreviation = "ID" },
                new State { Name = "Oregon", Abbreviation = "OR" },
                new State { Name = "Illinois", Abbreviation = "IL" },
                new State { Name = "Pennsylvania", Abbreviation = "PA" },
                new State { Name = "Indiana", Abbreviation = "IN" },
                new State { Name = "Rhode Island", Abbreviation = "RI" },
                new State { Name = "Iowa", Abbreviation = "IA" },
                new State { Name = "South Carolina", Abbreviation = "SC" },
                new State { Name = "Kansas", Abbreviation = "KS" },
                new State { Name = "South Dakota", Abbreviation = "SD" },
                new State { Name = "Kentucky", Abbreviation = "KY" },
                new State { Name = "Tennessee", Abbreviation = "TN" },
                new State { Name = "Louisiana", Abbreviation = "LA" },
                new State { Name = "Texas", Abbreviation = "TX" },
                new State { Name = "Maine", Abbreviation = "ME" },
                new State { Name = "Utah", Abbreviation = "UT" },
                new State { Name = "Maryland", Abbreviation = "MD" },
                new State { Name = "Vermont", Abbreviation = "VT" },
                new State { Name = "Massachusetts", Abbreviation = "MA" },
                new State { Name = "Virginia", Abbreviation = "VA" },
                new State { Name = "Michigan", Abbreviation = "MI" },
                new State { Name = "Washington", Abbreviation = "WA" },
                new State { Name = "Minnesota", Abbreviation = "MN" },
                new State { Name = "West Virginia", Abbreviation = "WV" },
                new State { Name = "Mississippi", Abbreviation = "MS" },
                new State { Name = "Wisconsin", Abbreviation = "WI" },
                new State { Name = "Missouri", Abbreviation = "MO" },
                new State { Name = "Wyoming", Abbreviation = "WY" }
            };

                return states;
            }
        }
    }

