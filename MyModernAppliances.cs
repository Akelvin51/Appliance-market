using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{

    internal class MyModernAppliances : ModernAppliances
    {

        //Array of checked out appliances, acting as a shopping cart
        List<Appliance> shoppingCart = new List<Appliance>();

        public override void Checkout()
        {

            Console.Write("Enter the item number of an appliance: ");
            long itemNumber = Convert.ToInt64(Console.ReadLine());
            bool inCart = false;

            Appliance foundAppliance = null;

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            foreach (Appliance appliance in shoppingCart)
            {
                if(appliance.ItemNumber == itemNumber)
                {
                    inCart = true;
                    break;
                }
            }

            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                if (foundAppliance != null && !inCart)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine($"Appliance {itemNumber} has been checked out.");
                    shoppingCart.Add(foundAppliance);
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }


        public override void Find()
        {
            Console.Write("Enter brand to search for: ");
            string brandToSearch = Console.ReadLine();

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand == brandToSearch)
                {
                    foundAppliances.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }


        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            Console.Write("Enter number of doors: ");
            string userInput = Console.ReadLine();

            int numberOfDoors;
            if (!int.TryParse(userInput, out numberOfDoors))
            {
                Console.WriteLine("Invalid input. Please enter a valid number of doors.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);

        }


        public override void DisplayVacuums()
        {
            //Console.WriteLine("Possible options:");
            //Console.WriteLine("0 - Any");
            //Console.WriteLine("1 - Residential");
            //Console.WriteLine("2 - Commercial");

            //Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high) ");
            //string gradeInput = Console.ReadLine();

            //string grade;
            //switch (gradeInput)
            //{
            //    case "0":
            //        grade = "Any";
            //        break;
            //    case "1":
            //        grade = "Residential";
            //        break;
            //    case "2":
            //        grade = "Commercial";
            //        break;
            //    default:
            //        Console.WriteLine("Invalid option.");
            //        return;
            //}

            //Console.WriteLine("Possible options:");
            //Console.WriteLine("0 - Any");
            //Console.WriteLine("1 - 18 Volt");
            //Console.WriteLine("2 - 24 Volt");

            Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high) ");
            string voltageInput = Console.ReadLine();

            int voltage;
            switch (voltageInput)
            {
                case "0":
                    voltage = 0;
                    break;
                case "18":
                    voltage = 18;
                    break;
                case "24":
                    voltage = 24;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    if (voltage == 0 || voltage == vacuum.BatteryVoltage)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, voltage);
        }


        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("A - Any");
            Console.WriteLine("K - Kitchen");
            Console.WriteLine("W - Work site");

            Console.Write("Enter room type: ");
            string roomTypeInput = Console.ReadLine();

            char roomType = char.ToUpper(roomTypeInput[0]);

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;
                    if (roomType == 'A' || roomType == char.ToUpper(microwave.RoomType))
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("A - Any");
            Console.WriteLine("Qr - Quieter");
            Console.WriteLine("Qu - Quiet");
            Console.WriteLine("M - Moderate");

            Console.Write("Enter the sound rating of the dishwasher:A(Any), Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate): ");
            string soundRatingInput = Console.ReadLine();

            string soundRating;
            switch (soundRatingInput.ToUpper())
            {
                case "A":
                    soundRating = "Any";
                    break;
                case "QR":
                    soundRating = "Qr";
                    break;
                case "QU":
                    soundRating = "Qu";
                    break;
                case "M":
                    soundRating = "M";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if (soundRating == "Any" || soundRating == dishwasher.SoundRating)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        public override void RandomList()
        {
            Console.Write("Enter number of appliances: ");
            string numAppliancesInput = Console.ReadLine();
            int numAppliances = Convert.ToInt32(numAppliancesInput);

            List<Appliance> foundAppliances = new List<Appliance>(Appliances);
            foundAppliances.Sort(new RandomComparer());

            DisplayAppliancesFromList(foundAppliances, numAppliances);
        }
    }
 }