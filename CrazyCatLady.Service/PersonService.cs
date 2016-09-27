using CrazyCatLady.Model;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CrazyCatLady.Service
{
    public class PersonService
    {
        #region Public Static Methods

        public static List<Person> GetOwners()
        {
            List<Person> owners = new List<Person>();

            // this would likely be put into a singleton from a reuse perspective
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // this would be managed in configuration
                using (HttpResponseMessage response = client.GetAsync("http://agl-developer-test.azurewebsites.net/people.json").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        owners = JsonConvert.DeserializeObject<List<Person>>(json, new PetConverter());
                    }
                }
            }

            return owners;
        }

        // testable
        public static List<PetNamesByOwnersGenderViewModel> GetPetNamesByOwnersGender(List<Person> owners, Type petType)
        {
            var query = from owner in owners where owner.Pets.Any(pet => pet.GetType() == petType) group owner by owner.Gender
                        into grp
                        select new PetNamesByOwnersGenderViewModel { OwnersGender = grp.Key, PetNames = grp.SelectMany(person => person.Pets.Where(pet => pet.GetType() == petType).OrderBy(pet => pet.Name).Select(pet => pet.Name)).ToList() };

            return query.ToList();
        }

        #endregion
    }
}
