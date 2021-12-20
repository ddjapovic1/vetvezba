using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VetBusiness
    {
        public VetRepository vr;

        public VetBusiness()
        {
            this.vr = new VetRepository();
        }

        public List<Vet> getAllVets() //vraca spisak svih veterinara
        {
            return this.vr.GetAllVets();
        }

        public List<Vet> proslediVece(decimal max)
        {
            return this.vr.GetAllVets().Where(vet => vet.yearsExperience > max).ToList();
        }
        public bool InsertVet(Vet v)
        {
            int result = this.vr.insertVet(v);
            if (result != 0)
                return true;
            return false;
        }
        public bool deleteVet(int vetId)
        {
            int result = this.vr.deletVet(vetId);
            if (result != 0)
                return true;
            return false;
        }
    }
}
