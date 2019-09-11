using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class DateRange
    {
        private DateTime _dateFrom;
        private DateTime _dateTo;

        public DateRange(DateTime dateFrom, DateTime dateTo)
        {
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }

        public DateTime DateFrom
        {
            get { return _dateFrom; }
        }
        public DateTime DateTo
        {
            get { return _dateTo; }
        }
    }

    internal class ReservationsQuery
    {
        public ReservationsQuery(DateRange dateRange, User user, int locationId, LocationType locationType, int? customerId = null)
        {
            DateRange = dateRange;
            User = user;
            LocationId = locationId;
            LocationType = locationType;
            CustomerId = customerId;
        }

        public DateRange DateRange { get; private set; }
        public User User { get; private set; }
        public int LocationId { get; private set; }
        public LocationType LocationType { get; private set; }
        public int? CustomerId { get; private set; }
    }

    class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(ReservationsQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
            {
                throw new ArgumentNullException("dateFrom");
            }

            if (query.DateRange.DateTo <= DateTime.Now)
            {
                throw new ArgumentNullException("dateTo");
            }

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationsQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
            {
                throw new ArgumentNullException("dateFrom");
            }

            if (query.DateRange.DateTo <= DateTime.Now)
            {
                throw new ArgumentNullException("dateTo");
            }

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange,
            ReservationDefinition sd)
        {
            if (dateRange.DateFrom >= DateTime.Now)
            {
                throw new ArgumentNullException("dateFrom");
            }

            if (dateRange.DateTo <= DateTime.Now)
            {
                throw new ArgumentNullException("dateTo");
            }

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.DateFrom >= DateTime.Now)
            {
                throw new ArgumentNullException("dateFrom");
            }

            if (dateRange.DateTo <= DateTime.Now)
            {
                throw new ArgumentNullException("dateTo");
            }

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {

    }

}
