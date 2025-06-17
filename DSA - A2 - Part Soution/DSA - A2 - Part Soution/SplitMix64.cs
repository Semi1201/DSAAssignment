using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA___A2___Part_Soution
{
    /// <summary>
    /// Use this class to implement the SplitMix64 PRNG exacty as described in the pseudocode
    /// provided for Task 2 of the the Assignment Brief. (Done)
    /// 
    /// NB: no variations from the given pseudcode are accepted, even if they work! IMPPPPPPPPPP
    /// </summary>
    using System;

    internal class SplitMix64
    {
        //Initialize state = current time in milliseconds // state is a 64-bit unsigned integer
        private ulong state = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public ulong Next(ulong min, ulong max) //both min and max are 64-bit unsigned integers
        {

            //z = state + a large constant 
            ulong z = state + 0x9E3779B97F4A7C15;

            //Update state to be equal to z
            state = z;

            //Update z to be (z XOR (z shifted right by 30 bits)) * 0xBF58476D1CE4E5B9
            z ^= z >> 30;
            z *= 0xBF58476D1CE4E5B9;

            //Update z to be (z XOR (z shifted right by 27 bits)) * 0x94D049BB133111EB
            z ^= z >> 27;
            z *= 0x94D049BB133111EB;

            //Update z to be z XOR (z shifted right by 31 bits)
            z ^= z >> 31;

            //Modify z so that it is in the range min to max
            ulong range = max - min + 1;
            z = min + (z % range);

            return z;
        }
    }

}


