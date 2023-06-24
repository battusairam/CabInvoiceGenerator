using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;
        private readonly double MINIMUM_CAST_PER_KM;
        private readonly int CAST_PER_TIME;
        private readonly double MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository=new RideRepository();
            
                try
                {
                    if (rideType.Equals(RideType.PREMIUM))
                    {
                        this.MINIMUM_CAST_PER_KM = 15;
                        this.CAST_PER_TIME = 2;
                        this.MINIMUM_FARE = 20;
                    }
                    else if (rideType.Equals(RideType.NORMAL))
                    {
                        this.MINIMUM_CAST_PER_KM = 10;
                        this.CAST_PER_TIME = 1;
                        this.MINIMUM_FARE = 5;
                    }
                }
                catch (CabInvoiceException)
                {

                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");

                }
            }
           public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_CAST_PER_KM * time * CAST_PER_TIME;

            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null)){
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
            
                 if(time < 0){
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
            
        }
    }
}
