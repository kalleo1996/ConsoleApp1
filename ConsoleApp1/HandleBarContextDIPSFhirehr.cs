using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HandleBarContextDIPSFhirehr
    {
         public Hl7.Fhir.Model.Resource fhirResource { get; }

        public HandleBarContextDIPSFhirehr(Hl7.Fhir.Model.Resource resource)
        {

           this.fhirResource = resource;
    
        }
    }
}
