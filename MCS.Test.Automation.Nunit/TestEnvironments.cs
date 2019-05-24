// <copyright file="TestEnvironments.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using MCS.Test.Automation.Common.Helpers;

    // using AventStack.ExtentReports;
    // using AventStack.ExtentReports.Reporter;
    // using AventStack.ExtentReports.Reporter.Configuration;
    using Common;
    using Common.Logger;
    using global::NUnit.Framework;
    using global::NUnit.Framework.Interfaces;
    using RelevantCodes.ExtentReports;

    public class TestEnvironments
    {
       public string Environment { get; set; }
    }
}
