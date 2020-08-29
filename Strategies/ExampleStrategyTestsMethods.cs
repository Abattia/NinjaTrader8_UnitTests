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
		// These are examples of some tests
		// Put Run Unit tests to True in settings,
		// then run strategy on a chart, 
		// and then review NT log for output
		
		/// <summary>
		/// Runs the specified tests
		/// </summary>
		private void testMethods()
		{
			#region enoughBars tests
			test_enoughBarsReturnsTrueIfEnough();
			test_enoughBarsReturnsFalseIfNotEnough();
			#endregion
		}
		
		// tests
		/// <summary>
		/// A test
		/// </summary>
		protected void test_enoughBarsReturnsTrueIfEnough()
		{
			// arrange
			int minimumNumberOfBars = 20;
			int currentBar = 25;
			
			// act
			var result = enoughBars(currentBar, minimumNumberOfBars);
			
			// assert
			assertResult(result);
		}

		/// <summary>
		/// A test
		/// </summary>
		protected void test_enoughBarsReturnsFalseIfNotEnough()
		{
			// arrange
			int minimumNumberOfBars = 20;
			int currentBar = 15;
			
			// act
			var result = enoughBars(currentBar, minimumNumberOfBars);
			
			// assert
			assertResult(!result);
		}
	}
}
