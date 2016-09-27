using System.Collections.Generic;

namespace CrazyCatLady.Model
{
    public class Person
    {
        #region Constructors

        public Person()
        {
            Pets = new List<Pet>();
        }

        #endregion

        #region Public Properties

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int? Age { get; set; }

        public ICollection<Pet> Pets { get; set; }

        #endregion
    }
}
