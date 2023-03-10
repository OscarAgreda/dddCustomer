using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace dDDCustomerLib.SharedKernel
{
    public class DateTimeRange : ValueObject
    {
        public DateTimeRange(DateTime start, DateTime end)
        {
            Guard.Against.OutOfRange(start, nameof(start), start, end);
            Start = start;
            End = end;
        }

        public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
        {
        }

        public DateTime Start { get; }
        public DateTime End { get; }

        public int DurationInMinutes()
        {
            return (int)Math.Round((End - Start).TotalMinutes, 0);
        }

        public DateTimeRange NewDuration(TimeSpan newDuration)
        {
            return new DateTimeRange(Start, newDuration);
        }

        public DateTimeRange NewEnd(DateTime newEnd)
        {
            return new DateTimeRange(Start, newEnd);
        }

        public DateTimeRange NewStart(DateTime newStart)
        {
            return new DateTimeRange(newStart, End);
        }

        public static DateTimeRange CreateOneDayRange(DateTime day)
        {
            return new DateTimeRange(day, day.AddDays(1));
        }

        public static DateTimeRange CreateOneWeekRange(DateTime startDay)
        {
            return new DateTimeRange(startDay, startDay.AddDays(7));
        }

        public bool Overlaps(DateTimeRange dateTimeRange)
        {
            return Start < dateTimeRange.End &&
                   End > dateTimeRange.Start;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }
}