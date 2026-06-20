using GymManagement.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.DAL.Models
{
    public class Trainer : GymUser
    {
        // HireDate => CreatedAt
        public Speciality Specility { get; set; }
    }


}
