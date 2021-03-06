//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
//Copyright � 2005  John Champion
//
//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.
//
//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public
//License along with this library; if not, write to the Free Software
//Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph
{
	/// <summary>
	/// The DateDualScale class inherits from the <see cref="Scale" /> class, and implements
	/// the features specific to <see cref="AxisType.DateDual" />.
	/// </summary>
	/// <remarks>
	/// DateDualScale is a cartesian axis labeled with calendar dates / times.  The data values are
	/// modified Julian days where day zero starts at midnight, 30 December 1899. Incrementing a Julian
	/// day value by one means adding one day. An hour is a change of 1/24 (approximately 0.04167). 
	/// Appropriate values for this scale are returned by the System.DateTime.ToOADate method and by
	/// the <see cref="ZedGraph.XDate" /> class.
	/// Labels appear in either one or two rows, depending on the date range displayed.
	/// When number of days >= MaxDaysMonthLabeled, only one row is used because only year labels can fit.
	/// When number of days > MaxDaysDayLabeled, a row of month labels and a row of year labels are drawn.
	/// When number of days > MaxDaysTimeLabeled, a row of day labels and a row of month + year labels are drawn.
	/// Otherwise, a row of time labels and a row of year + month + day labels are drawn.
	/// </remarks>
	/// 
	/// <author> John Champion, Mark Gray </author>
	/// <version> $Revision: 1.12 $ $Date: 2006/08/25 05:19:09 $ </version>
	[Serializable]
	class DateDualScale : Scale, ISerializable //, ICloneable
	{
		public double MaxDaysMonthLabeled = 666;
		public double MaxDaysDayLabeled = 60;
		public double MaxDaysTimeLabeled = 3;

		/// <summary> Full names of months for labeling when there is room </summary>
		private string[] MonthNamesFull = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames; //{"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

		/// <summary> Abbreviated names of months for labeling when there is less room </summary>
		private string[] MonthNamesAbbreviated = System.Globalization.DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames; //{ "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

		/// <summary> Natural numbers of years or days to label </summary>
		private int[] roundNumbers = { 1, 2, 5, 10, 20, 25, 50, 100, 200, 250, 500, 1000, 2000, 5000, 10000, 20000, 25000, 50000, 100000 };

		/// <summary> Natural numbers of minutes to label </summary>
		private int[] roundMinutes = { 1, 2, 5, 10, 15, 30, 60, 120, 240, 360, 480, 720, 1440 };
		// hours in roundMinutes                             1    2    4    6    8   12    24

	#region constructors

		/// <summary>
		/// Default constructor that defines the owner <see cref="Axis" />
		/// (containing object) for this new object.
		/// </summary>
		/// <param name="owner">The owner, or containing object, of this instance</param>
		public DateDualScale( Axis owner )
			: base( owner )
		{
			_ownerAxis._majorTic.IsInside = true;
			_ownerAxis._majorTic.IsOpposite = true;
			_ownerAxis._minorTic.IsInside = true;
			_ownerAxis._minorTic.IsOpposite = true;
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see cref="DateScale" /> object from which to copy</param>
		/// <param name="owner">The <see cref="Axis" /> object that will own the
		/// new instance of <see cref="DateScale" /></param>
		public DateDualScale( Scale rhs, Axis owner )
			: base( rhs, owner )
		{
		}

		/// <summary>
		/// Create a new clone of the current item, with a new owner assignment
		/// </summary>
		/// <param name="owner">The new <see cref="Axis" /> instance that will be
		/// the owner of the new Scale</param>
		/// <returns>A new <see cref="Scale" /> clone.</returns>
		public override Scale Clone( Axis owner )
		{
			return new DateDualScale( this, owner );
		}

	#endregion

	#region properties

		/// <summary>
		/// Return the <see cref="AxisType" /> for this <see cref="Scale" />, which is
		/// <see cref="AxisType.DateDual" />.
		/// </summary>
		public override AxisType Type
		{
			get { return AxisType.DateDual; }
		}

		/// <summary>
		/// Gets or sets the minimum value for this scale.
		/// </summary>
		/// <remarks>
		/// The set property is specifically adapted for <see cref="AxisType.DateDual" /> scales,
		/// in that it automatically limits the value to the range of valid dates for the
		/// <see cref="XDate" /> struct.
		/// </remarks>
		public override double Min
		{
			get { return _min; }
			set { _min = XDate.MakeValidDate( value ); _minAuto = false; }
		}

		/// <summary>
		/// Gets or sets the maximum value for this scale.
		/// </summary>
		/// <remarks>
		/// The set property is specifically adapted for <see cref="AxisType.DateDual" /> scales,
		/// in that it automatically limits the value to the range of valid dates for the
		/// <see cref="XDate" /> struct.
		/// </remarks>
		public override double Max
		{
			get { return _max; }
			set { _max = XDate.MakeValidDate( value ); _maxAuto = false; }
		}
	#endregion

#region methods


		private bool[] DrawWhich(double numDays)
		{
			bool[] drawThese = new bool[(int)DateUnit.Millisecond];
			drawThese[(int)DateUnit.Hour] = (numDays <= MaxDaysTimeLabeled);
			drawThese[(int)DateUnit.Day] = (numDays <= MaxDaysDayLabeled);
			drawThese[(int)DateUnit.Month] = (numDays > MaxDaysTimeLabeled) && (numDays < MaxDaysMonthLabeled);
			drawThese[(int)DateUnit.Year] = (numDays > MaxDaysDayLabeled);
			return drawThese;
		}

		internal override SizeF GetScaleMaxSpace(Graphics g, GraphPane pane, float scaleFactor, bool applyAngle)
		{
			if (_isVisible)
			{
				double scaleMult = Math.Pow((double)10.0, _mag);

				float saveAngle = _fontSpec.Angle;
				if (!applyAngle)
					_fontSpec.Angle = 0;

				SizeF maxSpace = _fontSpec.BoundingBox(g, "0000", scaleFactor);

				bool[] drawThese = DrawWhich(_maxLinearized - _minLinearized);
				int numLevels = 0;
				foreach (bool lDrawThis in drawThese)
				{
					if (lDrawThis) numLevels++;
				}

				maxSpace.Height *= numLevels;

				_fontSpec.Angle = saveAngle;

				return maxSpace;
			}
			else
				return new SizeF(0, 0);
		}

		/// <summary>
		/// Round up to a number in the given array
		/// </summary>
		/// <param name="number">number to round</param>
		/// <param name="roundArray">numbers to round up to</param>
		/// <returns>nearest "round" number that is at least as large as given number</returns>
		private int RoundNumber(int number, int[] roundArray)
		{
			foreach (int i in roundArray)
			{
				if (number <= i)
				{
					return i;
				}
			}
			return roundArray[roundArray.GetUpperBound(0)];
		}

		private float GetTextVerticalCenter(Graphics g, GraphPane pane,
				float scaledTic, float labelHeight, float shift, float scaleFactor)
		{
			// get the Y position of the center of the axis labels
			// (the axis itself is referenced at zero)
			//SizeF maxLabelSize = GetScaleMaxSpace(g, pane, scaleFactor, true);
			float charHeight = _fontSpec.GetHeight(scaleFactor);
			float maxSpace = charHeight;
			float textTop, textVerticalCenter;
			if (_ownerAxis.MajorTic.IsOutside)
				textTop = scaledTic + charHeight * _labelGap;
			else
				textTop = charHeight * _labelGap;

			if (_align == AlignP.Center)
				textVerticalCenter = textTop + maxSpace / 2.0F;
			else if (_align == AlignP.Outside)
				textVerticalCenter = textTop + maxSpace - labelHeight / 2.0F;
			else	// inside
				textVerticalCenter = textTop + labelHeight / 2.0F;

			if (_isLabelsInside)
				textVerticalCenter = shift - textVerticalCenter;
			else
				textVerticalCenter = shift + textVerticalCenter;
			return textVerticalCenter;
		}

		private void TruncateIntervalDrawTicGrid(Graphics g, 
												 GraphPane pane,
												 float topPix,
												 MinorTic tic,
												 MinorGrid grid,
												 bool drawGrid,
												 float shift,
												 float scaleFactor,
												 float scaledTic,
												 ref double dStartInterval,
												 ref double dEndInterval,
												 out float pStartInterval,
												 out float pEndInterval,
												 out float pIntervalWidth)
		{
			bool movedStart = false;
			bool movedEnd = false;
			if (dStartInterval < _minLinTemp)
			{
				dStartInterval = _minLinTemp;
				movedStart = true;
			}

			if (dEndInterval > _maxLinTemp)
			{
				dEndInterval = _maxLinTemp;
				movedEnd = true;
			}
			pStartInterval = LocalTransform(dStartInterval);
			pEndInterval = LocalTransform(dEndInterval);
			pIntervalWidth = pEndInterval - pStartInterval;
			if (pIntervalWidth > 0)
			{
				Pen lPen;
				if (drawGrid)
					lPen = grid.GetPen(pane, scaleFactor);
				else
					lPen = tic.GetPen(pane, scaleFactor);
				
				if (!movedStart)
				{
					if (drawGrid)
						grid.Draw(g, lPen, pStartInterval, topPix);
					else 
						tic.Draw(g, pane, lPen, pStartInterval, topPix, shift, scaledTic);
				}
				if (!movedEnd && pIntervalWidth > 2)
				{
					if (drawGrid)
						grid.Draw(g, lPen, pEndInterval, topPix);
					else
						tic.Draw(g, pane, lPen, pEndInterval, topPix, shift, scaledTic);
				}
			}
		}

		internal void DrawYearLabels(Graphics g, GraphPane pane, MinorTic tic, MinorGrid grid, bool drawGrid,
					float topPix, float rightPix, float shift, float scaleFactor)
		{
			int year;
			int month;
			int day;

			XDate xStartInterval = new XDate(_minLinTemp);
			XDate xEndInterval;
			string labelText = "2000";
			SizeF labelBox = _fontSpec.BoundingBox(g, labelText, scaleFactor);
			float labelWidth = labelBox.Width + 4;
			float labelWidthHalf = labelWidth / 2;

			float scaledTic = tic.ScaledTic(scaleFactor);
			float textVerticalCenter = GetTextVerticalCenter(g, pane, scaledTic, labelBox.Height, shift, scaleFactor);
			float textHorizontalCenter;

			double dStartInterval, dEndInterval;
			float pStartInterval, pEndInterval, pIntervalWidth;

			xStartInterval.GetDate(out year, out month, out day);
			xStartInterval.SetDate(year, 1, 1);
			xEndInterval = new XDate(year + 1, 1, 1);
			dStartInterval = xStartInterval.XLDate;
			dEndInterval = xEndInterval.XLDate;

			pStartInterval = LocalTransform(dStartInterval);
			pEndInterval = LocalTransform(dEndInterval);
			pIntervalWidth = pEndInterval - pStartInterval;

			int yearsPerLabel = RoundNumber((int)Math.Ceiling(labelWidth / pIntervalWidth), roundNumbers);
			int yearsPerTic = RoundNumber((int)Math.Ceiling(10 / pIntervalWidth), roundNumbers);

			while (dStartInterval < _maxLinTemp)
			{
				bool labelThisYear = ((year / yearsPerLabel) * yearsPerLabel == year);
				if (labelThisYear || ((year / yearsPerTic) * yearsPerTic == year))
				{
					TruncateIntervalDrawTicGrid(g, pane, topPix, tic, grid, drawGrid, shift, scaleFactor, scaledTic, 
						ref dStartInterval, ref dEndInterval, out pStartInterval, out pEndInterval, out pIntervalWidth);

					if (!drawGrid && this.IsVisible && labelThisYear)
					{
						textHorizontalCenter = (pStartInterval + pEndInterval) / 2;
						//if label will not extend beyond left or right edge of this axis, draw it
						if ((textHorizontalCenter - labelWidthHalf > 0) &&
							(textHorizontalCenter + labelWidthHalf) < rightPix)
						{
							labelText = year.ToString();
							_fontSpec.Draw(g, pane, labelText,
								textHorizontalCenter, textVerticalCenter,
								AlignH.Center, AlignV.Center, scaleFactor);
						}
					}
				}
				year += 1;
				xStartInterval.SetDate(year, 1, 1); // = new XDate(endInterval);
				xEndInterval.SetDate(year + 1, 1, 1);
				dStartInterval = xStartInterval.XLDate;
				dEndInterval = xEndInterval.XLDate;
			}
		}

		internal void DrawMonthLabels(Graphics g, GraphPane pane, MinorTic tic, MinorGrid grid, bool drawGrid,
					float topPix, float rightPix, float shift, float scaleFactor, bool includeYear)
		{
			int year;
			int month;
			int day;
			int MonthLabelType = WhichMonthLabels(g, pane, topPix, rightPix, shift, scaleFactor, includeYear);

			XDate xStartInterval = new XDate(_minLinTemp);
			XDate xEndInterval;
			string labelText = "0";
			SizeF labelBox = _fontSpec.BoundingBox(g, labelText, scaleFactor);
			float ticShift = (includeYear ? (shift + labelBox.Height / 2) : shift);
			float charWidth = labelBox.Width;
			float scaledTic = tic.ScaledTic(scaleFactor);
			float textVerticalCenter = GetTextVerticalCenter(g, pane, scaledTic, labelBox.Height, shift, scaleFactor);

			double dStartInterval, dEndInterval;
			float pStartInterval, pEndInterval, pIntervalWidth;

			SizeF labelSize;

			xStartInterval.GetDate(out year, out month, out day);
			if (day != 1) xStartInterval.SetDate(year, month, 1);
			xEndInterval = new XDate(xStartInterval);
			xEndInterval.AddMonths(1);
			dStartInterval = xStartInterval.XLDate;
			dEndInterval = xEndInterval.XLDate;

			

			// draw tics and labels
			dStartInterval = xStartInterval.XLDate;
			while (dStartInterval < _maxLinTemp)
			{
				TruncateIntervalDrawTicGrid(g, pane, topPix, tic, grid, drawGrid,
					ticShift, scaleFactor, scaledTic,
					ref dStartInterval, ref dEndInterval, out pStartInterval, out pEndInterval, out pIntervalWidth);

				// If the width of the interval is at least wide enough for a character,
				// try displaying a month label
				if (!drawGrid && this.IsVisible && pIntervalWidth > charWidth)
				{
					labelText = "";
					switch(MonthLabelType) 
					{
						case 3: labelText = MonthNamesFull[month - 1]; break;
						case 2: labelText = MonthNamesAbbreviated[month - 1]; break;
						case 1: labelText = MonthNamesAbbreviated[month - 1].Substring(0, 1); break;
					}
					if (includeYear) labelText += " " + year;
					labelSize = _fontSpec.BoundingBox(g, labelText, scaleFactor);
					if (labelSize.Width >= pIntervalWidth)
					{
						labelText = "";
					}
					if (labelText.Length > 0 )
						_fontSpec.Draw(g, pane, labelText,
							(pStartInterval + pEndInterval) / 2, textVerticalCenter,
							AlignH.Center, AlignV.Center,
							scaleFactor);
				}
				xStartInterval.AddMonths(1); // = new XDate(endInterval);
				xEndInterval.AddMonths(1);
				dStartInterval = xStartInterval.XLDate;
				dEndInterval = xEndInterval.XLDate;
				xStartInterval.GetDate(out year, out month, out day);
			}
		}

		private int WhichMonthLabels(Graphics g, GraphPane pane,
					float topPix, float rightPix, float shift, float scaleFactor, bool includeYear)
		{
			bool FullFit = true;
			bool AbbrevFit = true;
			bool CharFit = true;

			int year;
			int month;
			int day;

			string yearText = "";

			XDate xStartInterval = new XDate(_minLinTemp);
			XDate xEndInterval;
			string labelText = "0";
			SizeF labelBox = _fontSpec.BoundingBox(g, labelText, scaleFactor);
			float ticShift = (includeYear ? (shift + labelBox.Height / 2) : shift);
			float charWidth = labelBox.Width;

			MinorGrid grid = _ownerAxis._minorGrid;
			MinorTic tic = _ownerAxis._minorTic;
			float scaledTic = tic.ScaledTic(scaleFactor);
			float textVerticalCenter = GetTextVerticalCenter(g, pane, scaledTic, labelBox.Height, shift, scaleFactor);

			double dStartInterval, dEndInterval;
			float pStartInterval, pEndInterval, pIntervalWidth;

			xStartInterval.GetDate(out year, out month, out day);
			if (day != 1) xStartInterval.SetDate(year, month, 1);
			xEndInterval = new XDate(xStartInterval);
			xEndInterval.AddMonths(1);
			dStartInterval = xStartInterval.XLDate;
			dEndInterval = xEndInterval.XLDate;

			while (dStartInterval < _maxLinTemp)
			{
				TruncateIntervalDrawTicGrid(g, pane, topPix, tic, grid, false,
					ticShift, scaleFactor, scaledTic,
					ref dStartInterval, ref dEndInterval, out pStartInterval, out pEndInterval, out pIntervalWidth);

				// If the width of the interval is at least wide enough for a character
				// and we have more than 27 days, try displaying a month label
				if (pIntervalWidth > charWidth && (dEndInterval - dStartInterval > 27))
				{
					if (includeYear) yearText = " " + year;

					if (FullFit)   // First try to fit whole month name
					{
						FullFit = LabelFits(g, scaleFactor, MonthNamesFull[month - 1] + yearText, pIntervalWidth);
					}
					if (AbbrevFit) // Next try to fit abbreviated month name
					{
						AbbrevFit = LabelFits(g, scaleFactor, MonthNamesAbbreviated[month - 1] + yearText, pIntervalWidth);
					}
					if (CharFit)   // Finally try to fit first letter of month name
					{
						CharFit = LabelFits(g, scaleFactor, labelText.Substring(0, 1) + yearText, pIntervalWidth);
					}
				}
				xStartInterval.AddMonths(1); // = new XDate(endInterval);
				xEndInterval.AddMonths(1);
				dStartInterval = xStartInterval.XLDate;
				dEndInterval = xEndInterval.XLDate;
				xStartInterval.GetDate(out year, out month, out day);
			}
			if (FullFit) return 3;
			if (AbbrevFit) return 2;
			if (CharFit) return 1;
			return 0;
		}

		private bool LabelFits(Graphics g, float scaleFactor, string labelText, float maxWidth)
		{
			SizeF labelSize = _fontSpec.BoundingBox(g, labelText, scaleFactor);
			return (labelSize.Width < maxWidth);
		}

		internal void DrawDayLabels(Graphics g, GraphPane pane, MinorTic tic, MinorGrid grid, bool drawGrid,
			float topPix, float rightPix, float shift, float scaleFactor, bool includeMonthYear)
		{
			int year;
			int month;
			int day;
			XDate xStartInterval = new XDate(_minLinTemp);
			XDate xEndInterval;
			string labelText = "28";
			if (includeMonthYear) labelText = "2000 " + MonthNamesAbbreviated[1] + " 28";
			SizeF labelBox = _fontSpec.BoundingBox(g, labelText, scaleFactor);
			float labelWidth = labelBox.Width + 4;
			float labelWidthHalf = labelWidth / 2;
			float ticShift = (includeMonthYear ? (shift + labelBox.Height / 2) : shift);
			float scaledTic = tic.ScaledTic(scaleFactor);
			float textVerticalCenter = GetTextVerticalCenter(g, pane, scaledTic, labelBox.Height, shift, scaleFactor);
			float textHorizontalCenter;

			double dStartInterval, dEndInterval;
			float pStartInterval, pEndInterval, pIntervalWidth;

			xStartInterval.GetDate(out year, out month, out day);
			xStartInterval.SetDate(year, month, 1);
			xEndInterval = new XDate(year, month, 2);
			dStartInterval = xStartInterval.XLDate;
			dEndInterval = xEndInterval.XLDate;

			pStartInterval = LocalTransform(dStartInterval);
			pEndInterval = LocalTransform(dEndInterval);
			pIntervalWidth = pEndInterval - pStartInterval;

			int daysPerLabel = RoundNumber((int)Math.Ceiling(labelWidth / pIntervalWidth), roundNumbers);

			while (dStartInterval < _maxLinTemp)
			{
				TruncateIntervalDrawTicGrid(g, pane, topPix, tic, grid, drawGrid,
					ticShift + (includeMonthYear ? scaledTic : 0), scaleFactor, scaledTic, 
					ref dStartInterval, ref dEndInterval, out pStartInterval, out pEndInterval, out pIntervalWidth);

				if (!drawGrid && this.IsVisible && pIntervalWidth > 1)
				{
					if (((int)(day / daysPerLabel)) * daysPerLabel == day)
					{
						textHorizontalCenter = (pStartInterval + pEndInterval) / 2;
						//if label will not extend beyond left or right edge of this axis, draw it
						if ((textHorizontalCenter - labelWidthHalf > 0) &&
							(textHorizontalCenter + labelWidthHalf) < rightPix)
						{
							labelText = day.ToString();
							if (includeMonthYear) labelText = year + " " + MonthNamesAbbreviated[month - 1] + " " + labelText;
							_fontSpec.Draw(g, pane, labelText,
								textHorizontalCenter, textVerticalCenter,
								AlignH.Center, AlignV.Center, scaleFactor);
						}
					}
				}
				xStartInterval.AddDays(1);
				xStartInterval.GetDate(out year, out month, out day); // = new XDate(endInterval);
				dStartInterval = xStartInterval.XLDate;
				xEndInterval.AddDays(1);
				dEndInterval = xEndInterval.XLDate;
			}
		}

		internal void DrawHourMinuteLabels(Graphics g, GraphPane pane, MinorTic tic, MinorGrid grid, bool drawGrid,
			float topPix, float rightPix, float shift, float scaleFactor)
		{
			XDate xStartInterval = new XDate(_minLinTemp);
			DateTime dtStartInterval = xStartInterval.DateTime;
			DateTime dtEndInterval;
			string labelText = "24:00";
			SizeF labelBox = _fontSpec.BoundingBox(g, labelText, scaleFactor);
			float labelWidth = labelBox.Width + 4;
			float labelWidthHalf = labelWidth / 2;
			float scaledTic = tic.ScaledTic(scaleFactor);
			float textVerticalCenter = GetTextVerticalCenter(g, pane, scaledTic, labelBox.Height, shift, scaleFactor);

			double dStartInterval, dEndInterval;
			float pStartInterval, pEndInterval, pIntervalWidth;

			int year = dtStartInterval.Year;
			int month = dtStartInterval.Month;
			int day = dtStartInterval.Day;
			int hour = dtStartInterval.Hour;
			int minute = dtStartInterval.Minute;
			int second = dtStartInterval.Second;

			dtStartInterval = new DateTime(year, month, day, 0, 0, 0);
			dStartInterval = dtStartInterval.ToOADate();
			pStartInterval = LocalTransform(dStartInterval);

			dtEndInterval = dtStartInterval.AddMinutes(1);
			dEndInterval = dtEndInterval.ToOADate();
			pEndInterval = LocalTransform(dEndInterval);
			pIntervalWidth = pEndInterval - pStartInterval;

			int minutesPerLabel = RoundNumber((int)Math.Ceiling(labelWidth / pIntervalWidth), roundMinutes);
			dtEndInterval = dtStartInterval.AddMinutes(minutesPerLabel);
			dEndInterval = dtEndInterval.ToOADate();

			while (dStartInterval < _maxLinTemp)
			{
				int minutesHours = hour * 60 + minute;
				dtEndInterval = dtStartInterval.AddMinutes(minutesPerLabel);
				dEndInterval = dtEndInterval.ToOADate();

				TruncateIntervalDrawTicGrid(g, pane, topPix, tic, grid, drawGrid, shift, scaleFactor, scaledTic,
					ref dStartInterval, ref dEndInterval, out pStartInterval, out pEndInterval, out pIntervalWidth);

				//if label will not extend beyond left or right edge of this axis, draw it
				if (!drawGrid && this.IsVisible && (pStartInterval - labelWidthHalf > 0) &&
						                           (pStartInterval + labelWidthHalf) < rightPix)
				{
					labelText = hour.ToString() + ":" + ((minute < 10) ? "0" : "") + minute.ToString();
					_fontSpec.Draw(g, pane, labelText,
						pStartInterval, textVerticalCenter,
						AlignH.Center, AlignV.Center, scaleFactor);
				}               
				dtStartInterval = dtStartInterval.AddMinutes(minutesPerLabel);
				hour = dtStartInterval.Hour;
				minute = dtStartInterval.Minute;
				dStartInterval = dtStartInterval.ToOADate();
			}
		}

		/// <summary>
		/// Draw the scale, including the tic marks, value labels, and grid lines as
		/// required for this <see cref="Axis"/>.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see cref="GraphPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see cref="GraphPane"/> object using the
		/// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		/// <param name="shiftPos">
		/// The number of pixels to shift to account for non-primary axis position (e.g.,
		/// the second, third, fourth, etc. <see cref="YAxis" /> or <see cref="Y2Axis" />.
		/// </param>
		override internal void Draw(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
		{
			Draw(g, pane, scaleFactor, shiftPos, false);
		}
		override internal void DrawGrid(Graphics g, GraphPane pane, double baseVal, float topPix, float scaleFactor)
		{
			Draw(g, pane, scaleFactor, 0, true); // TODO: need shiftPos if not primary axis
		}
		internal void Draw(Graphics g, GraphPane pane, float scaleFactor, float shiftPos, bool drawGrid)
		{
			float rightPix,
					topPix;

			if (_ownerAxis is XAxis)
			{
				rightPix = pane.Chart._rect.Width;
				topPix = -pane.Chart._rect.Height;
			}
			else
			{
				rightPix = pane.Chart._rect.Height;
				topPix = -pane.Chart._rect.Width;
			}

			// sanity check
			if (_min >= _max)
				return;

			MajorGrid majorGrid = _ownerAxis._majorGrid;
			MajorTic majorTic = _ownerAxis._majorTic;
			MinorTic tic = _ownerAxis._minorTic;
			MinorGrid grid = _ownerAxis._minorGrid;

			if (!drawGrid)
			{
				Pen pen = new Pen(_ownerAxis.Color,
							pane.ScaledPenWidth(majorTic._penWidth, scaleFactor));

				// redraw the axis border
				if (_ownerAxis.IsAxisSegmentVisible)
					g.DrawLine(pen, 0.0F, shiftPos, rightPix, shiftPos);

				// Draw a zero-value line if needed
				if (majorGrid._isZeroLine && _min < 0.0 && _max > 0.0)
				{
					float zeroPix = LocalTransform(0.0);
					g.DrawLine(pen, zeroPix, 0.0F, zeroPix, topPix);
				}
				_ownerAxis.DrawTitle(g, pane, 0, scaleFactor);
			}

			// draw the time scales that fit best
			bool[] drawThese = DrawWhich((_maxLinTemp - _minLinTemp));

			// Note: the Draw*Labels routines draw tics or grids too
			if (drawThese[(int)DateUnit.Hour])
			{
				DrawHourMinuteLabels(g, pane, tic, grid, drawGrid, topPix, rightPix, shiftPos, scaleFactor);
				shiftPos += _fontSpec.GetHeight(scaleFactor) * 1.1F;
				tic = majorTic;
				grid = majorGrid;
			}

			if (drawThese[(int)DateUnit.Day])
			{
				DrawDayLabels(g, pane, tic, grid, drawGrid, topPix, rightPix, shiftPos, scaleFactor, !drawThese[(int)DateUnit.Month]);
				shiftPos += _fontSpec.GetHeight(scaleFactor) * 1.1F;
				tic = majorTic;
				grid = majorGrid;
			}

			if (drawThese[(int)DateUnit.Month])
			{
				DrawMonthLabels(g, pane, tic, grid, drawGrid, topPix, rightPix, shiftPos, scaleFactor, !drawThese[(int)DateUnit.Year]);
				shiftPos += _fontSpec.GetHeight(scaleFactor) * 1.1F;
			}

			if (drawThese[(int)DateUnit.Year])
			{
				DrawYearLabels(g, pane, majorTic, majorGrid, drawGrid, topPix, rightPix, shiftPos, scaleFactor);
				shiftPos += _fontSpec.GetHeight(scaleFactor) * 1.1F;
			}
		}

		//override all the default tic arithmetic since we do it in our custom Draw
		override internal double CalcMajorTicValue(double baseVal, double tic)
		{
			return 0;
		}
		internal override double CalcMinorTicValue(double baseVal, int iTic)
		{
			return 0;
		}
		internal override int CalcMinorStart(double baseVal)
		{
			return 0;
		}
		internal override double CalcBaseTic()
		{
			return 0;
		}
		internal override int CalcNumTics()
		{
			return 0;
		}
	#endregion

	#region Serialization
		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema2 = 10;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected DateDualScale(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema2" );

		}
		/// <summary>
		/// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		public override void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			base.GetObjectData( info, context );
			info.AddValue( "schema2", schema2 );
		}
	#endregion

	}
}
