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
			Nr = TimeUtils.IsoWeekNumber( date );
			int year = date.Year;
			if( date.Month == 12 && Nr == 1 )
				++year;
			else
			if( date.Month == 1 && Nr == 53 )
				;

			Year = year;
			WeekDates = TimeUtils.DaysOfWeek( Year, Nr );
		}

		public DateTime Get( DayOfWeek day )
		{
			return WeekDates.Get( day );
		}
	}
}
