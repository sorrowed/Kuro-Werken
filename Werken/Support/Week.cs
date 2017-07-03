using System;
using System.Collections.Generic;

namespace Werken.Support
{
	class Week
	{
		public int Year { get; set; }
		public int Nr { get; set; }
		public List<DateTime> WeekDates { get; private set; }

		public Week( DateTime date )
		{
			To( date );
		}

		public void Next()
		{
			var d = WeekDates.Get( DayOfWeek.Monday ).AddDays( 7 );
			To( d );
		}

		public void Previous()
		{
			var d = WeekDates.Get( DayOfWeek.Monday ).AddDays( -7 );
			To( d );
		}

		public void To( DateTime date )
		{
			var d = TimeUtils.FirstDayOfWeek( date );
			Year = d.Year;
			Nr = TimeUtils.IsoWeekNumber( d );
			WeekDates = TimeUtils.DaysOfWeek( Year, Nr );
		}

		public DateTime Get( DayOfWeek day )
		{
			return WeekDates.Get( day );
		}
	}
}
