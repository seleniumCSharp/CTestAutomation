// <copyright file="TestCaseDescriptionAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit
{
    using System;

    internal sealed class TestCaseDescriptionAttribute : Attribute
    {
        public TestCaseDescriptionAttribute()
        {
            this.PDFDownload = false;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool PDFDownload { get; set; }
    }
}