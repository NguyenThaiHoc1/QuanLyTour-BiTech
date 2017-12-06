using System;
namespace Core
{
    [Serializable]
    public class BitechTour : Exception
    {
        public BitechTour(string messageError) : base(messageError) 
        {
        }
    }
}
