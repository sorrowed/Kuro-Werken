using System;
using System.Collections.Generic;

namespace Werken.Support
{
	public class Week
	{
		public int Y { get; set; }
		public int W { get; set; }
		public List<DateTime> WeekDates { get; private set; }

		public Week( int year, int nr )
		{
			Y = year;
			W = nr;
			WeekDates = TimeUtil.DaysOfWeek( Y, W );
		}

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
			W = TimeUtil.IsoWeekNumber( date );
			int year = date.Year;
			if( date.Month == 12 && W == 1 )
				++year;

			Y = year;
			WeekDates = TimeUtil.DaysOfWeek( Y, W );
		}

		public DateTime Get( DayOfWeek day )
		{
			return WeekDates.Get( day );
		}
	}
}
