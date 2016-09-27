using System;
using CrazyCatLady.Model;
using Newtonsoft.Json.Linq;

namespace CrazyCatLady.Service
{
    public class PetConverter : JsonCreationConverter<Pet>
    {
        #region Protected Overrides

        protected override Pet Create(Type objectType, JObject jsonObject)
        {
            var petType = (string)jsonObject["type"];

            switch (petType.ToLower())
            {
                case "cat":
                    return new Cat();
                case "dog":
                    return new Dog();
                case "fish":
                    return new Fish();
            }

            return null;
        }

        #endregion
    }
}
