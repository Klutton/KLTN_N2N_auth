using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common
{
    public interface IConfigureService
    {
        void Configure();

        void ShutDown();
    }
}
