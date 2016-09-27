using CrazyCatLady.Model;
using System;
using System.Collections.Generic;

namespace CrazyCatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> owners = Service.PersonService.GetOwners();

            var petNamesByOwnersGender = Service.PersonService.GetPetNamesByOwnersGender(owners, typeof(Cat));
            
            foreach (var petsByOwnerGender in petNamesByOwnersGender)
            {
                Console.WriteLine(petsByOwnerGender.OwnersGender);

                foreach (var ownersPetsName in petsByOwnerGender.PetNames)
                {
                    Console.WriteLine($"- {ownersPetsName}");
                }
            }

            Console.ReadKey();
        }
    }
}
