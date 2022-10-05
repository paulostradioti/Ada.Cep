using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ada.Cep.Service
{
    public static class Constants
    {
        public static class Cep
        {
            public static readonly Uri CepApiBaseUrl = new Uri("https://opencep.com/v1/");
        }
    }
}
