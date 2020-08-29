#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Strategies in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class ExampleStrategy : Strategy
	{
		#region variables
		private int tests = 0;
		private int passes = 0;
		#endregion

		/// <summary>
		/// Tracks tests and passes
		/// </summary>
		/// <param name="result"></param>
		/// <param name="name"></param>
		protected void assertResult(
			bool result,
			[System.Runtime.CompilerServices.CallerMemberName] string name=""
			)
		{
			if (result)
			{
				passes += 1;
			}
			
			else {
				this.logUnitTestError(name);
			}
			
			tests += 1;
		}
		
		/// <summary>
		/// Writes name of failed test to NT log
		/// </summary>
		/// <param name="name"></param>
		protected void logUnitTestError(string name)
		{
			string msgUnitTestError = "Unit test failure:\t '{0}'";
			Log(
				string.Format(
					msgUnitTestError,
					name
					),
				LogLevel.Information
				);
		}
		
		/// <summary>
		/// Writes unit testing summary to NT log
		/// </summary>
		protected void logUnitTestSummary()
		{
			string msgUnitTestSummary = "\tunit tests: {0}\tfailures: {1}\tpasses: {2}";
			Log(
				string.Format(
					msgUnitTestSummary,
					tests,
					tests - passes,
					passes
					),
				LogLevel.Information
				);
		}
		
		/// <summary>
		/// Runs unit tests on 10th bar
		/// </summary>
		protected void runUnitTests()
		{
			if (BarsInProgress == 0 && CurrentBar == 10)
			{
				runTestSets();
				logUnitTestSummary();
			}
		}
		
		/// <summary>
		/// Runs the specified test sets
		/// </summary>
		protected void runTestSets()
		{
			testMethods();
		}
	}
}
