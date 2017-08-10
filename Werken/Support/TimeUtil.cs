using System;
using System.Collections.Generic;
using System.Globalization;

namespace Werken.Support
{
	public static class TimeUtil
	{
		public static int DayIndex( DayOfWeek day )
		{
			return day == DayOfWeek.Sunday ? 6 : (int)day - 1;
		}

		public static DateTime Get( this List<DateTime> dates, DayOfWeek day )
		{
			return dates[ DayIndex( day ) ];
		}

		/// <summary>
		/// Get weeknumber in year according to ISO8601
		/// </summary>
		/// <remarks>
		/// Default implementation of .NET of Calendar.GetWeekOfYear() does not conform to ISO8601
		/// </remarks>
		public static int IsoWeekNumber( DateTime date )
		{
			var cal = CultureInfo.InvariantCulture.Calendar;
			var day = cal.GetDayOfWeek( date );

			date = date.AddDays( 4 - ( (int)day == 0 ? 7 : (int)day ) );

			return cal.GetWeekOfYear( date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday );
		}

		/// <summary>
		/// Find the first day of week one of given year
		/// </summary>
		public static DateTime FirstDayOfWeekOne( int year )
		{
			var date = new DateTime( year, 1, 1 );
			while( IsoWeekNumber( date ) == 1 )
				date = date.AddDays( -1 );
			while( IsoWeekNumber( date ) != 1 )
				date = date.AddDays( 1 );

			return date;
		}

		/// <summary>
		/// Find the last day of given year
		/// </summary>
		public static DateTime LastDayOfLastWeek( int year )
		{
			var date = new DateTime( year, 12, 28 );

			while( IsoWeekNumber( date ) != 1 )
				date = date.AddDays( 1 );

			while( IsoWeekNumber( date ) == 1 )
				date = date.AddDays( -1 );

			return date;
		}

		/// <summary>
		/// Returns all days in given week
		/// </summary>
		public static List<DateTime> DaysOfWeek( int year, int week )
		{
			var dates = new List<DateTime>();

			var date = FirstDayOfWeekOne( year );
			while( IsoWeekNumber( date ) != week )
				date = date.AddDays( 1 );

			do
			{
				dates.Add( date );
				date = date.AddDays( 1 );
			}
			while( IsoWeekNumber( date ) == week );

			return dates;
		}

		public static DateTime FirstDayOfWeek( DateTime date )
		{
			return date.AddDays( -DayIndex( date.DayOfWeek ) );
		}
	}
}
