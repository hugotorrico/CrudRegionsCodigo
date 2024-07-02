using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BRegion
    {
        DRegion dRegion = new DRegion();

        public string Insert(Region region)
        {
            string message = string.Empty;

            //Regla: No registrar regiones con el mismo nombre
            int exist = dRegion.Get(region).Count;
            if (exist>0)
            {
                message = "Existe región con ese nombre";
                return message;
            }
           
            dRegion.Insert(region);
            message = "Sucessful";

            return message;
        }
    }
}
