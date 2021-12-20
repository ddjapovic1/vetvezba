using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Vet
    {
        public Vet(int id, string fullName, string specialty, int yearsExperience)
        {
            this.id = id;
            this.fullName = fullName;
            this.specialty = specialty;
            this.yearsExperience = yearsExperience;
        }

        public int id { get; set; }
        public string fullName { get; set; }
        public string specialty { get; set; }
        public int yearsExperience { get; set; }

        public override string ToString()
        {
            return $"Id je: {id}, ime je: {fullName} specijalnost je: {specialty} godine iskustva: {yearsExperience}";
        }



    }
}
