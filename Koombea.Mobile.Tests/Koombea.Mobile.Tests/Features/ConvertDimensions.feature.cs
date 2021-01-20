﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.5.0.0
//      SpecFlow Generator Version:3.5.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UnitConverter.Mobile.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Convert Units")]
    public partial class ConvertUnitsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ConvertDimensions.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Convert Units", "\tAs a user\r\n\tI want to be able to perform different conversion operations like le" +
                    "ngth, area, volume and speed.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Convert values functionality")]
        [NUnit.Framework.TestCaseAttribute("Length", "Kilometer", "Decameter", "-999999999", "-99999999900", null)]
        [NUnit.Framework.TestCaseAttribute("Length", "Kilometer", "Decameter", "0", "0", null)]
        [NUnit.Framework.TestCaseAttribute("Length", "Kilometer", "Decameter", "999999999", "99999999900", null)]
        [NUnit.Framework.TestCaseAttribute("Length", "Fathom", "Fathom", "-25000", "-25000", null)]
        [NUnit.Framework.TestCaseAttribute("Length", "[Hist.rus.] Arshin", "Kilometer", "0.0001", "0.00000007112", null)]
        [NUnit.Framework.TestCaseAttribute("Length", "Kilometer", "[Hist.rus.] Arshin", "0.00000007112", "0.0001", null)]
        [NUnit.Framework.TestCaseAttribute("Area", "Are", "Square thou", "-30", "-4650009300018.6", null)]
        [NUnit.Framework.TestCaseAttribute("Area", "Are", "Square thou", "0", "0", null)]
        [NUnit.Framework.TestCaseAttribute("Area", "Are", "Square thou", "30", "4650009300018.6", null)]
        [NUnit.Framework.TestCaseAttribute("Area", "Are", "Are", "30", "30", null)]
        [NUnit.Framework.TestCaseAttribute("Area", "Square thou", "Are", "-4650009300018.6", "-30", null)]
        [NUnit.Framework.TestCaseAttribute("Volume", "Hectoliter", "Cubic inch", "-999999999999999", "-6102374399999993897.6256", null)]
        [NUnit.Framework.TestCaseAttribute("Volume", "Hectoliter", "Cubic inch", "0", "0", null)]
        [NUnit.Framework.TestCaseAttribute("Volume", "Hectoliter", "Cubic inch", "999999999999999", "6102374399999993897.6256", null)]
        [NUnit.Framework.TestCaseAttribute("Volume", "Hectoliter", "Cubic inch", "999999999999999", "6102374399999993897.6256", null)]
        [NUnit.Framework.TestCaseAttribute("Volume", "Hectoliter", "Hectoliter", "1000", "1000", null)]
        [NUnit.Framework.TestCaseAttribute("Speed", "Kilometer per hour", "Speed of sound in steel", "0", "0", null)]
        [NUnit.Framework.TestCaseAttribute("Speed", "Kilometer per hour", "Speed of sound in steel", "0.0000001", "0.000000000004661", null)]
        [NUnit.Framework.TestCaseAttribute("Speed", "Seconds per meter", "Speed of sound in steel", "10000000000000000", "0.00000000000000000002", null)]
        [NUnit.Framework.TestCaseAttribute("Speed", "Kilometer per hour", "Kilometer per hour", "1000", "1000", null)]
        public virtual void ValidateConvertValuesFunctionality(string operation, string unitFrom, string unitTo, string entryValue, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("operation", operation);
            argumentsOfScenario.Add("unitFrom", unitFrom);
            argumentsOfScenario.Add("unitTo", unitTo);
            argumentsOfScenario.Add("entryValue", entryValue);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Convert values functionality", null, tagsOfScenario, argumentsOfScenario);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given(string.Format("a user that selects a conversion {0} from menu", operation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("the origin unit {0} is selected", unitFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.And(string.Format("the desired unit {0} is selected", unitTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
 testRunner.And(string.Format("the {0} is inserted", entryValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Only allow positive numbers for Speed operations")]
        public virtual void OnlyAllowPositiveNumbersForSpeedOperations()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Only allow positive numbers for Speed operations", null, tagsOfScenario, argumentsOfScenario);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
 testRunner.When("the operation is Speed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then("the change sign key is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
