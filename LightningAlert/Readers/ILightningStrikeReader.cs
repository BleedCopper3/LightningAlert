using LightningAlert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert.Readers
{
    public interface ILightningStrikeReader
    {
        LightningStrike Read(string line);
    }
}
