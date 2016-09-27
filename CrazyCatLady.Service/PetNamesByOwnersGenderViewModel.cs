using CrazyCatLady.Model;
using System.Collections.Generic;

namespace CrazyCatLady.Service
{
    public class PetNamesByOwnersGenderViewModel
    {
        #region Public Properties

        public Gender OwnersGender { get; set; }

        public List<string> PetNames { get; set; }

        #endregion
    }
}
