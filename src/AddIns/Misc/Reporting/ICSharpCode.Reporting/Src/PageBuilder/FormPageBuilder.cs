﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Drawing;
using System.Linq;

using ICSharpCode.Reporting.Globals;
using ICSharpCode.Reporting.Interfaces;
using ICSharpCode.Reporting.Interfaces.Export;

namespace ICSharpCode.Reporting.PageBuilder
{
	/// <summary>
	/// Description of FormPageBuilder.
	/// </summary>
	public class FormPageBuilder:BasePageBuilder
	{
		
		public FormPageBuilder(IReportModel reportModel):base(reportModel)
		{
			
		}
		
		
		public override void BuildExportList()
		{
			base.BuildExportList();
			WritePages ();
		}
		
		
		
		void BuilDetail()
		{
			Console.WriteLine("FormPageBuilder - Build DetailSection {0} - {1} - {2}",ReportModel.ReportSettings.PageSize.Width,ReportModel.ReportSettings.LeftMargin,ReportModel.ReportSettings.RightMargin);
			CurrentLocation = DetailStart;
			
			var detail = CreateSection(ReportModel.DetailSection,CurrentLocation);
			detail.Parent = CurrentPage;
			CurrentPage.ExportedItems.Insert(2,detail);
		}
		
		
		protected override void WritePages()
		{
			base.WritePages();
			BuilDetail();
			base.AddPage(CurrentPage);
			Console.WriteLine("------{0}---------",ReportModel.ReportSettings.PageSize);
		}
		
		
	}
}