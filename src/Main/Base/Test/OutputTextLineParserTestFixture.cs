﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Gui;
using NUnit.Framework;

namespace ICSharpCode.SharpDevelop.Tests
{
	[TestFixture]
	public class OutputTextLineParserTests
	{
		[Test]
		public void Multiline()
		{
			string output = "   at NunitFoo.Tests.FooTest.Foo() in c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs:line 22\n";
			FileLineReference lineRef = OutputTextLineParser.GetNUnitOutputFileLineReference(output, true);
			Assert.AreEqual(lineRef.FileName, "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs");
			Assert.AreEqual(22, lineRef.Line);
			Assert.AreEqual(0, lineRef.Column);
		}
		
		[Test]
		public void MultilineWithCarriageReturn()
		{
			string output = "   at NunitFoo.Tests.FooTest.Foo() in c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs:line 22\r\n";
			FileLineReference lineRef = OutputTextLineParser.GetNUnitOutputFileLineReference(output, true);
			Assert.AreEqual(lineRef.FileName, "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs");
			Assert.AreEqual(22, lineRef.Line);
			Assert.AreEqual(0, lineRef.Column);
		}

		[Test]
		public void MultipleLines()
		{
			string output = "   at NunitFoo.Tests.FooTest.Foo() in c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs:line 11\r\n" +
				"   at NunitFoo.Tests.FooTest.Foo() in c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs:line 22\r\n";
			FileLineReference lineRef = OutputTextLineParser.GetNUnitOutputFileLineReference(output, true);
			Assert.AreEqual(lineRef.FileName, "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs");
			Assert.AreEqual(22, lineRef.Line);
			Assert.AreEqual(0, lineRef.Column);
		}
		
		[Test]
		public void NUnitConsoleFailure()
		{
			string output = "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs(22)";
			FileLineReference lineRef = OutputTextLineParser.GetFileLineReference(output);
			Assert.AreEqual(lineRef.FileName, "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs");
			Assert.AreEqual(22, lineRef.Line);
			Assert.AreEqual(0, lineRef.Column);
		}
		
		[Test]
		public void CompilerFailure()
		{
			string output = "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs(22,10)";
			FileLineReference lineRef = OutputTextLineParser.GetFileLineReference(output);
			Assert.AreEqual(lineRef.FileName, "c:\\test\\NunitFoo\\NunitFoo.Tests\\FooTest.cs");
			Assert.AreEqual(22, lineRef.Line);
			Assert.AreEqual(10, lineRef.Column);
		}
	}
}